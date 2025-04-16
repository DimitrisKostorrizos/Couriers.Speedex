using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for canceling a consignment
    /// </summary>
    [XmlRoot("CancelBOLResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CancelConsignmentByVoucherIdInternalResponseModel : ReturnMessageInternalResponseModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CancelConsignmentByVoucherIdInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ReturnMessage;

        #endregion
    }
}
