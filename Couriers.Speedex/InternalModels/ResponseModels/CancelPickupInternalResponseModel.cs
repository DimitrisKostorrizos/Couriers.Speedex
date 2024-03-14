using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for canceling a pickup
    /// </summary>
    [XmlRoot("CancelPickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CancelPickupInternalResponseModel : INewWebMethodSOAPReturnMessageModel<bool>
    {
        #region Public Properties

        /// <summary>
        /// The result
        /// </summary>
        [XmlElement("CancelPickupResult")]
        public MessageInternalResponseModel<bool> Result { get; set; } = new MessageInternalResponseModel<bool>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CancelPickupInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result.Result ? "Successful" : "Unsuccessful";

        #endregion
    }
}
