using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the unique session id
    /// </summary>
    [XmlRoot("CreateSessionResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlInclude(typeof(SessionIdInternalResponseModel))]
    public class SessionIdInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<string>
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
        /// Creates a new instance of <see cref="SessionIdInternalResponseModel"/>
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