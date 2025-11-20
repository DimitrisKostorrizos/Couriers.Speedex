using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup checkpoint
    /// </summary>
    public record PickupCheckpointResponseModel
    {
        #region Public Properties


        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public string BranchDepot { get; }

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public DateTime CheckpointDate { get; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string PickupId { get; }

        /// <summary>
        /// The code of the event
        /// </summary>
        public string StatusCode { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupCheckpointResponseModel"/>
        /// </summary>
        /// <param name="branchDepot">The name of the depot responsible for the event</param>
        /// <param name="checkpointDate">The date-time of the event</param>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="statusCode">The code of the event</param>
        public PickupCheckpointResponseModel(string branchDepot, DateTime checkpointDate, string pickupId, string statusCode) : base()
        {
            if (string.IsNullOrWhiteSpace(branchDepot))
                throw new ArgumentException($"'{nameof(branchDepot)}' cannot be null or whitespace.", nameof(branchDepot));

            if (string.IsNullOrWhiteSpace(pickupId))
                throw new ArgumentException($"'{nameof(pickupId)}' cannot be null or whitespace.", nameof(pickupId));

            if (string.IsNullOrWhiteSpace(statusCode))
                throw new ArgumentException($"'{nameof(statusCode)}' cannot be null or whitespace.", nameof(statusCode));

            BranchDepot = branchDepot;

            CheckpointDate = checkpointDate;

            PickupId = pickupId;

            StatusCode = statusCode;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString() => PickupId;

        #endregion
    }
}
