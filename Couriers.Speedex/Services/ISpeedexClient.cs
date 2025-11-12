using Couriers.Common.ResultTypes;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;
using Couriers.Speedex.ResponseModels;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex.Services
{
    /// <summary>
    /// Provides abstraction for a client for the Speedex web service
    /// </summary>
    public interface ISpeedexClient
    {
        #region Methods

        /// <summary>
        /// Creates a new session
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<string>> CreateSessionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the consignment for the order with the specified <paramref name="voucherId"/>
        /// NOTE: A consignment that has already been picked up, cannot be canceled. 
        /// A member consignment of a master consignment, cannot be canceled.
        /// If a master consignment is canceled, all its member consignments are also canceled.
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult> CancelConsignmentByVoucherIdAsync(string voucherId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the specified <paramref name="values"/>
        /// </summary>
        /// <param name="values">The consignments</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<ConsignmentResponseModel>>> CreateConsignmentsAsync(IEnumerable<ConsignmentRequestModel> values, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The consignment</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<ConsignmentResponseModel>> CreateConsignmentAsync(ConsignmentRequestModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the voucher PDF for the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The consignments</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<ConsignmentPdfResponseModel>>> GetConsignmentPdfsAsync(ConsignmentPdfRequestModel value, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the voucher PDF for the voucher with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The voucher id</param>
        /// <param name="paperSize">The paper size</param>
        /// <param name="returnMultipleVouchers">The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<string>> GetConsignmentPdfAsync(string voucherId, PaperSize paperSize, bool returnMultipleVouchers = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the branch depots for the area with the specified <paramref name="zipCode"/>
        /// </summary>
        /// <param name="zipCode">The zip code</param>
        /// <param name="language">The language that the results will be translated to</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<BranchResponseModel>>> GetBranchesAsync(string zipCode, SupportedLanguage language = SupportedLanguage.Greek, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get last checkpoint of the for the consignment with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<CheckpointResponseModel>> GetLastCheckPointAsync(string voucherId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get last checkpoint of the for the pickup with the specified <paramref name="pickupId"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<PickupCheckpointResponseModel>> GetLastPickupCheckPointAsync(string pickupId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all the checkpoints of a consignment, using the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The client references</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByClientReferencesAsync(ClientReferencesRequestModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the checkpoints for all the new checkpoints of the consignments, in a specific time frame from <paramref name="dateTo"/> to <paramref name="dateFrom"/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByTimeFrameAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the checkpoints for all the new checkpoints of the consignments with the specified <paramref name="voucherId"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<CheckpointResponseModel>>> GetTraceByVoucherIdAsync(string voucherId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the pickup with the specified <paramref name="pickupId"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult> CancelPickupByIdAsync(string pickupId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the pickup with the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The pickup details</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<string>> CreatePickupAsync(PickupRequestModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all the consignments created on the specified date range, from <paramref name="dateFrom"/> to <paramref name="dateTo"/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<ConsignmentDetailsResponseModel>>> GetConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all the consignment deposits created on the specified date range, 
        /// from <paramref name="dateFrom"/> to <paramref name="dateTo"/>
        /// </summary>
        /// <param name="dateFrom">The beginning of the time frame</param>
        /// <param name="dateTo">The end of the time frame</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<IEnumerable<DepositedConsignmentResponseModel>>> GetDepositedConsignmentsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the pickup with the specified <paramref name="pickupId"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult<PickupResponseModel>> GetPickupByIdAsync(string pickupId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reschedules the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The details for the pickup reschedule</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<IHttpRequestResult> ReschedulePickupAsync(ReschedulePickupRequestModel model, CancellationToken cancellationToken = default);

        #endregion
    }
}