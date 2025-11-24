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

            var deliveryTimeFrom = new TimeOnly(13, 0);

            var deliveryTimeTo = new TimeOnly(16, 0);

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

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = -1,
                ChargeType = chargeType,
                CheckAmount = checkAmount,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = masterConsignmentId,
                ParcelCount = parcelCount,
                PickupAddress = pickupAddress,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = pickupPostCode,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = cashAmount,
                ChargeType = chargeType,
                CheckAmount = -1,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = masterConsignmentId,
                ParcelCount = parcelCount,
                PickupAddress = pickupAddress,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = pickupPostCode,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            });
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

            var deliveryTimeFrom = new TimeOnly(13, 0);

            var deliveryTimeTo = new TimeOnly(16, 0);

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

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = cashAmount,
                ChargeType = chargeType,
                CheckAmount = checkAmount,
                CheckpointCode = value!,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = masterConsignmentId,
                ParcelCount = parcelCount,
                PickupAddress = pickupAddress,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = pickupPostCode,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            });
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

            var deliveryTimeFrom = new TimeOnly(13, 0);

            var deliveryTimeTo = new TimeOnly(16, 0);

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

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = cashAmount,
                ChargeType = chargeType,
                CheckAmount = checkAmount,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = value!,
                ParcelCount = parcelCount,
                PickupAddress = pickupAddress,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = pickupPostCode,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            });
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

            var deliveryTimeFrom = new TimeOnly(13, 0);

            var deliveryTimeTo = new TimeOnly(16, 0);

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

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = cashAmount,
                ChargeType = chargeType,
                CheckAmount = checkAmount,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = masterConsignmentId,
                ParcelCount = parcelCount,
                PickupAddress = value!,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = pickupPostCode,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            });
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

            var deliveryTimeFrom = new TimeOnly(13, 0);

            var deliveryTimeTo = new TimeOnly(16, 0);

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

            Assert.ThrowsAny<Exception>(() => new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = cashAmount,
                ChargeType = chargeType,
                CheckAmount = checkAmount,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = masterConsignmentId,
                ParcelCount = parcelCount,
                PickupAddress = pickupAddress,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = value!,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            });
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

            var deliveryTimeFrom = new TimeOnly(13, 0);

            var deliveryTimeTo = new TimeOnly(16, 0);

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

            var result = new ConsignmentDetailsResponseModel()
            {
                Address = address,
                AgreementCode = agreementCode,
                CashAmount = cashAmount,
                ChargeType = chargeType,
                CheckAmount = checkAmount,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                ConsignmentId = consignmentId,
                CountryCode = countryCode,
                CustomerCode = customerCode,
                CustomerComments = customerComments,
                DeliveryTime = deliveryTime,
                DeliveryTimeFrom = deliveryTimeFrom,
                DeliveryTimeTo = deliveryTimeTo,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                InsuranceAmount = insuranceAmount,
                IsReturnItem = isReturnItem,
                MasterConsignmentId = masterConsignmentId,
                ParcelCount = parcelCount,
                PickupAddress = pickupAddress,
                PickupCity = pickupCity,
                PickupCountryCode = pickupCountryCode,
                PickupName = pickupName,
                PickupPhoneNumber = pickupPhoneNumber,
                PickupPostCode = pickupPostCode,
                RecipientName = recipientName,
                RecipientPhoneNumber = recipientPhoneNumber,
                ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday,
                Weight = weight,
                ZipCode = zipCode
            };

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