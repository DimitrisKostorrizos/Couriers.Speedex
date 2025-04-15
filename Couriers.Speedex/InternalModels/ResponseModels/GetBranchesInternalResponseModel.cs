using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting the branch depots
    /// </summary>
    [XmlRoot("GetBranchesResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetBranchesInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<IEnumerable<BranchResponseModel>>
    {
        #region Public Properties

#if NET8_0_OR_GREATER
        /// <summary>
        /// The branch depots
        /// </summary>
        [XmlArray("Branches")]
        [XmlArrayItem("Branch")]
        public BranchInternalResponseModel[] BranchDepots { get; set; } = [];
#else
        /// <summary>
        /// The branch depots
        /// </summary>
        [XmlArray("Branches")]
        [XmlArrayItem("Branch")]
        public BranchInternalResponseModel[] BranchDepots { get; set; } = Array.Empty<BranchInternalResponseModel>();
#endif

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
        {
#if NET8_0_OR_GREATER
            return [.. BranchDepots.Select(x => x.ToResponseModel())];
#else
            return BranchDepots.Select(x => x.ToResponseModel()).ToArray();
#endif
        }

        #endregion
    }
}
