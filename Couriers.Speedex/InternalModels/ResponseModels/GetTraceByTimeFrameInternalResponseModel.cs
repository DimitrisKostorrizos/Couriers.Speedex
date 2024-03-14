using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for all the new checkpoints of the consignments, in a specific time frame
    /// </summary>
    [XmlRoot("GetTraceByDateResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetTraceByTimeFrameInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<IEnumerable<CheckpointResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The checkpoints
        /// </summary>
        [XmlArray("checkpoints")]
        [XmlArrayItem("Checkpoint")]
        public List<CheckpointInternalResponseModel> Checkpoints { get; set; } = [];

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetTraceByTimeFrameInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Checkpoints.Count.ToString();

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{CheckpointResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CheckpointResponseModel> ToResponseModel() => Checkpoints.Select(x => x.ToResponseModel()).ToList();

        #endregion
    }
}
