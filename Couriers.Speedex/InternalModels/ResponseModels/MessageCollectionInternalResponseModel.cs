using Couriers.Speedex.Interfaces;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the list of results
    /// </summary>
    /// <typeparam name="TArrayResult">The type of the array result</typeparam>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class MessageCollectionInternalResponseModel<TArrayResult> : ISoapReturnMessageModel, IUnmappedXml
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
        public TArrayResult[] Result { get; set; } = Array.Empty<TArrayResult>();

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
        [ExcludeFromCodeCoverage]
        public override string ToString() => Message;

        #endregion
    }
}