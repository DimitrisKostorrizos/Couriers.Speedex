using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for canceling the specified pickup
    /// </summary>
    [XmlRoot("CancelPickup", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CancelPickupByIdInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("pickupNumber")]
        public string? PickupNumber { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CancelPickupByIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
