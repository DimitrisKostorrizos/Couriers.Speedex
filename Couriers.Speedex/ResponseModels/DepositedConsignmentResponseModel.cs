using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the deposited consignment
    /// </summary>
    public record DepositedConsignmentResponseModel
    {
        #region Private Fields

        /// <summary>
        /// The field for the <see cref="Id"/>
        /// </summary>
        private string _id = default!;

        /// <summary>
        /// The field for the <see cref="Amount"/>
        /// </summary>
        private decimal _amount;

        #endregion

        #region Public Properties

        /// <summary>
        /// The unique consignment id
        /// </summary>
        public required string Id
        {
            get => _id;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(Id)}' cannot be null or whitespace.", nameof(Id));

                _id = value;
            }
        }

        /// <summary>
        /// The deposited amount
        /// </summary>
        public required decimal Amount
        {
            get => _amount;
            init
            {
                if (value < 0)
                    throw new ArgumentException($"'{nameof(Amount)}' cannot be negative.", nameof(Amount));

                _amount = value;
            }
        }

        /// <summary>
        /// The date-time of that the consignment was deposited
        /// </summary>
        public required DateTime DateDeposited { get; init; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DepositedConsignmentResponseModel"/>
        /// </summary>
        public DepositedConsignmentResponseModel() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="DepositedConsignmentResponseModel"/>
        /// </summary>
        /// <param name="id">The unique consignment id</param>
        /// <param name="amount">The deposited amount</param>
        /// <param name="dateDeposited">The date-time of that the consignment was deposited</param>
        [SetsRequiredMembers]
        public DepositedConsignmentResponseModel(string id, decimal amount, DateTime dateDeposited) : this()
        {
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