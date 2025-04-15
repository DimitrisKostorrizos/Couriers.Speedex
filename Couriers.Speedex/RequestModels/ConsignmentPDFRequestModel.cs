using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the consignment PDF
    /// </summary>
    public sealed record ConsignmentPdfRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The voucher ids
        /// NOTE: The maximum number is <see cref="SpeedexConstants.MaximumNumberOfVouchers"/> consignments.
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
        public ConsignmentPdfRequestModel(IEnumerable<string> voucherIds, PaperSize paperSize, bool returnMultipleVouchers) : base()
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(voucherIds);
#else
            if (voucherIds is null)
                throw new ArgumentNullException(nameof(voucherIds));
#endif

            var voucherCount = voucherIds.Count();

            if (voucherCount == 0)
                throw new ArgumentOutOfRangeException(nameof(voucherIds), "At least voucher id has to be specified.");

            if (voucherCount > SpeedexConstants.MaximumNumberOfVouchers)
                throw new ArgumentOutOfRangeException(nameof(voucherIds), $"The maximum number of vouchers is {SpeedexConstants.MaximumNumberOfVouchers}.");

            PaperSize = paperSize;

            ReturnMultipleVouchers = returnMultipleVouchers;

            VoucherIds = voucherIds;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="voucherId">The voucher id</param>
        /// <param name="paperSize">The paper size</param>
        /// <param name="returnMultipleVouchers">The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned</param>
        public ConsignmentPdfRequestModel(string voucherId, PaperSize paperSize, bool returnMultipleVouchers) : this(

#if NET8_0_OR_GREATER
            [voucherId]
#else
            new string[] { voucherId }
#endif
            , paperSize, returnMultipleVouchers)
        {

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
