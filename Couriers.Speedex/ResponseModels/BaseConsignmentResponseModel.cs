using Couriers.Speedex.Enums;
using Couriers.Speedex.Structs;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// Contains the common properties for a consignment
    /// </summary>
    public record BaseConsignmentResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The weight of the consignment
        /// </summary>
        public double Weight { get; }

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        public ChargeType ChargeType { get; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        public string AgreementCode { get; }

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        public string CustomerCode { get; }

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        public string? FirstCustomerReference { get; }

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        public string? SecondCustomerReference { get; }

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        public string? ThirdCustomerReference { get; }

        /// <summary>
        /// The address for the delivery
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public string? RecipientName { get; }

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public string? RecipientPhoneNumber { get; }

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        public decimal InsuranceAmount { get; }

        /// <summary>
        /// A flag indicating whether the consignment is going to be delivered on Saturday
        /// </summary>
        public bool ShouldBeDeliveredOnSaturday { get; }

        /// <summary>
        /// The number of the consignment id
        /// </summary>
        public string ConsignmentId { get; }

        /// <summary>
        /// The total number of parcels of the consignment
        /// </summary>
        public int ParcelCount { get; }

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        public string ZipCode { get; }

        /// <summary>
        /// The delivery time limit
        /// NOTE: Cannot be combined with the field <see cref="ShouldBeDeliveredOnSaturday"/>.
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; }

        /// <summary>
        /// The delivery time window
        /// </summary>
        public DeliveryTimeWindow DeliveryTimeWindow { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BaseConsignmentResponseModel"/>
        /// </summary>
        /// <param name="weight">The weight of the consignment</param>
        /// <param name="chargeType">The charge type of the consignment</param>
        /// <param name="agreementCode">The agreement code provided by Speedex</param>
        /// <param name="customerCode">The customer code provided by Speedex</param>
        /// <param name="firstCustomerReference">The first customer reference of the consignment</param>
        /// <param name="secondCustomerReference">The second customer reference of the consignment</param>
        /// <param name="thirdCustomerReference">The third customer reference of the consignment</param>
        /// <param name="address">The address for the delivery</param>
        /// <param name="recipientName">The name of the recipient</param>
        /// <param name="recipientPhoneNumber">The phone number of the recipient</param>
        /// <param name="insuranceAmount">The insurance amount of the consignment</param>
        /// <param name="shouldBeDeliveredOnSaturday">A flag indicating whether the consignment is going to be delivered on Saturday</param>
        /// <param name="consignmentId">The number of the consignment id</param>
        /// <param name="parcelCount">The total number of parcels of the consignment</param>
        /// <param name="zipCode">The zip code for the delivery</param>
        /// <param name="deliveryTime">The delivery time limit</param>
        public BaseConsignmentResponseModel(double weight, ChargeType chargeType, string agreementCode, string customerCode,
            string? firstCustomerReference, string? secondCustomerReference, string? thirdCustomerReference, string address,
            string? recipientName, string? recipientPhoneNumber, decimal insuranceAmount, bool shouldBeDeliveredOnSaturday,
            string consignmentId, int parcelCount, string zipCode, DeliveryTimeLimit deliveryTime) : base()
        {
            Weight = weight;
            ChargeType = chargeType;
            AgreementCode = agreementCode;
            CustomerCode = customerCode;
            FirstCustomerReference = firstCustomerReference;
            SecondCustomerReference = secondCustomerReference;
            ThirdCustomerReference = thirdCustomerReference;
            Address = address;
            RecipientName = recipientName;
            RecipientPhoneNumber = recipientPhoneNumber;
            InsuranceAmount = insuranceAmount;
            ShouldBeDeliveredOnSaturday = shouldBeDeliveredOnSaturday;
            ConsignmentId = consignmentId;
            ParcelCount = parcelCount;
            ZipCode = zipCode;
            DeliveryTime = deliveryTime;
            DeliveryTimeWindow = SpeedexHelpers.ToDeliveryTimeWindow(deliveryTime);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ConsignmentId;

        #endregion
    }
}
