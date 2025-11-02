using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Couriers.Speedex.Services
{
    /// <summary>
    /// The client for the demo Speedex web service
    /// </summary>
    public class DemoSpeedexClient : BaseSpeedexClient
    {
        #region Public Properties

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override Uri APIURL { get; } = new("https://devspdxws.gr/accesspoint.asmx");

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SpeedexClient"/>
        /// </summary>
        /// <param name="credentials">The credentials</param>
        /// <param name="httpClient">The HTTP client</param>
        public DemoSpeedexClient([NotNull] SpeedexCredentials credentials, [NotNull] HttpClient httpClient) : base(credentials, httpClient)
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="SpeedexClient"/>
        /// </summary>
        /// <param name="credentials">The credentials</param>
        public DemoSpeedexClient([NotNull] SpeedexCredentials credentials) : base(credentials)
        {

        }

        #endregion
    }
}