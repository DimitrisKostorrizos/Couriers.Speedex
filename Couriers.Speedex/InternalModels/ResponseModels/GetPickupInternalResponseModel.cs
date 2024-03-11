using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting a pickup
    /// </summary>
    [XmlRoot("GetPickupResponse", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetPickupInternalResponseModel : INewWebMethodSOAPReturnMessageModel<PickupInternalResponseModel>, ISOAPResponseModel<PickupResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The return result
        /// </summary>
        [XmlElement("GetPickupResult")]
        public MessageInternalResponseModel<PickupInternalResponseModel> Result { get; set; } = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetPickupInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result.Result?.ToString() ?? string.Empty;

        /// <summary>
        /// Creates and return the <see cref="PickupResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public PickupResponseModel ToResponseModel() => Result.Result?.ToResponseModel() ?? new PickupResponseModel();

        #endregion
    }
}
