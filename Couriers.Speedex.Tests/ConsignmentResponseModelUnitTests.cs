using Couriers.Speedex.Enums;
using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentResponseModel"/>
    /// </summary>
    public sealed class ConsignmentResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentResponseModelUnitTests"/>
        /// </summary>
        public ConsignmentResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void ConsignmentResponseModel_WithInvalidArguments_ThrowsException()
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var branchBankCode = TestHelpers.GenerateRandomString(4);

            var comments = TestHelpers.GenerateRandomString(20);

            var cost = -1;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new ConsignmentResponseModel(0, branchBankCode, comments, comments, comments, PaymentType.Check, cost, weight,
                ChargeType.Sender, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName, recipientPhoneNumber,
                insuranceAmount, false, voucherId, parcelCount, zipCode, DeliveryTimeLimit.NoLimit));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var consignmentId = TestHelpers.GenerateTestVoucherNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var agreementCode = TestHelpers.GenerateRandomString(6);

            var branchBankCode = TestHelpers.GenerateRandomString(4);

            var chargeType = ChargeType.Recipient;

            var comments = TestHelpers.GenerateRandomString(20);

            var cost = 10;

            var customerCode = TestHelpers.GenerateRandomString(6);

            var customerFlag = 0;

            var deliveryTime = DeliveryTimeLimit.NoLimit;

            var customerReference = TestHelpers.GenerateRandomString(10);

            var insuranceAmount = 0;

            var parcelCount = 1;

            var paymentType = PaymentType.Cash;

            var recipientName = TestHelpers.GenerateRandomString(10);

            var recipientPhoneNumber = TestHelpers.GenerateRandomString(10);

            var shouldBeDeliveredOnSaturday = false;

            var weight = 1;

            var zipCode = TestHelpers.GenerateRandomString(5);

            var result = new ConsignmentResponseModel(customerFlag, branchBankCode, comments, comments, comments, paymentType, cost, weight,
                chargeType, agreementCode, customerCode, customerReference, customerReference, customerReference, address, recipientName, recipientPhoneNumber,
                insuranceAmount, shouldBeDeliveredOnSaturday, consignmentId, parcelCount, zipCode, deliveryTime);

            Assert.NotNull(result);

            Assert.Equal(customerFlag, result.CustomerFlag);

            Assert.Equal(branchBankCode, result.BranchBankCode);

            Assert.Equal(comments, result.CommentsFirstPart);

            Assert.Equal(comments, result.CommentsSecondPart);

            Assert.Equal(comments, result.CommentsThirdPart);

            Assert.Equal(cost, result.Cost);

            Assert.Equal(paymentType, result.PaymentType);
        }

        #endregion

        #endregion
    }
}