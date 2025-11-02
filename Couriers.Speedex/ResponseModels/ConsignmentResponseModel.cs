using Couriers.Speedex.Enums;

using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment
    /// </summary>
    public record ConsignmentResponseModel : BaseConsignmentResponseModel
    {
        #region Public Properties

#if NET7_0_OR_GREATER

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// </summary>
        public required int CustomerFlag { get; init; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public required string BranchBankCode
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
        /// The first part of the comments
        /// </summary>
        public string? CommentsFirstPart { get; init; }

        /// <summary>
        /// The second part of the comments
        /// </summary>
        public string? CommentsSecondPart { get; init; }

        /// <summary>
        /// The third part of the comments
        /// </summary>
        public string? CommentsThirdPart { get; init; }

        /// <summary>
        /// The payment type
        /// </summary>
        public PaymentType? PaymentType { get; init; }

        /// <summary>
        /// The cost
        /// </summary>
        public decimal Cost 
        { 
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentOutOfRangeException.ThrowIfNegative(value);
#else
                if (value < 0)
                    throw new ArgumentException($"'{nameof(value)}' cannot be negative.", nameof(value));
#endif
                field = value;
            }
        }
#else
        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// </summary>
        public int CustomerFlag { get; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public string BranchBankCode { get; }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        public string? CommentsFirstPart { get; }

        /// <summary>
        /// The second part of the comments
        /// </summary>
        public string? CommentsSecondPart { get; }

        /// <summary>
        /// The third part of the comments
        /// </summary>
        public string? CommentsThirdPart { get; }

        /// <summary>
        /// The payment type
        /// </summary>
        public PaymentType? PaymentType { get; }

        /// <summary>
        /// The cost
        /// </summary>
        public decimal Cost { get; }
#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER
        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentResponseModel"/>
        /// </summary>
        public ConsignmentResponseModel() : base()
        {

        }
#else
        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentResponseModel"/>
        /// </summary>
        public ConsignmentResponseModel(int customerFlag, string branchBankCode, string? commentsFirstPart, 
            string? commentsSecondPart, string? commentsThirdPart, PaymentType? paymentType, decimal cost, double weight, 
            ChargeType chargeType, string agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) : base(weight, chargeType, agreementCode, customerCode,
            firstCustomerReference, secondCustomerReference, thirdCustomerReference, address, recipientName,
            recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime)
        {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                ArgumentOutOfRangeException.ThrowIfNegative(value);
#else
            if (string.IsNullOrWhiteSpace(branchBankCode))
                throw new ArgumentException($"'{nameof(branchBankCode)}' cannot be null or whitespace.", nameof(branchBankCode));

            if (cost < 0)
                throw new ArgumentException($"'{nameof(cost)}' cannot be negative.", nameof(cost));
#endif
            CustomerFlag = customerFlag;
            BranchBankCode = branchBankCode;
            CommentsFirstPart = commentsFirstPart;
            CommentsSecondPart = commentsSecondPart;
            CommentsThirdPart = commentsThirdPart;
            PaymentType = paymentType;
            Cost = cost;
        }
#endif

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ConsignmentId;

        #endregion
    }
}
