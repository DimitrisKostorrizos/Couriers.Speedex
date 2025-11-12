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

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// </summary>
        public int CustomerFlag { get; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public string? BranchBankCode { get; }

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

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentResponseModel"/>
        /// </summary>
        public ConsignmentResponseModel(int customerFlag, string? branchBankCode, string? commentsFirstPart,
            string? commentsSecondPart, string? commentsThirdPart, PaymentType? paymentType, decimal cost, double weight,
            ChargeType chargeType, string agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) : base(weight, chargeType, agreementCode, customerCode,
            firstCustomerReference, secondCustomerReference, thirdCustomerReference, address, recipientName,
            recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime)
        {

            if (cost < 0)
                throw new ArgumentException($"'{nameof(cost)}' cannot be negative.", nameof(cost));

            CustomerFlag = customerFlag;
            BranchBankCode = branchBankCode;
            CommentsFirstPart = commentsFirstPart;
            CommentsSecondPart = commentsSecondPart;
            CommentsThirdPart = commentsThirdPart;
            PaymentType = paymentType;
            Cost = cost;
        }

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
