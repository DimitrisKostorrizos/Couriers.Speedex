using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The routes used for accessing the Speedex web service
    /// </summary>
    internal static class Routes
    {
        /// <summary>
        /// The base address for the test API
        /// </summary>
        public static readonly Uri TestAPIBaseAddress = new("https://devspdxws.gr/accesspoint.asmx");

        /// <summary>
        /// The base address
        /// </summary>
        public static readonly Uri BaseAddress = new("https://spdxws.gr/accesspoint.asmx");

        /// <summary>
        /// Get the base address based on the <paramref name="shouldAccessTestAPI"/>
        /// </summary>
        /// <param name="shouldAccessTestAPI">The flag indicating whether to access the test API</param>
        /// <returns></returns>
        public static Uri GetBaseAddress(bool shouldAccessTestAPI = false) => shouldAccessTestAPI ? TestAPIBaseAddress : BaseAddress;
    }
}
