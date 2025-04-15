using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Couriers.Speedex
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <typeparam name="TRequest">The type of the request</typeparam>
    /// <typeparam name="TResponse">The type of the response</typeparam>
    public sealed class TypedStringContent<TRequest, TResponse> : TypedStringContent
    {
        #region Public Properties

        /// <summary>
        /// The request type
        /// </summary>
        public override Type RequestType { get; } = typeof(TRequest);

        /// <summary>
        /// The type of the response
        /// </summary>
        public override Type ResponseType { get; } = typeof(TResponse);

        #endregion

        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        public TypedStringContent(string content) : base(content)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="encoding">The encoding</param>
        public TypedStringContent(string content, Encoding? encoding) : base(content, encoding)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="encoding">The encoding</param>
        /// <param name="mediaType">The media type</param>
        public TypedStringContent(string content, Encoding? encoding, string mediaType) : base(content, encoding, mediaType)
        {

        }
#if NET7_0_OR_GREATER

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="mediaType">The media type</param>
        public TypedStringContent(string content, MediaTypeHeaderValue mediaType) : base(content, mediaType)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="encoding">The encoding</param>
        /// <param name="mediaType">The media type</param>
        public TypedStringContent(string content, Encoding? encoding, MediaTypeHeaderValue mediaType) : base(content, encoding, mediaType)
        {

        }

#endif
        #endregion
    }

    /// <summary>
    /// A <see cref="StringContent"/> that contains the expected type of the request and response payload
    /// </summary>
    public abstract class TypedStringContent : StringContent
    {
        #region Public Properties

        /// <summary>
        /// The request type
        /// </summary>
        public abstract Type RequestType { get; }

        /// <summary>
        /// The type of the response
        /// </summary>
        public abstract Type ResponseType { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        protected TypedStringContent(string content) : base(content)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="encoding">The encoding</param>
        protected TypedStringContent(string content, Encoding? encoding) : base(content, encoding)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="encoding">The encoding</param>
        /// <param name="mediaType">The media type</param>
        protected TypedStringContent(string content, Encoding? encoding, string mediaType) : base(content, encoding, mediaType)
        {

        }
#if NET7_0_OR_GREATER

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="mediaType">The media type</param>
        protected TypedStringContent(string content, MediaTypeHeaderValue mediaType) : base(content, mediaType)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="encoding">The encoding</param>
        /// <param name="mediaType">The media type</param>
        protected TypedStringContent(string content, Encoding? encoding, MediaTypeHeaderValue mediaType) : base(content, encoding, mediaType)
        {

        }

#endif
        #endregion
    }
}
