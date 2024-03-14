using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for getting all the consignments created on the specified date range
    /// </summary>
    [XmlRoot("GetDepositedConsignmentsByDate", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetDepositedConsignmentsByDateRangeInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The beginning of the time frame
        /// </summary>
        [XmlElement("dateFrom")]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// The end of the time frame
        /// </summary>
        [XmlElement("dateTo")]
        public DateTime DateTo { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetDepositedConsignmentsByDateRangeInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
