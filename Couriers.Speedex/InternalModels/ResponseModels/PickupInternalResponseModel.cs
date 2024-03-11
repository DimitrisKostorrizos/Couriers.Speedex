using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the pickup
    /// </summary>
    [XmlRoot("Result", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupInternalResponseModel : ISOAPResponseModel<PickupResponseModel>
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
        public List<string> ConsignmentIds { get; set; } = new();

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
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        /// <summary>
        /// Creates and return the <see cref="PickupResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupResponseModel ToResponseModel()
        {
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
                PickupDate = DateTime.Parse(PickupDate),
                PostCode = PostCode
            };

            if (DateTime.TryParse(PickupTimeTo, out var result))
                model.PickupTimeTo = result;

            if (DateTime.TryParse(PickupTimeFrom, out result))
                model.PickupTimeFrom = result;

            return model;
        }

        #endregion
    }
}
