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
    public class CreateConsignmentsInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<IEnumerable<ConsignmentResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The consignments
        /// </summary>
        [XmlArray("outListPod")]
        [XmlArrayItem("BOL")]
        public ConsignmentInternalResponseModel[] Consignments { get; set; } = [];

        /// <summary>
        /// The consignments
        /// </summary>
        [XmlArray("statusList")]
        [XmlArrayItem("string")]
        public string[] Statuses { get; set; } = [];

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
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Consignments: {Consignments.Length}";

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentResponseModel> ToResponseModel() => Consignments.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
