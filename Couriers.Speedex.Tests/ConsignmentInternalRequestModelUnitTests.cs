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

            var requestModel = new ConsignmentRequestModel(0, 1, ChargeType.Sender, PaymentType.Cash, 9, TestHelpers.GenerateRandomString(15),
                TestHelpers.GenerateRandomString(20), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 1,
                0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = TestHelpers.GenerateRandomString(15),
                FirstCommentsPart = TestHelpers.GenerateRandomString(7),
                FirstCustomerReference = TestHelpers.GenerateRandomString(7),
                SecondCommentsPart = TestHelpers.GenerateRandomString(7),
                SecondCustomerReference = TestHelpers.GenerateRandomString(7),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(7),
                ThirdCustomerReference = TestHelpers.GenerateRandomString(7)
            };

            var result = ConsignmentInternalRequestModel.FromRequestModel(requestModel, agreementCode, customerCode);

            Assert.NotNull(result);

            Assert.False(string.IsNullOrWhiteSpace(result.PaymentType));

            Assert.Equal(SpeedexConstants.GreeceCountryCode, result.Country);

            var updatedRequest = new ConsignmentRequestModel(0, 1, ChargeType.Sender, null, 0, TestHelpers.GenerateRandomString(15),
                TestHelpers.GenerateRandomString(20), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 1,
                0, true, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = TestHelpers.GenerateRandomString(15),
                FirstCommentsPart = TestHelpers.GenerateRandomString(7),
                FirstCustomerReference = TestHelpers.GenerateRandomString(7),
                SecondCommentsPart = TestHelpers.GenerateRandomString(7),
                SecondCustomerReference = TestHelpers.GenerateRandomString(7),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(7),
                ThirdCustomerReference = TestHelpers.GenerateRandomString(7)
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