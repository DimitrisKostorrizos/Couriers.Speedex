using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ReschedulePickupRequestModel"/>
    /// </summary>
    public sealed class ReschedulePickupRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReschedulePickupRequestModelUnitTests"/>
        /// </summary>
        public ReschedulePickupRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ReschedulePickupRequestModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ReschedulePickupRequestModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var pickupDate = DateTime.Now;

            var comments = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ReschedulePickupRequestModel(value!, pickupDate)
            {
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Comments = comments
            });

            Assert.ThrowsAny<Exception>(() => new ReschedulePickupRequestModel(pickupId, pickupDate)
            {
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Comments = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ReschedulePickupRequestModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ReschedulePickupRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var pickupDate = DateTime.Now;

            var comments = TestHelpers.GenerateRandomString(10);

            var result = new ReschedulePickupRequestModel(pickupId, pickupDate)
            {
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Comments = comments
            };

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}