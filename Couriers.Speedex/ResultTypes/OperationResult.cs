using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex
{
    /// <summary>
    /// Describes the result for an operation that can fail
    /// </summary>
    public class OperationResult : IResult
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="SuccessfulOperationResult"/>
        /// </summary>
        private static readonly Lazy<OperationResult> _successfulOperationResult = new(() => new());

        #endregion

        #region Constants

        /// <summary>
        /// The message used when the result is successful
        /// </summary>
        public const string SuccessfulMessage = "Success";

        /// <summary>
        /// The operation result that indicates a successful operation
        /// </summary>
        public static OperationResult SuccessfulOperationResult => _successfulOperationResult.Value;

        #endregion

        #region Public Properties

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
        /// Creates a a result that indicates that the operation failed due to the <paramref name="exception"/>
        /// </summary>
        /// <param name="exception">The exception</param>
        public OperationResult([NotNull] Exception exception) : this(exception.Message)
        {
            ArgumentNullException.ThrowIfNull(exception, nameof(exception));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        public OperationResult([NotNull] string errorMessage) : this()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage, nameof(errorMessage));

            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        protected OperationResult() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="OperationResult{T}"/> for the specified <paramref name="result"/>
        /// </summary>
        /// <typeparam name="T">the type of the result</typeparam>
        /// <param name="result">The result</param>
        /// <returns></returns>
        public static OperationResult<T> FromResult<T>(T result)
            => new(result);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => IsSuccessful ? SuccessfulMessage : ErrorMessage;

        #endregion
    }

    /// <summary>
    /// Describes the result for an operation that can fail
    /// </summary>
    public class OperationResult<T> : OperationResult, IResult<T>
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
        /// Creates a a result that indicates that the operation failed due to the <paramref name="exception"/>
        /// </summary>
        /// <param name="exception">The exception</param>
        public OperationResult([NotNull] Exception exception) : base(exception)
        {
            _result = default!;
        }

        /// <summary>
        /// Creates a a result that indicates that the operation failed due to the <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        public OperationResult([NotNull] string errorMessage) : base(errorMessage)
        {
            _result = default!;
        }

        /// <summary>
        /// Creates a a result that indicates that the operation succeeded with <paramref name="result"/>
        /// </summary>
        /// <param name="result">The result</param>
        internal OperationResult(T result) : base()
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
