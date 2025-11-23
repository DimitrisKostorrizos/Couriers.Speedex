using Couriers.Speedex.Enums;
using Couriers.Speedex.InternalModels.RequestModels;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ReschedulePickupInternalRequestModel"/>
    /// </summary>
    public sealed class ReschedulePickupInternalRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReschedulePickupInternalRequestModelUnitTests"/>
        /// </summary>
        public ReschedulePickupInternalRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ReschedulePickupInternalRequestModel.FromRequestModel(ReschedulePickupRequestModel)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => ReschedulePickupInternalRequestModel.FromRequestModel(null!));
        }

        /// <summary>
        /// Validates that when <see cref="ReschedulePickupInternalRequestModel.FromRequestModel(ReschedulePickupRequestModel)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var requestModel = new ReschedulePickupRequestModel(TestHelpers.GenerateTestPickupNumber(), pickupDate)
            {
                Comments = TestHelpers.GenerateRandomString(15),
                DeliveryTime = DeliveryTimeLimit.NoLimit
            };

            var result = ReschedulePickupInternalRequestModel.FromRequestModel(requestModel);

            Assert.NotNull(result);

            Assert.False(result.PickupHourTo.HasValue);

            Assert.False(result.PickupHourFrom.HasValue);

            var updateRequestModel = requestModel with
            {
                DeliveryTime = DeliveryTimeLimit.TenAMToOnePM,
            };

            result = ReschedulePickupInternalRequestModel.FromRequestModel(updateRequestModel);

            Assert.NotNull(result);

            Assert.True(result.PickupHourTo.HasValue);

            Assert.True(result.PickupHourFrom.HasValue);
        }

        #endregion

        #endregion
    }
}