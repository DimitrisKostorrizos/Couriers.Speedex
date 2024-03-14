using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for rescheduling a pickup
    /// </summary>
    public record ReschedulePickupRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The date for the pickup
        /// </summary>
        public DateTime PickupDate { get; }

        /// <summary>
        /// The delivery time frame
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; }

        /// <summary>
        /// The comments for the pickup
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string? PickupId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pickupDate">The date for the pickup</param>
        /// <param name="deliveryTime">The delivery time frame</param>
        public ReschedulePickupRequestModel(DateTime pickupDate, DeliveryTimeLimit deliveryTime) : base()
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pickupDate, DateTime.Now, nameof(pickupDate));

            PickupDate = pickupDate;

            DeliveryTime = deliveryTime;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Pickup Date: {PickupDate}";

        #endregion
    }
}
