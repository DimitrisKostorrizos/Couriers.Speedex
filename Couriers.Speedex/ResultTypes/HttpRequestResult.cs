using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex
{
    /// <summary>
    /// The <see cref="OperationResult"/> implementation for a HTTP request operation
    /// </summary>
    public class HttpRequestResult : OperationResult
    {
        #region Public Properties

        /// <summary>
        /// The request payload
        /// </summary>
        public string? RequestPayload { get; }

        /// <summary>
        /// The response payload
        /// </summary>
        public string? ResponsePayload { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        public HttpRequestResult([NotNull] Exception exception, string? requestPayload, string? responsePayload) : base(exception)
        {
            RequestPayload = requestPayload;

            ResponsePayload = responsePayload;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        public HttpRequestResult([NotNull] string errorMessage, string? requestPayload, string? responsePayload) : base(errorMessage)
        {
            RequestPayload = requestPayload;

            ResponsePayload = responsePayload;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="requestPayload">The request payload</param>
        /// <param name="responsePayload">The response payload</param>
        internal HttpRequestResult(string? requestPayload, string? responsePayload) : base()
        {
            RequestPayload = requestPayload;

            ResponsePayload = responsePayload;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="OperationResult{T}"/> for the specified <paramref name="result"/>
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
        public override string ToString() => base.ToString();

        #endregion
    }

    /// <summary>
    /// Describes the result for an operation that can fail
    /// </summary>
    public class HttpRequestResult<T> : HttpRequestResult, IResult<T>
    {
        #region Private Members

        /// <summary>
        /// The field for the <see cref="Result"/>
        /// </summary>
        private readonly T _result;

        /// <summary>
        /// The exception thrown when the <see cref="Result"/> property is accessed, when the 
        /// </summary>
        private static readonly InvalidOperationException _resultException = new($"The '{nameof(Result)}' property can only be accessed if the '{nameof(IsSuccessful)}' is true");

        #endregion

        #region Public Properties

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public T Result => IsSuccessful ? _result : throw _resultException;

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
