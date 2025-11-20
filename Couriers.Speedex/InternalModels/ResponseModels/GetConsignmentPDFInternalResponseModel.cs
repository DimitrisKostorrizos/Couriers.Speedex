using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
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
        /// Creates a new instance of <see cref="GetConsignmentPdfInternalResponseModel"/>
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
        [ExcludeFromCodeCoverage]
        public override string ToString() 
            => $"Vouchers: {Vouchers.Length}";

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentPdfResponseModel> ToResponseModel()
            => [.. Vouchers.Select(x => x.ToResponseModel())];

        #endregion
    }
}