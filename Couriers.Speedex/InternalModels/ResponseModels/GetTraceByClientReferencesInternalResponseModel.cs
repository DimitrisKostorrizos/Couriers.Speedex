using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting the last event of a consignment
    /// </summary>
    [XmlRoot("GetTraceByClientKeyResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetTraceByClientReferencesInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<IEnumerable<CheckpointResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The checkpoints
        /// </summary>
        [XmlArray("checkpoints")]
        [XmlArrayItem("Checkpoint")]
        public CheckpointInternalResponseModel[] Checkpoints { get; set; } = null!;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetTraceByClientReferencesInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Checkpoints.Length.ToString();

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{CheckpointResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CheckpointResponseModel> ToResponseModel() => Checkpoints.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
