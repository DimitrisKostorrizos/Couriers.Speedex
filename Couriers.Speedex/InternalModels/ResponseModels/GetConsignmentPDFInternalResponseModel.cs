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
    public class GetConsignmentPdfInternalResponseModel : ReturnMessageInternalResponseModel, ISoapResponseModel<IEnumerable<ConsignmentPdfResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The vouchers
        /// </summary>
        [XmlArray("GetBOLPdfResult")]
        [XmlArrayItem("Voucher")]
        public ConsignmentPdfInternalResponseModel[] Vouchers { get; set; } = [];

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetConsignmentPdfInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Vouchers: {Vouchers.Length}";

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentPdfResponseModel> ToResponseModel() => Vouchers.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
