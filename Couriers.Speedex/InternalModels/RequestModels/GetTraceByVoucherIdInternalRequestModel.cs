using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for getting the tracing for the consignment that is related to the specified voucher
    /// </summary>
    [XmlRoot("GetTraceByVoucher", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetTraceByVoucherIdInternalRequestModel : SessionIdInternalRequestModel
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
        /// Creates a new instance of <see cref="GetTraceByVoucherIdInternalRequestModel"/>
        /// </summary>
        public GetTraceByVoucherIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
