using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal request model for canceling a pickup
    /// </summary>
    [XmlRoot("CancelPickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CancelPickupInternalResponseModel : INewWebMethodSoapReturnMessageModel<bool>
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
        /// Creates a new instance of <see cref="CancelPickupInternalResponseModel"/>
        /// </summary>
        public CancelPickupInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result.Result ? "Successful" : "Unsuccessful";

        #endregion
    }
}
