using Couriers.Speedex.InternalModels.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="CredentialsInternalRequestModel"/>
    /// </summary>
    public sealed class CredentialsInternalRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CredentialsInternalRequestModel"/>
        /// </summary>
        public CredentialsInternalRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="CredentialsInternalRequestModel.FromRequestModel(SpeedexCredentials)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => CredentialsInternalRequestModel.FromRequestModel(null!));
        }

        /// <summary>
        /// Validates that when <see cref="CredentialsInternalRequestModel.FromRequestModel(SpeedexCredentials)"/> method is called, 
        /// with valid arguments, the result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var requestModel = TestConstants.SpeedexCredentials;

            var result = CredentialsInternalRequestModel.FromRequestModel(requestModel);

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}