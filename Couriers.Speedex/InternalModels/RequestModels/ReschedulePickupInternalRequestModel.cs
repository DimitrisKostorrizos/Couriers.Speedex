using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
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
        /// Default constructor
        /// </summary>
        public ReschedulePickupInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="ReschedulePickupInternalRequestModel"/> from the <paramref name="value"/>
        /// </summary>
        /// <param name="value">The request model</param>
        /// <returns></returns>
        public static ReschedulePickupInternalRequestModel FromRequestModel(ReschedulePickupRequestModel value)
        {
            // Initialize the internal model
            var internalModel = new ReschedulePickupInternalRequestModel()
            {
                Comments = value.Comments,
                PickupDate = value.PickupDate,
                PickupId = value.PickupId
            };

            // Get the delivery times
            CouriersSpeedexDataModelHelpers.ToTimeLimit(value.DeliveryTime, out var deliveryTimeFrom, out var deliveryTimeTo);

            // Set the starting delivery time
            internalModel.PickupHourFrom = deliveryTimeFrom;

            // Set the ending delivery time
            internalModel.PickupHourTo = deliveryTimeTo;

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
