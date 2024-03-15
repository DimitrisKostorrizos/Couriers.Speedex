using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for all the new checkpoints of the consignment
    /// </summary>
    [XmlRoot("GetTraceByVoucherResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetTraceByVoucherIdInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<IEnumerable<CheckpointResponseModel>>
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
        public GetTraceByVoucherIdInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Checkpoints: {Checkpoints.Count}";

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{CheckpointResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CheckpointResponseModel> ToResponseModel() => Checkpoints.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
