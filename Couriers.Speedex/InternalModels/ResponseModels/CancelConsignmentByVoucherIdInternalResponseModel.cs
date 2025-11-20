using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
        /// Creates a new instance of <see cref="CancelConsignmentByVoucherIdInternalResponseModel"/>
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
        [ExcludeFromCodeCoverage]
        public override string ToString() => ReturnMessage;

        #endregion
    }
}