using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the last checkpoint of a consignment
    /// </summary>
    [XmlRoot("GetLastCheckpoint", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetLastCheckpointInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The unique voucher id
        /// </summary>
        [XmlElement("VoucherID")]
        public string? VoucherId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetLastCheckpointInternalRequestModel"/>
        /// </summary>
        public GetLastCheckpointInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
