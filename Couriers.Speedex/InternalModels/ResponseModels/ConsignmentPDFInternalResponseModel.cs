using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the consignment PDF
    /// </summary>
    [XmlRoot("Voucher", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentPdfInternalResponseModel : ISoapResponseModel<ConsignmentPdfResponseModel>, IUnmappedXml
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfInternalResponseModel"/>
        /// </summary>
        public ConsignmentPdfInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public ConsignmentPdfResponseModel ToResponseModel()
            => new(VoucherId, Voucher);

        #endregion
    }
}