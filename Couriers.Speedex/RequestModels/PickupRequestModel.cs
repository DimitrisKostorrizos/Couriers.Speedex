using System;
using System.Collections.Generic;
using System.Linq;

namespace Couriers.Speedex
{
    /// <summary>
    /// The request model for the pickup
    /// </summary>
    public class PickupRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The ids for the connected master consignments
        /// NOTE: The maximum count is 5 master consignment numbers
        /// </summary>
        public IEnumerable<string> ConsignmentIds { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// The comments
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// The requested date of the pickup
        /// </summary>
        public DateTime PickupDate { get; set; }

        /// <summary>
        /// The delivery time
        /// </summary>
        public DeliveryTimeLimit DeliveryTime { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PickupRequestModel() : base()
        {

        }

        #endregion
    }
}
