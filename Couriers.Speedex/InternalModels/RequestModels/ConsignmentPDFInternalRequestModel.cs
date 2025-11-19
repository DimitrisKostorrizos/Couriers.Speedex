using Couriers.Speedex.Constants;
using Couriers.Speedex.RequestModels;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the consignment PDF
    /// </summary>
    [XmlRoot("GetBOLPdf", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentPdfInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

#pragma warning disable CA1819 // Properties should not return arrays

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
        /// NOTE: The maximum number is <see cref="SpeedexConstants.MaximumNumberOfVouchers"/> consignments.
        /// </summary>
        [XmlArray("voucherIDs")]
        [XmlArrayItem("string")]
        public string[] VoucherIds { get; set; } = Array.Empty<string>();

#pragma warning restore CA1819 // Properties should not return arrays

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfInternalRequestModel"/>
        /// </summary>
        public ConsignmentPdfInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="ConsignmentPdfInternalRequestModel"/> from the <see cref="ConsignmentPdfRequestModel"/>
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns></returns>
        public static ConsignmentPdfInternalRequestModel FromRequestModel([NotNull] ConsignmentPdfRequestModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            return new()
            {
                PaperSize = SpeedexHelpers.FromPaperType(model.PaperSize),
                ReturnMultipleVouchers = model.ReturnMultipleVouchers,
                VoucherIds = model.VoucherIds.ToArray()
            };
        }

        #endregion
    }
}
