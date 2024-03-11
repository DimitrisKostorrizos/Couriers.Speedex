using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the deposited consignment
    /// </summary>
    public class DepositedConsignmentResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The unique consignment id
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The deposited amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The date-time of the deposit
        /// </summary>
        public DateTime DateDeposited { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DepositedConsignmentResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        #endregion
    }
}
