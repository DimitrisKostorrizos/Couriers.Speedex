using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="SpeedexClient"/>
    /// </summary>
    public class SpeedexClientUnitTests : IAsyncLifetime
    {
        #region Private Fields

        /// <summary>
        /// The test credentials
        /// </summary>
        private static readonly SpeedexCredentials _speedexCredentials = new("demoapi", "GOOD-GO-HOME-GUYS", "001", "DEMO");

        /// <summary>
        /// The client
        /// </summary>
        private SpeedexClient _speedexClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SpeedexClientUnitTests() : base()
        {
            var httpHandler = new SimulationHttpHandler();

            var httpClient = new HttpClient(httpHandler);

            _speedexClient = new(_speedexCredentials, httpClient, true);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Task DisposeAsync()
        {
            _speedexClient.Dispose();

            _speedexClient = null!;

            return Task.CompletedTask;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Task InitializeAsync()
            => Task.CompletedTask;

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreateSessionAsync"/> is called, 
        /// it successfully returns a session id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCreateSessionMethodIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.CreateSessionAsync();

            AssertHttpRequest(response);

            Assert.True(!string.IsNullOrWhiteSpace(response.Result));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CancelConsignmentByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCancelConsignmentByVoucherMethodIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.CancelConsignmentByVoucherIdAsync(Guid.NewGuid().ToString("N"));

            AssertHttpRequest(response);
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Asserts the <paramref name="httpRequestResult"/>
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result</param>
        private static void AssertHttpRequest(HttpRequestResult httpRequestResult)
        {
            Assert.NotNull(httpRequestResult);

            Assert.True(httpRequestResult.IsSuccessful);

            Assert.True(!string.IsNullOrWhiteSpace(httpRequestResult.RequestPayload));

            Assert.True(!string.IsNullOrWhiteSpace(httpRequestResult.ResponsePayload));
        }

        #endregion
    }
}