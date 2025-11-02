using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment checkpoint
    /// </summary>
    public record CheckpointResponseModel
    {
        #region Public Properties

#if NET7_0_OR_GREATER
        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public string? BranchDepot { get; init; }

        /// <summary>
        /// The unique branch depot id
        /// </summary>
        public string? BranchId { get; init; }

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public required DateTime CheckpointDate { get; init; }

        /// <summary>
        /// The customer's comments of the consignment
        /// </summary>
        public string? CustomerComments { get; init; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public string? FirstCustomerReference { get; init; }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public string? SecondCustomerReference { get; init; }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public string? ThirdCustomerReference { get; init; }

        /// <summary>
        /// The recipient name
        /// </summary>
        public string? RecipientName { get; init; }

        /// <summary>
        /// The code of the event
        /// </summary>
        public required string StatusCode
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
#else
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
#endif
                field = value;
            }
        }

        /// <summary>
        /// The description of the event
        /// </summary>
        public required string StatusDescription
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
#else
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
#endif
                field = value;
            }
        }

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public required string VoucherId
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
#else
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
#endif
                field = value;
            }
        }
#else
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
        public string? RecipientName { get; }

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
#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER
        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsResponseModel"/>
        /// </summary>
        public CheckpointResponseModel() : base()
        {

        }
#else
        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsResponseModel"/>
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
            if (string.IsNullOrWhiteSpace(statusCode))
                throw new ArgumentException($"'{nameof(statusCode)}' cannot be null or whitespace.", nameof(statusCode));

            if (string.IsNullOrWhiteSpace(statusDescription))
                throw new ArgumentException($"'{nameof(statusDescription)}' cannot be null or whitespace.", nameof(statusDescription));

            if (string.IsNullOrWhiteSpace(voucherId))
                throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

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

#endif
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
