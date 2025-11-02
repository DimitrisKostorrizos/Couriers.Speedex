using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment PDF
    /// </summary>
    public record ConsignmentPdfResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public string VoucherId { get; }

        /// <summary>
        /// The base64 representation of the PDF voucher
        /// </summary>
        public string Base64String { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModel"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="base64String">The base64 representation of the PDF voucher</param>
        public ConsignmentPdfResponseModel(string voucherId, string base64String) : base()
        {
            if (string.IsNullOrWhiteSpace(voucherId))
                throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

            if (string.IsNullOrWhiteSpace(base64String))
                throw new ArgumentException($"'{nameof(base64String)}' cannot be null or whitespace.", nameof(base64String));

            VoucherId = voucherId;

            Base64String = base64String;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        #endregion
    }
}
