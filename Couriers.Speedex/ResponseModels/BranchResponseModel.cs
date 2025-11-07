using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the branch depot
    /// </summary>
    public record BranchResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The address of the depot
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// The city of the depot
        /// </summary>
        public string City { get; }

        /// <summary>
        /// The unique id of the depot
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The name of the depot
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The telephone number of the depot
        /// </summary>
        public string? TelephoneNumber { get; }

        /// <summary>
        /// The zip code of the depot
        /// </summary>
        public string ZipCode { get; }

        /// <summary>
        /// The latitude of the depot
        /// </summary>
        public string Latitude { get; }

        /// <summary>
        /// The longitude of the depot
        /// </summary>
        public string Longitude { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BranchResponseModel"/>
        /// </summary>
        /// <param name="address">The address of the depot</param>
        /// <param name="city">The city of the depot</param>
        /// <param name="id">The name of the depot</param>
        /// <param name="name">The name of the depot</param>
        /// <param name="telephoneNumber">The telephone number of the depot</param>
        /// <param name="zipCode">The zip code of the depot</param>
        /// <param name="latitude">The latitude of the depot</param>
        /// <param name="longitude">The longitude of the depot</param>
        public BranchResponseModel(string address, string city, string id, string name, string? telephoneNumber, string zipCode, string latitude, string longitude) : base()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace.", nameof(city));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException($"'{nameof(zipCode)}' cannot be null or whitespace.", nameof(zipCode));

            if (string.IsNullOrWhiteSpace(latitude))
                throw new ArgumentException($"'{nameof(latitude)}' cannot be null or whitespace.", nameof(latitude));

            if (string.IsNullOrWhiteSpace(longitude))
                throw new ArgumentException($"'{nameof(longitude)}' cannot be null or whitespace.", nameof(longitude));

            Address = address;

            City = city;

            Id = id;

            Name = name;

            TelephoneNumber = telephoneNumber;

            ZipCode = zipCode;

            Latitude = latitude;

            Longitude = longitude;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        #endregion
    }
}
