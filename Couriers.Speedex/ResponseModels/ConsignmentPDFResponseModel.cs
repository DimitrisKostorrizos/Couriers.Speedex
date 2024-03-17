using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the consignment PDF
    /// </summary>
    public sealed record ConsignmentPDFResponseModel
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
        /// Default constructor
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="base64String">The base64 representation of the PDF voucher</param>
        public ConsignmentPDFResponseModel(string voucherId, string base64String) : base()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId, nameof(voucherId));

            ArgumentException.ThrowIfNullOrWhiteSpace(base64String, nameof(base64String));

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
