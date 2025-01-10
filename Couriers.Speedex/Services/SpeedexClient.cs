using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex
{
    /// <summary>
    /// The client for the Speedex web service
    /// </summary>
    public class SpeedexClient : IDisposable
    {
        #region Constants

        /// <summary>
        /// The media type header value
        /// </summary>
        public const string MediaHeader = "text/xml; charset=utf-8.";

        /// <summary>
        /// The media type header
        /// </summary>
        private static readonly MediaTypeHeaderValue _mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(MediaHeader);

        /// <summary>
        /// The maximum expiration time of the 
        /// </summary>
        private static readonly TimeSpan _maximumExpirationTime = new(1, 0, 0);

        #endregion

        #region Private Fields

        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// A flag indicating whether the current instance should be disposed
        /// </summary>
        private readonly bool _shouldDispose;

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
        /// The flag indicating whether to access the test API
        /// </summary>
        public bool ShouldAccessTestAPI { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="credentials">The credentials</param>
        /// <param name="useTestAPI">The flag indicating whether to use the test API</param>
        /// <param name="httpClient">The HTTP client</param>
        /// <param name="shouldDispose">A flag indicating whether the current instance should be disposed</param>
        public SpeedexClient([NotNull] SpeedexCredentials credentials, [NotNull] HttpClient httpClient, bool useTestAPI = false, bool shouldDispose = true) : base()
        {
            ArgumentNullException.ThrowIfNull(credentials);

            ArgumentNullException.ThrowIfNull(httpClient);

            Credentials = credentials;

            _httpClient = httpClient;

            _shouldDispose = shouldDispose;

            ShouldAccessTestAPI = useTestAPI;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="credentials">The credentials</param>
        /// <param name="useTestAPI">The flag indicating whether to use the test API</param>
        /// <param name="shouldDispose">A flag indicating whether the current instance should be disposed</param>
        public SpeedexClient([NotNull] SpeedexCredentials credentials, bool useTestAPI = false, bool shouldDispose = true) : this(credentials, new HttpClient(), useTestAPI, shouldDispose)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new session
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<string>> CreateSessionAsync(CancellationToken cancellationToken = default)
        {
            var requestModel = CredentialsInternalRequestModel.FromRequestModel(Credentials);

            // Get the response
            var response = await BaseSoapEnvelopeRequest<SessionIdInternalResponseModel, CredentialsInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<string>();

            // Return the successful result
            return HttpRequestResult.FromResult(_sessionId, response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Cancels the consignment for the order with the specified <paramref name="voucherId"/>
        /// NOTE: A consignment that has already been picked up, cannot be canceled. 
        /// A member consignment of a master consignment, cannot be canceled.
        /// If a master consignment is canceled, all its member consignments are also canceled.
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult> CancelConsignmentByVoucherIdAsync([NotNull] string voucherId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId);

            return await BaseValidatedSOAPEnvelopeRequest<CancelConsignmentByVoucherIdInternalResponseModel, CancelConsignmentByVoucherIdInternalRequestModel>(new CancelConsignmentByVoucherIdInternalRequestModel()
            {
                VoucherId = voucherId
            }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates the specified <paramref name="values"/>
        /// NOTE: The max number of consignments per request is 10
        /// </summary>
        /// <param name="values">The consignments</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<ConsignmentResponseModel>>> CreateConsignmentsAsync([NotNull] IEnumerable<ConsignmentRequestModel> values, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(values);

            var numberOfItems = values.Count();

            if(numberOfItems == 0)
                throw new ArgumentOutOfRangeException(nameof(values), "At least one consignment must be specified");

            // If more than 10 values are specified...
            if (numberOfItems > SpeedexConstants.MaximumNumberOfConsignments)
                throw new InvalidOperationException($"The maximum number of consignments is {SpeedexConstants.MaximumNumberOfConsignments}.");

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<CreateConsignmentsInternalResponseModel, CreateConsignmentsInternalRequestModel>(CreateConsignmentsInternalRequestModel.FromRequestModel(values, Credentials.AgreementCode, Credentials.CustomerCode), cancellationToken).ConfigureAwait(false);

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

        /// <summary>
        /// Creates the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The consignment</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<ConsignmentResponseModel>> CreateConsignmentAsync([NotNull] ConsignmentRequestModel model, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(model);

            // Get the response
            var response = await CreateConsignmentsAsync([model], cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                return response.ToUnsuccessfulHttpRequestResult<ConsignmentResponseModel>();

            // Return the response
            return HttpRequestResult.FromResult(response.Result.First(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get the voucher PDF for the specified <paramref name="value"/>
        /// NOTE: The max number of consignments per request is 20
        /// </summary>
        /// <param name="value">The consignments</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>> GetConsignmentPdfsAsync([NotNull] ConsignmentPdfRequestModel value, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(value);

            var requestModel = ConsignmentPdfInternalRequestModel.FromRequestModel(value);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetConsignmentPdfInternalResponseModel, ConsignmentPdfInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>();

            // Return the successful result
            return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get the voucher PDF for the voucher with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The voucher id</param>
        /// <param name="paperSize">The paper size</param>
        /// <param name="returnMultipleVouchers">The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<string>> GetConsignmentPdfAsync([NotNull] string voucherId, PaperSize paperSize, bool returnMultipleVouchers = false, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId);

            // Initialize the model
            var value = new ConsignmentPdfRequestModel([voucherId], paperSize, returnMultipleVouchers);

            // Get the response
            var response = await GetConsignmentPdfsAsync(value, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<string>();

            // Return the successful result
            return HttpRequestResult.FromResult(response.Result.First().Base64String, response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get the branch depots for the area with the specified <paramref name="zipCode"/>
        /// </summary>
        /// <param name="zipCode">The zip code</param>
        /// <param name="language">The language that the results will be translated to</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<BranchResponseModel>>> GetBranchesAsync([NotNull] string zipCode, SupportedLanguage language = SupportedLanguage.Greek, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(zipCode);

            SpeedexHelpers.ThrowIfInvalidZipCode(zipCode);

            // Get the selected language
            var selectedLanguage = SpeedexHelpers.FromSupportedLanguage(language);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetBranchesInternalResponseModel, BranchInternalRequestModel>(new BranchInternalRequestModel()
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

        /// <summary>
        /// Get last checkpoint of the for the consignment with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<CheckpointResponseModel>> GetLastCheckPointAsync([NotNull] string voucherId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetLastCheckpointInternalResponseModel, GetLastCheckpointInternalRequestModel>(new GetLastCheckpointInternalRequestModel()
            {
                VoucherId = voucherId
            }, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<CheckpointResponseModel>();

            return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get last checkpoint of the for the pickup with the specified <paramref name="pickupId"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<PickupCheckpointResponseModel>> GetLastPickupCheckPointAsync([NotNull] string pickupId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(pickupId);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetLastPickupCheckpointInternalResponseModel, GetLastPickupCheckpointInternalRequestModel>(new GetLastPickupCheckpointInternalRequestModel()
            {
                PickupId = pickupId
            }, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<PickupCheckpointResponseModel>();

            return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get all the checkpoints of a consignment, using the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The client references</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByClientReferencesAsync([NotNull] ClientReferencesRequestModel model, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(model);

            var requestModel = ClientReferencesInternalRequestModel.FromRequestModel(model);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetTraceByClientReferencesInternalResponseModel, ClientReferencesInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<IEnumerable<CheckpointResponseModel>>();

            return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get the checkpoints for all the new checkpoints of the consignments, in a specific time frame from <paramref name="dateTo"/> to <paramref name="dateFrom"/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByTimeFrameAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (dateFrom > dateTo)
                throw new ArgumentOutOfRangeException(nameof(dateFrom), $"The {nameof(dateFrom)} has to be before {nameof(dateTo)}.");

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetTraceByTimeFrameInternalResponseModel, GetCheckpointsByTimeFrameInternalRequestModel>(new GetCheckpointsByTimeFrameInternalRequestModel()
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

        /// <summary>
        /// Get the checkpoints for all the new checkpoints of the consignments with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByVoucherIdAsync([NotNull] string voucherId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetTraceByVoucherIdInternalResponseModel, GetTraceByVoucherIdInternalRequestModel>(new GetTraceByVoucherIdInternalRequestModel()
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

        /// <summary>
        /// Cancels the pickup with the specified <paramref name="pickupId"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult> CancelPickupByIdAsync([NotNull] string pickupId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(pickupId);

            return await BaseValidatedSOAPEnvelopeRequest<CancelPickupInternalResponseModel, CancelPickupByIdInternalRequestModel>(new CancelPickupByIdInternalRequestModel()
            {
                PickupNumber = pickupId
            }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates the pickup with the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The pickup details</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<string>> CreatePickupAsync([NotNull] PickupRequestModel model, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(model);

            var requestModel = PickupInternalRequestModel.FromRequestModel(model);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<CreatePickupInternalResponseModel, PickupInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<string>();

            // Return the successful result
            return HttpRequestResult.FromResult(response.Result.Result.Result, response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get all the consignments created on the specified date range, from <paramref name="dateFrom"/> to <paramref name="dateTo"/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>> GetConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (dateFrom > dateTo)
                throw new ArgumentOutOfRangeException(nameof(dateFrom), $"The {nameof(dateFrom)} has to be before {nameof(dateTo)}.");

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetConsignmentsByDateInternalResponseModel, GetConsignmentsByDateRangeInternalRequestModel>(new GetConsignmentsByDateRangeInternalRequestModel()
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

        /// <summary>
        /// Get all the consignment deposits created on the specified date range, from <paramref name="dateFrom"/> to <paramref name="dateTo"/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>> GetDepositedConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (dateFrom > dateTo)
                throw new ArgumentOutOfRangeException(nameof(dateFrom), $"The {nameof(dateFrom)} has to be before {nameof(dateTo)}.");

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetDepositedConsignmentsByDateInternalResponseModel, GetDepositedConsignmentsByDateRangeInternalRequestModel>(new GetDepositedConsignmentsByDateRangeInternalRequestModel()
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

        /// <summary>
        /// Get the pickup with the specified <paramref name="pickupId"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<PickupResponseModel>> GetPickupByIdAsync([NotNull] string pickupId, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(pickupId);

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetPickupInternalResponseModel, GetPickupByIdInternalRequestModel>(new GetPickupByIdInternalRequestModel()
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

        /// <summary>
        /// Reschedules the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The details for the pickup reschedule</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpRequestResult> ReschedulePickupAsync(ReschedulePickupRequestModel model, CancellationToken cancellationToken = default)
        {
            var requestModel = ReschedulePickupInternalRequestModel.FromRequestModel(model);

            return await BaseValidatedSOAPEnvelopeRequest<ReschedulePickupInternalResponseModel, ReschedulePickupInternalRequestModel>(requestModel, cancellationToken).ConfigureAwait(false);
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
            if (!_shouldDispose)
                return;

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
        private async Task<HttpRequestResult> EnsureValidSessionAsync(CancellationToken cancellationToken = default)
        {
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
        private async Task<HttpRequestResult<TResponse>> BaseValidatedSOAPEnvelopeRequest<TResponse, TRequest>(TRequest requestModel, CancellationToken cancellationToken = default)
            where TResponse : class, ISoapReturnMessageModel, new()
            where TRequest : SessionIdInternalRequestModel, new()
        {
            // If the session id requires refresh...
            if (RequiresSessionIdRefresh())
                // Refresh the token
                await EnsureValidSessionAsync(cancellationToken).ConfigureAwait(false);

            // Set the session id
            requestModel.SessionId = _sessionId;

            // Get the response
            var response = await BaseSoapEnvelopeRequest<TResponse, TRequest>(requestModel, cancellationToken).ConfigureAwait(false);

            // If the request has failed, due to an expired session...
            if (response.IsUnauthorizedRequest)
            {
                // Refresh the token
                await EnsureValidSessionAsync(cancellationToken).ConfigureAwait(false);

                // Set the session id
                requestModel.SessionId = _sessionId;

                response = await BaseSoapEnvelopeRequest<TResponse, TRequest>(requestModel, cancellationToken).ConfigureAwait(false);
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
        private async Task<InternalHttpRequestResult<TResponse>> BaseSoapEnvelopeRequest<TResponse, TRequest>(TRequest requestModel, CancellationToken cancellationToken = default)
            where TResponse : class, ISoapReturnMessageModel, new()
            where TRequest : class, new()
        {
            var serializedRequestPayload = string.Empty;

            var serializedResponsePayload = string.Empty;

#pragma warning disable CA1031 // Do not catch general exception types

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

                using var httpRequest = new TypedStringContent<TRequest, TResponse>(serializedRequestPayload, _mediaTypeHeaderValue);

                // Get the response
                using var response = await _httpClient.PostAsync(Routes.GetBaseAddress(ShouldAccessTestAPI), httpRequest, cancellationToken).ConfigureAwait(false);

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

                // Return the successful result
                return new InternalHttpRequestResult<TResponse>(responseModel, serializedRequestPayload, serializedResponsePayload);
            }
            catch (Exception ex)
            {
                return new InternalHttpRequestResult<TResponse>(ex, serializedRequestPayload, serializedResponsePayload);
            }

#pragma warning restore CA1031 // Do not catch general exception types

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
            /// <param name="result">The result</param>
            /// <param name="requestPayload">The request payload</param>
            /// <param name="responsePayload">The response payload</param>
            internal InternalHttpRequestResult(TResponse result, string? requestPayload, string? responsePayload) : base(result, requestPayload, responsePayload)
            {

            }

            #endregion
        }

        #endregion
    }
}
