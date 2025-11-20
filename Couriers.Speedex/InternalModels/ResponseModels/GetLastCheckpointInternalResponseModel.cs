using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for getting the last event of a consignment
    /// </summary>
    [XmlRoot("GetLastCheckpointResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetLastCheckpointInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<CheckpointResponseModel>
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
        /// Creates a new instance of <see cref="GetLastCheckpointInternalResponseModel"/>
        /// </summary>
        public GetLastCheckpointInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString() 
            => LastCheckPoint.ToString();

        /// <summary>
        /// Creates and return the <see cref="CheckpointResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public CheckpointResponseModel ToResponseModel() 
            => LastCheckPoint.ToResponseModel();

        #endregion
    }
}