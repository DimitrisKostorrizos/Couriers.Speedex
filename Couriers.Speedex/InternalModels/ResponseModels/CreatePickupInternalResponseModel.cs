using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the pickup
    /// </summary>
    [XmlRoot("CreatePickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CreatePickupInternalResponseModel : INewWebMethodSoapReturnMessageModel<string>
    {
        #region Public Properties

        /// <summary>
        /// The result
        /// </summary>
        [XmlElement("CreatePickupResult")]
        public MessageInternalResponseModel<string> Result { get; set; } = new MessageInternalResponseModel<string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
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
