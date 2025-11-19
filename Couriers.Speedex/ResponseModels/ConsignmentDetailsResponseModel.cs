using Couriers.Speedex.Enums;

using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment details
    /// </summary>
    public record ConsignmentDetailsResponseModel : BaseConsignmentResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="CashAmount"/>
        /// </summary>
        private double _cashAmount;

        /// <summary>
        /// The field for the <see cref="CheckAmount"/>
        /// </summary>
        private double _checkAmount;

        /// <summary>
        /// The field for the <see cref="CheckpointCode"/>
        /// </summary>
        private string _checkpointCode = default!;

        /// <summary>
        /// The field for the <see cref="MasterConsignmentId"/>
        /// </summary>
        private string _masterConsignmentId = default!;

        /// <summary>
        /// The field for the <see cref="PickupAddress"/>
        /// </summary>
        private string _pickupAddress = default!;

        /// <summary>
        /// The field for the <see cref="PickupPostCode"/>
        /// </summary>
        private string _pickupPostCode = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The cash amount of the consignment to be collected
        /// </summary>
        public required double CashAmount
        {
            get => _cashAmount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(CashAmount), $"The {nameof(CashAmount)} cannot be negative.");

                _cashAmount = value;
            }
        }

        /// <summary>
        /// The check amount of the consignment to be collected
        /// </summary>
        public required double CheckAmount
        {
            get => _checkAmount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(CheckAmount), $"The {nameof(CheckAmount)} cannot be negative.");

                _checkAmount = value;
            }
        }

        /// <summary>
        /// The city for the delivery
        /// </summary>
        public required string? City { get; set; }

        /// <summary>
        /// The country code for the delivery
        /// </summary>
        public required string? CountryCode { get; set; }

        /// <summary>
        /// The comments of the consignment
        /// </summary>
        public required string? CustomerComments { get; set; }

        /// <summary>
        /// The initial time of the delivery time-frame window
        /// </summary>
        public required TimeOnly? DeliveryTimeFrom { get; set; }

        /// <summary>
        /// The final time of the delivery time-frame window
        /// </summary>
        public required TimeOnly? DeliveryTimeTo { get; set; }

        /// <summary>
        /// The checkpoint code of the consignment
        /// </summary>
        public required string CheckpointCode
        {
            get => _checkpointCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(CheckpointCode)}' cannot be null or whitespace.", nameof(CheckpointCode));

                _checkpointCode = value;
            }
        }

        /// <summary>
        /// The group checkpoint code of the consignment
        /// </summary>
        public required string? CheckpointGroupCode { get; set; }

        /// <summary>
        /// Indicates whether the consignment is a return item
        /// </summary>
        public required bool IsReturnItem { get; set; }

        /// <summary>
        /// The number of the master consignment id
        /// </summary>
        public required string MasterConsignmentId
        {
            get => _masterConsignmentId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(MasterConsignmentId)}' cannot be null or whitespace.", nameof(MasterConsignmentId));

                _masterConsignmentId = value;
            }
        }

        /// <summary>
        /// The address for the pickup of the consignment
        /// </summary>
        public required string PickupAddress
        {
            get => _pickupAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(PickupAddress)}' cannot be null or whitespace.", nameof(PickupAddress));

                _pickupAddress = value;
            }
        }

        /// <summary>
        /// The city for the pickup of the consignment
        /// </summary>
        public required string? PickupCity { get; set; }

        /// <summary>
        /// The country code for the pickup of the consignment
        /// </summary>
        public required string? PickupCountryCode { get; set; }

        /// <summary>
        /// The name for the pickup of the consignment
        /// </summary>
        public required string? PickupName { get; set; }

        /// <summary>
        /// The phone number for the pickup of the consignment
        /// </summary>
        public required string? PickupPhoneNumber { get; set; }

        /// <summary>
        /// The post code for the pickup of the consignment
        /// </summary>
        public required string PickupPostCode
        {
            get => _pickupPostCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(PickupPostCode)}' cannot be null or whitespace.", nameof(PickupPostCode));

                _pickupPostCode = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsResponseModel"/>
        /// </summary>
        public ConsignmentDetailsResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsResponseModel"/>
        /// </summary>
        /// <param name="cashAmount">The cash amount of the consignment to be collected</param>
        /// <param name="checkAmount">The check amount of the consignment to be collected</param>
        /// <param name="city">The city for the delivery</param>
        /// <param name="countryCode">The country code for the delivery</param>
        /// <param name="customerComments">The comments of the consignment</param>
        /// <param name="deliveryTimeFrom">The initial time of the delivery time-frame window</param>
        /// <param name="deliveryTimeTo">The final time of the delivery time-frame window</param>
        /// <param name="checkpointCode">The group checkpoint code of the consignment</param>
        /// <param name="checkpointGroupCode">The group checkpoint code of the consignment</param>
        /// <param name="isReturnItem">Indicates whether the consignment is a return item</param>
        /// <param name="masterConsignmentId">The number of the master consignment id</param>
        /// <param name="pickupAddress">The address for the pickup of the consignment</param>
        /// <param name="pickupCity">The city for the pickup of the consignment</param>
        /// <param name="pickupCountryCode">The country code for the pickup of the consignment</param>
        /// <param name="pickupName">The phone number for the pickup of the consignment</param>
        /// <param name="pickupPhoneNumber"></param>
        /// <param name="pickupPostCode">The post code for the pickup of the consignment</param>
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
        public ConsignmentDetailsResponseModel(double cashAmount, double checkAmount, string city, string countryCode,
            string customerComments, TimeOnly? deliveryTimeFrom, TimeOnly? deliveryTimeTo, string checkpointCode,
            string checkpointGroupCode, bool isReturnItem, string masterConsignmentId, string pickupAddress, string pickupCity,
            string pickupCountryCode, string pickupName, string pickupPhoneNumber, string pickupPostCode, double weight, ChargeType chargeType, string agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) :
            base(weight, chargeType, agreementCode, customerCode,
            firstCustomerReference, secondCustomerReference, thirdCustomerReference, address,
            recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday,
            consignmentId, parcelCount, zipCode, deliveryTime)
        {
            CashAmount = cashAmount;
            CheckAmount = checkAmount;
            City = city;
            CountryCode = countryCode;
            CustomerComments = customerComments;
            DeliveryTimeFrom = deliveryTimeFrom;
            DeliveryTimeTo = deliveryTimeTo;
            CheckpointCode = checkpointCode;
            CheckpointGroupCode = checkpointGroupCode;
            IsReturnItem = isReturnItem;
            MasterConsignmentId = masterConsignmentId;
            PickupAddress = pickupAddress;
            PickupCity = pickupCity;
            PickupCountryCode = pickupCountryCode;
            PickupName = pickupName;
            PickupPhoneNumber = pickupPhoneNumber;
            PickupPostCode = pickupPostCode;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MasterConsignmentId;

        #endregion
    }
}