using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup checkpoint
    /// </summary>
    public record PickupCheckpointResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="BranchDepot"/>
        /// </summary>
        private string _branchDepot = default!;

        /// <summary>
        /// The field for the <see cref="PickupId"/>
        /// </summary>
        private string _pickupId = default!;

        /// <summary>
        /// The field for the <see cref="StatusCode"/>
        /// </summary>
        private string _statusCode = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public required string BranchDepot
        {
            get => _branchDepot;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(BranchDepot)}' cannot be null or whitespace.", nameof(BranchDepot));

                _branchDepot = value;
            }
        }

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public required DateTime CheckpointDate { get; set; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public required string PickupId
        {
            get => _pickupId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(PickupId)}' cannot be null or whitespace.", nameof(PickupId));

                _pickupId = value;
            }
        }

        /// <summary>
        /// The code of the event
        /// </summary>
        public string StatusCode
        {
            get => _statusCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(StatusCode)}' cannot be null or whitespace.", nameof(StatusCode));

                _statusCode = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupCheckpointResponseModel"/>
        /// </summary>
        public PickupCheckpointResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="PickupCheckpointResponseModel"/>
        /// </summary>
        /// <param name="branchDepot">The name of the depot responsible for the event</param>
        /// <param name="checkpointDate">The date-time of the event</param>
        /// <param name="pickupId">The unique pickup id</param>
        /// <param name="statusCode">The code of the event</param>
        [SetsRequiredMembers]
        public PickupCheckpointResponseModel(string branchDepot, DateTime checkpointDate, string pickupId, string statusCode) : this()
        {
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
