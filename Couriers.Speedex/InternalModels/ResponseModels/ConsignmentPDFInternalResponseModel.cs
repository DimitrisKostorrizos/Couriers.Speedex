using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the consignment PDF
    /// </summary>
    [XmlRoot("Voucher", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentPDFInternalResponseModel : ISOAPResponseModel<ConsignmentPDFResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The unique voucher id
        /// </summary>
        [XmlElement("VoucherID")]
        public string VoucherId { get; set; } = string.Empty;

        /// <summary>
        /// The base64 representation of the PDF voucher
        /// </summary>
        [XmlElement("pdf")]
        public string Voucher { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentPDFInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        /// <summary>
        /// Creates and return the <see cref="ConsignmentPDFResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public ConsignmentPDFResponseModel ToResponseModel() => new()
        {
            Base64String = Voucher,
            VoucherId = VoucherId
        };

        #endregion
    }
}
