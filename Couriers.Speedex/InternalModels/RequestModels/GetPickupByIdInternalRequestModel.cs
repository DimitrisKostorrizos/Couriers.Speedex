using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for getting the specified pickup
    /// </summary>
    [XmlRoot("GetPickup", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetPickupByIdInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("pickupNumber")]
        public string PickupNumber { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetPickupByIdInternalRequestModel"/>
        /// </summary>
        public GetPickupByIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
