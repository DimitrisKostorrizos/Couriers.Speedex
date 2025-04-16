using Couriers.Speedex.ResultTypes;

using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.Extensions
{
    /// <summary>
    /// Contains the extensions methods related to the <see cref="HttpRequestResult"/>
    /// </summary>
    public static class HttpRequestResultExtensions
    {
        #region Public Methods

        /// <summary>
        /// Creates an returns a new instance of <see cref="HttpRequestResult{T}"/> from the specified <paramref name="result"/>
        /// </summary>
        /// <typeparam name="TResult">The type of the new result</typeparam>
        /// <param name="result">The result</param>
        /// <param name="errorMessage">The error message</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">An exception is thrown if the <paramref name="result"/> is successful</exception>
        public static HttpRequestResult<TResult> ToUnsuccessfulHttpRequestResult<TResult>([NotNull] this HttpRequestResult result, string? errorMessage = null)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(result);
#else
            if (result is null)
                throw new ArgumentNullException(nameof(result));
#endif

            if (result.IsSuccessful)
                throw new InvalidOperationException($"The specified '{nameof(result)}' is successful.");

            var resultErrorMessage = string.IsNullOrWhiteSpace(errorMessage) ? result.ErrorMessage : errorMessage;

            return new HttpRequestResult<TResult>(resultErrorMessage, result.RequestPayload, result.ResponsePayload);
        }

        #endregion
    }
}
