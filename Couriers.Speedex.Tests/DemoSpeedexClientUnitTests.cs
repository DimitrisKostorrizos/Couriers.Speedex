using Couriers.Speedex.Services;

using System;
using System.Net.Http;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="DemoSpeedexClient"/>
    /// </summary>
    public sealed class DemoSpeedexClientUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DemoSpeedexClientUnitTests"/>
        /// </summary>
        public DemoSpeedexClientUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="DemoSpeedexClient"/> constructors are called, 
        /// using valid data, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void DemoSpeedexClient_WithValidData_ExpectedResultIsReturned()
        {
            var client = new DemoSpeedexClient(TestConstants.SpeedexCredentials);

            var apiUrl = new Uri("https://devspdxws.gr/accesspoint.asmx");

            Assert.NotNull(client);

            Assert.Equal(apiUrl, client.APIURL);

            Assert.Equal(TestConstants.SpeedexCredentials, client.Credentials);

            client = new DemoSpeedexClient(TestConstants.SpeedexCredentials, new HttpClient());

            Assert.NotNull(client);

            Assert.Equal(apiUrl, client.APIURL);

            Assert.Equal(TestConstants.SpeedexCredentials, client.Credentials);

            client.Dispose();
        }

        #endregion

        #endregion
    }
}