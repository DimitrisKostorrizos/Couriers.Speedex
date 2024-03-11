using System.Collections.Generic;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the consignment PDF
    /// </summary>
    public class ConsignmentPDFRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The paper size
        /// </summary>
        public PaperSize PaperSize { get; set; }

        /// <summary>
        /// The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned
        /// </summary>
        public bool ReturnMultipleVouchers { get; set; }

        /// <summary>
        /// The voucher ids
        /// NOTE: The maximum number is 20 consignments.
        /// </summary>
        public IEnumerable<string> VoucherIds { get; set; } = new List<string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentPDFRequestModel() : base()
        {

        }

        #endregion
    }
}
