using Couriers.Speedex.Enums;

using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment
    /// </summary>
    public record ConsignmentResponseModel : BaseConsignmentResponseModel
    {
        #region Private Fields
		
        /// <summary>
        /// The field for the <see cref="Cost"/>
        /// </summary>
        private decimal _cost;

        #endregion

        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// </summary>
        public required int CustomerFlag { get; set; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public required string? BranchBankCode { get; set; }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        public required string? CommentsFirstPart { get; set; }

        /// <summary>
        /// The second part of the comments
        /// </summary>
        public required string? CommentsSecondPart { get; set; }

        /// <summary>
        /// The third part of the comments
        /// </summary>
        public required string? CommentsThirdPart { get; set; }

        /// <summary>
        /// The payment type
        /// </summary>
        public required PaymentType? PaymentType { get; set; }

        /// <summary>
        /// The cost
        /// </summary>
        public required decimal Cost
        {
            get => _cost;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"'{nameof(Cost)}' cannot be negative.", nameof(Cost));

                _cost = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentResponseModel"/>
        /// </summary>
        public ConsignmentResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentResponseModel"/>
        /// </summary>
        /// <param name="customerFlag">The customer flag</param>
        /// <param name="branchBankCode">The cost center of the customer agreement</param>
        /// <param name="commentsFirstPart">The first part of the comments</param>
        /// <param name="commentsSecondPart">The second part of the comments</param>
        /// <param name="commentsThirdPart">The third part of the comments</param>
        /// <param name="paymentType">The payment type</param>
        /// <param name="cost">The cost</param>
        /// <param name="weight">The weight of the consignment</param>
        /// <param name="chargeType">The charge type of the consignment</param>
        /// <param name="agreementCode">The agreement code provided by Speedex</param>
        /// <param name="customerCode">The customer code provided by Speedex</param>
        /// <param name="firstCustomerReference">The first customer reference of the consignment</param>
        /// <param name="secondCustomerReference">The second customer reference of the consignment</param>
        /// <param name="thirdCustomerReference">The third customer reference of the consignment</param>
        /// <param name="address">The address for the delivery</param>
        /// <param name="recipientName">The name of the recipient</param>
        /// <param name="recipientPhoneNumber">The phone number of the recipient</param>
        /// <param name="insuranceAmount">The insurance amount of the consignment</param>
        /// <param name="shouldBeDeliveredOnSaturday">A flag indicating whether the consignment is going to be delivered on Saturday</param>
        /// <param name="consignmentId">The number of the consignment id</param>
        /// <param name="parcelCount">The total number of parcels of the consignment</param>
        /// <param name="zipCode">The zip code for the delivery</param>
        /// <param name="deliveryTime">The delivery time limit</param>
        [SetsRequiredMembers]
        public ConsignmentResponseModel(int customerFlag, string? branchBankCode, string? commentsFirstPart,
            string? commentsSecondPart, string? commentsThirdPart, PaymentType? paymentType, decimal cost, double weight,
            ChargeType chargeType, string? agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) : base(weight, chargeType, agreementCode, customerCode,
            firstCustomerReference, secondCustomerReference, thirdCustomerReference, address, recipientName,
            recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime)
        {
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
        [ExcludeFromCodeCoverage]
        public override string ToString() => ConsignmentId;

        #endregion
    }
}