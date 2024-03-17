using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the deposited consignment
    /// </summary>
    public sealed record DepositedConsignmentResponseModel
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
        /// Default constructor
        /// </summary>
        /// <param name="id">The unique consignment id</param>
        /// <param name="amount">The deposited amount</param>
        /// <param name="dateDeposited">The date-time of that the consignment was deposited</param>
        public DepositedConsignmentResponseModel(string id, decimal amount, DateTime dateDeposited) : base()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id, nameof(id));

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
