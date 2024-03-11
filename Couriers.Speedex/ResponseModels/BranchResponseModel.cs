namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the branch depot
    /// </summary>
    public class BranchResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The address of the depot
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city of the depot
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The unique id of the depot
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The name of the depot
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The telephone number of the depot
        /// </summary>
        public string TelephoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The zip code of the depot
        /// </summary>
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// The latitude of the depot
        /// </summary>
        public string Latitude { get; set; } = string.Empty;

        /// <summary>
        /// The longitude of the depot
        /// </summary>
        public string Longitude { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        #endregion
    }
}
