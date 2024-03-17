namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the consignment
    /// </summary>
    public sealed record ConsignmentResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// </summary>
        public uint CustomerFlag { get; set; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public string BranchBankCode { get; set; } = string.Empty;

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
        /// The number of items of the consignment
        /// </summary>
        public uint ItemCount { get; set; }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        public string FirstCommentsPart { get; set; } = string.Empty;

        /// <summary>
        /// The second part of the comments
        /// </summary>
        public string SecondCommentsPart { get; set; } = string.Empty;

        /// <summary>
        /// The third part of the comments
        /// </summary>
        public string ThirdCommentsPart { get; set; } = string.Empty;

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        public ChargeType ChargeType { get; set; }

        /// <summary>
        /// The payment type
        /// </summary>
        public PaymentType? PaymentType { get; set; }

        /// <summary>
        /// The cost
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// The address for the delivery
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public string RecipientPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// The flag indicating whether the consignment is going to be delivered on Saturday
        /// NOTE: Cannot be combined with the field <see cref="DeliveryTime"/>.
        /// </summary>
        public bool ShouldBeDeliveredOnSaturday { get; set; }

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        public uint InsuranceAmount { get; set; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        public string AgreementCode { get; set; } = string.Empty;

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        /// The delivery time window
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; set; }

        /// <summary>
        /// The unique voucher id
        /// </summary>
        public string VoucherId { get; set; } = string.Empty;

        /// <summary>
        /// The weight of the consignment
        /// NOTE: The minimum value is 0.5 per item. 
        /// It is possible to change after the weighting from Speedex
        /// </summary>
        public double Weight { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        #endregion
    }
}
