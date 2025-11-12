using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for getting a pickup
    /// </summary>
    [XmlRoot("GetPickupResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetPickupInternalResponseModel : INewWebMethodSoapReturnMessageModel<PickupInternalResponseModel>, ISoapResponseModel<PickupResponseModel>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The return result
        /// </summary>
        [XmlElement("GetPickupResult")]
        public MessageInternalResponseModel<PickupInternalResponseModel> Result { get; set; } = new();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetPickupInternalResponseModel"/>
        /// </summary>
        public GetPickupInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result.Result.ToString();

        /// <summary>
        /// Creates and return the <see cref="PickupResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupResponseModel ToResponseModel() => Result.Result.ToResponseModel();

        #endregion
    }
}