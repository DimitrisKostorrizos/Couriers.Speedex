using Couriers.Speedex.RequestModels;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for the consignment
    /// </summary>
    [XmlRoot("BOL", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The customer flag
        /// NOTE: The value must be 0 or 100, except specified otherwise by Speedex.
        /// The value 0 indicates that the default data from the customer agreement will be used as the sender’s data. 
        /// The value 100 indicates that the related fields will be used as the sender’s data.
        /// </summary>
        [XmlElement("_cust_Flag")]
        public int CustomerFlag { get; set; }

        /// <summary>
        /// The cost center of the customer agreement
        /// </summary>
        [XmlElement("BranchBankCode")]
        public string? BranchBankCode { get; set; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        [XmlElement("Comments_2853_1")]
        public string? FirstCustomerReference { get; set; }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        [XmlElement("Comments_2853_2")]
        public string? SecondCustomerReference { get; set; }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        [XmlElement("Comments_2853_3")]
        public string? ThirdCustomerReference { get; set; }

        /// <summary>
        /// The number of items of the consignment
        /// </summary>
        [XmlElement("Items")]
        public int ItemCount { get; set; }

        /// <summary>
        /// The first part of the comments
        /// </summary>
        [XmlElement("Paratiriseis_2853_1")]
        public string? FirstCommentsPart { get; set; }

        /// <summary>
        /// The second part of the comments
        /// </summary>
        [XmlElement("Paratiriseis_2853_2")]
        public string? SecondCommentsPart { get; set; }

        /// <summary>
        /// The third part of the comments
        /// </summary>
        [XmlElement("Paratiriseis_2853_3")]
        public string? ThirdCommentsPart { get; set; }

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
        public string? PaymentType { get; set; }

        /// <summary>
        /// The address for the delivery
        /// </summary>
        [XmlElement("RCV_Addr1")]
        public string? Address { get; set; }

        /// <summary>
        /// The country for the delivery
        /// </summary>
        [XmlElement("RCV_Country")]
        public string? Country { get; } = "GR";

        /// <summary>
        /// The name of the recipient
        /// </summary>
        [XmlElement("RCV_Name")]
        public string? RecipientName { get; set; }

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        [XmlElement("RCV_Tel1")]
        public string? RecipientPhoneNumber { get; set; }

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        [XmlElement("RCV_Zip_Code")]
        public string? ZipCode { get; set; }

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
        public int InsuranceAmount { get; set; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        [XmlElement("Snd_agreement_id")]
        public string? AgreementCode { get; set; }

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        [XmlElement("SND_Customer_Id")]
        public string? CustomerCode { get; set; }

        /// <summary>
        /// The delivery time window
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        [XmlElement("Time_Limit")]
        public string? DeliveryTime { get; set; }

        /// <summary>
        /// The weight of the consignment
        /// NOTE: The minimum value is 0.5 per item. 
        /// It is possible to change after the weighting from Speedex
        /// </summary>
        [XmlElement("Voucher_Weight")]
        public double Weight { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentInternalRequestModel"/>
        /// </summary>
        public ConsignmentInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="ConsignmentInternalRequestModel"/> from the <see cref="ConsignmentRequestModel"/>
        /// </summary>
        /// <param name="model">The request model</param>
        /// <param name="agreementCode">The agreement code</param>
        /// <param name="customerCode">The customer code</param>
        /// <returns></returns>
        public static ConsignmentInternalRequestModel FromRequestModel([NotNull] ConsignmentRequestModel model, [NotNull] string agreementCode, [NotNull] string customerCode)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(agreementCode))
                throw new ArgumentException($"'{nameof(agreementCode)}' cannot be null or whitespace.", nameof(agreementCode));

            if (string.IsNullOrWhiteSpace(customerCode))
                throw new ArgumentException($"'{nameof(customerCode)}' cannot be null or whitespace.", nameof(customerCode));

            var internalModel = new ConsignmentInternalRequestModel()
            {
                Address = model.Address,
                AgreementCode = agreementCode,
                BranchBankCode = model.BranchBankCode,
                ChargeType = SpeedexHelpers.FromChargeType(model.ChargeType),
                Cost = model.Cost,
                CustomerCode = customerCode,
                CustomerFlag = model.CustomerFlag,
                DeliveryTime = SpeedexHelpers.FromDeliveryTimeLimit(model.DeliveryTime),
                FirstCustomerReference = model.FirstCustomerReference,
                FirstCommentsPart = model.FirstCommentsPart,
                InsuranceAmount = model.InsuranceAmount,
                ItemCount = model.NumberOfVouchers,
                RecipientName = model.RecipientName,
                RecipientPhoneNumber = model.RecipientPhoneNumber,
                SecondCustomerReference = model.SecondCustomerReference,
                SecondCommentsPart = model.SecondCommentsPart,
                ShouldBeDeliveredOnSaturday = (uint)(model.ShouldBeDeliveredOnSaturday ? 1 : 0),
                ThirdCustomerReference = model.ThirdCustomerReference,
                ThirdCommentsPart = model.ThirdCommentsPart,
                Weight = Math.Round(model.Weight, 1),
                ZipCode = model.ZipCode
            };

            if (model.PaymentType.HasValue)
                internalModel.PaymentType = SpeedexHelpers.FromPaymentType(model.PaymentType.Value);

            return internalModel;
        }

        #endregion
    }
}
