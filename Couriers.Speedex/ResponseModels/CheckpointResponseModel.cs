using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment checkpoint
    /// </summary>
    public record CheckpointResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="StatusCode"/>
        /// </summary>
        private string _statusCode = default!;

        /// <summary>
        /// The field for the <see cref="StatusDescription"/>
        /// </summary>
        private string _statusDescription = default!;

        /// <summary>
        /// The field for the <see cref="VoucherId"/>
        /// </summary>
        private string _voucherId = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public required string? BranchDepot { get; set; }

        /// <summary>
        /// The unique branch depot id
        /// </summary>
        public required string? BranchId { get; set; }

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public required DateTime CheckpointDate { get; set; }

        /// <summary>
        /// The customer's comments of the consignment
        /// </summary>
        public required string? CustomerComments { get; set; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public required string? FirstCustomerReference { get; set; }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public required string? SecondCustomerReference { get; set; }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public required string? ThirdCustomerReference { get; set; }

        /// <summary>
        /// The recipient name
        /// </summary>
        public required string? RecipientName { get; set; }

        /// <summary>
        /// The code of the event
        /// </summary>
        public required string StatusCode
        {
            get => _statusCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(StatusCode)}' cannot be null or whitespace.", nameof(StatusCode));

                _statusCode = value;
            }
        }

        /// <summary>
        /// The description of the event
        /// </summary>
        public required string StatusDescription
        {
            get => _statusDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(StatusDescription)}' cannot be null or whitespace.", nameof(StatusDescription));

                _statusDescription = value;
            }
        }

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public required string VoucherId
        {
            get => _voucherId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(VoucherId)}' cannot be null or whitespace.", nameof(VoucherId));

                _voucherId = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CheckpointResponseModel"/>
        /// </summary>
        public CheckpointResponseModel() : base()
        {

        }

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
        [SetsRequiredMembers]
        public CheckpointResponseModel(string branchDepot, string branchId, DateTime checkpointDate, string? customerComments, string? firstCustomerReference,
            string? secondCustomerReference, string? thirdCustomerReference, string recipientName, string statusCode, string statusDescription, string voucherId) : this()
        {
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
        [ExcludeFromCodeCoverage]
        public override string ToString() => VoucherId;

        #endregion
    }
}