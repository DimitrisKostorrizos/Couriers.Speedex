using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting all the deposited consignments created on the specified date range
    /// </summary>
    [XmlRoot("GetDepositedConsignmentsByDateResponse", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetDepositedConsignmentsByDateInternalResponseModel : ISoapReturnMessageModel, ISoapResponseModel<IEnumerable<DepositedConsignmentResponseModel>>
    {
        #region Public Properties

        /// <summary>
        /// The return result
        /// </summary>
        [XmlElement("GetDepositedConsignmentsByDateResult")]
        public GetDepositedConsignmentsByDateResult Result { get; set; } = new();

        /// <summary>
        /// The return message
        /// </summary>
        string ISoapReturnMessageModel.Message { get => Result.Message; set { Result.Message = value; } }

        /// <summary>
        /// The return code
        /// </summary>
        uint ISoapReturnMessageModel.Code { get => Result.Code; set { Result.Code = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetDepositedConsignmentsByDateInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result.ToString();

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepositedConsignmentResponseModel> ToResponseModel() => Result.Results.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }

    /// <summary>
    /// The internal response model for deposited consignments result
    /// </summary>
    [XmlRoot(Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetDepositedConsignmentsByDateResult : ISoapResponseModel<IEnumerable<DepositedConsignmentResponseModel>>
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
        [XmlArrayItem("GetDepositedConsignmentsByDateResult")]
        public DepositedConsignmentInternalResponseModel[] Results { get; set; } = [];

        /// <summary>
        /// The return code
        /// </summary>
        [XmlElement("Code")]
        public uint Code { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetDepositedConsignmentsByDateResult() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Message;

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{T}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepositedConsignmentResponseModel> ToResponseModel() => Results.Select(x => x.ToResponseModel()).ToArray();

        #endregion
    }
}
