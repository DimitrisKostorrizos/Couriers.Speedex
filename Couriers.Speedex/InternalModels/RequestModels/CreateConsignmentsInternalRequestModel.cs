using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal request model for creating consignments
    /// </summary>
    [XmlRoot("CreateBOL", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CreateConsignmentsInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The consignments
        /// </summary>
        [XmlArray("inListPod")]
        [XmlArrayItem("BOL")]
        public ConsignmentInternalRequestModel[]? Consignments { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateConsignmentsInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="CreateConsignmentsInternalRequestModel"/> from the <paramref name="values"/>
        /// </summary>
        /// <param name="values">The request models</param>
        /// <param name="agreementCode">The agreement code</param>
        /// <param name="customerCode">The customer code</param>
        /// <returns></returns>
        public static CreateConsignmentsInternalRequestModel FromRequestModel([NotNull] IEnumerable<ConsignmentRequestModel> values, [NotNull] string agreementCode, [NotNull] string customerCode)
        {
            ArgumentNullException.ThrowIfNull(values, nameof(values));

            ArgumentException.ThrowIfNullOrWhiteSpace(agreementCode, nameof(agreementCode));

            ArgumentException.ThrowIfNullOrWhiteSpace(customerCode, nameof(customerCode));

            // Transform the values
            var internalValues = values.Select(x => ConsignmentInternalRequestModel.FromRequestModel(x, agreementCode, customerCode)).ToArray();

            // Return the internal model
            return new CreateConsignmentsInternalRequestModel() { Consignments = internalValues };
        }

        #endregion
    }
}
