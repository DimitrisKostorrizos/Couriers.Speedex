using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;

using System;
using System.Diagnostics.CodeAnalysis;

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

        /// <summary>
        /// The field of the <see cref="NumberOfVouchers"/>
        /// </summary>
        private int _numberOfVouchers;

        /// <summary>
        /// The field of the <see cref="PaymentType"/>
        /// </summary>
        private PaymentType? _paymentType;

        /// <summary>
        /// The field of the <see cref="Cost"/>
        /// </summary>
        private double _cost;

        /// <summary>
        /// The field of the <see cref="Address"/>
        /// </summary>
        private string _address = default!;

        /// <summary>
        /// The field of the <see cref="RecipientName"/>
        /// </summary>
        private string _recipientName = default!;

        /// <summary>
        /// The field of the <see cref="RecipientPhoneNumber"/>
        /// </summary>
        private string _recipientPhoneNumber = default!;

        /// <summary>
        /// The field of the <see cref="ZipCode"/>
        /// </summary>
        private string _zipCode = default!;

        /// <summary>
        /// The field of the <see cref="InsuranceAmount"/>
        /// </summary>
        private int _insuranceAmount;

        /// <summary>
        /// The field of the <see cref="ShouldBeDeliveredOnSaturday"/>
        /// </summary>
        private bool _shouldBeDeliveredOnSaturday;

        /// <summary>
        /// The field of the <see cref="DeliveryTime"/>
        /// </summary>
        private DeliveryTimeLimit _deliveryTime;
        private double _weight;

        #endregion

        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// The value 0 indicates that the default data from the customer agreement will be used as the sender’s data. 
        /// The value 100 indicates that the related fields will be used as the sender’s data.
        /// </summary>
        public required int CustomerFlag { get; set; }

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
            set
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
        public required int NumberOfVouchers
        {
            get => _numberOfVouchers;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(NumberOfVouchers), $"The {nameof(NumberOfVouchers)} cannot be negative or zero.");

                if (value > SpeedexConstants.MaximumNumberOfVouchers)
                    throw new ArgumentOutOfRangeException(nameof(NumberOfVouchers), $"The {nameof(NumberOfVouchers)} cannot be greater than {SpeedexConstants.MaximumNumberOfVouchers}.");

                _numberOfVouchers = value;
            }
        }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        public string? FirstCommentsPart
        {
            get => _firstCommentsPart;
            set
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
            set
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
            set
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                _thirdCommentsPart = value;
            }
        }

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        public required ChargeType ChargeType { get; set; }

        /// <summary>
        /// The payment type
        /// </summary>
        public PaymentType? PaymentType
        {
            get => _paymentType;
            set
            {
                if (Cost > 0 && !value.HasValue)
                    throw new InvalidOperationException($"The '{nameof(PaymentType)}' is required when the '{nameof(Cost)}' is greater then 0.");

                _paymentType = value;
            }
        }

        /// <summary>
        /// The cost
        /// </summary>
        public double Cost
        {
            get => _cost;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Cost), $"The {nameof(Cost)} cannot be negative.");

                if (value > 0 && !PaymentType.HasValue)
                    throw new InvalidOperationException($"The '{nameof(PaymentType)}' is required when the '{nameof(Cost)}' is greater then 0.");

                _cost = value;
            }
        }

        /// <summary>
        /// The address for the delivery
        /// </summary>
        public required string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(Address)}' cannot be null or whitespace.", nameof(Address));

                if (value.Length > SpeedexConstants.MaximumAddressLength)
                    throw new InvalidOperationException($"The '{nameof(Address)}' is not a valid address. The maximum length for an address field is {SpeedexConstants.MaximumAddressLength}.");

                _address = value;
            }
        }

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public required string RecipientName
        {
            get => _recipientName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(RecipientName)}' cannot be null or whitespace.", nameof(RecipientName));

                _recipientName = value;
            }
        }

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public required string RecipientPhoneNumber
        {
            get => _recipientPhoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(RecipientPhoneNumber)}' cannot be null or whitespace.", nameof(RecipientPhoneNumber));

                if (value.Length > SpeedexConstants.MaximumPhoneNumberLength)
                    throw new InvalidOperationException($"The '{nameof(RecipientPhoneNumber)}' is not a valid phone number. The maximum length for a phone number field is {SpeedexConstants.MaximumPhoneNumberLength}.");

                _recipientPhoneNumber = value;
            }
        }

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        public required string ZipCode
        {
            get => _zipCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(ZipCode)}' cannot be null or whitespace.", nameof(ZipCode));

                SpeedexHelpers.ThrowIfInvalidZipCode(value);

                _zipCode = value;
            }
        }

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        public required int InsuranceAmount
        {
            get => _insuranceAmount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(InsuranceAmount), $"The {nameof(InsuranceAmount)} cannot be negative.");

                _insuranceAmount = value;
            }
        }

        /// <summary>
        /// The flag indicating whether the consignment is going to be delivered on Saturday
        /// NOTE: Cannot be combined with the field <see cref="DeliveryTime"/>.
        /// </summary>
        public required bool ShouldBeDeliveredOnSaturday
        {
            get => _shouldBeDeliveredOnSaturday;
            set
            {
                if (value && DeliveryTime != DeliveryTimeLimit.NoLimit)
                    throw new InvalidOperationException("A Saturday delivery cannot be combined with a delivery time limit.");

                _shouldBeDeliveredOnSaturday = value;
            }
        }

        /// <summary>
        /// The delivery time window
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        public required DeliveryTimeLimit DeliveryTime
        {
            get => _deliveryTime;
            set
            {
                if (ShouldBeDeliveredOnSaturday && value != DeliveryTimeLimit.NoLimit)
                    throw new InvalidOperationException("A Saturday delivery cannot be combined with a delivery time limit.");

                _deliveryTime = value;
            }
        }

        /// <summary>
        /// The weight of the consignment
        /// NOTE: The minimum value is 0.5 per item. 
        /// It is possible to change after the weighting from Speedex
        /// </summary>
        public required double Weight
        {
            get => _weight;
            set
            {
                var minimumWeight = NumberOfVouchers * SpeedexConstants.MinimumWeightPerVoucher;

                if (value < minimumWeight)
                    throw new InvalidOperationException($"The '{nameof(Weight)}' is invalid. The minimum weight for a voucher is {SpeedexConstants.MinimumWeightPerVoucher} kilos.");

                _weight = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentRequestModel"/>
        /// </summary>
        public ConsignmentRequestModel() : base()
        {

        }

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
        [SetsRequiredMembers]
        public ConsignmentRequestModel(int customerFlag, int numberOfVouchers, ChargeType chargeType, PaymentType? paymentType,
            double cost, string address, string recipientName, string recipientPhoneNumber, string zipCode, double weight,
            int insuranceAmount = 0, bool shouldBeDeliveredOnSaturday = false, DeliveryTimeLimit deliveryTime = DeliveryTimeLimit.NoLimit) : this()
        {
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
        [ExcludeFromCodeCoverage]
        public override string ToString() 
            => $"Address: {Address}, Zip Code: {ZipCode}";

        #endregion
    }
}