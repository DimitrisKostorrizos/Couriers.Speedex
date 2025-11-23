using Couriers.Speedex.InternalModels.ResponseModels;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="SessionIdInternalResponseModel"/>
    /// </summary>
    public sealed class SessionIdInternalResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SessionIdInternalResponseModelUnitTests"/>
        /// </summary>
        public SessionIdInternalResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="SessionIdInternalResponseModel.ToResponseModel()"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToResponseModel_WithValidValues_ReturnsExpectedResult()
        {
            var responseModel = new SessionIdInternalResponseModel()
            {
                SessionId = TestHelpers.GenerateRandomString(15)
            };

            var result = responseModel.ToResponseModel();

            Assert.NotNull(result);

            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        #endregion

        #endregion
    }
}