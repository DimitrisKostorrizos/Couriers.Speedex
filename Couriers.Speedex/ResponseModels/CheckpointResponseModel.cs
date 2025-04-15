using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the consignment checkpoint
    /// </summary>
    public sealed record CheckpointResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public string? BranchDepot { get; }

        /// <summary>
        /// The unique branch depot id
        /// </summary>
        public string? BranchId { get; }

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public DateTime CheckpointDate { get; }

        /// <summary>
        /// The customer's comments of the consignment
        /// </summary>
        public string? CustomerComments { get; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public string? FirstCustomerReference { get; }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public string? SecondCustomerReference { get; }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public string? ThirdCustomerReference { get; }

        /// <summary>
        /// The recipient name
        /// </summary>
        public string RecipientName { get; }

        /// <summary>
        /// The code of the event
        /// </summary>
        public string StatusCode { get; }

        /// <summary>
        /// The description of the event
        /// </summary>
        public string StatusDescription { get; }

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public string VoucherId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="branchDepot">The name of the depot responsible for the event</param>
        /// <param name="branchId">The unique branch depot id</param>
        /// <param name="checkpointDate">The date-time of the event</param>
        /// <param name="customerComments">The customer's comments of the consignment</param>
        /// <param name="firstCustomerReference">The first customer reference of the consignment</param>
        /// <param name="secondCustomerReference">The second customer reference of the consignment</param>
        /// <param name="thirdCustomerReference">The third customer reference of the consignment</param>
        /// <param name="recipientName">The recipient name</param>
        /// <param name="statusCode">The code of the event</param>
        /// <param name="statusDescription">The description of the event</param>
        /// <param name="voucherId">The unique voucher id</param>
        public CheckpointResponseModel(string branchDepot, string branchId, DateTime checkpointDate, string? customerComments, string? firstCustomerReference,
            string? secondCustomerReference, string? thirdCustomerReference, string recipientName, string statusCode, string statusDescription, string voucherId) : base()
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(statusCode);

            ArgumentException.ThrowIfNullOrWhiteSpace(statusDescription);

            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId);
#else
            if (string.IsNullOrWhiteSpace(statusCode))
                throw new ArgumentException($"'{nameof(statusCode)}' cannot be null or whitespace.", nameof(statusCode));

            if (string.IsNullOrWhiteSpace(statusDescription))
                throw new ArgumentException($"'{nameof(statusDescription)}' cannot be null or whitespace.", nameof(statusDescription));

            if (string.IsNullOrWhiteSpace(voucherId))
                throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));
#endif

            BranchDepot = branchDepot;

            BranchId = branchId;

            CheckpointDate = checkpointDate;

            CustomerComments = customerComments;

            FirstCustomerReference = firstCustomerReference;

            SecondCustomerReference = secondCustomerReference;

            ThirdCustomerReference = thirdCustomerReference;

            RecipientName = recipientName;

            StatusCode = statusCode;

            StatusDescription = statusDescription;

            VoucherId = voucherId;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        #endregion
    }
}
