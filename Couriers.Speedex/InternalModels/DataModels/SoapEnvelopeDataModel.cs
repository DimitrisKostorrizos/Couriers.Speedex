using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The data model for the SOAP envelope
    /// </summary>
    /// <typeparam name="TBody">The body</typeparam>
    [XmlRoot("Envelope", Namespace = XmlNamespaces.SoapNamespace)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoapEnvelopeDataModel<TBody>
        where TBody : class, new()
    {
        #region Public Properties

        /// <summary>
        /// The envelope body
        /// </summary>
        [XmlElement("Body")]
        public SoapEnvelopeBodyDataModel<TBody> Body { get; set; } = new SoapEnvelopeBodyDataModel<TBody>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SoapEnvelopeDataModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Body.ToString();

        #endregion
    }
}
