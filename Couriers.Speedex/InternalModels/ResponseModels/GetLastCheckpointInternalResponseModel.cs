using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting the last event of a consignment
    /// </summary>
    [XmlRoot("GetLastCheckpointResponse", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetLastCheckpointInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<CheckpointResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The last checkpoint
        /// </summary>
        [XmlElement("checkpoint")]
        public CheckpointInternalResponseModel LastCheckPoint { get; set; } = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetLastCheckpointInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => LastCheckPoint.ToString();

        /// <summary>
        /// Creates and return the <see cref="CheckpointResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public CheckpointResponseModel ToResponseModel() => LastCheckPoint.ToResponseModel();

        #endregion
    }
}
