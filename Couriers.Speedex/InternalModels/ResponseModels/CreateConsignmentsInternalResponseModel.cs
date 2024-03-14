using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for creating consignments
    /// </summary>
    [XmlRoot("CreateBOLResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CreateConsignmentsInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<CreateConsignmentsResponseModel>
    {
        #region Public Properties

        /// <summary>
        /// The consignments
        /// </summary>
        [XmlArray("outListPod")]
        [XmlArrayItem("BOL")]
        public List<ConsignmentInternalResponseModel> Consignments { get; set; } = [];

        /// <summary>
        /// The consignments
        /// </summary>
        [XmlArray("statusList")]
        [XmlArrayItem("string")]
        public List<string> Statuses { get; set; } = [];

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateConsignmentsInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Consignments.Count.ToString();

        /// <summary>
        /// Creates and return the <see cref="CreateConsignmentsResponseModel"/> from the current object
        /// </summary>
        /// <returns></returns>
        public CreateConsignmentsResponseModel ToResponseModel() => new CreateConsignmentsResponseModel()
        {
            Consignments = Consignments.Select(x => x.ToResponseModel()).ToList(),
            Statuses = Statuses
        };

        #endregion
    }
}
