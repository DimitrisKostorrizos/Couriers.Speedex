using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the pickup checkpoint
    /// </summary>
    [XmlRoot("Ordercheckpoint", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupCheckpointInternalResponseModel : ISOAPResponseModel<PickupCheckpointResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        [XmlElement("Branch")]
        public string BranchDepot { get; set; } = string.Empty;

        /// <summary>
        /// The date-time of the event
        /// </summary>
        [XmlElement("CheckpointDate")]
        public DateTime CheckpointDate { get; set; }

        /// <summary>
        /// The unique pickup id
        /// </summary>
        [XmlElement("orderID")]
        public string PickupId { get; set; } = string.Empty;

        /// <summary>
        /// The code of the event
        /// </summary>
        [XmlElement("StatusDesc")]
        public string StatusCode { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PickupCheckpointInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => PickupId;

        /// <summary>
        /// Creates and return the <see cref="PickupCheckpointResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupCheckpointResponseModel ToResponseModel() => new PickupCheckpointResponseModel()
        {
            BranchDepot = BranchDepot,
            CheckpointDate = CheckpointDate,
            PickupId = PickupId,
            StatusCode = StatusCode
        };

        #endregion
    }
}
