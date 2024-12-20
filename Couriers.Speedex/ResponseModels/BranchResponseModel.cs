using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the branch depot
    /// </summary>
    public sealed record BranchResponseModel
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
        public string TelephoneNumber { get; }

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
        /// Default constructor
        /// </summary>
        /// <param name="address">The address of the depot</param>
        /// <param name="city">The city of the depot</param>
        /// <param name="id">The name of the depot</param>
        /// <param name="name">The name of the depot</param>
        /// <param name="telephoneNumber">The telephone number of the depot</param>
        /// <param name="zipCode">The zip code of the depot</param>
        /// <param name="latitude">The latitude of the depot</param>
        /// <param name="longitude">The longitude of the depot</param>
        public BranchResponseModel(string address, string city, string id, string name, string telephoneNumber, string zipCode, string latitude, string longitude) : base()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(address);

            ArgumentException.ThrowIfNullOrWhiteSpace(city);

            ArgumentException.ThrowIfNullOrWhiteSpace(id);

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            ArgumentException.ThrowIfNullOrWhiteSpace(telephoneNumber);

            ArgumentException.ThrowIfNullOrWhiteSpace(zipCode);

            ArgumentException.ThrowIfNullOrWhiteSpace(latitude);

            ArgumentException.ThrowIfNullOrWhiteSpace(longitude);

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
