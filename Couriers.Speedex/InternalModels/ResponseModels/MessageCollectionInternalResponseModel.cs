using Couriers.Speedex.Interfaces;

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the list of results
    /// </summary>
    /// <typeparam name="TArrayResult">The type of the array result</typeparam>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class MessageCollectionInternalResponseModel<TArrayResult> : ISoapReturnMessageModel
    {
        #region Public Properties

#pragma warning disable CA1819 // Properties should not return arrays

        /// <summary>
        /// The return message
        /// </summary>
        [XmlElement("Message")]
        public string Message { get; set; } = string.Empty;

#if NET8_0_OR_GREATER
        /// <summary>
        /// The result
        /// </summary>
        [XmlArray("Result")]
        public TArrayResult[] Result { get; set; } = [];
#else
        /// <summary>
        /// The result
        /// </summary>
        [XmlArray("Result")]
        public TArrayResult[] Result { get; set; } = Array.Empty<TArrayResult>();
#endif

        /// <summary>
        /// The return code
        /// </summary>
        [XmlElement("Code")]
        public uint Code { get; set; }

#pragma warning restore CA1819 // Properties should not return arrays

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="MessageCollectionInternalResponseModel{TArrayResult}"/>
        /// </summary>
        public MessageCollectionInternalResponseModel() : base()
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
