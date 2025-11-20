using Couriers.Speedex.Enums;

using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.RequestModels
{
    /// <summary>
    /// The request model for rescheduling a pickup
    /// </summary>
    public sealed record ReschedulePickupRequestModel
    {
        #region Private Fields

        /// <summary>
        /// The field of the <see cref="Comments"/>
        /// </summary>
        private string? comments;

        /// <summary>
        /// The field of the <see cref="PickupId"/>
        /// </summary>
        private string pickupId = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public required DateOnly PickupDate { get; set; }

        /// <summary>
        /// The delivery time frame
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; set; }

        /// <summary>
        /// The comments for the pickup
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

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public required string PickupId
        {
            get => pickupId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(PickupId)}' cannot be null or whitespace.", nameof(PickupId));

                pickupId = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReschedulePickupRequestModel"/>
        /// </summary>
        public ReschedulePickupRequestModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ReschedulePickupRequestModel"/>
        /// </summary>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="pickupDate">The date for the pickup</param>
        [SetsRequiredMembers]
        public ReschedulePickupRequestModel(string pickupId, DateOnly pickupDate) : this()
        {
            PickupId = pickupId;

            PickupDate = pickupDate;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString() 
            => $"Pickup: {PickupId}, Pickup Date: {PickupDate}";

        #endregion
    }
}