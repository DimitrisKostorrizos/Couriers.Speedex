using Couriers.Speedex.Interfaces;

using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the message
    /// </summary>
    /// <typeparam name="TResult">The type of result</typeparam>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class MessageInternalResponseModel<TResult> : ISoapReturnMessageModel, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The return message
        /// </summary>
        [XmlElement("Message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The result
        /// </summary>
        [XmlElement("Result")]
        public TResult Result { get; set; } = default!;

        /// <summary>
        /// The return code
        /// </summary>
        [XmlElement("Code")]
        public uint Code { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="MessageInternalResponseModel{TResult}"/>
        /// </summary>
        public MessageInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Message;

        #endregion
    }
}