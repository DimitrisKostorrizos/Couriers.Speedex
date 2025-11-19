using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment PDF
    /// </summary>
    public record ConsignmentPdfResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="VoucherId"/>
        /// </summary>
        private string _voucherId = default!;

        /// <summary>
        /// The field for the <see cref="Base64String"/>
        /// </summary>
        private string _base64String = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public required string VoucherId
        {
            get => _voucherId;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                _voucherId = value;
            }
        }

        /// <summary>
        /// The base64 representation of the PDF voucher
        /// </summary>
        public required string Base64String
        {
            get => _base64String;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                _base64String = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModel"/>
        /// </summary>
        public ConsignmentPdfResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModel"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="base64String">The base64 representation of the PDF voucher</param>
        [SetsRequiredMembers]
        public ConsignmentPdfResponseModel(string voucherId, string base64String) : this()
        {
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