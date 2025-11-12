using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the session id
    /// </summary>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The unique session id
        /// </summary>
        [XmlElement("sessionID")]
        public string? SessionId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SessionIdInternalRequestModel"/>
        /// </summary>
        public SessionIdInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
