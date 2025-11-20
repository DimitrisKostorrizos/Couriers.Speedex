using Couriers.Speedex.Constants;
using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the pickup
    /// </summary>
    [XmlRoot("Result", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupInternalResponseModel : ISoapResponseModel<PickupResponseModel>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("Number")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The related consignment ids
        /// </summary>
        [XmlArray("ConsignmentNumbers")]
        [XmlArrayItem("string")]
        public string[] ConsignmentIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The checkpoint code
        /// </summary>
        [XmlElement("EventCode")]
        public string CheckpointCode { get; set; } = string.Empty;

        /// <summary>
        /// The group checkpoint code
        /// </summary>
        [XmlElement("EventGroupCode")]
        public string CheckpointGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// The address for the pickup
        /// </summary>
        [XmlElement("PickupAddress")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city for the pickup
        /// </summary>
        [XmlElement("PickupCity")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The country code for the pickup
        /// </summary>
        [XmlElement("PickupCountryCode")]
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The pickup date
        /// </summary>
        [XmlElement("PickupDate")]
        public string PickupDate { get; set; } = string.Empty;

        /// <summary>
        /// The comments of the pickup
        /// </summary>
        [XmlElement("PickupCustomerComments")]
        public string Comments { get; set; } = string.Empty;

        /// <summary>
        /// The name for the pickup
        /// </summary>
        [XmlElement("PickupName")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The phone number for the pickup
        /// </summary>
        [XmlElement("PickupPhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The post code for the pickup
        /// </summary>
        [XmlElement("PickupPostCode")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// The start of the time frame of the pickup
        /// </summary>
        [XmlElement("PickupTimeFrom")]
        public string PickupTimeFrom { get; set; } = string.Empty;

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        [XmlElement("PickupTimeTo")]
        public string PickupTimeTo { get; set; } = string.Empty;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReturnMessageInternalResponseModel"/>
        /// </summary>
        public PickupInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString() => Id;

        /// <summary>
        /// Creates and return the <see cref="PickupResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupResponseModel ToResponseModel()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Parse(PickupDate, SpeedexConstants.SpeedexCultureInfo));

            var pickupTimeFrom = default(TimeOnly?);

            if (TimeOnly.TryParse(PickupTimeFrom, SpeedexConstants.SpeedexCultureInfo, DateTimeStyles.None, out var pickupTimeFromResult))
                pickupTimeFrom = pickupTimeFromResult;

            var pickupTimeTo = default(TimeOnly?);

            if (TimeOnly.TryParse(PickupTimeTo, SpeedexConstants.SpeedexCultureInfo, DateTimeStyles.None, out var pickupTimeToResult))
                pickupTimeTo = pickupTimeToResult;

            return new(Id, ConsignmentIds, CheckpointCode, CheckpointGroupCode, Address, City, CountryCode, Comments, Name, PhoneNumber, PostCode, pickupDate, pickupTimeFrom, pickupTimeTo);
        }

        #endregion
    }
}