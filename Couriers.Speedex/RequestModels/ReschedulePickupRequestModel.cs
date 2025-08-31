using Couriers.Speedex.Enums;

using System;

namespace Couriers.Speedex.RequestModels
{
    /// <summary>
    /// The request model for rescheduling a pickup
    /// </summary>
    public sealed record ReschedulePickupRequestModel
    {
        #region Private Fields

        /// <summary>
        /// The field of the <see cref="Comments"/>
        /// </summary>
        private string? comments;

        #endregion

        #region Public Properties

#if NET5_0
        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public DateTime PickupDate { get; }
#else
        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public DateOnly PickupDate { get; }
#endif

        /// <summary>
        /// The delivery time frame
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; }

        /// <summary>
        /// The comments for the pickup
        /// </summary>
        public string? Comments
        {
            get => comments;
            set
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                comments = value;
            }
        }

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
        public ReschedulePickupRequestModel(
#if NET5_0
            DateTime pickupDate,
#else
            DateOnly pickupDate,
#endif

            DeliveryTimeLimit deliveryTime) : base()
        {
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
