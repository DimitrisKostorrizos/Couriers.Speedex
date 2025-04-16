using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the pickup checkpoint
    /// </summary>
    public sealed record PickupCheckpointResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public string BranchDepot { get; set; } = string.Empty;

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public DateTime CheckpointDate { get; set; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        public string PickupId { get; set; } = string.Empty;

        /// <summary>
        /// The code of the event
        /// </summary>
        public string StatusCode { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PickupCheckpointResponseModel() : base()
        {

        }

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
