using System.Collections.Generic;
using System.Linq;

namespace Couriers.Speedex
{
    /// <summary>
    /// The response model for creating the consignments
    /// </summary>
    public class CreateConsignmentsResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The consignments
        /// </summary>
        public IEnumerable<ConsignmentResponseModel> Consignments { get; set; } = Enumerable.Empty<ConsignmentResponseModel>();

        /// <summary>
        /// The consignments
        /// </summary>
        public IEnumerable<string> Statuses { get; set; } = Enumerable.Empty<string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateConsignmentsResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Consignments.Count().ToString();

        #endregion
    }
}
