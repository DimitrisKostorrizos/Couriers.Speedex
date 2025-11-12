using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal request model for the pickup
    /// </summary>
    [XmlRoot("CreatePickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CreatePickupInternalResponseModel : INewWebMethodSoapReturnMessageModel<string>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The result
        /// </summary>
        [XmlElement("CreatePickupResult")]
        public MessageInternalResponseModel<string> Result { get; set; } = new();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CreatePickupInternalResponseModel"/>
        /// </summary>
        public CreatePickupInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result?.Result ?? string.Empty;

        #endregion
    }
}