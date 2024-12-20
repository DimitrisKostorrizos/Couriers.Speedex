using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the consignment
    /// </summary>
    [XmlRoot("BOL", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentInternalResponseModel : ISoapResponseModel<ConsignmentResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// </summary>
        [XmlElement("_cust_Flag")]
        public uint CustomerFlag { get; set; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        [XmlElement("BranchBankCode")]
        public string BranchBankCode { get; set; } = string.Empty;

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        [XmlElement("Comments_2853_1")]
        public string FirstCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        [XmlElement("Comments_2853_2")]
        public string SecondCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        [XmlElement("Comments_2853_3")]
        public string ThirdCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The number of items of the consignment
        /// </summary>
        [XmlElement("Items")]
        public uint ItemCount { get; set; }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        [XmlElement("Paratiriseis_2853_1")]
        public string FirstCommentsPart { get; set; } = string.Empty;

        /// <summary>
        /// The second part of the comments
        /// </summary>
        [XmlElement("Paratiriseis_2853_2")]
        public string SecondCommentsPart { get; set; } = string.Empty;

        /// <summary>
        /// The third part of the comments
        /// </summary>
        [XmlElement("Paratiriseis_2853_3")]
        public string ThirdCommentsPart { get; set; } = string.Empty;

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        [XmlElement("PayCode_Flag")]
        public uint ChargeType { get; set; }

        /// <summary>
        /// The cost
        /// </summary>
        [XmlElement("Pod_Amount_Cash")]
        public double Cost { get; set; }

        /// <summary>
        /// The payment type
        /// </summary>
        [XmlElement("Pod_Amount_Description")]
        public string PaymentType { get; set; } = string.Empty;

        /// <summary>
        /// The address for the delivery
        /// </summary>
        [XmlElement("RCV_Addr1")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The country for the delivery
        /// </summary>
        [XmlElement("RCV_Country")]
        public string Country { get; } = "GR";

        /// <summary>
        /// The name of the recipient
        /// </summary>
        [XmlElement("RCV_Name")]
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        [XmlElement("RCV_Tel1")]
        public string RecipientPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        [XmlElement("RCV_Zip_Code")]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// The flag indicating whether the consignment is going to be delivered on Saturday
        /// NOTE: Cannot be combined with the field Time_Limit.
        /// </summary>
        [XmlElement("Saturday_Delivery")]
        public uint ShouldBeDeliveredOnSaturday { get; set; }

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        [XmlElement("Security_Value")]
        public uint InsuranceAmount { get; set; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        [XmlElement("Snd_agreement_id")]
        public string AgreementCode { get; set; } = string.Empty;

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        [XmlElement("SND_Customer_Id")]
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        /// The delivery time window
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        [XmlElement("Time_Limit")]
        public string DeliveryTime { get; set; } = string.Empty;

        /// <summary>
        /// The unique voucher id
        /// </summary>
        [XmlElement("voucher_code")]
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
        public ConsignmentInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => VoucherId;

        /// <summary>
        /// Creates and return the <see cref="ConsignmentResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public ConsignmentResponseModel ToResponseModel()
        {
            var responseModel = new ConsignmentResponseModel()
            {
                Address = Address,
                AgreementCode = AgreementCode,
                BranchBankCode = BranchBankCode,
                ChargeType = SpeedexHelpers.ToChargeType(ChargeType),
                Cost = Cost,
                CustomerCode = CustomerCode,
                CustomerFlag = CustomerFlag,
                DeliveryTime = SpeedexHelpers.ToDeliveryTimeLimit(DeliveryTime),
                FirstCustomerReference = FirstCustomerReference,
                FirstCommentsPart = FirstCustomerReference,
                InsuranceAmount = InsuranceAmount,
                ItemCount = ItemCount,
                RecipientName = RecipientName,
                RecipientPhoneNumber = RecipientPhoneNumber,
                SecondCustomerReference = SecondCustomerReference,
                SecondCommentsPart = SecondCommentsPart,
                ShouldBeDeliveredOnSaturday = (ShouldBeDeliveredOnSaturday == 1),
                VoucherId = VoucherId,
                ThirdCustomerReference = ThirdCustomerReference,
                ThirdCommentsPart = ThirdCommentsPart,
                Weight = Weight,
                ZipCode = ZipCode
            };

            if (PaymentType is not null)
                responseModel.PaymentType = SpeedexHelpers.ToPaymentType(PaymentType);

            return responseModel;
        }

        #endregion
    }
}
