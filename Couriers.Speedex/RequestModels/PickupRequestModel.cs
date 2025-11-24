using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Couriers.Speedex.RequestModels
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

        /// <summary>
        /// The field of the <see cref="ConsignmentIds"/>
        /// </summary>
        private IEnumerable<string> consignmentIds = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The ids for the connected master consignments
        /// NOTE: The maximum count is 5 master consignment numbers
        /// </summary>
        public required IEnumerable<string> ConsignmentIds
        {
            get => consignmentIds;
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                var consignmentCount = value.Count();

                if (consignmentCount == 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "At least consignment id has to be specified.");

                if (consignmentCount > SpeedexConstants.MaximumNumberOfConsignments)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The maximum number of consignments is {SpeedexConstants.MaximumNumberOfConsignments}.");

                if (value.Any(x => string.IsNullOrWhiteSpace(x)))
                    throw new ArgumentException($"All the consignment ids cannot be null or whitespace.", nameof(value));

                consignmentIds = value;
            }
        }

        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public required DateOnly PickupDate { get; set; }

        /// <summary>
        /// The delivery time
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string? Comments
        {
            get => comments;
            set
            {
                SpeedexHelpers.ThrowIfInvalidComments(value);

                comments = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupRequestModel"/>
        /// </summary>
        public PickupRequestModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="PickupRequestModel"/>
        /// </summary>
        /// <param name="consignmentIds">The ids for the connected master consignments</param>
        /// <param name="pickupDate">The date for the pickup</param>
        [SetsRequiredMembers]
        public PickupRequestModel(IEnumerable<string> consignmentIds, DateOnly pickupDate) : this()
        {
            ConsignmentIds = consignmentIds;

            PickupDate = pickupDate;
        }

        /// <summary>
        /// Creates a new instance of <see cref="PickupRequestModel"/>
        /// </summary>
        /// <param name="consignmentId">The id for the connected master consignment</param>
        /// <param name="pickupDate">The date for the pickup</param>
        [SetsRequiredMembers]
        public PickupRequestModel(string consignmentId, DateOnly pickupDate) : this(new string[] { consignmentId }, pickupDate)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString()
            => $"Consignments: {ConsignmentIds.Count()}";

        #endregion
    }
}