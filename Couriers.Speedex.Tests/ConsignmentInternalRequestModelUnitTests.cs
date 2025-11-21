using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.InternalModels.RequestModels;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentInternalRequestModel"/>
    /// </summary>
    public sealed class ConsignmentInternalRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentInternalRequestModel"/>
        /// </summary>
        public ConsignmentInternalRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentInternalRequestModel.FromRequestModel(ConsignmentRequestModel, string, string)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void FromRequestModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var agreementCode = TestHelpers.GenerateRandomString(6);

            var customerCode = TestHelpers.GenerateRandomString(6);

            var requestModel = TestConstants.TestConsignment;

            Assert.ThrowsAny<Exception>(() => ConsignmentInternalRequestModel.FromRequestModel(null!, agreementCode, customerCode));

            Assert.ThrowsAny<Exception>(() => ConsignmentInternalRequestModel.FromRequestModel(requestModel, value!, customerCode));

            Assert.ThrowsAny<Exception>(() => ConsignmentInternalRequestModel.FromRequestModel(requestModel, agreementCode, value!));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentInternalRequestModel.FromRequestModel(ConsignmentRequestModel, string, string)"/> method is called, 
        /// with valid arguments, the result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var agreementCode = TestHelpers.GenerateRandomString(6);

            var customerCode = TestHelpers.GenerateRandomString(6);

            var requestModel = new ConsignmentRequestModel()
            {
                Address = TestHelpers.GenerateRandomString(15),
                BranchBankCode = TestHelpers.GenerateRandomString(15),
                ChargeType = ChargeType.Sender,
                CustomerFlag = 0,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                PaymentType = PaymentType.Cash,
                Cost = 9,
                FirstCommentsPart = TestHelpers.GenerateRandomString(7),
                FirstCustomerReference = TestHelpers.GenerateRandomString(7),
                InsuranceAmount = 0,
                NumberOfVouchers = 1,
                RecipientName = TestHelpers.GenerateRandomString(20),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(7),
                SecondCustomerReference = TestHelpers.GenerateRandomString(7),
                ShouldBeDeliveredOnSaturday = false,
                ThirdCommentsPart = TestHelpers.GenerateRandomString(7),
                ThirdCustomerReference = TestHelpers.GenerateRandomString(7),
                Weight = 1,
                ZipCode = TestHelpers.GenerateRandomString(5)
            };

            var result = ConsignmentInternalRequestModel.FromRequestModel(requestModel, agreementCode, customerCode);

            Assert.NotNull(result);

            Assert.False(string.IsNullOrWhiteSpace(result.PaymentType));

            Assert.Equal(SpeedexConstants.GreeceCountryCode, result.Country);

            var updatedRequest = requestModel with
            {
                Cost = 0,
                PaymentType = null,
                ShouldBeDeliveredOnSaturday = true
            };

            result = ConsignmentInternalRequestModel.FromRequestModel(updatedRequest, agreementCode, customerCode);

            Assert.NotNull(result);

            Assert.True(string.IsNullOrWhiteSpace(result.PaymentType));

            Assert.Equal(SpeedexConstants.GreeceCountryCode, result.Country);
        }

        #endregion

        #endregion
    }
}