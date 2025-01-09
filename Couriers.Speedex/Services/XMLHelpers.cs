using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// Helper methods associated with the XML model
    /// </summary>
    public static class XmlHelpers
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
        /// Deserializes the <paramref name="element"/> to the specified <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the element</typeparam>
        /// <param name="element">The element</param>
        /// <returns></returns>
        public static T Deserialize<T>([NotNull] this XContainer element)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(element);

            // Use a temporary reader for the Xml element
            using var reader = element.CreateReader();

            // Initialize the serializer
            var serializer = new XmlSerializer(typeof(T));

            // Deserialize the reader
            var result = serializer.Deserialize(reader);

            // If the cast failed...
            if (result is not T value)
                throw new InvalidOperationException("Invalid XML");

            // Return the value
            return value;
        }

        /// <summary>
        /// Serializes the <paramref name="obj"/> to the specified <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="obj">The object</param>
        /// <returns></returns>
        public static XElement SerializeToXElement<T>([NotNull] this T obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            // Declare a document
            var document = new XDocument();

            // Use a temporary reader for the Xml element
            using (var writer = document.CreateWriter())
            {
                // Declare the namespaces
                var namespaces = new XmlSerializerNamespaces();

                // Add the default namespace
                namespaces.Add(SpeedexXmlNamespaces.DefaultPrefix, SpeedexXmlNamespaces.DefaultNamespace);

                // Declare a new serializer for the object
                var serializer = new XmlSerializer(typeof(T));

                // Serialize the object
                serializer.Serialize(writer, obj, namespaces);
            }

            // Get the root element
            var element = document.Root
                ?? throw new InvalidOperationException("Invalid XML");

            // Remove the root element
            element.Remove();

            // Return the element
            return element;
        }

        /// <summary>
        /// Serializes the specified <paramref name="obj"/> to an XML string, using the specified <paramref name="namespaces"/>
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <param name="namespaces">The name spaces</param>
        public static string ToXml([NotNull] object obj, [NotNull] XmlSerializerNamespaces namespaces)
        {
            ArgumentNullException.ThrowIfNull(obj);

            ArgumentNullException.ThrowIfNull(namespaces);

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
        public static string ToXml([NotNull] object obj, [NotNull] XmlSerializerNamespaces namespaces, [NotNull] XmlWriterSettings settings)
        {
            ArgumentNullException.ThrowIfNull(obj);

            ArgumentNullException.ThrowIfNull(namespaces);

            ArgumentNullException.ThrowIfNull(settings);

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
        public static T? FromXml<T>([NotNull] string xml) 
            => (T?)FromXml(xml, typeof(T));

        /// <summary>
        /// Deserializes the specified <paramref name="xml"/> to an object
        /// of the specified <paramref name="type"/>
        /// </summary>
        public static object? FromXml([NotNull] string xml, [NotNull] Type type)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(xml);

            ArgumentNullException.ThrowIfNull(type);

            if (type == typeof(string))
                return xml;

            ArgumentException.ThrowIfNullOrWhiteSpace(xml);

            using var stringReader = new StringReader(xml);

            var xmlSerializer = new XmlSerializer(type);

            using var xmlReader = XmlReader.Create(stringReader);

            return xmlSerializer.Deserialize(xmlReader);
        }

        #endregion
    }
}
