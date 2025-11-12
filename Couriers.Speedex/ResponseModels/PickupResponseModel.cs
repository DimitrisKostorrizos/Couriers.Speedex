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

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The related consignment ids
        /// </summary>
        public IEnumerable<string> ConsignmentIds { get; }

        /// <summary>
        /// The checkpoint code
        /// </summary>
        public string? CheckpointCode { get; }

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
        public string PostCode { get; }

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

        #endregion

        #region Constructors

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
        public PickupResponseModel(string id, IEnumerable<string> consignmentIds, string? checkpointCode, string checkpointGroupCode,
            string address, string city, string countryCode, string? comments, string? name, string? phoneNumber, string postCode,
            DateTime pickupDate, DateTime? pickupTimeFrom, DateTime? pickupTimeTo) : base()
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

            ArgumentNullException.ThrowIfNull(consignmentIds);

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
