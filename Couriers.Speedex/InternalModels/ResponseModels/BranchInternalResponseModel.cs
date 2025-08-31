using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the branch depot
    /// </summary>
    [XmlRoot("Voucher", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class BranchInternalResponseModel : ISoapResponseModel<BranchResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The address of the depot
        /// </summary>
        [XmlElement("BranchAddress")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city of the depot
        /// </summary>
        [XmlElement("BranchCity")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The unique id of the depot
        /// </summary>
        [XmlElement("BranchCode")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The name of the depot
        /// </summary>
        [XmlElement("BranchName")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The telephone number of the depot
        /// </summary>
        [XmlElement("BranchTelephone")]
        public string TelephoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The zip code of the depot
        /// </summary>
        [XmlElement("BranchZipcode")]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// The latitude of the depot
        /// </summary>
        [XmlElement("pointX")]
        public string Latitude { get; set; } = string.Empty;

        /// <summary>
        /// The longitude of the depot
        /// </summary>
        [XmlElement("pointY")]
        public string Longitude { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchInternalResponseModel() : base()
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
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public BranchResponseModel ToResponseModel()
        {
#if NET7_0_OR_GREATER
            return new()
            {
                Address = Address, 
                City = City, 
                Id = Id, 
                Name = Name,
                TelephoneNumber = TelephoneNumber,
                ZipCode = ZipCode,
                Latitude = Latitude, 
                Longitude = Longitude
            };
#else
            return new(Address, City, Id, Name, TelephoneNumber, ZipCode, Latitude, Longitude);
#endif
        }

#endregion
    }
}
