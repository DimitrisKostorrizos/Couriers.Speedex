using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for rescheduling a pickup
    /// </summary>
    [XmlRoot("ReschedulePickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ReschedulePickupInternalResponseModel : INewWebMethodSoapReturnMessageModel<bool>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The return result
        /// </summary>
        [XmlElement("ReschedulePickupResult")]
        public MessageInternalResponseModel<bool> Result { get; set; } = new();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

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