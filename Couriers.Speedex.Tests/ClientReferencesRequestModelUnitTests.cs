using Couriers.Speedex.Constants;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ClientReferencesRequestModel"/>
    /// </summary>
    public sealed class ClientReferencesRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ClientReferencesRequestModelUnitTests"/>
        /// </summary>
        public ClientReferencesRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ClientReferencesRequestModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ClientReferencesRequestModel_WithInvalidArguments_ThrowsException()
        {
            var reference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ClientReferencesRequestModel()
            {
                FirstClientReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                SecondClientReference = reference,
                ThirdClientReference = reference
            });

            Assert.ThrowsAny<Exception>(() => new ClientReferencesRequestModel()
            {
                FirstClientReference = reference,
                SecondClientReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                ThirdClientReference = reference
            });

            Assert.ThrowsAny<Exception>(() => new ClientReferencesRequestModel()
            {
                FirstClientReference = reference,
                SecondClientReference = reference,
                ThirdClientReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ClientReferencesRequestModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ClientReferencesRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var reference = TestHelpers.GenerateRandomString(10);

            var result = new ClientReferencesRequestModel()
            {
                FirstClientReference = reference,
                SecondClientReference = reference,
                ThirdClientReference = reference
            };

            Assert.NotNull(result);

            var copiedResult = result with
            {
                FirstClientReference = reference,
                SecondClientReference = reference,
                ThirdClientReference = reference
            };

            Assert.NotNull(copiedResult);

            Assert.NotSame(result, copiedResult);
        }

        #endregion

        #endregion
    }
}