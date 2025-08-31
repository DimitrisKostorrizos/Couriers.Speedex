using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the branch depot
    /// </summary>
    public record BranchResponseModel
    {
        #region Public Properties
#if NET7_0_OR_GREATER

        /// <summary>
        /// The address of the depot
        /// </summary>
        public required string Address
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
        /// The city of the depot
        /// </summary>
        public required string City
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
        /// The unique id of the depot
        /// </summary>
        public required string Id
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
        /// The name of the depot
        /// </summary>
        public required string Name
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
        /// The telephone number of the depot
        /// </summary>
        public required string TelephoneNumber
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
        /// The zip code of the depot
        /// </summary>
        public required string ZipCode
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
        /// The latitude of the depot
        /// </summary>
        public required string Latitude
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
        /// The longitude of the depot
        /// </summary>
        public required string Longitude
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
#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchResponseModel() : base()
        {

        }
#else
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
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace.", nameof(city));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            if (string.IsNullOrWhiteSpace(telephoneNumber))
                throw new ArgumentException($"'{nameof(telephoneNumber)}' cannot be null or whitespace.", nameof(telephoneNumber));

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
#endif

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
