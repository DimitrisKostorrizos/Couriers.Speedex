using Couriers.Speedex.Constants;
using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the pickup
    /// </summary>
    [XmlRoot("Result", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupInternalResponseModel : ISoapResponseModel<PickupResponseModel>
    {
        #region Public Properties

#pragma warning disable CA1819 // Properties should not return arrays

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("Number")]
        public string Id { get; set; } = string.Empty;

#if NET8_0_OR_GREATER
        /// <summary>
        /// The related consignment ids
        /// </summary>
        [XmlArray("ConsignmentNumbers")]
        [XmlArrayItem("string")]
        public string[] ConsignmentIds { get; set; } = [];
#else
        /// <summary>
        /// The related consignment ids
        /// </summary>
        [XmlArray("ConsignmentNumbers")]
        [XmlArrayItem("string")]
        public string[] ConsignmentIds { get; set; } = Array.Empty<string>();
#endif

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

#pragma warning restore CA1819 // Properties should not return arrays

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
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
        public override string ToString() => Id;

        /// <summary>
        /// Creates and return the <see cref="PickupResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupResponseModel ToResponseModel()
        {
            var pickupDate = DateTime.Parse(PickupDate, SpeedexConstants.SpeedexCultureInfo);

            var model = new PickupResponseModel()
            {
                Address = Address,
                CheckpointCode = CheckpointCode,
                CheckpointGroupCode = CheckpointGroupCode,
                City = City,
                Comments = Comments,
                ConsignmentIds = ConsignmentIds,
                CountryCode = CountryCode,
                Id = Id,
                Name = Name,
                PhoneNumber = PhoneNumber,
#if NET5_0
                PickupDate = pickupDate,
#else
                PickupDate = DateOnly.FromDateTime(pickupDate),
#endif
                PostCode = PostCode
            };

#if NET5_0
            if (DateTime.TryParse(PickupTimeTo, SpeedexConstants.SpeedexCultureInfo, DateTimeStyles.None, out var result))
#elif NET6_0
            if (TimeOnly.TryParse(PickupTimeTo, SpeedexConstants.SpeedexCultureInfo, DateTimeStyles.None, out var result))
#else
            if (TimeOnly.TryParse(PickupTimeTo, SpeedexConstants.SpeedexCultureInfo, out var result))
#endif
                model.PickupTimeTo = result;

#if NET5_0
            if (DateTime.TryParse(PickupTimeFrom, SpeedexConstants.SpeedexCultureInfo, DateTimeStyles.None, out result))
#elif NET6_0
            if (TimeOnly.TryParse(PickupTimeFrom, SpeedexConstants.SpeedexCultureInfo, DateTimeStyles.None, out result))
#else
            if (TimeOnly.TryParse(PickupTimeFrom, SpeedexConstants.SpeedexCultureInfo, out result))
#endif
                model.PickupTimeFrom = result;

            return model;
        }

        #endregion
    }
}
