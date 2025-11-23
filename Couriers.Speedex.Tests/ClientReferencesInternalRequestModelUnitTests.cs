using Couriers.Speedex.InternalModels.RequestModels;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ClientReferencesInternalRequestModel"/>
    /// </summary>
    public sealed class ClientReferencesInternalRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ClientReferencesInternalRequestModelUnitTests"/>
        /// </summary>
        public ClientReferencesInternalRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ClientReferencesInternalRequestModel.FromRequestModel(ClientReferencesRequestModel)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => ClientReferencesInternalRequestModel.FromRequestModel(null!));
        }

        /// <summary>
        /// Validates that when <see cref="ClientReferencesInternalRequestModel.FromRequestModel(ClientReferencesRequestModel)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var requestModel = new ClientReferencesRequestModel()
            {
                FirstClientReference = TestHelpers.GenerateRandomString(10),
                SecondClientReference = TestHelpers.GenerateRandomString(10),
                ThirdClientReference = TestHelpers.GenerateRandomString(10)
            };

            var result = ClientReferencesInternalRequestModel.FromRequestModel(requestModel);

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}