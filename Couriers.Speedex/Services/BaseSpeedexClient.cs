using Couriers.Common;
using Couriers.Common.Extensions;
using Couriers.Common.ResultTypes;
using Couriers.Common.Xml;
using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.Interfaces;
using Couriers.Speedex.InternalModels.DataModels;
using Couriers.Speedex.InternalModels.RequestModels;
using Couriers.Speedex.InternalModels.ResponseModels;
using Couriers.Speedex.RequestModels;
using Couriers.Speedex.ResponseModels;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex.Services
{
    /// <summary>
    /// The base client for the Speedex web service
    /// </summary>
    public abstract class BaseSpeedexClient : ISpeedexClient, IDisposable
    {
        #region Constants

        /// <summary>
        /// The media type header value
        /// </summary>
        public const string MediaHeader = "text/xml";

        /// <summary>
        /// The maximum expiration time for the <see cref="_sessionId"/>
        /// </summary>
        private static readonly TimeSpan _maximumExpirationTime = new(1, 0, 0);

        /// <summary>
        /// The error message used when an asynchronous operation is cancelled
        /// </summary>
        private const string OperationCancelledErrorMessage = "Operation cancelled.";

        #endregion

        #region Private Fields

        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// A flag indicating whether the object is already disposed
        /// </summary>
        private bool _isAlreadyDisposed;

        /// <summary>
        /// The session id
        /// </summary>
        private string _sessionId = string.Empty;

        /// <summary>
        /// The date-time the session id was last refreshed
        /// </summary>
        private DateTimeOffset _lastSessionIdRefreshDate;

        #endregion

        #region Public Properties

        /// <summary>
        /// The credentials
        /// </summary>
        public SpeedexCredentials Credentials { get; }

        /// <summary>
        /// The URL for the API
        /// </summary>
        public abstract Uri APIURL { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BaseSpeedexClient"/>
        /// </summary>
        /// <param name="credentials">The credentials</param>
        /// <param name="httpClient">The HTTP client</param>
        protected BaseSpeedexClient([NotNull] SpeedexCredentials credentials, [NotNull] HttpClient httpClient) : base()
        {
            if (credentials is null)
                throw new ArgumentNullException(nameof(credentials));

            if (httpClient is null)
                throw new ArgumentNullException(nameof(httpClient));

            Credentials = credentials;

            _httpClient = httpClient;
        }

        /// <summary>
        /// Creates a new instance of <see cref="BaseSpeedexClient"/>
        /// </summary>
        /// <param name="credentials">The credentials</param>
        protected BaseSpeedexClient([NotNull] SpeedexCredentials credentials) : this(credentials, new HttpClient())
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<string>> CreateSessionAsync(CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<string>(OperationCancelledErrorMessage);

            var requestModel = CredentialsInternalRequestModel.FromRequestModel(Credentials);

            // Get the response
            var response = await ExecuteSoapEnvelopeRequest<SessionIdInternalResponseModel, CredentialsInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<string>();

            // Return the successful result
            return HttpRequestResult.FromResult(response.Result.SessionId, response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult> CancelConsignmentByVoucherIdAsync([NotNull] string voucherId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(voucherId))
                    throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

                return await ExecuteValidatedSOAPEnvelopeRequest<CancelConsignmentByVoucherIdInternalResponseModel, CancelConsignmentByVoucherIdInternalRequestModel>(new CancelConsignmentByVoucherIdInternalRequestModel()
                {
                    VoucherId = voucherId
                }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// NOTE: The max number of consignments per request is <see cref="SpeedexConstants.MaximumNumberOfConsignments"/>
        /// </summary>
        /// <param name="values">The consignments</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<ConsignmentResponseModel>>> CreateConsignmentsAsync([NotNull] IEnumerable<ConsignmentRequestModel> values, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<ConsignmentResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (values is null)
                    throw new ArgumentNullException(nameof(values));

                var numberOfItems = values.Count();

                if (numberOfItems == 0)
                    throw new ArgumentOutOfRangeException(nameof(values), "At least one consignment must be specified");

                // If more than 10 values are specified...
                if (numberOfItems > SpeedexConstants.MaximumNumberOfConsignments)
                    throw new InvalidOperationException($"The maximum number of consignments is {SpeedexConstants.MaximumNumberOfConsignments}.");

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<CreateConsignmentsInternalResponseModel, CreateConsignmentsInternalRequestModel>(CreateConsignmentsInternalRequestModel.FromRequestModel(values, Credentials.AgreementCode, Credentials.CustomerCode), cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                {
                    var statusPerConsignment = response.Result
                        .Statuses
                        .Select((element, index) => $"Consignment {index}: {element}");

                    var resultMessage = string.Join(", ", statusPerConsignment);

                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<ConsignmentResponseModel>>(resultMessage);
                }

                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<ConsignmentResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="model">The consignment</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<ConsignmentResponseModel>> CreateConsignmentAsync([NotNull] ConsignmentRequestModel model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<ConsignmentResponseModel>(OperationCancelledErrorMessage);

            try
            {
                if (model is null)
                    throw new ArgumentNullException(nameof(model));

                // Get the response
                var response = await CreateConsignmentsAsync(new ConsignmentRequestModel[] { model }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    return response.ToUnsuccessfulHttpRequestResult<ConsignmentResponseModel>();

                // Return the response
                return HttpRequestResult.FromResult(response.Result.First(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<ConsignmentResponseModel>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// NOTE: The max number of consignments per request is <see cref="SpeedexConstants.MaximumNumberOfVouchers"/>
        /// </summary>
        /// <param name="value">The consignments</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>> GetConsignmentPdfsAsync([NotNull] ConsignmentPdfRequestModel value, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));

                var requestModel = ConsignmentPdfInternalRequestModel.FromRequestModel(value);

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetConsignmentPdfInternalResponseModel, ConsignmentPdfInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="voucherId">The voucher id</param>
        /// <param name="paperSize">The paper size</param>
        /// <param name="returnMultipleVouchers">The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<string>> GetConsignmentPdfAsync([NotNull] string voucherId, PaperSize paperSize, bool returnMultipleVouchers = false, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<string>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(voucherId))
                    throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

                // Initialize the model
                var value = new ConsignmentPdfRequestModel(voucherId, paperSize, returnMultipleVouchers);

                // Get the response
                var response = await GetConsignmentPdfsAsync(value, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<string>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.First().Base64String, response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<string>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="zipCode">The zip code</param>
        /// <param name="language">The language that the results will be translated to</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<BranchResponseModel>>> GetBranchesAsync([NotNull] string zipCode, SupportedLanguage language = SupportedLanguage.Greek, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<BranchResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(zipCode))
                    throw new ArgumentException($"'{nameof(zipCode)}' cannot be null or whitespace.", nameof(zipCode));

                SpeedexHelpers.ThrowIfInvalidZipCode(zipCode);

                // Get the selected language
                var selectedLanguage = SpeedexHelpers.FromSupportedLanguage(language);

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetBranchesInternalResponseModel, BranchInternalRequestModel>(new BranchInternalRequestModel()
                {
                    ZipCode = zipCode,
                    Language = selectedLanguage
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<BranchResponseModel>>();

                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<BranchResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<CheckpointResponseModel>> GetLastCheckPointAsync([NotNull] string voucherId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<CheckpointResponseModel>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(voucherId))
                    throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetLastCheckpointInternalResponseModel, GetLastCheckpointInternalRequestModel>(new GetLastCheckpointInternalRequestModel()
                {
                    VoucherId = voucherId
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<CheckpointResponseModel>();

                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<CheckpointResponseModel>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<PickupCheckpointResponseModel>> GetLastPickupCheckPointAsync([NotNull] string pickupId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<PickupCheckpointResponseModel>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(pickupId))
                    throw new ArgumentException($"'{nameof(pickupId)}' cannot be null or whitespace.", nameof(pickupId));

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetLastPickupCheckpointInternalResponseModel, GetLastPickupCheckpointInternalRequestModel>(new GetLastPickupCheckpointInternalRequestModel()
                {
                    PickupId = pickupId
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<PickupCheckpointResponseModel>();

                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<PickupCheckpointResponseModel>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="model">The client references</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByClientReferencesAsync([NotNull] ClientReferencesRequestModel model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (model is null)
                    throw new ArgumentNullException(nameof(model));

                var requestModel = ClientReferencesInternalRequestModel.FromRequestModel(model);

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetTraceByClientReferencesInternalResponseModel, ClientReferencesInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<CheckpointResponseModel>>();

                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByTimeFrameAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (dateFrom > dateTo)
                    throw new ArgumentOutOfRangeException(nameof(dateFrom), $"The {nameof(dateFrom)} has to be before {nameof(dateTo)}.");

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetTraceByTimeFrameInternalResponseModel, GetCheckpointsByTimeFrameInternalRequestModel>(new GetCheckpointsByTimeFrameInternalRequestModel()
                {
                    DateFrom = dateFrom,
                    DateTo = dateTo
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<CheckpointResponseModel>>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByVoucherIdAsync([NotNull] string voucherId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(voucherId))
                    throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetTraceByVoucherIdInternalResponseModel, GetTraceByVoucherIdInternalRequestModel>(new GetTraceByVoucherIdInternalRequestModel()
                {
                    VoucherId = voucherId
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<CheckpointResponseModel>>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult> CancelPickupByIdAsync([NotNull] string pickupId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(pickupId))
                    throw new ArgumentException($"'{nameof(pickupId)}' cannot be null or whitespace.", nameof(pickupId));

                return await ExecuteValidatedSOAPEnvelopeRequest<CancelPickupInternalResponseModel, CancelPickupByIdInternalRequestModel>(new CancelPickupByIdInternalRequestModel()
                {
                    PickupNumber = pickupId
                }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="model">The pickup details</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<string>> CreatePickupAsync([NotNull] PickupRequestModel model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<string>(OperationCancelledErrorMessage);

            try
            {
                if (model is null)
                    throw new ArgumentNullException(nameof(model));

                var requestModel = PickupInternalRequestModel.FromRequestModel(model);

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<CreatePickupInternalResponseModel, PickupInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<string>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.Result.Result, response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<string>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>> GetConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (dateFrom > dateTo)
                    throw new ArgumentOutOfRangeException(nameof(dateFrom), $"The {nameof(dateFrom)} has to be before {nameof(dateTo)}.");

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetConsignmentsByDateInternalResponseModel, GetConsignmentsByDateRangeInternalRequestModel>(new GetConsignmentsByDateRangeInternalRequestModel()
                {
                    DateFrom = dateFrom,
                    DateTo = dateTo
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>> GetDepositedConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>(OperationCancelledErrorMessage);

            try
            {
                if (dateFrom > dateTo)
                    throw new ArgumentOutOfRangeException(nameof(dateFrom), $"The {nameof(dateFrom)} has to be before {nameof(dateTo)}.");

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetDepositedConsignmentsByDateInternalResponseModel, GetDepositedConsignmentsByDateRangeInternalRequestModel>(new GetDepositedConsignmentsByDateRangeInternalRequestModel()
                {
                    DateFrom = dateFrom,
                    DateTo = dateTo
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult<PickupResponseModel>> GetPickupByIdAsync([NotNull] string pickupId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<PickupResponseModel>(OperationCancelledErrorMessage);

            try
            {
                if (string.IsNullOrWhiteSpace(pickupId))
                    throw new ArgumentException($"'{nameof(pickupId)}' cannot be null or whitespace.", nameof(pickupId));

                // Get the response
                var response = await ExecuteValidatedSOAPEnvelopeRequest<GetPickupInternalResponseModel, GetPickupByIdInternalRequestModel>(new GetPickupByIdInternalRequestModel()
                {
                    PickupNumber = pickupId
                }, cancellationToken).ConfigureAwait(false);

                // If not successful...
                if (!response.IsSuccessful)
                    // Return the unsuccessful result
                    return response.ToUnsuccessfulHttpRequestResult<PickupResponseModel>();

                // Return the successful result
                return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<PickupResponseModel>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="model">The details for the pickup reschedule</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<IHttpRequestResult> ReschedulePickupAsync([NotNull] ReschedulePickupRequestModel model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult(OperationCancelledErrorMessage);

            try
            {
                if (model is null)
                    throw new ArgumentNullException(nameof(model));

                var requestModel = ReschedulePickupInternalRequestModel.FromRequestModel(model);

                return await ExecuteValidatedSOAPEnvelopeRequest<ReschedulePickupInternalResponseModel, ReschedulePickupInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<PickupResponseModel>(ex, null, null);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Disposes the managed and unmanaged resources that this objects uses
        /// </summary>
        /// <param name="disposing">A flag indicating whether the current object should be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isAlreadyDisposed)
                return;

            if (disposing)
            {
                _httpClient.Dispose();

                _httpClient = null!;
            }

            _isAlreadyDisposed = true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks whether one hour has been passed since the last session id refresh
        /// </summary>
        /// <returns></returns>
        private bool RequiresSessionIdRefresh()
            => DateTimeOffset.Now.Subtract(_lastSessionIdRefreshDate) >= _maximumExpirationTime;

        /// <summary>
        /// Validates the <see cref="Credentials"/> and returns a valid session id that expires in 1 hour
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        private async Task<IHttpRequestResult> EnsureValidSessionAsync(CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<IEnumerable<CheckpointResponseModel>>("Operation cancelled.");

            // Get the response
            var response = await CreateSessionAsync(cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response;

            // Set the session id
            _sessionId = response.Result;

            // Set the date-time the session id was last refreshed
            _lastSessionIdRefreshDate = DateTimeOffset.Now;

            // Return the successful result
            return response;
        }

        /// <summary>
        /// Checks whether the <see cref="_sessionId"/> needs refresh, if a refresh is needed, the session id is refreshed and the specified call is made
        /// </summary>
        /// <typeparam name="TResponse">The type of the response model</typeparam>
        /// <typeparam name="TRequest">The type of the request model</typeparam>
        /// <param name="requestModel">The request model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        private async Task<IHttpRequestResult<TResponse>> ExecuteValidatedSOAPEnvelopeRequest<TResponse, TRequest>(TRequest requestModel, CancellationToken cancellationToken = default)
            where TResponse : class, ISoapReturnMessageModel, IUnmappedXml, new()
            where TRequest : SessionIdInternalRequestModel, new()
        {
            if (cancellationToken.IsCancellationRequested)
                return new HttpRequestResult<TResponse>(OperationCancelledErrorMessage);

            // If the session id requires refresh...
            if (RequiresSessionIdRefresh())
                // Refresh the token
                await EnsureValidSessionAsync(cancellationToken).ConfigureAwait(false);

            // Set the session id
            requestModel.SessionId = _sessionId;

            // Get the response
            var response = await ExecuteSoapEnvelopeRequest<TResponse, TRequest>(requestModel, cancellationToken).ConfigureAwait(false);

            // If the request has failed, due to an expired session...
            if (response.IsUnauthorizedRequest)
            {
                // Refresh the token
                await EnsureValidSessionAsync(cancellationToken).ConfigureAwait(false);

                // Set the session id
                requestModel.SessionId = _sessionId;

                response = await ExecuteSoapEnvelopeRequest<TResponse, TRequest>(requestModel, cancellationToken).ConfigureAwait(false);
            }

            return response;
        }

        /// <summary>
        /// Embeds the <paramref name="requestModel"/> into a <see cref="SoapEnvelopeDataModel{TRequest}"/>, make the POST call and
        /// extracts the <typeparamref name="TResponse"/> from the returned <see cref="SoapEnvelopeDataModel{TResponse}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response model</typeparam>
        /// <typeparam name="TRequest">The type of the request model</typeparam>
        /// <param name="requestModel">The request model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        private async Task<InternalHttpRequestResult<TResponse>> ExecuteSoapEnvelopeRequest<TResponse, TRequest>(TRequest requestModel, CancellationToken cancellationToken = default)
            where TResponse : class, ISoapReturnMessageModel, IUnmappedXml, new()
            where TRequest : class, new()
        {
            if (cancellationToken.IsCancellationRequested)
                return new InternalHttpRequestResult<TResponse>(OperationCancelledErrorMessage);

            var serializedRequestPayload = string.Empty;

            var serializedResponsePayload = string.Empty;

            try
            {
                // Embed the request model
                var model = new SoapEnvelopeDataModel<TRequest>()
                {
                    Body = new SoapEnvelopeBodyDataModel<TRequest>()
                    {
                        Model = requestModel
                    }
                };

                serializedRequestPayload = XmlHelpers.ToXml(model, SpeedexXmlNamespaces.SpeedexNamespaces);

                using var httpRequest = new TypedStringContent<TRequest, TResponse>(serializedRequestPayload, Encoding.UTF8, MediaHeader);

                // Get the response
                using var response = await _httpClient.PostAsync(APIURL, httpRequest, cancellationToken).ConfigureAwait(false);

                serializedResponsePayload = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    return new InternalHttpRequestResult<TResponse>(serializedResponsePayload, serializedRequestPayload, serializedResponsePayload);

                var deserializedResponse = XmlHelpers.FromXml<SoapEnvelopeDataModel<TResponse>>(serializedResponsePayload);

                if (deserializedResponse is null)
                    return new InternalHttpRequestResult<TResponse>("De-serialization error", serializedRequestPayload, serializedResponsePayload);

                // Get the response model
                var responseModel = deserializedResponse.Body.Model;

                // If not successful...
                if (responseModel.Code != 1 && !responseModel.Message.Contains("OK.", StringComparison.OrdinalIgnoreCase))
                {
                    // Get the error message
                    var errorMessage = responseModel.Message;

                    return new InternalHttpRequestResult<TResponse>(errorMessage, serializedRequestPayload, serializedResponsePayload, responseModel.Code);
                }

#if DEBUG
                // If there is at least one unmapped XML element...
                if (responseModel.HasUnmappedElements)
                    Debugger.Break();
#endif

                // Return the successful result
                return new InternalHttpRequestResult<TResponse>(responseModel, serializedRequestPayload, serializedResponsePayload);
            }
            catch (Exception ex)
            {
                return new InternalHttpRequestResult<TResponse>(ex, serializedRequestPayload, serializedResponsePayload);
            }
        }

        #endregion

        #region Private Classes

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the result of the response</typeparam>
        private sealed class InternalHttpRequestResult<TResponse> : HttpRequestResult<TResponse>
        {
            #region Constants

            /// <summary>
            /// The code that indicates whether the request is unauthorized
            /// </summary>
            public const uint UnauthorizedRequestCode = 1401;

            #endregion

            #region Public Properties

            /// <summary>
            /// A flag indicating whether the request was unauthorized
            /// </summary>
            public bool IsUnauthorizedRequest { get; }

            #endregion

            #region Constructors

            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            /// <param name="exception">The exception</param>
            /// <param name="requestPayload">The request payload</param>
            /// <param name="responsePayload">The response payload</param>
            public InternalHttpRequestResult([NotNull] Exception exception, string? requestPayload, string? responsePayload) : base(exception, requestPayload, responsePayload)
            {

            }

            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            /// <param name="errorMessage">The error message</param>
            /// <param name="requestPayload">The request payload</param>
            /// <param name="responsePayload">The response payload</param>
            /// <param name="errorCode">The error code</param>
            public InternalHttpRequestResult([NotNull] string errorMessage, string? requestPayload, string? responsePayload, uint? errorCode = null) : base(errorMessage, requestPayload, responsePayload)
            {
                IsUnauthorizedRequest = errorCode.HasValue && errorCode.Value == UnauthorizedRequestCode;
            }

            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            /// <param name="errorMessage">The error message</param>
            public InternalHttpRequestResult([NotNull] string errorMessage) : this(errorMessage, null, null, 0)
            {

            }

            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            /// <param name="result">The result</param>
            /// <param name="requestPayload">The request payload</param>
            /// <param name="responsePayload">The response payload</param>
            internal InternalHttpRequestResult(TResponse result, string requestPayload, string responsePayload) : base(result, requestPayload, responsePayload)
            {

            }

            #endregion
        }

        #endregion
    }
}