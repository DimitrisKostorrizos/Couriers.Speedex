using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The Xml namespaces used for the accessing the Speedex web service
    /// </summary>
    public static class SpeedexXmlNamespaces
    {
        /// <summary>
        /// The Xml namespaces
        /// </summary>
        public static XmlSerializerNamespaces Namespaces = new(
        [
            new(DefaultPrefix, DefaultNamespace),
            new(SoapPrefix, SoapNamespace),
            new(XsiPrefix, XsiNamespace),
            new(XsdPrefix, XsdNamespace)
        ]);

        #region Prefixes

        /// <summary>
        /// The prefix for the default namespace
        /// </summary>
        public const string DefaultPrefix = "";

        /// <summary>
        /// The prefix for the SOAP 1.2 namespace
        /// </summary>
        public const string SoapPrefix = "soap12";

        /// <summary>
        /// The prefix for the Xsi namespace
        /// </summary>
        public const string XsiPrefix = "xsi";

        /// <summary>
        /// The prefix for the Xsd namespace
        /// </summary>
        public const string XsdPrefix = "xsd";

        #endregion

        #region Namespaces

        /// <summary>
        /// The default namespace
        /// </summary>
        public const string DefaultNamespace = "https://spdxws.gr/";

        /// <summary>
        /// The SOAP namespace
        /// </summary>
        public const string SoapNamespace = "http://www.w3.org/2003/05/soap-envelope";

        /// <summary>
        /// The Xsi namespace
        /// </summary>
        public const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// The Xsd namespace
        /// </summary>
        public const string XsdNamespace = "http://www.w3.org/2001/XMLSchema";

        #endregion
    }
}
