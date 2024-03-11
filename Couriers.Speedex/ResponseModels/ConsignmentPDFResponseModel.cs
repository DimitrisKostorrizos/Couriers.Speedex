namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the consignment PDF
    /// </summary>
    public class ConsignmentPDFResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public string VoucherId { get; set; } = string.Empty;

        /// <summary>
        /// The base64 representation of the PDF voucher
        /// </summary>
        public string Base64String { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentPDFResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        #endregion
    }
}
