using Couriers.Speedex.Constants;
using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the consignment details
    /// </summary>
    [XmlType("Consignment", IncludeInSchema = false, Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ConsignmentDetailsInternalResponseModel : ISoapResponseModel<ConsignmentDetailsResponseModel>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The weight of the consignment
        /// </summary>
        [XmlElement("BenchWeight")]
        public double Weight { get; set; }

        /// <summary>
        /// The charge type of the consignment
        /// </summary>
        [XmlElement("Charge")]
        public string ChargeType { get; set; } = string.Empty;

        /// <summary>
        /// The cash amount of the consignment to be collected
        /// </summary>
        [XmlElement("CollectOnDeliveryCashAmount")]
        public double CashAmount { get; set; }

        /// <summary>
        /// The check amount of the consignment to be collected
        /// </summary>
        [XmlElement("CollectOnDeliveryCheckAmount")]
        public double CheckAmount { get; set; }

        /// <summary>
        /// The agreement code provided by Speedex
        /// </summary>
        [XmlElement("CustomerAgreementCode")]
        public string AgreementCode { get; set; } = string.Empty;

        /// <summary>
        /// The customer code provided by Speedex
        /// </summary>
        [XmlElement("CustomerCostCenterCode")]
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        [XmlElement("CustomerReference1")]
        public string FirstCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        [XmlElement("CustomerReference2")]
        public string SecondCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        [XmlElement("CustomerReference3")]
        public string ThirdCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The address for the delivery
        /// </summary>
        [XmlElement("DeliveryAddress")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The city for the delivery
        /// </summary>
        [XmlElement("DeliveryCity")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The country code for the delivery
        /// </summary>
        [XmlElement("DeliveryCountryCode")]
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The comments of the consignment
        /// </summary>
        [XmlElement("DeliveryCustomerComments")]
        public string CustomerComments { get; set; } = string.Empty;

        /// <summary>
        /// The name of the recipient
        /// </summary>
        [XmlElement("DeliveryName")]
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the recipient
        /// </summary>
        [XmlElement("DeliveryPhoneNumber")]
        public string RecipientPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The post code for the delivery
        /// </summary>
        [XmlElement("DeliveryPostCode")]
        public string DeliveryPostCode { get; set; } = string.Empty;

        /// <summary>
        /// The initial time of the delivery timeframe window
        /// </summary>
        [XmlElement("DeliveryTimeFrom")]
        public string DeliveryTimeFrom { get; set; } = string.Empty;

        /// <summary>
        /// The final time of the delivery time-frame window
        /// </summary>
        [XmlElement("DeliveryTimeTo")]
        public string DeliveryTimeTo { get; set; } = string.Empty;

        /// <summary>
        /// The checkpoint code of the consignment
        /// </summary>
        [XmlElement("EventCode")]
        public string CheckpointCode { get; set; } = string.Empty;

        /// <summary>
        /// The group checkpoint code of the consignment
        /// </summary>
        [XmlElement("EventGroupCode")]
        public string CheckpointGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// The insurance amount of the consignment
        /// </summary>
        [XmlElement("InsuranceAmount")]
        public decimal InsuranceAmount { get; set; }

        /// <summary>
        /// Indicates whether the consignment is a return item
        /// </summary>
        [XmlElement("IsReturn")]
        public bool IsReturnItem { get; set; }

        /// <summary>
        /// Indicates whether the consignment is going to be delivered on Saturday
        /// </summary>
        [XmlElement("IsSaturdayDelivery")]
        public bool IsSaturdayDelivery { get; set; }

        /// <summary>
        /// The number of the master consignment id
        /// </summary>
        [XmlElement("MasterConsignmentNumber")]
        public string MasterConsignmentId { get; set; } = string.Empty;

        /// <summary>
        /// The number of the consignment id
        /// </summary>
        [XmlElement("Number")]
        public string ConsignmentId { get; set; } = string.Empty;

        /// <summary>
        /// The address for the pickup of the consignment
        /// </summary>
        [XmlElement("PickupAddress")]
        public string PickupAddress { get; set; } = string.Empty;

        /// <summary>
        /// The city for the pickup of the consignment
        /// </summary>
        [XmlElement("PickupCity")]
        public string PickupCity { get; set; } = string.Empty;

        /// <summary>
        /// The country code for the pickup of the consignment
        /// </summary>
        [XmlElement("PickupCountryCode")]
        public string PickupCountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The name for the pickup of the consignment
        /// </summary>
        [XmlElement("PickupName")]
        public string PickupName { get; set; } = string.Empty;

        /// <summary>
        /// The phone number for the pickup of the consignment
        /// </summary>
        [XmlElement("PickupPhoneNumber")]
        public string PickupPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The post code for the pickup of the consignment
        /// </summary>
        [XmlElement("PickupPostCode")]
        public string PickupPostCode { get; set; } = string.Empty;

        /// <summary>
        /// The total number of parcels of the consignment
        /// </summary>
        [XmlElement("TotalNumberOfParcels")]
        public uint ParcelCount { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentDetailsInternalResponseModel"/>
        /// </summary>
        public ConsignmentDetailsInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public override string ToString() => MasterConsignmentId;

        /// <summary>
        /// Creates and return the <see cref="ConsignmentDetailsResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public ConsignmentDetailsResponseModel ToResponseModel()
        {
            var startingDeliveryTime = default(TimeOnly?);

            if (TimeOnly.TryParse(DeliveryTimeFrom, SpeedexConstants.SpeedexCultureInfo, out var result))
                startingDeliveryTime = result;

            var endingDeliveryTime = default(TimeOnly?);

            if (TimeOnly.TryParse(DeliveryTimeTo, SpeedexConstants.SpeedexCultureInfo, out result))
                endingDeliveryTime = result;

            var deliveryTime = SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(startingDeliveryTime, endingDeliveryTime);

            var chargeType = SpeedexHelpers.ToChargeType(ChargeType);

            return new(CashAmount, CheckAmount, City, CountryCode, CustomerComments, startingDeliveryTime, endingDeliveryTime, CheckpointCode, CheckpointGroupCode, IsReturnItem, MasterConsignmentId, PickupAddress,
                PickupCity, PickupCountryCode, PickupName, PickupPhoneNumber, PickupPostCode, Weight, chargeType, AgreementCode, CustomerCode, FirstCustomerReference, SecondCustomerReference,
                ThirdCustomerReference, Address, RecipientName, RecipientPhoneNumber, InsuranceAmount, IsSaturdayDelivery, ConsignmentId, (int)ParcelCount, DeliveryPostCode, deliveryTime);
        }

        #endregion
    }
}