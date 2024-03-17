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
        private static readonly SpeedexCredentials _speedexCredentials = new("demoapi", "GOOD-GO-HOME-GUYS", "002", "DEMO");

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
        public async Task FullTest()
        {
            using var newSpeedexClient = new SpeedexClient(_speedexCredentials, true);

            var sessionResponse = await newSpeedexClient.CreateSessionAsync();

            AssertHttpRequest(sessionResponse);

            var createVoucherResponse = await newSpeedexClient.CreateConsignmentAsync(new ConsignmentRequestModel(0, 2, ChargeType.Recipient, PaymentType.Cash, 2, "Test", "Test", "1234567890", "12345", 4));

            AssertHttpRequest(createVoucherResponse);

            var voucher = createVoucherResponse.Result.VoucherId;

            var pdfResponse = await newSpeedexClient.GetConsignmentPDFAsync(voucher, PaperSize.A4);

            AssertHttpRequest(pdfResponse);

            var lastCheckpointResponse = await newSpeedexClient.GetLastCheckPointAsync(voucher);

            AssertHttpRequest(lastCheckpointResponse);

            var checkpointsResponse = await newSpeedexClient.GetTraceByVoucherIdAsync(voucher);

            AssertHttpRequest(checkpointsResponse);

            var cancelVoucherResponse = await newSpeedexClient.CancelConsignmentByVoucherIdAsync(voucher);

            AssertHttpRequest(cancelVoucherResponse);

            var branchesResponse = await newSpeedexClient.GetBranchesAsync("36100");

            AssertHttpRequest(branchesResponse);
        }

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

            Assert.False(string.IsNullOrWhiteSpace(response.Result));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CancelConsignmentByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCancelConsignmentByVoucherMethodIsCalled_ItSuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucher();

            var response = await _speedexClient.CancelConsignmentByVoucherIdAsync(voucher);

            AssertHttpRequest(response);
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Asserts the <paramref name="httpRequestResult"/>
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result</param>
        private static void AssertHttpRequest<T>(HttpRequestResult<T> httpRequestResult)
        {
            AssertHttpRequest((HttpRequestResult)httpRequestResult);

            Assert.NotNull(httpRequestResult.Result);
        }

        /// <summary>
        /// Asserts the <paramref name="httpRequestResult"/>
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result</param>
        private static void AssertHttpRequest(HttpRequestResult httpRequestResult)
        {
            Assert.NotNull(httpRequestResult);

            Assert.True(httpRequestResult.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(httpRequestResult.RequestPayload));

            Assert.False(string.IsNullOrWhiteSpace(httpRequestResult.ResponsePayload));
        }

        #endregion
    }
}