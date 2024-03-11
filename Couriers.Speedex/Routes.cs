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
        public const string TestAPIBaseAddress = "https://devspdxws.gr/accesspoint.asmx";

        /// <summary>
        /// The base address
        /// </summary>
        public const string BaseAddress = "https://spdxws.gr/accesspoint.asmx";

        /// <summary>
        /// Get the base address based on the <paramref name="shouldAccessTestAPI"/>
        /// </summary>
        /// <param name="shouldAccessTestAPI">The flag indicating whether to access the test API</param>
        /// <returns></returns>
        public static string GetBaseAddress(bool shouldAccessTestAPI = false) => shouldAccessTestAPI ? TestAPIBaseAddress : BaseAddress;
    }
}
