using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the consignment PDF
    /// </summary>
    [XmlRoot("GetBOLPdf", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentPDFInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The paper size
        /// </summary>
        [XmlElement("paperType")]
        public uint PaperSize { get; set; }

        /// <summary>
        /// The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned
        /// </summary>
        [XmlElement("perVoucher")]
        public bool ReturnMultipleVouchers { get; set; }

        /// <summary>
        /// The voucher ids
        /// NOTE: The maximum number is 20 consignments.
        /// </summary>
        [XmlArray("voucherIDs")]
        [XmlArrayItem("string")]
        public List<string> VoucherIds { get; set; } = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentPDFInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="ConsignmentPDFInternalRequestModel"/> from the <see cref="ConsignmentPDFRequestModel"/>
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns></returns>
        public static ConsignmentPDFInternalRequestModel FromRequestModel(ConsignmentPDFRequestModel model) => new ConsignmentPDFInternalRequestModel()
        {
            PaperSize = CouriersSpeedexDataModelHelpers.FromPaperType(model.PaperSize),
            ReturnMultipleVouchers = model.ReturnMultipleVouchers,
            VoucherIds = model.VoucherIds.ToList()
        };

        #endregion
    }
}
