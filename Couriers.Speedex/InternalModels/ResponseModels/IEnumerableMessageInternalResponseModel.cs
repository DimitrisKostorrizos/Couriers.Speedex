using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the list of results
    /// </summary>
    /// <typeparam name="TArrayResult">The type of the array result</typeparam>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class IEnumerableMessageInternalResponseModel<TArrayResult> : ISOAPReturnMessageModel
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
        [XmlArray("Result")]
        public List<TArrayResult> Result { get; set; } = new();

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
        public IEnumerableMessageInternalResponseModel() : base()
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
