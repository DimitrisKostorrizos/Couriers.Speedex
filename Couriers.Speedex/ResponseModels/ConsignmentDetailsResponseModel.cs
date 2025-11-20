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
        #region Public Properties

        /// <summary>
        /// The cash amount of the consignment to be collected
        /// </summary>
        public double CashAmount { get; }

        /// <summary>
        /// The check amount of the consignment to be collected
        /// </summary>
        public double CheckAmount { get; }

        /// <summary>
        /// The city for the delivery
        /// </summary>
        public string? City { get; }

        /// <summary>
        /// The country code for the delivery
        /// </summary>
        public string? CountryCode { get; }

        /// <summary>
        /// The comments of the consignment
        /// </summary>
        public string? CustomerComments { get; }

        /// <summary>
        /// The initial time of the delivery time-frame window
        /// </summary>
        public DateTime? DeliveryTimeFrom { get; }

        /// <summary>
        /// The final time of the delivery time-frame window
        /// </summary>
        public DateTime? DeliveryTimeTo { get; }

        /// <summary>
        /// The checkpoint code of the consignment
        /// </summary>
        public string CheckpointCode { get; }

        /// <summary>
        /// The group checkpoint code of the consignment
        /// </summary>
        public string? CheckpointGroupCode { get; }

        /// <summary>
        /// Indicates whether the consignment is a return item
        /// </summary>
        public bool IsReturnItem { get; }

        /// <summary>
        /// The number of the master consignment id
        /// </summary>
        public string MasterConsignmentId { get; }

        /// <summary>
        /// The address for the pickup of the consignment
        /// </summary>
        public string PickupAddress { get; }

        /// <summary>
        /// The city for the pickup of the consignment
        /// </summary>
        public string? PickupCity { get; }

        /// <summary>
        /// The country code for the pickup of the consignment
        /// </summary>
        public string? PickupCountryCode { get; }

        /// <summary>
        /// The name for the pickup of the consignment
        /// </summary>
        public string? PickupName { get; }

        /// <summary>
        /// The phone number for the pickup of the consignment
        /// </summary>
        public string? PickupPhoneNumber { get; }

        /// <summary>
        /// The post code for the pickup of the consignment
        /// </summary>
        public string PickupPostCode { get; }

        #endregion

        #region Constructors

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
        public ConsignmentDetailsResponseModel(double cashAmount, double checkAmount, string? city, string? countryCode,
            string? customerComments, DateTime? deliveryTimeFrom, DateTime? deliveryTimeTo, string checkpointCode,
            string? checkpointGroupCode, bool isReturnItem, string masterConsignmentId, string pickupAddress, string? pickupCity,
            string? pickupCountryCode, string? pickupName, string? pickupPhoneNumber, string pickupPostCode, double weight, ChargeType chargeType, string? agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) :
            base(weight, chargeType, agreementCode, customerCode,
            firstCustomerReference, secondCustomerReference, thirdCustomerReference, address,
            recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday,
            consignmentId, parcelCount, zipCode, deliveryTime)
        {
            if (cashAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(cashAmount), $"The {nameof(cashAmount)} cannot be negative.");

            if (checkAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(checkAmount), $"The {nameof(checkAmount)} cannot be negative.");

            if (string.IsNullOrWhiteSpace(checkpointCode))
                throw new ArgumentException($"'{nameof(checkpointCode)}' cannot be null or whitespace.", nameof(checkpointCode));

            if (string.IsNullOrWhiteSpace(masterConsignmentId))
                throw new ArgumentException($"'{nameof(masterConsignmentId)}' cannot be null or whitespace.", nameof(masterConsignmentId));

            if (string.IsNullOrWhiteSpace(pickupAddress))
                throw new ArgumentException($"'{nameof(pickupAddress)}' cannot be null or whitespace.", nameof(pickupAddress));

            if (string.IsNullOrWhiteSpace(pickupPostCode))
                throw new ArgumentException($"'{nameof(pickupPostCode)}' cannot be null or whitespace.", nameof(pickupPostCode));

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
        [ExcludeFromCodeCoverage]
        public override string ToString() => MasterConsignmentId;

        #endregion
    }
}