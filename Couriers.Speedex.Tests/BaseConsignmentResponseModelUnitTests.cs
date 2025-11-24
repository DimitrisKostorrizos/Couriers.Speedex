using Couriers.Speedex.Enums;
using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="BaseConsignmentResponseModel"/>
    /// </summary>
    public sealed class BaseConsignmentResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BaseConsignmentResponseModel"/>
        /// </summary>
        public BaseConsignmentResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid weight, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void BaseConsignmentResponseModel_WithInvalidWeight_ThrowsException()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(-1, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid customer code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void BaseConsignmentResponseModel_WithInvalidCustomerCode_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, value!, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid address, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void BaseConsignmentResponseModel_WithInvalidAddress_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                value!, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid insurance amount, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void BaseConsignmentResponseModel_WithInvalidInsuranceAmount_ThrowsException()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, -1, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid consignment id, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void BaseConsignmentResponseModel_WithInvalidConsignmentId_ThrowsException(string? value)
        {
            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, value!, parcelCount, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid parcel count, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void BaseConsignmentResponseModel_WithInvalidParcelCount_ThrowsException()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, -1, zipCode, deliveryTime));

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, 0, zipCode, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with an invalid zip code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void BaseConsignmentResponseModel_WithInvalidZipCode_ThrowsException(string? value)
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            Assert.ThrowsAny<Exception>(() => new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, value!, deliveryTime));
        }

        /// <summary>
        /// Validates that when <see cref="BaseConsignmentResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void BaseConsignmentResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var chargeType = ChargeType.Recipient;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            var result = new BaseConsignmentResponseModel(weight, chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference,
                address, recipientName, recipientPhoneNumber, insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime);

            Assert.NotNull(result);

            Assert.Equal(address, result.Address);

            Assert.Equal(agreementCode, result.AgreementCode);

            Assert.Equal(chargeType, result.ChargeType);

            Assert.Equal(consignmentId, result.ConsignmentId);

            Assert.Equal(customerCode, result.CustomerCode);

            Assert.Equal(deliveryTime, result.DeliveryTime);

            Assert.Equal(customerReference, result.FirstCustomerReference);

            Assert.Equal(customerReference, result.SecondCustomerReference);

            Assert.Equal(customerReference, result.ThirdCustomerReference);

            Assert.Equal(insuranceAmount, result.InsuranceAmount);

            Assert.Equal(parcelCount, result.ParcelCount);

            Assert.Equal(recipientName, result.RecipientName);

            Assert.Equal(recipientPhoneNumber, result.RecipientPhoneNumber);

            Assert.Equal(shouldBeDeliveredOnSaturday, result.ShouldBeDeliveredOnSaturday);

            Assert.Equal(weight, result.Weight);

            Assert.Equal(zipCode, result.ZipCode);
        }

        #endregion

        #endregion
    }
}