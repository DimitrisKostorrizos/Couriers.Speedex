using System.Xml;
using System.Xml.Serialization;

namespace Couriers.Speedex.Interfaces
{
    /// <summary>
    /// Provides abstractions for an XML type, that might contain unmapped elements
    /// </summary>
    internal interface IUnmappedXml
    {
        #region Properties

        /// <summary>
        /// Contains any unmapped XML elements
        /// </summary>
        [XmlAnyElement]
        XmlElement[]? UnmappedElements { get; set; }

        /// <summary>
        /// A flag indicating whether any unmapped elements exist
        /// </summary>
        bool HasUnmappedElements => UnmappedElements is not null && UnmappedElements.Length > 0;

        #endregion
    }
}
