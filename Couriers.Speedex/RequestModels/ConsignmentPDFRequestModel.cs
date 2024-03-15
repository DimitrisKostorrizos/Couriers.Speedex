using System;
using System.Collections.Generic;
using System.Linq;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the consignment PDF
    /// </summary>
    public record ConsignmentPDFRequestModel
    {
        #region Constants

        /// <summary>
        /// The maximum
        /// </summary>
        public const int MaximumNumberOfVouchers = 20;

        #endregion

        #region Public Properties

        /// <summary>
        /// The voucher ids
        /// NOTE: The maximum number is 20 consignments.
        /// </summary>
        public IEnumerable<string> VoucherIds { get; }

        /// <summary>
        /// The paper size
        /// </summary>
        public PaperSize PaperSize { get; }

        /// <summary>
        /// The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned
        /// </summary>
        public bool ReturnMultipleVouchers { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="voucherIds">The voucher ids</param>
        /// <param name="paperSize">The paper size</param>
        /// <param name="returnMultipleVouchers">The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned</param>
        public ConsignmentPDFRequestModel(IEnumerable<string> voucherIds, PaperSize paperSize, bool returnMultipleVouchers) : base()
        {
            ArgumentNullException.ThrowIfNull(voucherIds, nameof(voucherIds));

            var voucher = voucherIds.Count();

            if (voucher == 0)
                throw new ArgumentOutOfRangeException(nameof(voucherIds), "At least voucher id has to be specified.");

            if (voucher > MaximumNumberOfVouchers)
                throw new ArgumentOutOfRangeException(nameof(voucherIds), $"The maximum number of vouchers is {MaximumNumberOfVouchers}.");

            PaperSize = paperSize;

            ReturnMultipleVouchers = returnMultipleVouchers;

            VoucherIds = voucherIds;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Voucher Count: {VoucherIds.Count()}";

        #endregion
    }
}
