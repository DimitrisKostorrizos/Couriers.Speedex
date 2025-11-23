using Couriers.Speedex.Constants;
using Couriers.Speedex.InternalModels.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="PickupInternalResponseModel"/>
    /// </summary>
    public sealed class PickupInternalResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupInternalResponseModelUnitTests"/>
        /// </summary>
        public PickupInternalResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="PickupInternalResponseModel.ToResponseModel()"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToResponseModel_WithValidValues_ReturnsExpectedResult()
        {
            var responseModel = new PickupInternalResponseModel()
            {
                Address = TestHelpers.GenerateRandomString(15),
                Comments = TestHelpers.GenerateRandomString(15),
                CheckpointCode = TestHelpers.GenerateRandomString(7),
                CheckpointGroupCode = TestHelpers.GenerateRandomString(7),
                City = TestHelpers.GenerateRandomString(7),
                ConsignmentIds = [TestHelpers.GenerateTestVoucherNumber()],
                CountryCode = SpeedexConstants.GreeceCountryCode,
                Id = TestHelpers.GenerateTestPickupNumber(),
                Name = TestHelpers.GenerateRandomString(15),
                PhoneNumber = TestHelpers.GenerateRandomString(10),
                PickupDate = DateTime.Now.ToString(SpeedexConstants.SpeedexCultureInfo),
                PickupTimeFrom = new TimeOnly(10, 0, 0).ToString(SpeedexConstants.SpeedexCultureInfo),
                PickupTimeTo = new TimeOnly(13, 0, 0).ToString(SpeedexConstants.SpeedexCultureInfo),
                PostCode = TestHelpers.GenerateRandomString(5)
            };

            var result = responseModel.ToResponseModel();

            Assert.NotNull(result);

            Assert.True(result.PickupTimeFrom.HasValue);

            Assert.True(result.PickupTimeTo.HasValue);

            responseModel.PickupTimeFrom = string.Empty;

            responseModel.PickupTimeTo = string.Empty;

            result = responseModel.ToResponseModel();

            Assert.NotNull(result);

            Assert.False(result.PickupTimeFrom.HasValue);

            Assert.False(result.PickupTimeTo.HasValue);
        }

        #endregion

        #endregion
    }
}