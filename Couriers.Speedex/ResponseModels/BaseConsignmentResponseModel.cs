using Couriers.Speedex.Enums;
using Couriers.Speedex.Structs;

using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// Contains the common properties for a consignment
    /// </summary>
    public record BaseConsignmentResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="Weight"/>
        /// </summary>
        private double weight;

        /// <summary>
        /// The field for the <see cref="CustomerCode"/>
        /// </summary>
        private string _customerCode = default!;

        /// <summary>
        /// The field for the <see cref="Address"/>
        /// </summary>
        private string address = default!;

        /// <summary>
        /// The field for the <see cref="ConsignmentId"/>
        /// </summary>
        private string _consignmentId = default!;

        /// <summary>
        /// The field for the <see cref="ParcelCount"/>
        /// </summary>
        private int parcelCount;

        /// <summary>
        /// The field for the <see cref="ZipCode"/>
        /// </summary>
        private string _zipCode = default!;

        /// <summary>
        /// The field for the <see cref="InsuranceAmount"/>
        /// </summary>
        private decimal _insuranceAmount;

        #endregion

        #region Public Properties

        /// <summary>
        /// The weight of the consignment
        /// </summary>
        public required double Weight
        {
            get => weight;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);

                weight = value;
            }
        }

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        public required ChargeType ChargeType { get; set; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        public required string? AgreementCode { get; set; }

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        public required string CustomerCode
        {
            get => _customerCode;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                _customerCode = value;
            }
        }

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
        /// The address for the delivery
        /// </summary>
        public required string Address
        {
            get => address;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                address = value;
            }
        }

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public required string? RecipientName { get; set; }

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public required string? RecipientPhoneNumber { get; set; }

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        public required decimal InsuranceAmount
        {
            get => _insuranceAmount;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);

                _insuranceAmount = value;
            }
        }

        /// <summary>
        /// A flag indicating whether the consignment is going to be delivered on Saturday
        /// </summary>
        public required bool ShouldBeDeliveredOnSaturday { get; set; }

        /// <summary>
        /// The number of the consignment id
        /// </summary>
        public required string ConsignmentId
        {
            get => _consignmentId;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                _consignmentId = value;
            }
        }

        /// <summary>
        /// The total number of parcels of the consignment
        /// </summary>
        public required int ParcelCount
        {
            get => parcelCount;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);

                parcelCount = value;
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
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                _zipCode = value;
            }
        }

        /// <summary>
        /// The delivery time limit
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        public required DeliveryTimeLimit DeliveryTime { get; set; }

        /// <summary>
        /// The delivery time window
        /// </summary>
        public DeliveryTimeWindow DeliveryTimeWindow { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BaseConsignmentResponseModel"/>
        /// </summary>
        public BaseConsignmentResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="BaseConsignmentResponseModel"/>
        /// </summary>
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
        public BaseConsignmentResponseModel(double weight, ChargeType chargeType, string? agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) : this()
        {
            Weight = weight;
            ChargeType = chargeType;
            AgreementCode = agreementCode;
            CustomerCode = customerCode;
            FirstCustomerReference = firstCustomerReference;
            SecondCustomerReference = secondCustomerReference;
            ThirdCustomerReference = thirdCustomerReference;
            Address = address;
            RecipientName = recipientName;
            RecipientPhoneNumber = recipientPhoneNumber;
            InsuranceAmount = insuranceAmount;
            ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday;
            ConsignmentId = consignmentId;
            ParcelCount = parcelCount;
            ZipCode = zipCode;
            DeliveryTime = deliveryTime;
            DeliveryTimeWindow = SpeedexHelpers.ToDeliveryTimeWindow(deliveryTime);
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