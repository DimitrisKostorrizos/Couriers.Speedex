using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the unique voucher id
    /// </summary>
    [XmlRoot(Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class VoucherIdInternalRequestModel : SessionIdInternalRequestModel
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
        /// Creates a new instance of <see cref="VoucherIdInternalRequestModel"/>
        /// </summary>
        public VoucherIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
