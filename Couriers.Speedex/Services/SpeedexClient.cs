using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;

namespace Couriers.Speedex
{
    /// <summary>
    /// The client for the Speedex web service
    /// </summary>
    public class SpeedexClient
    {
        #region Constants

        /// <summary>
        /// The media type header value
        /// </summary>
        public const string MediaHeader = "application/soap+xml";

        private static readonly MediaTypeHeaderValue mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(MediaHeader);

        /// <summary>
        /// The maximum expiration time of the 
        /// </summary>
        private static readonly TimeSpan _maximumExpirationTime = new(1, 0, 0);

        /// <summary>
        /// The session id
        /// </summary>
        private string _sessionId = string.Empty;

        /// <summary>
        /// The date-time the session id was last refreshed
        /// </summary>
        private DateTimeOffset _lastSessionIdRefreshDate;

        #endregion

        #region Private Fields

        private readonly HttpClient _httpClient;

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
        public SpeedexClient(SpeedexCredentials credentials, HttpClient httpClient, bool useTestAPI = false) : base()
        {
            ArgumentNullException.ThrowIfNull(credentials, nameof(credentials));

            ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));

            Credentials = credentials;

            _httpClient = httpClient;

            ShouldAccessTestAPI = useTestAPI;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="credentials">The credentials</param>
        /// <param name="useTestAPI">The flag indicating whether to use the test API</param>
        public SpeedexClient(SpeedexCredentials credentials, bool useTestAPI = false) : this(credentials, new HttpClient(), useTestAPI)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Validates the <see cref="Credentials"/> and returns a valid session id that expires in 1 hour
        /// </summary>
        /// <returns></returns>
        public async Task<HttpRequestResult<string>> CreateSessionAsync()
        {
            // Get the response
            var response = await BaseSOAPEnvelopeRequest<SessionIdInternalResponseModel, CredentialsInternalRequestModel>(CredentialsInternalRequestModel.FromRequestModel(Credentials));

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<string>();

            // Set the session id
            _sessionId = response.Result.ToResponseModel();

            // Set the date-time the session id was last refreshed
            _lastSessionIdRefreshDate = DateTimeOffset.Now;

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
        /// <returns></returns>
        public async Task<HttpRequestResult> CancelConsignmentByVoucherIdAsync(string voucherId)
            => await BaseValidatedSOAPEnvelopeRequest<CancelConsignmentByVoucherIdInternalResponseModel, CancelConsignmentByVoucherIdInternalRequestModel>(new CancelConsignmentByVoucherIdInternalRequestModel() { VoucherId = voucherId });

        /// <summary>
        /// Creates the specified <paramref name="values"/>
        /// NOTE: The max number of consignments per request is 10
        /// </summary>
        /// <param name="values">The consignments</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<CreateConsignmentsResponseModel>> CreateConsignmentsAsync(IEnumerable<ConsignmentRequestModel> values)
        {
            // If more than 10 values are specified...
            if (values.Count() > 10)
                throw new InvalidOperationException("More than 10 values were specified.");

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<CreateConsignmentsInternalResponseModel, CreateConsignmentsInternalRequestModel>(CreateConsignmentsInternalRequestModel.FromRequestModel(values));

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<CreateConsignmentsResponseModel>();

            return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Creates the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The consignment</param>
        /// <returns></returns>
        public Task<HttpRequestResult<CreateConsignmentsResponseModel>> CreateConsignmentAsync(ConsignmentRequestModel model)
        {
            // Set the agreement code
            model.AgreementCode = Credentials.AgreementCode;

            // Set the customer code
            model.CustomerCode = Credentials.CustomerCode;

            // Return the response
            return CreateConsignmentsAsync([model]);
        }

        /// <summary>
        /// Get the voucher PDF for the specified <paramref name="value"/>
        /// NOTE: The max number of consignments per request is 20
        /// </summary>
        /// <param name="value">The consignments</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<ConsignmentPDFResponseModel>>> GetConsignmentPDFsAsync(ConsignmentPDFRequestModel value)
        {
            // If more than 20 values are specified...
            if (value.VoucherIds.Count() > 20)
                throw new InvalidOperationException("More than 20 values were specified.");

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetConsignmentPDFInternalResponseModel, ConsignmentPDFInternalRequestModel>(ConsignmentPDFInternalRequestModel.FromRequestModel(value));

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<IEnumerable<ConsignmentPDFResponseModel>>();

            // Return the successful result
            return HttpRequestResult.FromResult(response.Result.ToResponseModel(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get the voucher PDF for the voucher with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The voucher id</param>
        /// <param name="paperSize">The paper size</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<ConsignmentPDFResponseModel>> GetConsignmentPDFAsync(string voucherId, PaperSize paperSize = PaperSize.A4)
        {
            // Initialize the model
            var value = new ConsignmentPDFRequestModel() { PaperSize = paperSize, VoucherIds = new List<string>() { voucherId } };

            // Get the response
            var response = await GetConsignmentPDFsAsync(value);

            // If not successful...
            if (!response.IsSuccessful)
                // Return the unsuccessful result
                return response.ToUnsuccessfulHttpRequestResult<ConsignmentPDFResponseModel>();

            // Return the successful result
            return HttpRequestResult.FromResult(response.Result.First(), response.RequestPayload, response.ResponsePayload);
        }

        /// <summary>
        /// Get the branch depots for the area with the specified <paramref name="zipCode"/>
        /// </summary>
        /// <param name="zipCode">The zip code</param>
        /// <param name="language">The language that the results will be translated to</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<BranchResponseModel>>> GetBranchesAsync(string zipCode, SupportedLanguage language = SupportedLanguage.Greek)
        {
            // Get the selected language
            var selectedLanguage = language == SupportedLanguage.Greek ? 1u : 2u;

            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetBranchesInternalResponseModel, BranchInternalRequestModel>(new BranchInternalRequestModel() { ZipCode = zipCode, Language = selectedLanguage });

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
        /// <returns></returns>
        public async Task<HttpRequestResult<CheckpointResponseModel>> GetLastCheckPointAsync(string voucherId)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetLastCheckpointInternalResponseModel, GetLastCheckpointInternalRequestModel>(new GetLastCheckpointInternalRequestModel() { VoucherId = voucherId });

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
        /// <returns></returns>
        public async Task<HttpRequestResult<PickupCheckpointResponseModel>> GetLastPickupCheckPointAsync(string pickupId)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetLastPickupCheckpointInternalResponseModel, GetLastPickupCheckpointInternalRequestModel>(new GetLastPickupCheckpointInternalRequestModel() { PickupId = pickupId });

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
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByClientReferencesAsync(ClientReferencesRequestModel model)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetTraceByClientReferencesInternalResponseModel, ClientReferencesInternalRequestModel>(ClientReferencesInternalRequestModel.FromRequestModel(model));

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
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByTimeFrameAsync(DateTime dateFrom, DateTime dateTo)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetTraceByTimeFrameInternalResponseModel, GetCheckpointsByTimeFrameInternalRequestModel>(new GetCheckpointsByTimeFrameInternalRequestModel() { DateFrom = dateFrom, DateTo = dateTo });

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
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByVoucherIdAsync(string voucherId)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetTraceByVoucherIdInternalResponseModel, GetTraceByVoucherIdInternalRequestModel>(new GetTraceByVoucherIdInternalRequestModel() { VoucherId = voucherId });

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
        /// <returns></returns>
        public async Task<HttpRequestResult> CancelPickupByIdAsync(string pickupId)
            => await BaseValidatedSOAPEnvelopeRequest<CancelPickupInternalResponseModel, CancelPickupByIdInternalRequestModel>(new CancelPickupByIdInternalRequestModel() { PickupNumber = pickupId });

        /// <summary>
        /// Creates the pickup with the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The pickup details</param>
        /// <returns></returns>
        public async Task<HttpRequestResult<string>> CreatePickupAsync(PickupRequestModel model)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<CreatePickupInternalResponseModel, PickupInternalRequestModel>(PickupInternalRequestModel.FromRequestModel(model));

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
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>> GetConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetConsignmentsByDateInternalResponseModel, GetConsignmentsByDateRangeInternalRequestModel>(new GetConsignmentsByDateRangeInternalRequestModel() { DateFrom = dateFrom, DateTo = dateTo });

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
        /// <returns></returns>
        public async Task<HttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>> GetDepositedConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetDepositedConsignmentsByDateInternalResponseModel, GetDepositedConsignmentsByDateRangeInternalRequestModel>(new GetDepositedConsignmentsByDateRangeInternalRequestModel() { DateFrom = dateFrom, DateTo = dateTo });

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
        /// <returns></returns>
        public async Task<HttpRequestResult<PickupResponseModel>> GetPickupByIdAsync(string pickupId)
        {
            // Get the response
            var response = await BaseValidatedSOAPEnvelopeRequest<GetPickupInternalResponseModel, GetPickupByIdInternalRequestModel>(new GetPickupByIdInternalRequestModel() { PickupNumber = pickupId });

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
        /// <returns></returns>
        public async Task<HttpRequestResult> ReschedulePickupAsync(ReschedulePickupRequestModel model)
            => await BaseValidatedSOAPEnvelopeRequest<ReschedulePickupInternalResponseModel, ReschedulePickupInternalRequestModel>(ReschedulePickupInternalRequestModel.FromRequestModel(model));

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks whether one hour has been passed since the last session id refresh
        /// </summary>
        /// <returns></returns>
        private bool RequiresSessionIdRefresh()
            => DateTimeOffset.Now.Subtract(_lastSessionIdRefreshDate) >= _maximumExpirationTime;

        /// <summary>
        /// Checks whether the <see cref="_sessionId"/> needs refresh, if a refresh is needed, the session id is refreshed and the specified call is made
        /// </summary>
        /// <typeparam name="TResponse">The type of the response model</typeparam>
        /// <typeparam name="TRequest">The type of the request model</typeparam>
        /// <param name="requestModel">The request model</param>
        /// <returns></returns>
        private async Task<HttpRequestResult<TResponse>> BaseValidatedSOAPEnvelopeRequest<TResponse, TRequest>(TRequest requestModel)
            where TResponse : class, ISOAPReturnMessageModel, new()
            where TRequest : SessionIdInternalRequestModel, new()
        {
            // If the session id requires refresh...
            if (RequiresSessionIdRefresh())
                // Refresh the token
                await CreateSessionAsync();

            // Set the session id
            requestModel.SessionId = _sessionId;

            // Return the response
            return await BaseSOAPEnvelopeRequest<TResponse, TRequest>(requestModel);
        }

        /// <summary>
        /// Embeds the <paramref name="requestModel"/> into a <see cref="SoapEnvelopeDataModel{TRequest}"/>, make the POST call and
        /// extracts the <typeparamref name="TResponse"/> from the returned <see cref="SoapEnvelopeDataModel{TResponse}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response model</typeparam>
        /// <typeparam name="TRequest">The type of the request model</typeparam>
        /// <param name="requestModel">The request model</param>
        /// <returns></returns>
        private async Task<HttpRequestResult<TResponse>> BaseSOAPEnvelopeRequest<TResponse, TRequest>(TRequest requestModel)
            where TResponse : class, ISOAPReturnMessageModel, new()
            where TRequest : class, new()
        {
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

                serializedRequestPayload = XMLHelpers.ToXml(model, XmlNamespaces.Namespaces);

                using var httpRequest = new StringContent(serializedRequestPayload, mediaTypeHeaderValue);

                // Get the response
                using var response = await _httpClient.PostAsync(Routes.GetBaseAddress(ShouldAccessTestAPI), httpRequest);

                serializedResponsePayload = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return new HttpRequestResult<TResponse>(serializedResponsePayload, serializedRequestPayload, serializedResponsePayload);

                var deserializedResponse = XMLHelpers.FromXml<SoapEnvelopeDataModel<TResponse>>(serializedResponsePayload);

                if(deserializedResponse is null)
                    return new HttpRequestResult<TResponse>("De-serialization error", serializedRequestPayload, serializedResponsePayload);

                // Get the response model
                var responseModel = deserializedResponse.Body.Model;

                // If not successful...
                if (responseModel.Code != 1 && !responseModel.Message.Contains("OK."))
                {
                    // Declare an XML document
                    var xmlDocument = new XmlDocument();

                    // Load it from the XML server response
                    xmlDocument.LoadXml(serializedResponsePayload);

                    // Get the error message
                    var errorMessage = string.Join(", ", xmlDocument.GetElementsByTagName("string")
                        .OfType<XmlNode>()
                        .Select(x => x.InnerText));

                    return new HttpRequestResult<TResponse>(errorMessage, serializedRequestPayload, serializedResponsePayload);
                }

                // Return the successful result
                return HttpRequestResult.FromResult(responseModel, serializedRequestPayload, serializedResponsePayload);
            }
            catch (Exception ex)
            {
                return new HttpRequestResult<TResponse>(ex, serializedRequestPayload, serializedResponsePayload);
            }
        }

        #endregion
    }
}
