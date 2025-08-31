using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup checkpoint
    /// </summary>
    public record PickupCheckpointResponseModel
    {
        #region Public Properties

#if NET7_0_OR_GREATER
        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public required string BranchDepot
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
        /// The date-time of the event
        /// </summary>
        public required DateTime CheckpointDate { get; init; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public required string PickupId
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
        /// The code of the event
        /// </summary>
        public required string StatusCode
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
#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER
        /// <summary>
        /// Default constructor
        /// </summary>
        public PickupCheckpointResponseModel() : base()
        {

        }
#else
        /// <summary>
        /// Default constructor
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
#endif

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => PickupId;

        #endregion
    }
}
