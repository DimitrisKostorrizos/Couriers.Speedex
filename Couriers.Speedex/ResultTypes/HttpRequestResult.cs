using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Couriers.Speedex
{
    /// <summary>
    /// The result type for a HTTP request operation
    /// </summary>
    public class HttpRequestResult
    {
        #region Constants

        /// <summary>
        /// The message used when the result is successful
        /// </summary>
        public const string SuccessfulMessage = "Success";

        #endregion

        #region Public Properties

        /// <summary>
        /// The request payload
        /// </summary>
        public string? RequestPayload { get; }

        /// <summary>
        /// The response payload
        /// </summary>
        public string? ResponsePayload { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [MemberNotNullWhen(false, nameof(ErrorMessage))]
        public bool IsSuccessful => string.IsNullOrWhiteSpace(ErrorMessage);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string? ErrorMessage { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        public HttpRequestResult([NotNull] Exception exception, string? requestPayload, string? responsePayload) : this(exception.Message, requestPayload, responsePayload)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(exception);
#else
            if (exception is null)
                throw new ArgumentNullException(nameof(exception));
#endif
        }
         
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        public HttpRequestResult([NotNull] string errorMessage, string? requestPayload, string? responsePayload) : base()
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
#else
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException($"'{nameof(errorMessage)}' cannot be null or whitespace.", nameof(errorMessage));
#endif
            ErrorMessage = errorMessage;

            RequestPayload = requestPayload;

            ResponsePayload = responsePayload;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        protected HttpRequestResult(string? requestPayload, string? responsePayload) : base()
        {
            RequestPayload = requestPayload;

            ResponsePayload = responsePayload;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="HttpRequestResult{T}"/> for the specified <paramref name="result"/>
        /// </summary>
        /// <typeparam name="T">the type of the result</typeparam>
        /// <param name="result">The result</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        /// <returns></returns>
        public static HttpRequestResult<T> FromResult<T>(T result, string? requestPayload, string? responsePayload)
            => new(result, requestPayload, responsePayload);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => IsSuccessful ? SuccessfulMessage : ErrorMessage;

        #endregion
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <typeparam name="T">The type of the result of the response</typeparam>
    public class HttpRequestResult<T> : HttpRequestResult
    {
        #region Private Members

        /// <summary>
        /// The field for the <see cref="Result"/>
        /// </summary>
        private readonly T _result;

        #endregion

        #region Public Properties

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public T Result => IsSuccessful ? _result : throw new InvalidOperationException ($"The '{nameof(Result)}' property can only be accessed if the '{nameof(IsSuccessful)}' is true");

        #endregion

        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        public HttpRequestResult([NotNull] Exception exception, string? requestPayload, string? responsePayload) : base(exception, requestPayload, responsePayload)
        {
            _result = default!;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        public HttpRequestResult([NotNull] string errorMessage, string? requestPayload, string? responsePayload) : base(errorMessage, requestPayload, responsePayload)
        {
            _result = default!;
        }

        /// <summary>
        /// Creates a a result that indicates that the operation succeeded with <paramref name="result"/>
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        internal HttpRequestResult(T result, string? requestPayload, string? responsePayload) : base(requestPayload, responsePayload)
        {
            _result = result;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!IsSuccessful)
                return ErrorMessage;

            var successMessage = SuccessfulMessage;

            if (Result is not null)
            {
                var resultAsString = Result.ToString();

                if (!string.IsNullOrWhiteSpace(resultAsString))
                    successMessage = resultAsString;
            }

            return successMessage;
        }

        #endregion
    }
}
