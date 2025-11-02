using Couriers.Speedex.Constants;
using Couriers.Speedex.RequestModels;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the pickup
    /// </summary>
    [XmlRoot("CreatePickup", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

#pragma warning disable CA1819 // Properties should not return arrays

        /// <summary>
        /// The ids for the connected master consignments
        /// NOTE: The maximum count is <see cref="SpeedexConstants.MaximumNumberOfConsignmentsForPickup"/> master consignment numbers
        /// </summary>
        [XmlArray("consignmentNumbers")]
        [XmlArrayItem("string")]
        public string[] ConsignmentIds { get; set; } = Array.Empty<string>();

#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The comments
        /// </summary>
        [XmlElement("pickupCustomerComments")]
        public string? Comments { get; set; }

        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        [XmlElement("pickupDate")]
        public DateTime PickupDate { get; set; }

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
        /// Creates a new instance of <see cref="PickupInternalRequestModel"/>
        /// </summary>
        public PickupInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="PickupInternalRequestModel"/> from the <see cref="PickupRequestModel"/>
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns></returns>
        public static PickupInternalRequestModel FromRequestModel([NotNull] PickupRequestModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var internalModel = new PickupInternalRequestModel()
            {
                Comments = model.Comments,
                ConsignmentIds = model.ConsignmentIds.ToArray(),
                PickupDate = model.PickupDate
            };

            // Get the delivery times
            var deliveryTimeWindow = SpeedexHelpers.ToDeliveryTimeWindow(model.DeliveryTime);

            var startingPickupTime = default(DateTime?);

            if (deliveryTimeWindow.StartingTime.HasValue)
                startingPickupTime = model.PickupDate.Date.AddHours(deliveryTimeWindow.StartingTime.Value.Hour);

            var endingPickupTime = default(DateTime?);

            if (deliveryTimeWindow.EndingTime.HasValue)
                endingPickupTime = model.PickupDate.Date.AddHours(deliveryTimeWindow.EndingTime.Value.Hour);

            // Set the starting delivery time
            internalModel.PickupHourFrom = startingPickupTime;

            // Set the ending delivery time
            internalModel.PickupHourTo = endingPickupTime;

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
