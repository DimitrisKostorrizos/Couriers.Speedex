using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

#if NET8_0_OR_GREATER
        /// <summary>
        /// The vouchers
        /// </summary>
        [XmlArray("GetBOLPdfResult")]
        [XmlArrayItem("Voucher")]
        public ConsignmentPdfInternalResponseModel[] Vouchers { get; set; } = [];
#else
        /// <summary>
        /// The vouchers
        /// </summary>
        [XmlArray("GetBOLPdfResult")]
        [XmlArrayItem("Voucher")]
        public ConsignmentPdfInternalResponseModel[] Vouchers { get; set; } = Array.Empty<ConsignmentPdfInternalResponseModel>();
#endif

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
        public IEnumerable<ConsignmentPdfResponseModel> ToResponseModel()
        {
#if NET8_0_OR_GREATER
            return [.. Vouchers.Select(x => x.ToResponseModel())];
#else
            return Vouchers.Select(x => x.ToResponseModel()).ToArray();
#endif
        }

        #endregion
    }
}
