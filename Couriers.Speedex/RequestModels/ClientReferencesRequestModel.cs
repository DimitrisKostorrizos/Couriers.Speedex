namespace Couriers.Speedex.RequestModels
{
    /// <summary>
    /// The request model for the client references
    /// </summary>
    public sealed record ClientReferencesRequestModel
    {
        #region Private Fields

        /// <summary>
        /// The field of the <see cref="FirstClientReference"/>
        /// </summary>
        private string? _firstClientReference;

        /// <summary>
        /// The field of the <see cref="SecondClientReference"/>
        /// </summary>
        private string? _secondClientReference;

        /// <summary>
        /// The field of the <see cref="ThirdClientReference"/>
        /// </summary>
        private string? _thirdClientReference;

        #endregion

        #region Public Properties

        /// <summary>
        /// The first client reference for searching the consignments
        /// </summary>
        public string? FirstClientReference
        {
            get => _firstClientReference;
            init
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);
                _firstClientReference = value;
            }
        }

        /// <summary>
        /// The second client reference for searching the consignments
        /// </summary>
        public string? SecondClientReference
        {
            get => _secondClientReference;
            init
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);

                _secondClientReference = value;
            }
        }

        /// <summary>
        /// The third client reference for searching the consignments
        /// </summary>
        public string? ThirdClientReference
        {
            get => _thirdClientReference;
            init
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);

                _thirdClientReference = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ClientReferencesRequestModel"/>
        /// </summary>
        public ClientReferencesRequestModel() : base()
        {

        }

        #endregion
    }
}