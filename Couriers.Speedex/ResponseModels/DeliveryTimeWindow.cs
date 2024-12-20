using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// Represents a time window for Speedex to handle the delivery
    /// </summary>
    public readonly struct DeliveryTimeWindow
    {
        #region Public Properties

        /// <summary>
        /// The starting time
        /// </summary>
        public TimeOnly? StartingTime { get; }

        /// <summary>
        /// The ending time
        /// </summary>
        public TimeOnly? EndingTime { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeliveryTimeWindow()
        {

        }

        /// <summary>
        /// Creates a new instance using the specified <paramref name="startingTime"/> and <paramref name="endingTime"/>
        /// </summary>
        /// <param name="startingTime">The starting time</param>
        /// <param name="endingTime">The ending time</param>
        public DeliveryTimeWindow(TimeOnly startingTime, TimeOnly endingTime)
        {
            if (endingTime < startingTime)
                throw new InvalidOperationException($"The {nameof(startingTime)} must not be before {nameof(endingTime)}.");

            StartingTime = startingTime;

            EndingTime = endingTime;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            if (StartingTime.HasValue && EndingTime.HasValue)
                return $"{StartingTime} - {EndingTime}";

            return base.ToString();
        }

        #endregion
    }
}
