using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;

using System;

namespace Couriers.Speedex.RequestModels
{
    /// <summary>
    /// The request model for the consignment
    /// </summary>
    public sealed record ConsignmentRequestModel
    {
        #region Private Members

        /// <summary>
        /// The field of the <see cref="FirstCommentsPart"/>
        /// </summary>
        private string? _firstCommentsPart;

        /// <summary>
        /// The field of the <see cref="SecondCommentsPart"/>
        /// </summary>
        private string? _secondCommentsPart;

        /// <summary>
        /// The field of the <see cref="ThirdCommentsPart"/>
        /// </summary>
        private string? _thirdCommentsPart;

        /// <summary>
        /// The field of the <see cref="FirstCustomerReference"/>
        /// </summary>
        private string? _firstCustomerReference;

        /// <summary>
        /// The field of the <see cref="SecondCustomerReference"/>
        /// </summary>
        private string? _secondCustomerReference;

        /// <summary>
        /// The field of the <see cref="ThirdCustomerReference"/>
        /// </summary>
        private string? _thirdCustomerReference;

        #endregion

        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// The value 0 indicates that the default data from the customer agreement will be used as the sender’s data. 
        /// The value 100 indicates that the related fields will be used as the sender’s data.
        /// </summary>
        public int CustomerFlag { get; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public string? BranchBankCode { get; set; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public string? FirstCustomerReference
        {
            get => _firstCustomerReference;
            init
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);

                _firstCustomerReference = value;
            }
        }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public string? SecondCustomerReference
        {
            get => _secondCustomerReference;
            set
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);

                _secondCustomerReference = value;
            }
        }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public string? ThirdCustomerReference
        {
            get => _thirdCustomerReference;
            set
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);

                _thirdCustomerReference = value;
            }
        }

        /// <summary>
        /// The number of vouchers
        /// </summary>
        public int NumberOfVouchers { get; }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        public string? FirstCommentsPart
        {
            get => _firstCommentsPart;
            init
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                _firstCommentsPart = value;
            }
        }

        /// <summary>
        /// The second part of the comments
        /// </summary>
        public string? SecondCommentsPart
        {
            get => _secondCommentsPart;
            init
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                _secondCommentsPart = value;
            }
        }

        /// <summary>
        /// The third part of the comments
        /// </summary>
        public string? ThirdCommentsPart
        {
            get => _thirdCommentsPart;
            init
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                _thirdCommentsPart = value;
            }
        }

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        public ChargeType ChargeType { get; }

        /// <summary>
        /// The payment type
        /// </summary>
        public PaymentType? PaymentType { get; }

        /// <summary>
        /// The cost
        /// </summary>
        public double Cost { get; }

        /// <summary>
        /// The address for the delivery
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public string RecipientName { get; }

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public string RecipientPhoneNumber { get; }

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        public string ZipCode { get; }

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        public int InsuranceAmount { get; }

        /// <summary>
        /// The flag indicating whether the consignment is going to be delivered on Saturday
        /// NOTE: Cannot be combined with the field <see cref="DeliveryTime"/>.
        /// </summary>
        public bool ShouldBeDeliveredOnSaturday { get; }

        /// <summary>
        /// The delivery time window
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; }

        /// <summary>
        /// The weight of the consignment
        /// NOTE: The minimum value is 0.5 per item. 
        /// It is possible to change after the weighting from Speedex
        /// </summary>
        public double Weight { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentRequestModel"/>
        /// </summary>
        /// <param name="customerFlag">The customer flag</param>
        /// <param name="numberOfVouchers">The number of vouchers</param>
        /// <param name="chargeType">The charge type of the consignment</param>
        /// <param name="paymentType">The payment type</param>
        /// <param name="cost">The cost</param>
        /// <param name="address">The address for the delivery</param>
        /// <param name="recipientName">The name of the recipient</param>
        /// <param name="recipientPhoneNumber">The phone number of the recipient</param>
        /// <param name="zipCode">The zip code for the delivery</param>
        /// <param name="insuranceAmount">The insurance amount of the consignment</param>
        /// <param name="weight">The weight of the consignment</param>
        /// <param name="shouldBeDeliveredOnSaturday">The flag indicating whether the consignment is going to be delivered on Saturday</param>
        /// <param name="deliveryTime">The delivery time window</param>
        public ConsignmentRequestModel(int customerFlag, int numberOfVouchers, ChargeType chargeType, PaymentType? paymentType,
            double cost, string address, string recipientName, string recipientPhoneNumber, string zipCode, double weight,
            int insuranceAmount = 0, bool shouldBeDeliveredOnSaturday = false, DeliveryTimeLimit deliveryTime = DeliveryTimeLimit.NoLimit) : base()
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfVouchers);

            ArgumentOutOfRangeException.ThrowIfNegative(cost);

            ArgumentOutOfRangeException.ThrowIfNegative(insuranceAmount);

            ArgumentException.ThrowIfNullOrWhiteSpace(address);

            ArgumentException.ThrowIfNullOrWhiteSpace(recipientName);

            ArgumentException.ThrowIfNullOrWhiteSpace(zipCode);

            ArgumentException.ThrowIfNullOrWhiteSpace(recipientPhoneNumber);

            ArgumentOutOfRangeException.ThrowIfGreaterThan(numberOfVouchers, SpeedexConstants.MaximumNumberOfVouchers);
