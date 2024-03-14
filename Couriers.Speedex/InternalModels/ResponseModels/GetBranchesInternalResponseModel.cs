using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting the branch depots
    /// </summary>
    [XmlRoot("GetBranchesResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetBranchesInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<IEnumerable<BranchResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The branch depots
        /// </summary>
        [XmlArray("Branches")]
        [XmlArrayItem("Branch")]
        public BranchInternalResponseModel[] BranchDepots { get; set; } = [];

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
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => BranchDepots.Length.ToString();

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{BranchResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BranchResponseModel> ToResponseModel() => BranchDepots.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
