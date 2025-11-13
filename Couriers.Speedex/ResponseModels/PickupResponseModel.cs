using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup
    /// </summary>
    public record PickupResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="Id"/>
        /// </summary>
        private string _id = default!;

        /// <summary>
        /// The field for the <see cref="ConsignmentIds"/>
        /// </summary>
        private IEnumerable<string> _consignmentIds = default!;

        /// <summary>
        /// The field for the <see cref="CheckpointGroupCode"/>
        /// </summary>
        private string _checkpointGroupCode = default!;

        /// <summary>
        /// The field for the <see cref="Address"/>
        /// </summary>
        private string _address = default!;

        /// <summary>
        /// The field for the <see cref="City"/>
        /// </summary>
        private string _city = default!;

        /// <summary>
        /// The field for the <see cref="CountryCode"/>
        /// </summary>
        private string _countryCode = default!;

        /// <summary>
        /// The field for the <see cref="PostCode"/>
        /// </summary>
        private string _postCode = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public required string Id
        {
            get => _id;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(Id)}' cannot be null or whitespace.", nameof(Id));

                _id = value;
            }
        }

        /// <summary>
        /// The related consignment ids
        /// </summary>
        public required IEnumerable<string> ConsignmentIds
        {
            get => _consignmentIds;
            init
            {
                ArgumentNullException.ThrowIfNull(value);

                _consignmentIds = value;
            }
        }

        /// <summary>
        /// The checkpoint code
        /// </summary>
        public required string? CheckpointCode { get; init; }

        /// <summary>
        /// The group checkpoint code
        /// </summary>
        public required string CheckpointGroupCode
        {
            get => _checkpointGroupCode;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(CheckpointGroupCode)}' cannot be null or whitespace.", nameof(CheckpointGroupCode));

                _checkpointGroupCode = value;
            }
        }

        /// <summary>
        /// The address for the pickup
        /// </summary>
        public required string Address
        {
            get => _address;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(Address)}' cannot be null or whitespace.", nameof(Address));

                _address = value;
            }
        }

        /// <summary>
        /// The city for the pickup
        /// </summary>
        public required string City
        {
            get => _city;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(City)}' cannot be null or whitespace.", nameof(City));

                _city = value;
            }
        }

        /// <summary>
        /// The country code for the pickup
        /// </summary>
        public required string CountryCode
        {
            get => _countryCode;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(CountryCode)}' cannot be null or whitespace.", nameof(CountryCode));

                _countryCode = value;
            }
        }

        /// <summary>
        /// The comments of the pickup
        /// </summary>
        public required string? Comments { get; init; }

        /// <summary>
        /// The name for the pickup
        /// </summary>
        public required string? Name { get; init; }

        /// <summary>
        /// The phone number for the pickup
        /// </summary>
        public required string? PhoneNumber { get; init; }

        /// <summary>
        /// The post code for the pickup
        /// </summary>
        public required string PostCode
        {
            get => _postCode;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(PostCode)}' cannot be null or whitespace.", nameof(PostCode));

                _postCode = value;
            }
        }

        /// <summary>
        /// The pickup date
        /// </summary>
        public required DateOnly PickupDate { get; init; }

        /// <summary>
        /// The start of the time frame of the pickup
        /// </summary>
        public required TimeOnly? PickupTimeFrom { get; init; }

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        public required TimeOnly? PickupTimeTo { get; init; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupResponseModel"/>
        /// </summary>
        public PickupResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="PickupResponseModel"/>
        /// </summary>
        /// <param name="id">The unique pickup id</param>
        /// <param name="consignmentIds">The related consignment ids</param>
        /// <param name="checkpointCode">The checkpoint code</param>
        /// <param name="checkpointGroupCode">The group checkpoint code</param>
        /// <param name="address">The address for the pickup</param>
        /// <param name="city">The city for the pickup</param>
        /// <param name="countryCode">The country code for the pickup</param>
        /// <param name="comments">The comments of the pickup</param>
        /// <param name="name">The name for the pickup</param>
        /// <param name="phoneNumber">The phone number for the pickup</param>
        /// <param name="postCode">The post code for the pickup</param>
        /// <param name="pickupDate">The pickup date</param>
        /// <param name="pickupTimeFrom">The start of the time frame of the pickup</param>
        /// <param name="pickupTimeTo">The end of the time frame of the pickup</param>
        [SetsRequiredMembers]
        public PickupResponseModel(string id, IEnumerable<string> consignmentIds, string? checkpointCode, string checkpointGroupCode,
            string address, string city, string countryCode, string? comments, string? name, string? phoneNumber, string postCode,
            DateOnly pickupDate, TimeOnly? pickupTimeFrom, TimeOnly? pickupTimeTo) : this()
        {
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