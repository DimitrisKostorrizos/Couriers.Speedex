using Couriers.Speedex.RequestModels;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for rescheduling a pickup
    /// </summary>
    [XmlRoot("ReschedulePickup", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ReschedulePickupInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The comments for the pickup
        /// </summary>
        [XmlElement("pickupCustomerComments")]
        public string? Comments { get; set; }

        /// <summary>
        /// The date for the pickup
        /// </summary>
        [XmlElement("pickupDate")]
        public DateTime PickupDate { get; set; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("pickupNumber")]
        public string? PickupId { get; set; }

        /// <summary>
        /// The start of the requested time frame of the pickup
        /// </summary>
        [XmlElement("pickupTimeTo")]
        public DateTime? PickupHourTo { get; set; }

        /// <summary>
        /// The end of the requested time frame of the pickup
        /// </summary>
        [XmlElement("pickupTimeFrom")]
        public DateTime? PickupHourFrom { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReschedulePickupInternalRequestModel"/>
        /// </summary>
        public ReschedulePickupInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="ReschedulePickupInternalRequestModel"/> from the <paramref name="model"/>
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns></returns>
        public static ReschedulePickupInternalRequestModel FromRequestModel([NotNull] ReschedulePickupRequestModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            // Initialize the internal model
            var internalModel = new ReschedulePickupInternalRequestModel()
            {
                Comments = model.Comments,
                PickupDate = model.PickupDate,
                PickupId = model.PickupId
            };

            // Get the delivery times
            var deliveryTimeWindow = SpeedexHelpers.ToDeliveryTimeWindow(model.DeliveryTime);

            var startingPickupTime = default(DateTime?);

            var endingPickupTime = default(DateTime?);

            if (deliveryTimeWindow.StartingTime.HasValue)
                startingPickupTime = model.PickupDate.AddTicks(deliveryTimeWindow.StartingTime.Value.Ticks);

            if (deliveryTimeWindow.EndingTime.HasValue)
                endingPickupTime = model.PickupDate.AddTicks(deliveryTimeWindow.EndingTime.Value.Ticks);

            // Set the starting delivery time
            internalModel.PickupHourFrom = startingPickupTime;

            // Set the ending delivery time
            internalModel.PickupHourTo = endingPickupTime;

            // Return the internal model
            return internalModel;
        }

        /// <summary>
        /// Checks if <see cref="PickupHourTo"/> should be serialized
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializePickupHourTo() => PickupHourTo.HasValue;

        /// <summary>
        /// Checks if <see cref="PickupHourFrom"/> should be serialized
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializePickupHourFrom() => PickupHourFrom.HasValue;

        #endregion
    }
}
