using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the unique pickup id
    /// </summary>
    [XmlRoot(Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupIdInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("orderid")]
        public string? PickupId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupIdInternalRequestModel"/>
        /// </summary>
        public PickupIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
