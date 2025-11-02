using Couriers.Speedex.RequestModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal request model for creating consignments
    /// </summary>
    [XmlRoot("CreateBOL", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CreateConsignmentsInternalRequestModel : SessionIdInternalRequestModel
    {
        #region Public Properties

#pragma warning disable CA1819 // Properties should not return arrays

        /// <summary>
        /// The consignments
        /// </summary>
        [XmlArray("inListPod")]
        [XmlArrayItem("BOL")]
        public ConsignmentInternalRequestModel[]? Consignments { get; set; }

#pragma warning restore CA1819 // Properties should not return arrays

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CreateConsignmentsInternalRequestModel"/>
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
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(values);
#else
            if (values is null)
                throw new ArgumentNullException(nameof(values));
#endif

#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(agreementCode);

            ArgumentException.ThrowIfNullOrWhiteSpace(customerCode);
#else
            if (string.IsNullOrWhiteSpace(agreementCode))
                throw new ArgumentException($"'{nameof(agreementCode)}' cannot be null or whitespace.", nameof(agreementCode));

            if (string.IsNullOrWhiteSpace(customerCode))
                throw new ArgumentException($"'{nameof(customerCode)}' cannot be null or whitespace.", nameof(customerCode));
#endif

            // Transform the values
            var internalValues = values.Select(x => ConsignmentInternalRequestModel.FromRequestModel(x, agreementCode, customerCode)).ToArray();

            // Return the internal model
            return new CreateConsignmentsInternalRequestModel() { Consignments = internalValues };
        }

        #endregion
    }
}
