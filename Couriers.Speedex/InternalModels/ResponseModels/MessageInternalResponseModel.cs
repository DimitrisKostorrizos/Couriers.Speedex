using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the message
    /// </summary>
    /// <typeparam name="TResult">The type of result</typeparam>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class MessageInternalResponseModel<TResult> : ISOAPReturnMessageModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Message;

        #endregion
    }
}
