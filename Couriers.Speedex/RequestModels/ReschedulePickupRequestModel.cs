using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for rescheduling a pickup
    /// </summary>
    public class ReschedulePickupRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The comments for the pickup
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// The date for the pickup
        /// </summary>
        public DateTime PickupDate { get; set; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string? PickupId { get; set; }

        /// <summary>
        /// The delivery time frame
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReschedulePickupRequestModel() : base()
        {

        }

        #endregion
    }
}
