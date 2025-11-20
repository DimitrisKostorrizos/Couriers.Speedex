using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the branch depot
    /// </summary>
    public record BranchResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="Address"/>
        /// </summary>
        private string _address = default!;

        /// <summary>
        /// The field for the <see cref="City"/>
        /// </summary>
        private string _city = default!;

        /// <summary>
        /// The field for the <see cref="Id"/>
        /// </summary>
        private string _id = default!;

        /// <summary>
        /// The field for the <see cref="Name"/>
        /// </summary>
        private string _name = default!;

        /// <summary>
        /// The field for the <see cref="ZipCode"/>
        /// </summary>
        private string _zipCode = default!;

        /// <summary>
        /// The field for the <see cref="Latitude"/>
        /// </summary>
        private string _latitude = default!;

        /// <summary>
        /// The field for the <see cref="Longitude"/>
        /// </summary>
        private string _longitude = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The address of the depot
        /// </summary>
        public required string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(Address));

                _address = value;
            }
        }

        /// <summary>
        /// The city of the depot
        /// </summary>
        public required string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(City));

                _city = value;
            }
        }

        /// <summary>
        /// The unique id of the depot
        /// </summary>
        public required string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(Id));

                _id = value;
            }
        }

        /// <summary>
        /// The name of the depot
        /// </summary>
        public required string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(Name));

                _name = value;
            }
        }

        /// <summary>
        /// The telephone number of the depot
        /// </summary>
        public required string? TelephoneNumber { get; set; }

        /// <summary>
        /// The zip code of the depot
        /// </summary>
        public required string ZipCode
        {
            get => _zipCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(ZipCode));

                _zipCode = value;
            }
        }

        /// <summary>
        /// The latitude of the depot
        /// </summary>
        public required string Latitude
        {
            get => _latitude;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(Latitude));

                _latitude = value;
            }
        }

        /// <summary>
        /// The longitude of the depot
        /// </summary>
        public required string Longitude
        {
            get => _longitude;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(Longitude));

                _longitude = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BranchResponseModel"/>
        /// </summary>
        public BranchResponseModel() : base()
        {

        }

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
        [SetsRequiredMembers]
        public BranchResponseModel(string address, string city, string id, string name, string? telephoneNumber, string zipCode, string latitude, string longitude) : this()
        {
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
        [ExcludeFromCodeCoverage]
        public override string ToString() => Id;

        #endregion
    }
}