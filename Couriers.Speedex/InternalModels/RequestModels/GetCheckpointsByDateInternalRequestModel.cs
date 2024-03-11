using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for getting the checkpoints for all the new checkpoints of the consignments, in a specific time frame 
    /// </summary>
    [XmlRoot("GetTraceByDate", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetCheckpointsByTimeFrameInternalRequestModel : SessionIdInternalRequestModel
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
        public GetCheckpointsByTimeFrameInternalRequestModel() : base()
        {

        }

        #endregion
    }
}
