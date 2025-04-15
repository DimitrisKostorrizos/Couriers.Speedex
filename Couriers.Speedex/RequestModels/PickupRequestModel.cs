using System;
using System.Collections.Generic;
using System.Linq;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the pickup
    /// </summary>
    public sealed record PickupRequestModel
    {
        #region Private Fields

        /// <summary>
        /// The field of the <see cref="Comments"/>
        /// </summary>
        private string? comments;

        #endregion

        #region Public Properties

        /// <summary>
        /// The ids for the connected master consignments
        /// NOTE: The maximum count is 5 master consignment numbers
        /// </summary>
        public IEnumerable<string> ConsignmentIds { get; }


#if NET5_0
        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public DateTime PickupDate { get; }
#else
        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public DateOnly PickupDate { get; }
#endif

        /// <summary>
        /// The delivery time
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; }

        /// <summary>
        /// The comments
        /// </summary>
        public string? Comments
        {
            get => comments;
            init
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                comments = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="consignmentIds">The ids for the connected master consignments</param>
        /// <param name="pickupDate">The date for the pickup</param>
        /// <param name="deliveryTime">The delivery time frame</param>
        public PickupRequestModel(IEnumerable<string> consignmentIds,
#if NET5_0
            DateTime pickupDate,
#else
            DateOnly pickupDate,
#endif
            DeliveryTimeLimit deliveryTime) : base()
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(consignmentIds);
#else
            if (consignmentIds is null)
                throw new ArgumentNullException(nameof(consignmentIds));
#endif

            var consignmentCount = consignmentIds.Count();

            if (consignmentCount == 0)
                throw new ArgumentOutOfRangeException(nameof(consignmentIds), "At least consignment id has to be specified.");

            if (consignmentCount > SpeedexConstants.MaximumNumberOfConsignments)
                throw new ArgumentOutOfRangeException(nameof(consignmentIds), $"The maximum number of consignments is {SpeedexConstants.MaximumNumberOfConsignments}.");

            ConsignmentIds = consignmentIds;

            PickupDate = pickupDate;

            DeliveryTime = deliveryTime;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="consignmentId">The id for the connected master consignment</param>
        /// <param name="pickupDate">The date for the pickup</param>
        /// <param name="deliveryTime">The delivery time frame</param>
        public PickupRequestModel(string consignmentId,
#if NET5_0
            DateTime pickupDate,
#else
            DateOnly pickupDate,
#endif
            DeliveryTimeLimit deliveryTime) : this(
#if NET8_0_OR_GREATER
                [consignmentId],
#else
                new string[] { consignmentId },
#endif
                pickupDate, deliveryTime)
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(consignmentId);
#else
            if (string.IsNullOrWhiteSpace(consignmentId))
                throw new ArgumentException($"'{nameof(consignmentId)}' cannot be null or whitespace.", nameof(consignmentId));
#endif
        }

#endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Number of Consignments: {ConsignmentIds.Count()}";

        #endregion
    }
}
