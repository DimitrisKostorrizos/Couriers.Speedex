using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The extension methods for <see cref="XObject"/>
    /// </summary>
    internal static class XObjectExtensions
    {
        /// <summary>
        /// Deserializes the <paramref name="element"/> to the specified <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the element</typeparam>
        /// <param name="element">The element</param>
        /// <returns></returns>
        public static T Deserialize<T>(this XContainer element)
            where T : class
        {
            // Use a temporary reader for the Xml element
            using (var reader = element.CreateReader())
            {
                // Initialize the serializer
                var serializer = new XmlSerializer(typeof(T));

                // Deserialize the reader
                var result = serializer.Deserialize(reader);

                // Cast the value
                var value = result as T;

                // If the cast failed...
                if (value is null)
                    throw new InvalidOperationException("Invalid XML");

                // Return the value
                return value;
            }
        }

        /// <summary>
        /// Serializes the <paramref name="obj"/> to the specified <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="obj">The object</param>
        /// <returns></returns>
        public static XElement SerializeToXElement<T>(this T obj)
        {
            // Declare a document
            var document = new XDocument();

            // Use a temporary reader for the Xml element
            using (var writer = document.CreateWriter())
            {
                // Declare the namespaces
                var namespaces = new XmlSerializerNamespaces();

                // Add the default namespace
                namespaces.Add(XmlNamespaces.DefaultPrefix, XmlNamespaces.DefaultNamespace);

                // Declare a new serializer for the object
                var serializer = new XmlSerializer(typeof(T));

                // Serialize the object
                serializer.Serialize(writer, obj, namespaces);
            }

            // Get the root element
            var element = document.Root;

            // If the cast failed...
            if (element is null)
                throw new InvalidOperationException("Invalid XML");

            // Remove the root element
            element.Remove();

            // Return the element
            return element;
        }
    }
}
