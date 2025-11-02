using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment PDF
    /// </summary>
    public record ConsignmentPdfResponseModel
    {
        #region Public Properties

#if NET7_0_OR_GREATER
        /// <summary>
        /// The unique voucher id
        /// </summary>
        public required string VoucherId
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
#else
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
#endif
                field = value;
            }
        }

        /// <summary>
        /// The base64 representation of the PDF voucher
        /// </summary>
        public required string Base64String
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
#else
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
#endif
                field = value;
            }
        }
#else
        /// <summary>
        /// The unique voucher id
        /// </summary>
        public string VoucherId { get; }

        /// <summary>
        /// The base64 representation of the PDF voucher
        /// </summary>
        public string Base64String { get; }
#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER
        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModel"/>
        /// </summary>
        public ConsignmentPdfResponseModel() : base()
        {

        }
#else
        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModel"/>
        /// </summary>
        /// <param name="voucherId">The unique voucher id</param>
        /// <param name="base64String">The base64 representation of the PDF voucher</param>
        public ConsignmentPdfResponseModel(string voucherId, string base64String) : base()
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(voucherId);

            ArgumentException.ThrowIfNullOrWhiteSpace(base64String);
#else
            if (string.IsNullOrWhiteSpace(voucherId))
                throw new ArgumentException($"'{nameof(voucherId)}' cannot be null or whitespace.", nameof(voucherId));

            if (string.IsNullOrWhiteSpace(base64String))
                throw new ArgumentException($"'{nameof(base64String)}' cannot be null or whitespace.", nameof(base64String));
#endif

            VoucherId = voucherId;

            Base64String = base64String;
        }
#endif

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
