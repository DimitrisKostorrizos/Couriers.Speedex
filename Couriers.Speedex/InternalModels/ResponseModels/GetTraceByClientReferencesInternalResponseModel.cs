using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for getting the last event of a consignment
    /// </summary>
    [XmlRoot("GetTraceByClientKeyResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetTraceByClientReferencesInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<IEnumerable<CheckpointResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The checkpoints
        /// </summary>
        [XmlArray("checkpoints")]
        [XmlArrayItem("Checkpoint")]
        public CheckpointInternalResponseModel[] Checkpoints { get; set; } = Array.Empty<CheckpointInternalResponseModel>();

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetTraceByClientReferencesInternalResponseModel"/>
        /// </summary>
        public GetTraceByClientReferencesInternalResponseModel() : base()
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
            => $"Checkpoints: {Checkpoints.Length}";

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CheckpointResponseModel> ToResponseModel() 
            => Checkpoints.Select(x => x.ToResponseModel()).ToList();

        #endregion
    }
}