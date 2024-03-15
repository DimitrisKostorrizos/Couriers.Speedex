using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the pickup
    /// </summary>
    [XmlRoot("CreatePickup", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The ids for the connected master consignments
        /// NOTE: The maximum count is 5 master consignment numbers
        /// </summary>
        [XmlArray("consignmentNumbers")]
        [XmlArrayItem("string")]
        public List<string>? ConsignmentIds { get; set; }

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
        /// Default constructor
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
            ArgumentNullException.ThrowIfNull(model, nameof(model));

            var internalModel = new PickupInternalRequestModel()
            {
                Comments = model.Comments,
                ConsignmentIds = model.ConsignmentIds.ToList(),
                PickupDate = model.PickupDate
            };

            // Get the delivery times
            CouriersSpeedexDataModelHelpers.ToTimeLimit(model.DeliveryTime, out var deliveryTimeFrom, out var deliveryTimeTo);

            // Set the starting delivery time
            internalModel.PickupHourFrom = deliveryTimeFrom;

            // Set the ending delivery time
            internalModel.PickupHourTo = deliveryTimeTo;

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
