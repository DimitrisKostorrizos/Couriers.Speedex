using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting the consignment PDF
    /// </summary>
    [XmlRoot("GetBOLPdfResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetConsignmentPDFInternalResponseModel : ReturnMessageInternalResponseModel, ISOAPResponseModel<IEnumerable<ConsignmentPDFResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The vouchers
        /// </summary>
        [XmlArray("GetBOLPdfResult")]
        [XmlArrayItem("Voucher")]
        public List<ConsignmentPDFInternalResponseModel> Vouchers { get; set; } = [];

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetConsignmentPDFInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Vouchers: {Vouchers.Count}";

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{ConsignmentPDFResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentPDFResponseModel> ToResponseModel() => Vouchers.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
