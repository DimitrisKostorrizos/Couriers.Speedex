using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex
{
    /// <summary>
    /// Contains the extensions methods related to the <see cref="IResult"/>
    /// </summary>
    public static class IResultExtensions
    {
        #region Public Methods

        /// <summary>
        /// Creates an returns a new instance of <see cref="IResult"/> from the specified <paramref name="result"/>
        /// </summary>
        /// <typeparam name="TResult">The type of the new result</typeparam>
        /// <param name="result">The result</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">An exception is thrown if the <paramref name="result"/> is successful</exception>
        public static IResult<TResult> ToUnsuccessfulIResult<TResult>([NotNull] this IResult result)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));

            if (result.IsSuccessful)
                throw new InvalidOperationException($"The specified '{nameof(result)}' is successful.");

            return new OperationResult<TResult>(result.ErrorMessage);
        }

        /// <summary>
        /// Creates an returns a new instance of <see cref="HttpRequestResult{T}"/> from the specified <paramref name="result"/>
        /// </summary>
        /// <typeparam name="TResult">The type of the new result</typeparam>
        /// <param name="result">The result</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">An exception is thrown if the <paramref name="result"/> is successful</exception>
        public static HttpRequestResult<TResult> ToUnsuccessfulHttpRequestResult<TResult>([NotNull] this HttpRequestResult result)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));

            if (result.IsSuccessful)
                throw new InvalidOperationException($"The specified '{nameof(result)}' is successful.");

            return new HttpRequestResult<TResult>(result.ErrorMessage, result.RequestPayload, result.ResponsePayload);
        }

        #endregion
    }
}
