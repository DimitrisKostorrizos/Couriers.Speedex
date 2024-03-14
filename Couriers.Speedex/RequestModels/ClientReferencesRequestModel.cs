namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the client references
    /// </summary>
    public record ClientReferencesRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The first client reference for searching the consignments
        /// </summary>
        public string? FirstClientReference { get; set; }

        /// <summary>
        /// The second client reference for searching the consignments
        /// </summary>
        public string? SecondClientReference { get; set; }

        /// <summary>
        /// The third client reference for searching the consignments
        /// </summary>
        public string? ThirdClientReference { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientReferencesRequestModel() : base()
        {

        }

        #endregion
    }
}
