using Couriers.Speedex.Constants;
using Couriers.Speedex.RequestModels;

using Newtonsoft.Json.Linq;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="SpeedexCredentials"/>
    /// </summary>
    public sealed class SpeedexCredentialsUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SpeedexCredentialsUnitTests"/>
        /// </summary>
        public SpeedexCredentialsUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="SpeedexCredentials"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void SpeedexCredentials_WithInvalidArguments_ThrowsException(string? value)
        {
            var username = TestHelpers.GenerateRandomString(4);

            var password = TestHelpers.GenerateRandomString(4);

            var agreementCode = TestHelpers.GenerateRandomString(4);

            var customerCode = TestHelpers.GenerateRandomString(4);

            Assert.ThrowsAny<Exception>(() => new SpeedexCredentials(value!, password, agreementCode, customerCode));

            Assert.ThrowsAny<Exception>(() => new SpeedexCredentials(username, value!, agreementCode, customerCode));

            Assert.ThrowsAny<Exception>(() => new SpeedexCredentials(username, password, value!, customerCode));

            Assert.ThrowsAny<Exception>(() => new SpeedexCredentials(username, password, agreementCode, value!));

            Assert.ThrowsAny<Exception>(() => new SpeedexCredentials(username, password, TestHelpers.GenerateRandomString(SpeedexConstants.MaximumAgreementCodeLength + 1), customerCode));

            Assert.ThrowsAny<Exception>(() => new SpeedexCredentials(username, password, agreementCode, TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerCodeLength + 1)));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexCredentials"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void SpeedexCredentials_WithValidArguments_ReturnsExpectedResult()
        {
            var username = TestHelpers.GenerateRandomString(4);

            var password = TestHelpers.GenerateRandomString(4);

            var agreementCode = TestHelpers.GenerateRandomString(4);

            var customerCode = TestHelpers.GenerateRandomString(4);

            var result = new SpeedexCredentials(username, password, agreementCode, customerCode);

            Assert.NotNull(result);

            var copiedResult = result with
            {

            };

            Assert.NotNull(copiedResult);

            Assert.NotSame(result, copiedResult);
        }

        #endregion

        #endregion
    }
}