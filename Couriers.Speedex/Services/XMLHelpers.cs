using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// Helper methods associated with the XML model
    /// </summary>
    internal static class XMLHelpers
    {
        #region Constants

        /// <summary>
        /// The default XML writer settings
        /// </summary>
        private static readonly XmlWriterSettings _defaultSettings = new()
        {
            Indent = true,
            NewLineOnAttributes = true,
            Async = true,
            CloseOutput = true,
            OmitXmlDeclaration = true
        };

        #endregion

        #region Public Methods

        /// <summary>
        /// Serializes the specified <paramref name="obj"/> to an XML string, using the specified <paramref name="namespaces"/>
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <param name="namespaces">The name spaces</param>
        public static string ToXml(object obj, XmlSerializerNamespaces namespaces)
        {
            var objectType = obj.GetType();

            var xmlSerializer = new XmlSerializer(objectType);

            var stringBuilder = new StringBuilder();

            using (var writer = XmlWriter.Create(stringBuilder, _defaultSettings))
            {
                xmlSerializer.Serialize(writer, obj, namespaces);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Serializes the specified <paramref name="obj"/> to an XML string, using the specified <paramref name="namespaces"/> and the specified <paramref name="settings"/>
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <param name="namespaces">The name spaces</param>
        /// <param name="settings">The settings</param>
        public static string ToXml(object obj, XmlSerializerNamespaces namespaces, XmlWriterSettings settings)
        {
            var T = obj.GetType();

            var xs = new XmlSerializer(T);

            var sb = new StringBuilder();

            using (var writer = XmlWriter.Create(sb, settings))
            {
                xs.Serialize(writer, obj, namespaces);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Deserializes the specified <paramref name="xml"/> to an object of the
        /// specified type
        /// </summary>
        /// <param name="xml">The XML</param>
        public static T? FromXml<T>(string xml) => (T?)FromXml(xml, typeof(T));

        /// <summary>
        /// Deserializes the specified <paramref name="xml"/> to an object
        /// of the specified <paramref name="type"/>
        /// </summary>
        public static object? FromXml(string xml, Type type)
        {
            if (type == typeof(string))
                return xml;

            using var stringReader = new StringReader(xml);

            var xmlSerializer = new XmlSerializer(type);

            return xmlSerializer.Deserialize(stringReader);
        }

        #endregion
    }
}
