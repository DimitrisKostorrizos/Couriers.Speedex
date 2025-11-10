using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the pickup checkpoint
    /// </summary>
    [XmlRoot("Ordercheckpoint", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PickupCheckpointInternalResponseModel : ISoapResponseModel<PickupCheckpointResponseModel>, IUnmappedXml
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupCheckpointInternalResponseModel"/>
        /// </summary>
        public PickupCheckpointInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => PickupId;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public PickupCheckpointResponseModel ToResponseModel()
            => new(BranchDepot, CheckpointDate, PickupId, StatusCode);

        #endregion
    }
}