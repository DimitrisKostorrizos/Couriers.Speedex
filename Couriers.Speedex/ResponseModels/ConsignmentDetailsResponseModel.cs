using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for the consignment details
    /// </summary>
    public class ConsignmentDetailsResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The weight of the consignment
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        public ChargeType ChargeType { get; set; }

        /// <summary>
        /// The cash amount of the consignment to be collected
        /// </summary>
        public double CashAmount { get; set; }

        /// <summary>
        /// The check amount of the consignment to be collected
        /// </summary>
        public double CheckAmount { get; set; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        public string AgreementCode { get; set; } = string.Empty;

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        public string CustomerCode { get; set; } = string.Empty;

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
        /// The address for the delivery
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city for the delivery
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The country code for the delivery
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The comments of the consignment
        /// </summary>
        public string CustomerComments { get; set; } = string.Empty;

        /// <summary>
        /// The name of the recipient
        /// </summary>
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        public string RecipientPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The post code for the delivery
        /// </summary>
        public string DeliveryPostCode { get; set; } = string.Empty;

        /// <summary>
        /// The initial time of the delivery timeframe window
        /// </summary>
        public DateTime? DeliveryTimeFrom { get; set; }

        /// <summary>
        /// The final time of the delivery timeframe window
        /// </summary>
        public DateTime? DeliveryTimeTo { get; set; }

        /// <summary>
        /// The checkpoint code of the consignment
        /// </summary>
        public string CheckpointCode { get; set; } = string.Empty;

        /// <summary>
        /// The group checkpoint code of the consignment
        /// </summary>
        public string CheckpointGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        public decimal InsuranceAmount { get; set; }

        /// <summary>
        /// Indicates whether the consignment is a return item
        /// </summary>
        public bool IsReturnItem { get; set; }

        /// <summary>
        /// Indicates whether the consignment is going to be delivered on Saturday
        /// </summary>
        public bool IsSaturdayDelivery { get; set; }

        /// <summary>
        /// The number of the master consignment id
        /// </summary>
        public string MasterConsignmentId { get; set; } = string.Empty;

        /// <summary>
        /// The number of the consignment id
        /// </summary>
        public string ConsignmentId { get; set; } = string.Empty;

        /// <summary>
        /// The address for the pickup of the consignment
        /// </summary>
        public string PickupAddress { get; set; } = string.Empty;

        /// <summary>
        /// The city for the pickup of the consignment
        /// </summary>
        public string PickupCity { get; set; } = string.Empty;

        /// <summary>
        /// The country code for the pickup of the consignment
        /// </summary>
        public string PickupCountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The name for the pickup of the consignment
        /// </summary>
        public string PickupName { get; set; } = string.Empty;

        /// <summary>
        /// The phone number for the pickup of the consignment
        /// </summary>
        public string PickupPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The post code for the pickup of the consignment
        /// </summary>
        public string PickupPostCode { get; set; } = string.Empty;

        /// <summary>
        /// The total number of parcels of the consignment
        /// </summary>
        public uint ParcelCount { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsignmentDetailsResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MasterConsignmentId;

        #endregion
    }
}
