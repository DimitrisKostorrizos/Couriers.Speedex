using Couriers.Speedex.Enums;
using Couriers.Speedex.InternalModels.RequestModels;
using Couriers.Speedex.RequestModels;

using System;
using System.Collections.Generic;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="CreateConsignmentsInternalRequestModel"/>
    /// </summary>
    public sealed class CreateConsignmentsInternalRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CreateConsignmentsInternalRequestModelUnitTests"/>
        /// </summary>
        public CreateConsignmentsInternalRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="CreateConsignmentsInternalRequestModel.FromRequestModel(IEnumerable{ConsignmentRequestModel}, string, string)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void FromRequestModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var agreementCode = TestHelpers.GenerateRandomString(6);

            var customerCode = TestHelpers.GenerateRandomString(6);

            var requestModel = TestConstants.TestConsignment;

            Assert.ThrowsAny<Exception>(() => CreateConsignmentsInternalRequestModel.FromRequestModel(null!, agreementCode, customerCode));

            Assert.ThrowsAny<Exception>(() => CreateConsignmentsInternalRequestModel.FromRequestModel([requestModel], value!, customerCode));

            Assert.ThrowsAny<Exception>(() => CreateConsignmentsInternalRequestModel.FromRequestModel([requestModel], agreementCode, value!));
        }

        /// <summary>
        /// Validates that when <see cref="CreateConsignmentsInternalRequestModel.FromRequestModel(IEnumerable{ConsignmentRequestModel}, string, string)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var agreementCode = TestHelpers.GenerateRandomString(6);

            var customerCode = TestHelpers.GenerateRandomString(6);

            var requestModel = new ConsignmentRequestModel(0, 1, ChargeType.Sender, PaymentType.Cash, 9, TestHelpers.GenerateRandomString(15),
                TestHelpers.GenerateRandomString(20), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 1,
                0 , false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = TestHelpers.GenerateRandomString(15),
                FirstCommentsPart = TestHelpers.GenerateRandomString(7),
                FirstCustomerReference = TestHelpers.GenerateRandomString(7),
                SecondCommentsPart = TestHelpers.GenerateRandomString(7),
                SecondCustomerReference = TestHelpers.GenerateRandomString(7),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(7),
                ThirdCustomerReference = TestHelpers.GenerateRandomString(7)
            };

            var result = CreateConsignmentsInternalRequestModel.FromRequestModel([requestModel], agreementCode, customerCode);

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}