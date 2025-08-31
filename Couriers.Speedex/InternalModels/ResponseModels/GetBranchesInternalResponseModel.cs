using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for getting the branch depots
    /// </summary>
    [XmlRoot("GetBranchesResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetBranchesInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<IEnumerable<BranchResponseModel>>
    {
        #region Public Properties

#pragma warning disable CA1819 // Properties should not return arrays

        /// <summary>
        /// The branch depots
        /// </summary>
        [XmlArray("Branches")]
        [XmlArrayItem("Branch")]
        public BranchInternalResponseModel[] BranchDepots { get; set; } = [];

#pragma warning restore CA1819 // Properties should not return arrays

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetBranchesInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Branch Depots: {BranchDepots.Length}";

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BranchResponseModel> ToResponseModel() 
            => [.. BranchDepots.Select(x => x.ToResponseModel())];

        #endregion
    }
}
