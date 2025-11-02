using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the return message
    /// </summary>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ReturnMessageInternalResponseModel : ISoapReturnMessageModel
    {
        #region Public Properties

        /// <summary>
        /// The return message
        /// </summary>
        [XmlElement("returnMessage")]
        public string ReturnMessage { get; set; } = string.Empty;

        /// <summary>
        /// The return code
        /// </summary>
        [XmlElement("returnCode")]
        public uint ReturnCode { get; set; }

        /// <summary>
        /// The return message
        /// </summary>
        string ISoapReturnMessageModel.Message { get => ReturnMessage; set => ReturnMessage = value; }

        /// <summary>
        /// The return code
        /// </summary>
        uint ISoapReturnMessageModel.Code { get => ReturnCode; set => ReturnCode = value; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ReturnMessageInternalResponseModel"/>
        /// </summary>
        public ReturnMessageInternalResponseModel() : base()
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
