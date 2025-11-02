using Couriers.Speedex.Constants;
using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for the deposited consignment
    /// </summary>
    [XmlRoot(Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class DepositedConsignmentInternalResponseModel : ISoapResponseModel<DepositedConsignmentResponseModel>
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
        /// Creates a new instance of <see cref="DepositedConsignmentInternalResponseModel"/>
        /// </summary>
        public DepositedConsignmentInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public DepositedConsignmentResponseModel ToResponseModel()
        {
            var dateDeposited = DateTime.Parse(DateDeposited, SpeedexConstants.SpeedexCultureInfo);

            return new(Id, Amount, dateDeposited);
        }

        #endregion
    }
}
