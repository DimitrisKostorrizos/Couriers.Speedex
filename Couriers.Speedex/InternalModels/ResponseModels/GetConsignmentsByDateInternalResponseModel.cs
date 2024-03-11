using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for getting all the consignments created on the specified date range
    /// </summary>
    [XmlRoot("GetConsignmentsByDateResponse", Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetConsignmentsByDateInternalResponseModel : ISOAPReturnMessageModel, ISOAPResponseModel<IEnumerable<ConsignmentDetailsResponseModel>>
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
        string ISOAPReturnMessageModel.Message { get => Result.Message; set { Result.Message = value; } }

        /// <summary>
        /// The return code
        /// </summary>
        uint ISOAPReturnMessageModel.Code { get => Result.Code; set { Result.Code = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetConsignmentsByDateInternalResponseModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Result.ToString();

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{ConsignmentDetailsResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentDetailsResponseModel> ToResponseModel() => Result.Results.Select(x => x.ToResponseModel()).ToList();

        #endregion
    }

    /// <summary>
    /// The internal response model for deposited consignments result
    /// </summary>
    [XmlRoot(Namespace = XmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GetConsignmentsByDateResult : ISOAPResponseModel<IEnumerable<ConsignmentDetailsResponseModel>>
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
        public List<ConsignmentDetailsInternalResponseModel> Results { get; set; } = new();

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
        public GetConsignmentsByDateResult() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Message;

        /// <summary>
        /// Creates and return the <see cref="IEnumerable{ConsignmentDetailsResponseModel}"/> from the current object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsignmentDetailsResponseModel> ToResponseModel() => Results.Select(x => x.ToResponseModel()).ToList();

        #endregion
    }
}
