using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the unique pickup id
    /// </summary>
    [XmlRoot(Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupNumberInternalRequestModel : SessionIdInternalRequestModel
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
        public PickupNumberInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
