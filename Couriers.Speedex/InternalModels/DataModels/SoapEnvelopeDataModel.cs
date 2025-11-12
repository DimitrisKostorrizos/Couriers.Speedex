using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.DataModels
{
    /// <summary>
    /// The data model for the SOAP envelope
    /// </summary>
    /// <typeparam name="TBody">The body</typeparam>
    [XmlRoot("Envelope", Namespace = SpeedexXmlNamespaces.SoapNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Creates a new instance of <see cref="SoapEnvelopeDataModel{TBody}"/>
        /// </summary>
        public SoapEnvelopeDataModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Body.ToString();

        #endregion
    }
}
