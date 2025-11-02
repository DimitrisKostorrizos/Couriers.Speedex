using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for rescheduling a pickup
    /// </summary>
    [XmlRoot("ReschedulePickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ReschedulePickupInternalResponseModel : INewWebMethodSoapReturnMessageModel<bool>
    {
        #region Public Properties

        /// <summary>
        /// The return result
        /// </summary>
        [XmlElement("ReschedulePickupResult")]
        public MessageInternalResponseModel<bool> Result { get; set; } = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReturnMessageInternalResponseModel"/>
        /// </summary>
        public ReschedulePickupInternalResponseModel() : base()
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
