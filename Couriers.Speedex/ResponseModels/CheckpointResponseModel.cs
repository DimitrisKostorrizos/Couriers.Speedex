using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the consignment checkpoint
    /// </summary>
    public class CheckpointResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        public string BranchDepot { get; set; } = string.Empty;

        /// <summary>
        /// The unique branch depot id
        /// </summary>
        public string BranchId { get; set; } = string.Empty;

        /// <summary>
        /// The date-time of the event
        /// </summary>
        public DateTime CheckpointDate { get; set; }

        /// <summary>
        /// The customer's comments of the consignment
        /// </summary>
        public string CustomerComments { get; set; } = string.Empty;

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public string FirstCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public string SecondCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public string ThirdCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The recipient name
        /// </summary>
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// The code of the event
        /// </summary>
        public string StatusCode { get; set; } = string.Empty;

        /// <summary>
        /// The description of the event
        /// </summary>
        public string StatusDescription { get; set; } = string.Empty;

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public string VoucherId { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CheckpointResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        #endregion
    }
}
