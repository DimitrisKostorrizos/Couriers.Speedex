using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for the pickup
    /// </summary>
    [XmlRoot("CreatePickupResponse", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CreatePickupInternalResponseModel : INewWebMethodSOAPReturnMessageModel<string>
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
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result?.Result ?? string.Empty;

        #endregion
    }
}
