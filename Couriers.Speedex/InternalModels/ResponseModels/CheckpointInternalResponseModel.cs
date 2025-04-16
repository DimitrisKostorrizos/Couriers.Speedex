using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the consignment checkpoint
    /// </summary>
    [XmlRoot("checkpoint", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CheckpointInternalResponseModel : ISoapResponseModel<CheckpointResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The name of the depot responsible for the event
        /// </summary>
        [XmlElement("Branch")]
        public string BranchDepot { get; set; } = string.Empty;

        /// <summary>
        /// The unique branch depot id
        /// </summary>
        [XmlElement("BranchID")]
        public string BranchId { get; set; } = string.Empty;

        /// <summary>
        /// The date-time of the event
        /// </summary>
        [XmlElement("CheckpointDate")]
        public DateTime CheckpointDate { get; set; }

        /// <summary>
        /// The customer's comments of the consignment
        /// </summary>
        [XmlElement("ClientComments1")]
        public string CustomerComments { get; set; } = string.Empty;

        /// <summary>
        /// The first customer reference of the consignment
        /// </summary>
        [XmlElement("ClientRef1")]
        public string FirstCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The second customer reference of the consignment
        /// </summary>
        [XmlElement("ClientRef2")]
        public string SecondCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The third customer reference of the consignment
        /// </summary>
        [XmlElement("ClientRef3")]
        public string ThirdCustomerReference { get; set; } = string.Empty;

        /// <summary>
        /// The recipient name
        /// </summary>
        [XmlElement("SpeedexComments1")]
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// The code of the event
        /// </summary>
        [XmlElement("StatusCode")]
        public string StatusCode { get; set; } = string.Empty;

        /// <summary>
        /// The description of the event
        /// </summary>
        [XmlElement("StatusDesc")]
        public string StatusDescription { get; set; } = string.Empty;

        /// <summary>
        /// The unique voucher id
        /// </summary>
        [XmlElement("VoucherID")]
        public string VoucherId { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CheckpointInternalResponseModel() : base()
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
        /// Creates and return the <see cref="CheckpointResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public CheckpointResponseModel ToResponseModel() => new(BranchDepot, BranchId, CheckpointDate, CustomerComments, FirstCustomerReference,
            SecondCustomerReference, ThirdCustomerReference, RecipientName, StatusCode, StatusDescription, VoucherId);

        #endregion
    }
}
