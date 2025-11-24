using Couriers.Speedex.Interfaces;
using Couriers.Speedex.ResponseModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.ResponseModels
{
    /// <summary>
    /// The internal response model for getting all the consignments created on the specified date range
    /// </summary>
    [XmlRoot("GetConsignmentsByDateResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetConsignmentsByDateInternalResponseModel : ISoapReturnMessageModel, ISoapResponseModel<IEnumerable<ConsignmentDetailsResponseModel>>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The return result
        /// </summary>
        [XmlElement("GetConsignmentsByDateResult")]
        public GetConsignmentsByDateResult Result { get; set; } = new GetConsignmentsByDateResult();

        /// <summary>
        /// The return message
        /// </summary>
        [ExcludeFromCodeCoverage]
        string ISoapReturnMessageModel.Message
        {
            get => Result.Message;
            set { Result.Message = value; }
        }

        /// <summary>
        /// The return code
        /// </summary>
        [ExcludeFromCodeCoverage]
        uint ISoapReturnMessageModel.Code
        {
            get => Result.Code;
            set => Result.Code = value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetConsignmentsByDateInternalResponseModel"/>
        /// </summary>
        public GetConsignmentsByDateInternalResponseModel() : base()
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
            => Result.ToString();

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentDetailsResponseModel> ToResponseModel()
            => Result.Results.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }

    /// <summary>
    /// The internal response model for deposited consignments result
    /// </summary>
    [XmlRoot(Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetConsignmentsByDateResult : ISoapResponseModel<IEnumerable<ConsignmentDetailsResponseModel>>, IUnmappedXml
    {
        #region Public Properties

        /// <summary>
        /// The return message
        /// </summary>
        [XmlElement("Message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The results
        /// </summary>
        [XmlArray("Result")]
        [XmlArrayItem("Consignment")]
        public ConsignmentDetailsInternalResponseModel[] Results { get; set; } = Array.Empty<ConsignmentDetailsInternalResponseModel>();

        /// <summary>
        /// The return code
        /// </summary>
        [XmlElement("Code")]
        public uint Code { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [XmlAnyElement]
        public XmlElement[]? UnmappedElements { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetConsignmentsByDateResult"/>
        /// </summary>
        public GetConsignmentsByDateResult() : base()
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
            => Message;

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentDetailsResponseModel> ToResponseModel()
            => Results.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}