#else
            if (numberOfVouchers <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfVouchers), $"The {nameof(numberOfVouchers)} cannot be negative or zero.");

            if (cost < 0)
                throw new ArgumentOutOfRangeException(nameof(cost), $"The {nameof(cost)} cannot be negative.");

            if (insuranceAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(insuranceAmount), $"The {nameof(insuranceAmount)} cannot be negative.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));

            if (string.IsNullOrWhiteSpace(recipientName))
                throw new ArgumentException($"'{nameof(recipientName)}' cannot be null or whitespace.", nameof(recipientName));

            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException($"'{nameof(zipCode)}' cannot be null or whitespace.", nameof(zipCode));

            if (string.IsNullOrWhiteSpace(recipientPhoneNumber))
                throw new ArgumentException($"'{nameof(recipientPhoneNumber)}' cannot be null or whitespace.", nameof(recipientPhoneNumber));

            if (numberOfVouchers > SpeedexConstants.MaximumNumberOfVouchers)
                throw new ArgumentOutOfRangeException(nameof(numberOfVouchers), $"The {nameof(numberOfVouchers)} cannot be greater than {SpeedexConstants.MaximumNumberOfVouchers}.");
#endif

            if (cost > 0 && !paymentType.HasValue)
                throw new InvalidOperationException($"The '{nameof(paymentType)}' is required when the '{nameof(cost)}' is greater then 0.");

            if (address.Length > SpeedexConstants.MaximumAddressLength)
                throw new InvalidOperationException($"The '{nameof(address)}' is not a valid address. The maximum length for an address field is {SpeedexConstants.MaximumAddressLength}.");

            if (recipientPhoneNumber.Length > SpeedexConstants.MaximumPhoneNumberLength)
                throw new InvalidOperationException($"The '{nameof(recipientPhoneNumber)}' is not a valid phone number. The maximum length for a phone number field is {SpeedexConstants.MaximumPhoneNumberLength}.");

            SpeedexHelpers.ThrowIfInvalidZipCode(zipCode);

            var minimumWeight = NumberOfVouchers * SpeedexConstants.MinimumWeightPerVoucher;

            if (weight < minimumWeight)
                throw new InvalidOperationException($"The '{nameof(weight)}' is invalid. The minimum weight for a voucher is {SpeedexConstants.MinimumWeightPerVoucher} kilos.");

            if (shouldBeDeliveredOnSaturday && deliveryTime != DeliveryTimeLimit.NoLimit)
                throw new InvalidOperationException("A Saturday delivery cannot be combined with a delivery time limit.");

            CustomerFlag = customerFlag;

            NumberOfVouchers = numberOfVouchers;

            ChargeType = chargeType;

            PaymentType = paymentType;

            Cost = cost;

            Address = address;

            RecipientName = recipientName;

            RecipientPhoneNumber = recipientPhoneNumber;

            ZipCode = zipCode;

            InsuranceAmount = insuranceAmount;

            Weight = weight;

            ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday;

            DeliveryTime = deliveryTime;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Address: {Address}, Zip Code: {ZipCode}";

        #endregion
    }
}