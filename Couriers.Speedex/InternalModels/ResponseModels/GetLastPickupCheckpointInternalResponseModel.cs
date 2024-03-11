using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting the last pickup checkpoint
    /// </summary>
    [XmlRoot("GetOrderLastCheckpointResponse", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetLastPickupCheckpointInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<PickupCheckpointResponseModel>
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
        /// Returns a string that represents the current object.
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
