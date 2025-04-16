using System;
using System.Collections.Generic;
using System.Linq;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup
    /// </summary>
    public sealed record PickupResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string Id { get; set; } = string.Empty;

#if NET8_0_OR_GREATER
        /// <summary>
        /// The related consignment ids
        /// </summary>
        public IEnumerable<string> ConsignmentIds { get; set; } = [];
#else
        /// <summary>
        /// The related consignment ids
        /// </summary>
        public IEnumerable<string> ConsignmentIds { get; set; } = Enumerable.Empty<string>();
#endif

        /// <summary>
        /// The checkpoint code
        /// </summary>
        public string CheckpointCode { get; set; } = string.Empty;

        /// <summary>
        /// The group checkpoint code
        /// </summary>
        public string CheckpointGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// The address for the pickup
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city for the pickup
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The country code for the pickup
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The comments of the pickup
        /// </summary>
        public string Comments { get; set; } = string.Empty;

#if NET5_0
        /// <summary>
        /// The pickup date
        /// </summary>
        public DateTime PickupDate { get; set; }
#else
        /// <summary>
        /// The pickup date
        /// </summary>
        public DateOnly PickupDate { get; set; }
#endif

        /// <summary>
        /// The name for the pickup
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The phone number for the pickup
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The post code for the pickup
        /// </summary>
        public string PostCode { get; set; } = string.Empty;

#if NET5_0
        /// <summary>
        /// The start of the time frame of the pickup
        /// </summary>
        public DateTime? PickupTimeFrom { get; set; }

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        public DateTime? PickupTimeTo { get; set; }
#else
        /// <summary>
        /// The start of the time frame of the pickup
        /// </summary>
        public TimeOnly? PickupTimeFrom { get; set; }

        /// <summary>
        /// The end of the time frame of the pickup
        /// </summary>
        public TimeOnly? PickupTimeTo { get; set; }
#endif

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PickupResponseModel() : base()
        {

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
