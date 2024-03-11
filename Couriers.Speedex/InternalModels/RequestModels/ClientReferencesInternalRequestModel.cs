using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the client references
    /// </summary>
    [XmlRoot("GetTraceByClientKey", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ClientReferencesInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The first client reference for searching the consignments
        /// </summary>
        [XmlElement("ClientKey1")]
        public string? FirstClientReference { get; set; }

        /// <summary>
        /// The second client reference for searching the consignments
        /// </summary>
        [XmlElement("ClientKey2")]
        public string? SecondClientReference { get; set; }

        /// <summary>
        /// The third client reference for searching the consignments
        /// </summary>
        [XmlElement("ClientKey3")]
        public string? ThirdClientReference { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientReferencesInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="ClientReferencesInternalRequestModel"/> from the <paramref name="value"/>
        /// </summary>
        /// <param name="value">The request model</param>
        /// <returns></returns>
        public static ClientReferencesInternalRequestModel FromRequestModel(ClientReferencesRequestModel value) => new ClientReferencesInternalRequestModel()
        {
            FirstClientReference = value.FirstClientReference,
            SecondClientReference = value.SecondClientReference,
            ThirdClientReference = value.ThirdClientReference
        };

        #endregion
    }
}
