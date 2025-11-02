using Couriers.Speedex.Enums;

using System;

namespace Couriers.Speedex.ResponseModels
{
    /// <summary>
    /// The response model for the consignment details
    /// </summary>
    public record ConsignmentDetailsResponseModel : BaseConsignmentResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The cash amount of the consignment to be collected
        /// </summary>
        public double CashAmount { get; set; }

        /// <summary>
        /// The check amount of the consignment to be collected
        /// </summary>
        public double CheckAmount { get; set; }

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
        /// Indicates whether the consignment is a return item
        /// </summary>
        public bool IsReturnItem { get; set; }

        /// <summary>
        /// The number of the master consignment id
        /// </summary>
        public string MasterConsignmentId { get; set; } = string.Empty;

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

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsResponseModel"/>
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
