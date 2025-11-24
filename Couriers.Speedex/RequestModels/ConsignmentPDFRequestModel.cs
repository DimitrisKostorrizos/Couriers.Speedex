using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Couriers.Speedex.RequestModels
{
    /// <summary>
    /// The request model for the consignment PDF
    /// </summary>
    public sealed record ConsignmentPdfRequestModel
    {
        #region PrivateFields

        /// <summary>
        /// The field for the <see cref="VoucherIds"/>
        /// </summary>
        private IEnumerable<string> voucherIds = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The voucher ids
        /// NOTE: The maximum number is <see cref="SpeedexConstants.MaximumNumberOfVouchers"/> consignments.
        /// </summary>
        public required IEnumerable<string> VoucherIds
        {
            get => voucherIds;
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                var voucherCount = value.Count();

                if (voucherCount == 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "At least voucher id has to be specified.");

                if (voucherCount > SpeedexConstants.MaximumNumberOfVouchers)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The maximum number of vouchers is {SpeedexConstants.MaximumNumberOfVouchers}.");

                if (value.Any(x => string.IsNullOrWhiteSpace(x)))
                    throw new ArgumentException($"All the voucher ids cannot be null or whitespace.", nameof(value));

                voucherIds = value;
            }
        }

        /// <summary>
        /// The paper size
        /// </summary>
        public required PaperSize PaperSize { get; set; }

        /// <summary>
        /// The flag indicating whether a single merged PDF file will be returned or one PDF file per consignment will be returned
        /// </summary>
        public bool ReturnMultipleVouchers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfRequestModel"/>
        /// </summary>
        public ConsignmentPdfRequestModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfRequestModel"/>
        /// </summary>
        /// <param name="voucherIds">The voucher ids</param>
        /// <param name="paperSize">The paper size</param>
        [SetsRequiredMembers]
        public ConsignmentPdfRequestModel(IEnumerable<string> voucherIds, PaperSize paperSize) : this()
        {
            PaperSize = paperSize;

            VoucherIds = voucherIds;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfRequestModel"/>
        /// </summary>
        /// <param name="voucherId">The voucher id</param>
        /// <param name="paperSize">The paper size</param>
        [SetsRequiredMembers]
        public ConsignmentPdfRequestModel(string voucherId, PaperSize paperSize) : this(new string[] { voucherId }, paperSize)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString()
            => $"Vouchers: {VoucherIds.Count()}";

        #endregion
    }
}