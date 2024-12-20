using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The data model for the SOAP envelope body
    /// </summary>
    [XmlRoot("Envelope")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class SoapEnvelopeBodyDataModel<TBody>
        where TBody : class, new()
    {
        #region Public Properties

        /// <summary>
        /// The embedded model
        /// </summary>
        [XmlIgnore]
        public TBody Model { get; set; } = null!;

        /// <summary>
        /// The serializable XML entity
        /// </summary>
        [XmlAnyElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement XmlEntity
        {
            get => XmlHelpers.SerializeToXElement(Model);
            set => Model = XmlHelpers.Deserialize<TBody>(value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SoapEnvelopeBodyDataModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Model.ToString() ?? string.Empty;

        #endregion
    }
}
