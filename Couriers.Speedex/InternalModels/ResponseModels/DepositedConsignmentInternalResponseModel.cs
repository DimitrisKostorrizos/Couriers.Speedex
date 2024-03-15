using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the deposited consignment
    /// </summary>
    [XmlRoot(Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class DepositedConsignmentInternalResponseModel : ISOAPResponseModel<DepositedConsignmentResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The unique consignment id
        /// </summary>
        [XmlElement("ConsignmentNumber")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The deposited amount
        /// </summary>
        [XmlElement("Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The date-time of the deposit
        /// </summary>
        [XmlElement("Date")]
        public string DateDeposited { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DepositedConsignmentInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        /// <summary>
        /// Creates and return the <see cref="DepositedConsignmentResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public DepositedConsignmentResponseModel ToResponseModel()
            => new()
            {
                Amount = Amount,
                Id = Id,
                DateDeposited = DateTime.Parse(DateDeposited, CultureInfo.InvariantCulture)
            };

        #endregion
    }
}
