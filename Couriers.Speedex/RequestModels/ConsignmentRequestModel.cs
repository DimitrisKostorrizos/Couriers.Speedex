namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the consignment
    /// </summary>
    public class ConsignmentRequestModel
    {
        #region Constants

        /// <summary>
        /// The maximum length for the comments
        /// </summary>
        public const int MaxCommentLength = 40;

        /// <summary>
        /// The maximum length for the customer reference
        /// </summary>
        public const int MaxCustomerReferenceLength = 50;

        #endregion

        #region Private Members

        /// <summary>
        /// The member of the <see cref="NumberOfVouchers"/>
        /// </summary>
        private uint mItemCount;

        /// <summary>
        /// The member of the <see cref="Weight"/>
        /// </summary>
        private double mWeight;

        /// <summary>
        /// The member of the <see cref="FirstCommentsPart"/>
        /// </summary>
        private string? mFirstCommentsPart;

        /// <summary>
        /// The member of the <see cref="SecondCommentsPart"/>
        /// </summary>
        private string? mSecondCommentsPart;

        /// <summary>
        /// The member of the <see cref="ThirdCommentsPart"/>
        /// </summary>
        private string? mThirdCommentsPart;
        private string? firstCustomerReference;

        #endregion

        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// The value 0 indicates that the default data from the customer agreement will be used as the sender’s data. 
        /// The value 100 indicates that the related fields will be used as the sender’s data.
        /// </summary>
        public uint CustomerFlag { get; set; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        public string? BranchBankCode { get; set; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public string? FirstCustomerReference
        {
            get => firstCustomerReference;
            set
            {
                firstCustomerReference = value;
            }
        }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public string? SecondCustomerReference { get; set; }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public string? ThirdCustomerReference { get; set; }

        /// <summary>
        /// The number of items of the consignment
        /// </summary>
        public uint NumberOfVouchers
        {
            get => mItemCount;
            set
            {
                mItemCount = value > 20 ? 20 : value;
            }
        }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        public string? FirstCommentsPart
        {
            get => mFirstCommentsPart;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 40)
                    value = value[..MaxCommentLength];

                mFirstCommentsPart = value;
            }
        }

        /// <summary>
        /// The second part of the comments
        /// </summary>
        public string? SecondCommentsPart
        {
            get => mSecondCommentsPart;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 40)
                    value = value[..MaxCommentLength];

                mSecondCommentsPart = value;
            }
        }

        /// <summary>
        /// The third part of the comments
        /// </summary>
        public string? ThirdCommentsPart
        {
            get => mThirdCommentsPart;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 40)
                    value = value[..MaxCommentLength];

                mThirdCommentsPart = value;
            }
        }

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
        public string? Address { get; set; }

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public string? RecipientName { get; set; }

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public string? RecipientPhoneNumber { get; set; }

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        public string? ZipCode { get; set; }

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
        /// The delivery time window
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; set; }

        /// <summary>
        /// The weight of the consignment
        /// NOTE: The minimum value is 0.5 per item. 
        /// It is possible to change after the weighting from Speedex
        /// </summary>
        public double Weight
        {
            get => mWeight;
            set
            {
                var minimumWeight = NumberOfVouchers * 0.5;

                if (value < minimumWeight)
                    mWeight = minimumWeight;
                else
                    mWeight = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentRequestModel(uint customerFlag) : base()
        {
            CustomerFlag = customerFlag;
        }

        #endregion
    }
}