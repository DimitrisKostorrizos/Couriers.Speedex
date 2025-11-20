using Couriers.Speedex.Structs;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="DeliveryTimeWindow"/>
    /// </summary>
    public sealed class DeliveryTimeWindowUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DeliveryTimeWindowUnitTests"/>
        /// </summary>
        public DeliveryTimeWindowUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="DeliveryTimeWindow"/> default constructor is called, 
        /// no time window is specified
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void DeliveryTimeWindow_WithNoArguments_NoWindowIsSpecified()
        {
            var deliveryTimeWindow = new DeliveryTimeWindow();

            Assert.False(deliveryTimeWindow.IsTimeWindowSpecified);

            Assert.Null(deliveryTimeWindow.StartingTime);

            Assert.Null(deliveryTimeWindow.EndingTime);
        }

        /// <summary>
        /// Validates that when <see cref="DeliveryTimeWindow"/> constructor is called, 
        /// with invalid time window arguments, the expected time window is specified
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void DeliveryTimeWindow_WithInvalidArguments_ThrowsException()
        {
            var earlierTime = new TimeOnly(10, 0, 0);

            var laterTime = new TimeOnly(12, 0, 0);

            Assert.ThrowsAny<Exception>(() => new DeliveryTimeWindow(laterTime, earlierTime));
        }

        /// <summary>
        /// Validates that when <see cref="DeliveryTimeWindow"/> constructor is called, 
        /// with valid time window arguments, the expected time window is specified
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void DeliveryTimeWindow_WithValidArguments_ExpectedWindowIsSpecified()
        {
            var startingTime = new TimeOnly(10, 0, 0);

            var endingTime = new TimeOnly(12, 0, 0);

            var deliveryTimeWindow = new DeliveryTimeWindow(startingTime, endingTime);

            Assert.True(deliveryTimeWindow.IsTimeWindowSpecified);

            Assert.Equal(startingTime, deliveryTimeWindow.StartingTime);

            Assert.Equal(endingTime, deliveryTimeWindow.EndingTime);
        }

        /// <summary>
        /// Validates that when <see cref="DeliveryTimeWindow"/> equality related methods
        /// and operators are used, they return the expected results
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void DeliveryTimeWindow_Equality_ExpectedResultsAreReturned()
        {
            var startingTime = new TimeOnly(10, 0, 0);

            var endingTime = new TimeOnly(12, 0, 0);

            var firstDeliveryTimeWindow = new DeliveryTimeWindow(startingTime, endingTime);

            var secordDeliveryTimeWindow = new DeliveryTimeWindow(startingTime, endingTime);

            Assert.True(firstDeliveryTimeWindow.Equals(secordDeliveryTimeWindow));

            Assert.False(firstDeliveryTimeWindow.Equals(new DeliveryTimeWindow()));

            Assert.True(new DeliveryTimeWindow().Equals(new DeliveryTimeWindow()));

            Assert.False(firstDeliveryTimeWindow.Equals(new DeliveryTimeWindow(startingTime, new TimeOnly(13, 0, 0))));

            Assert.False(firstDeliveryTimeWindow.Equals(new DeliveryTimeWindow(new TimeOnly(9, 0, 0), endingTime)));

            Assert.Equal(firstDeliveryTimeWindow.GetHashCode(), secordDeliveryTimeWindow.GetHashCode());

            Assert.True(firstDeliveryTimeWindow == secordDeliveryTimeWindow);

            Assert.False(firstDeliveryTimeWindow != secordDeliveryTimeWindow);

            Assert.True(firstDeliveryTimeWindow.Equals((object?) secordDeliveryTimeWindow));

            Assert.False(firstDeliveryTimeWindow.Equals(null));

            Assert.False(firstDeliveryTimeWindow.Equals(endingTime));
        }

        #endregion

        #endregion
    }
}