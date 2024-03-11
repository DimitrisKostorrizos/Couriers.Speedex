using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for canceling a consignment with the specified the unique voucher id
    /// </summary>
    [XmlRoot("CancelBOL", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CancelConsignmentByVoucherIdInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The unique voucher id
        /// </summary>
        [XmlElement("voucherID")]
        public string? VoucherId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CancelConsignmentByVoucherIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
