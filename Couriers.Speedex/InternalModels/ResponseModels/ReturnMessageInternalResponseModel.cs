using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the return message
    /// </summary>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ReturnMessageInternalResponseModel : ISoapReturnMessageModel, IUnmappedXml
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
        [ExcludeFromCodeCoverage]
        string ISoapReturnMessageModel.Message
        {
            get => ReturnMessage;
            set => ReturnMessage = value;
        }

        /// <summary>
        /// The return code
        /// </summary>
        [ExcludeFromCodeCoverage]
        uint ISoapReturnMessageModel.Code
        {
            get => ReturnCode;
            set => ReturnCode = value;
        }

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
        public ReturnMessageInternalResponseModel() : base()
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