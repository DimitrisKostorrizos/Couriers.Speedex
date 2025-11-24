using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentDetailsResponseModel"/>
    /// </summary>
    public sealed class ConsignmentDetailsResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsResponseModelUnitTests"/>
        /// </summary>
        public ConsignmentDetailsResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentDetailsResponseModel"/> constructor is called, 
        /// with invalid amounts, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void ConsignmentDetailsResponseModel_WithInvalidAmounts_ThrowsException()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var cashAmount = 10;

            var checkAmount = 0;

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(10);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerComments = TestHelpers.GenerateRandomString(10);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var deliveryTimeFrom = DateTime.MinValue.AddHours(13);

            var deliveryTimeTo = DateTime.MinValue.AddHours(16);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var isReturnItem = false;

            var masterConsignmentId = TestHelpers.GenerateTestVoucherNumber();

            var parcelCount = 1;

            var pickupAddress = TestHelpers.GenerateRandomString(20);

            var pickupCity = TestHelpers.GenerateRandomString(10);

            var pickupCountryCode = SpeedexConstants.GreeceCountryCode;

            var pickupName = TestHelpers.GenerateRandomString(10);

            var pickupPhoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupPostCode = TestHelpers.GenerateRandomString(5);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel(-1, checkAmount, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                checkpointCode, checkpointGroupCode, isReturnItem, masterConsignmentId, pickupAddress, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                pickupPostCode, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel(cashAmount, -1, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                checkpointCode, checkpointGroupCode, isReturnItem, masterConsignmentId, pickupAddress, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                pickupPostCode, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentDetailsResponseModel"/> constructor is called, 
        /// with an invalid checkpoint code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentDetailsResponseModel_WithInvalidCheckpointCode_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var cashAmount = 10;

            var checkAmount = 0;

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(10);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerComments = TestHelpers.GenerateRandomString(10);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var deliveryTimeFrom = DateTime.MinValue.AddHours(13);

            var deliveryTimeTo = DateTime.MinValue.AddHours(16);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var isReturnItem = false;

            var masterConsignmentId = TestHelpers.GenerateTestVoucherNumber();

            var parcelCount = 1;

            var pickupAddress = TestHelpers.GenerateRandomString(20);

            var pickupCity = TestHelpers.GenerateRandomString(10);

            var pickupCountryCode = SpeedexConstants.GreeceCountryCode;

            var pickupName = TestHelpers.GenerateRandomString(10);

            var pickupPhoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupPostCode = TestHelpers.GenerateRandomString(5);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel(cashAmount, checkAmount, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                value!, checkpointGroupCode, isReturnItem, masterConsignmentId, pickupAddress, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                pickupPostCode, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentDetailsResponseModel"/> constructor is called, 
        /// with an invalid master consignment id, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentDetailsResponseModel_WithInvalidMasterConsignmentId_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var cashAmount = 10;

            var checkAmount = 0;

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(10);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerComments = TestHelpers.GenerateRandomString(10);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var deliveryTimeFrom = DateTime.MinValue.AddHours(13);

            var deliveryTimeTo = DateTime.MinValue.AddHours(16);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var isReturnItem = false;

            var parcelCount = 1;

            var pickupAddress = TestHelpers.GenerateRandomString(20);

            var pickupCity = TestHelpers.GenerateRandomString(10);

            var pickupCountryCode = SpeedexConstants.GreeceCountryCode;

            var pickupName = TestHelpers.GenerateRandomString(10);

            var pickupPhoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupPostCode = TestHelpers.GenerateRandomString(5);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel(cashAmount, checkAmount, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                checkpointCode, checkpointGroupCode, isReturnItem, value!, pickupAddress, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                pickupPostCode, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentDetailsResponseModel"/> constructor is called, 
        /// with an invalid pickup address, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentDetailsResponseModel_WithInvalidPickupAddress_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var cashAmount = 10;

            var checkAmount = 0;

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(10);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerComments = TestHelpers.GenerateRandomString(10);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var deliveryTimeFrom = DateTime.MinValue.AddHours(13);

            var deliveryTimeTo = DateTime.MinValue.AddHours(16);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var isReturnItem = false;

            var masterConsignmentId = TestHelpers.GenerateTestVoucherNumber();

            var parcelCount = 1;

            var pickupCity = TestHelpers.GenerateRandomString(10);

            var pickupCountryCode = SpeedexConstants.GreeceCountryCode;

            var pickupName = TestHelpers.GenerateRandomString(10);

            var pickupPhoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupPostCode = TestHelpers.GenerateRandomString(5);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel(cashAmount, checkAmount, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                checkpointCode, checkpointGroupCode, isReturnItem, masterConsignmentId, value!, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                pickupPostCode, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentDetailsResponseModel"/> constructor is called, 
        /// with an invalid pickup post code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentDetailsResponseModel_WithInvalidPickupPostCode_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var cashAmount = 10;

            var checkAmount = 0;

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(10);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerComments = TestHelpers.GenerateRandomString(10);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var deliveryTimeFrom = DateTime.MinValue.AddHours(13);

            var deliveryTimeTo = DateTime.MinValue.AddHours(16);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var isReturnItem = false;

            var masterConsignmentId = TestHelpers.GenerateTestVoucherNumber();

            var parcelCount = 1;

            var pickupAddress = TestHelpers.GenerateRandomString(20);

            var pickupCity = TestHelpers.GenerateRandomString(10);

            var pickupCountryCode = SpeedexConstants.GreeceCountryCode;

            var pickupName = TestHelpers.GenerateRandomString(10);

            var pickupPhoneNumber = TestHelpers.GenerateRandomString(10);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel(cashAmount, checkAmount, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                checkpointCode, checkpointGroupCode, isReturnItem, masterConsignmentId, pickupAddress, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                value!, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }
        
        /// <summary>
        /// Validates that when <see cref="ConsignmentDetailsResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentDetailsResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var cashAmount = 10;

            var checkAmount = 0;

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(10);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerComments = TestHelpers.GenerateRandomString(10);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var deliveryTimeFrom = DateTime.MinValue.AddHours(13);

            var deliveryTimeTo = DateTime.MinValue.AddHours(16);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var isReturnItem = false;

            var masterConsignmentId = TestHelpers.GenerateTestVoucherNumber();

            var parcelCount = 1;

            var pickupAddress = TestHelpers.GenerateRandomString(20);

            var pickupCity = TestHelpers.GenerateRandomString(10);

            var pickupCountryCode = SpeedexConstants.GreeceCountryCode;

            var pickupName = TestHelpers.GenerateRandomString(10);

            var pickupPhoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupPostCode = TestHelpers.GenerateRandomString(5);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            var result = new ConsignmentDetailsResponseModel(cashAmount, checkAmount, city, countryCode, customerComments, deliveryTimeFrom, deliveryTimeTo,
                checkpointCode, checkpointGroupCode, isReturnItem, masterConsignmentId, pickupAddress, pickupCity, pickupCountryCode, pickupName, pickupPhoneNumber,
                pickupPostCode, weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName,
                recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime);

            Assert.NotNull(result);

            Assert.Equal(cashAmount, result.CashAmount);

            Assert.Equal(checkAmount, result.CheckAmount);

            Assert.Equal(checkpointCode, result.CheckpointCode);

            Assert.Equal(checkpointGroupCode, result.CheckpointGroupCode);

            Assert.Equal(city, result.City);

            Assert.Equal(countryCode, result.CountryCode);

            Assert.Equal(customerComments, result.CustomerComments);

            Assert.Equal(deliveryTimeFrom, result.DeliveryTimeFrom);

            Assert.Equal(deliveryTimeTo, result.DeliveryTimeTo);

            Assert.Equal(isReturnItem, result.IsReturnItem);

            Assert.Equal(masterConsignmentId, result.MasterConsignmentId);

            Assert.Equal(pickupAddress, result.PickupAddress);

            Assert.Equal(pickupCity, result.PickupCity);

            Assert.Equal(pickupCountryCode, result.PickupCountryCode);

            Assert.Equal(pickupName, result.PickupName);

            Assert.Equal(pickupPhoneNumber, result.PickupPhoneNumber);

            Assert.Equal(pickupPostCode, result.PickupPostCode);
        }

        #endregion

        #endregion
    }
}