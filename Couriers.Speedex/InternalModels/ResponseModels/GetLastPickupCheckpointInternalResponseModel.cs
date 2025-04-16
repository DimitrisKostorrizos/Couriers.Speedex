using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for getting the last pickup checkpoint
    /// </summary>
    [XmlRoot("GetOrderLastCheckpointResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetLastPickupCheckpointInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<PickupCheckpointResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The last checkpoint
        /// </summary>
        [XmlElement("Ordercheckpoint")]
        public PickupCheckpointInternalResponseModel LastCheckpoint { get; set; } = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetLastPickupCheckpointInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => LastCheckpoint.ToString();

        /// <summary>
        /// Creates and return the <see cref="PickupCheckpointResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupCheckpointResponseModel ToResponseModel() => LastCheckpoint.ToResponseModel();

        #endregion
    }
}
