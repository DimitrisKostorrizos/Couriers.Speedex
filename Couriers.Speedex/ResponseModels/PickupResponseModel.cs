using System;
using System.Collections.Generic;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup
    /// </summary>
    public record PickupResponseModel
    {
        #region Public Properties

#if NET7_0_OR_GREATER
        /// <summary>
        /// The unique pickup id
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
        /// The related consignment ids
        /// </summary>
        public required IEnumerable<string> ConsignmentIds
        {
            get;
            init
            {
                ArgumentNullException.ThrowIfNull(value);

                field = value;
            }
        }

        /// <summary>
        /// The checkpoint code
        /// </summary>
        public required string CheckpointCode
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
        /// The group checkpoint code
        /// </summary>
        public required string CheckpointGroupCode
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
        /// The address for the pickup
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
        /// The city for the pickup
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
        /// The country code for the pickup
        /// </summary>
        public required string CountryCode
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
        /// The comments of the pickup
        /// </summary>
        public string? Comments { get; init; }

        /// <summary>
        /// The pickup date
        /// </summary>
        public required DateOnly PickupDate { get; init; }

        /// <summary>
        /// The name for the pickup
        /// </summary>
        public string? Name { get; init; }

        /// <summary>
        /// The phone number for the pickup
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// The post code for the pickup
        /// </summary>
        public required string PostCode
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
        /// The start of the time frame of the pickup
        /// </summary>
        public TimeOnly? PickupTimeFrom { get; init; }

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        public TimeOnly? PickupTimeTo { get; init; }
#else
        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The related consignment ids
        /// </summary>
        public IEnumerable<string> ConsignmentIds { get;}

        /// <summary>
        /// The checkpoint code
        /// </summary>
        public string CheckpointCode { get;}

        /// <summary>
        /// The group checkpoint code
        /// </summary>
        public string CheckpointGroupCode { get; }

        /// <summary>
        /// The address for the pickup
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// The city for the pickup
        /// </summary>
        public string City { get; }

        /// <summary>
        /// The country code for the pickup
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// The comments of the pickup
        /// </summary>
        public string? Comments { get; }

        /// <summary>
        /// The name for the pickup
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// The phone number for the pickup
        /// </summary>
        public string? PhoneNumber { get; }

        /// <summary>
        /// The post code for the pickup
        /// </summary>
        public string PostCode { get;}

#if NET5_0
        /// <summary>
        /// The pickup date
        /// </summary>
        public DateTime PickupDate { get; }

        /// <summary>
        /// The start of the time frame of the pickup
        /// </summary>
        public DateTime? PickupTimeFrom { get; }

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        public DateTime? PickupTimeTo { get; }
#else
        /// <summary>
        /// The pickup date
        /// </summary>
        public DateOnly PickupDate { get; }

        /// <summary>
        /// The start of the time frame of the pickup
        /// </summary>
        public TimeOnly? PickupTimeFrom { get; }

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        public TimeOnly? PickupTimeTo { get; }
#endif

#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER
        /// <summary>
        /// Creates a new instance of <see cref="PickupResponseModel"/>
        /// </summary>
        public PickupResponseModel() : base()
        {

        }
#else
        /// <summary>
        /// Creates a new instance of <see cref="PickupResponseModel"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consignmentIds"></param>
        /// <param name="checkpointCode"></param>
        /// <param name="checkpointGroupCode"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="countryCode"></param>
        /// <param name="comments"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="postCode"></param>
        /// <param name="pickupDate">The pickup date</param>
        /// <param name="pickupTimeFrom">The start of the time frame of the pickup</param>
        /// <param name="pickupTimeTo">The end of the time frame of the pickup</param>
        public PickupResponseModel(string id, IEnumerable<string> consignmentIds, string checkpointCode, string checkpointGroupCode,
            string address, string city, string countryCode, string? comments, string? name, string? phoneNumber, string postCode,
#if NET5_0
        DateTime pickupDate, DateTime? pickupTimeFrom, DateTime? pickupTimeTo
#else
            DateOnly pickupDate, TimeOnly? pickupTimeFrom, TimeOnly? pickupTimeTo
#endif
            ) : base()
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

            if (consignmentIds is null)
                throw new ArgumentNullException(nameof(consignmentIds));

            if (string.IsNullOrWhiteSpace(checkpointCode))
                throw new ArgumentException($"'{nameof(checkpointCode)}' cannot be null or whitespace.", nameof(checkpointCode));

            if (string.IsNullOrWhiteSpace(checkpointGroupCode))
                throw new ArgumentException($"'{nameof(checkpointGroupCode)}' cannot be null or whitespace.", nameof(checkpointGroupCode));

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace.", nameof(city));

            if (string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentException($"'{nameof(countryCode)}' cannot be null or whitespace.", nameof(countryCode));

            if (string.IsNullOrWhiteSpace(postCode))
                throw new ArgumentException($"'{nameof(postCode)}' cannot be null or whitespace.", nameof(postCode));

            Id = id;
            ConsignmentIds = consignmentIds;
            CheckpointCode = checkpointCode;
            CheckpointGroupCode = checkpointGroupCode;
            Address = address;
            City = city;
            CountryCode = countryCode;
            Comments = comments;
            Name = name;
            PhoneNumber = phoneNumber;
            PostCode = postCode;
            PickupDate = pickupDate;
            PickupTimeFrom = pickupTimeFrom;
            PickupTimeFrom = pickupTimeFrom;
            PickupTimeTo = pickupTimeTo;
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
