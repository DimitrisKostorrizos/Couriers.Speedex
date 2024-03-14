using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the branch depot
    /// </summary>
    [XmlRoot("GetBranches", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class BranchInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The language that the results will be translated to
        /// </summary>
        [XmlElement("language")]
        public uint Language { get; set; }

        /// <summary>
        /// The zip code
        /// </summary>
        [XmlElement("zipCode")]
        public string? ZipCode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
