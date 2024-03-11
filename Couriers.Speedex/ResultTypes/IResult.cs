using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex
{
    /// <summary>
    /// Provides abstraction for a result type
    /// </summary>
    public interface IResult
    {
        #region Properties

        /// <summary>
        /// Returns whether the operation is successful
        /// </summary>
        [MemberNotNullWhen(false, nameof(ErrorMessage))]
        bool IsSuccessful { get; }

        /// <summary>
        /// The error message
        /// </summary>
        string? ErrorMessage { get; }

        #endregion
    }

    /// <summary>
    /// Provides abstraction for a result type
    /// </summary>
    /// <typeparam name="T">The type of the result</typeparam>
    public interface IResult<out T> : IResult
    {
        #region Properties

        /// <summary>
        /// The result
        /// </summary>
        T Result { get; }

        #endregion
    }
}
