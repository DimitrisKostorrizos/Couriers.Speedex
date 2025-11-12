using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the deposited consignment
    /// </summary>
    public record DepositedConsignmentResponseModel
    {
        #region Public Properties

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

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DepositedConsignmentResponseModel"/>
        /// </summary>
        /// <param name="id">The unique consignment id</param>
        /// <param name="amount">The deposited amount</param>
        /// <param name="dateDeposited">The date-time of that the consignment was deposited</param>
        public DepositedConsignmentResponseModel(string id, decimal amount, DateTime dateDeposited) : base()
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

            if (amount < 0)
                throw new ArgumentException($"'{nameof(amount)}' cannot be negative.", nameof(amount));
            Id = id;

            Amount = amount;

            DateDeposited = dateDeposited;
        }

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
