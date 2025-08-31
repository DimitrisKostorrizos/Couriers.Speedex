using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the deposited consignment
    /// </summary>
    public record DepositedConsignmentResponseModel
    {
        #region Public Properties

#if NET7_0_OR_GREATER

        /// <summary>
        /// The unique consignment id
        /// </summary>
        public required string Id
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
#else
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
#endif
                field = value;
            }
        }

        /// <summary>
        /// The deposited amount
        /// </summary>
        public required decimal Amount
        {
            get;
            init
            {
#if NET8_0_OR_GREATER
                ArgumentOutOfRangeException.ThrowIfNegative(value);
#else
                if (value < 0)
                    throw new ArgumentException($"'{nameof(value)}' cannot be negative.", nameof(value));
#endif
                field = value;
            }
        }

        /// <summary>
        /// The date-time of that the consignment was deposited
        /// </summary>
        public required DateTime DateDeposited { get; init; }
#else
        /// <summary>
        /// The unique consignment id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The deposited amount
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// The date-time of that the consignment was deposited
        /// </summary>
        public DateTime DateDeposited { get; }
#endif

        #endregion

        #region Constructors

#if NET7_0_OR_GREATER
        /// <summary>
        /// Default constructor
        /// </summary>
        public DepositedConsignmentResponseModel() : base()
        {

        }
#else
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">The unique consignment id</param>
        /// <param name="amount">The deposited amount</param>
        /// <param name="dateDeposited">The date-time of that the consignment was deposited</param>
        public DepositedConsignmentResponseModel(string id, decimal amount, DateTime dateDeposited) : base()
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
                
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value);
#else
            if (amount < 0)
                throw new ArgumentException($"'{nameof(amount)}' cannot be negative.", nameof(amount));
#endif
            Id = id;

            Amount = amount;

            DateDeposited = dateDeposited;
        }
#endif

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        #endregion
    }
}
