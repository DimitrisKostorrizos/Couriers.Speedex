using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.Structs
{
    /// <summary>
    /// Represents a time window for Speedex to handle the delivery
    /// </summary>
    public readonly struct DeliveryTimeWindow : IEquatable<DeliveryTimeWindow>
    {
        #region Public Properties

        /// <summary>
        /// The starting time
        /// </summary>
        public DateTime? StartingTime { get; }

        /// <summary>
        /// The ending time
        /// </summary>
        public DateTime? EndingTime { get; }

        /// <summary>
        /// A flag indicating whether the time window is specified
        /// </summary>
        [MemberNotNullWhen(true, nameof(StartingTime), nameof(EndingTime))]
        public bool IsTimeWindowSpecified => StartingTime.HasValue && EndingTime.HasValue;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance using the specified <paramref name="startingTime"/> and <paramref name="endingTime"/>
        /// </summary>
        /// <param name="startingTime">The starting time</param>
        /// <param name="endingTime">The ending time</param>
        public DeliveryTimeWindow(DateTime startingTime, DateTime endingTime)
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
            if (IsTimeWindowSpecified)
                return $"{StartingTime.Value} - {EndingTime.Value}";

            return "No time window.";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => HashCode.Combine(StartingTime, EndingTime);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns></returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return false;

            if (obj is not DeliveryTimeWindow strongTypedObj)
                return false;

            return Equals(strongTypedObj);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns></returns>
        public bool Equals(DeliveryTimeWindow other)
        {
            if (!IsTimeWindowSpecified && !other.IsTimeWindowSpecified)
                return true;

            if (IsTimeWindowSpecified
                && other.IsTimeWindowSpecified
                && StartingTime.Value == other.StartingTime
                && EndingTime.Value == other.EndingTime.Value)
                return true;

            return false;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Returns true if the <paramref name="left"/> and <paramref name="right"/> are equal, false otherwise
        /// </summary>
        /// <param name="left">The left operand</param>
        /// <param name="right">The right operand</param>
        /// <returns></returns>
        public static bool operator ==(DeliveryTimeWindow left, DeliveryTimeWindow right)
            => left.Equals(right);

        /// <summary>
        /// Returns true if the <paramref name="left"/> and <paramref name="right"/> aren't equal, false otherwise
        /// </summary>
        /// <param name="left">The left operand</param>
        /// <param name="right">The right operand</param>
        /// <returns></returns>
        public static bool operator !=(DeliveryTimeWindow left, DeliveryTimeWindow right)
            => !(left == right);

        #endregion
    }
}
