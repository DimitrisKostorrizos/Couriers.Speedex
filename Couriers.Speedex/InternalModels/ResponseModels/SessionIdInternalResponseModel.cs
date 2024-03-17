using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the unique session id
    /// </summary>
    [XmlRoot("CreateSessionResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlInclude(typeof(SessionIdInternalResponseModel))]
    public class SessionIdInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<string>
    {
        #region Public Properties

        /// <summary>
        /// The unique session id
        /// </summary>
        [XmlElement("sessionId")]
        public string SessionId { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SessionIdInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => SessionId;

        /// <summary>
        /// Creates and return the <see cref="SessionId"/> from the current object
        /// </summary>
        /// <returns></returns>
        public string ToResponseModel() => SessionId;

        #endregion
    }
}
