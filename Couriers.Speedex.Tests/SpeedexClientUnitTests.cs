using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="SpeedexClient"/>
    /// </summary>
    public sealed class SpeedexClientUnitTests : IAsyncLifetime, IDisposable
    {
        #region Private Fields

        /// <summary>
        /// A flag indicating whether the object is already disposed
        /// </summary>
        private bool _isAlreadyDisposed;

        /// <summary>
        /// The test credentials
        /// </summary>
        private static readonly SpeedexCredentials _speedexCredentials = new("demoapi", "GOOD-GO-HOME-GUYS", "002", "DEMO");

        /// <summary>
        /// The client
        /// </summary>
        private SpeedexClient _speedexClient = new (_speedexCredentials, new HttpClient(new SimulationHttpHandler()), true);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SpeedexClientUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Task DisposeAsync()
        {
            Dispose(true);

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
            using var speedexClient = new SpeedexClient(_speedexCredentials, true);

            var sessionResponse = await speedexClient.CreateSessionAsync()
                .ConfigureAwait(true);

            AssertHttpRequest(sessionResponse);

            var createVoucherResponse = await speedexClient.CreateConsignmentAsync(new ConsignmentRequestModel(0, 2, ChargeType.Recipient, PaymentType.Cash, 2, "Test", "Test", "1234567890", "12345", 4))
                .ConfigureAwait(true);

            AssertHttpRequest(createVoucherResponse);

            var voucher = createVoucherResponse.Result.VoucherId;

            var pdfResponse = await speedexClient.GetConsignmentPDFAsync(voucher, PaperSize.A4)
                .ConfigureAwait(true);

            AssertHttpRequest(pdfResponse);

            var lastCheckpointResponse = await speedexClient.GetLastCheckPointAsync(voucher)
                .ConfigureAwait(true);

            AssertHttpRequest(lastCheckpointResponse);

            var checkpointsResponse = await speedexClient.GetTraceByVoucherIdAsync(voucher)
                .ConfigureAwait(true);

            AssertHttpRequest(checkpointsResponse);

            var cancelVoucherResponse = await speedexClient.CancelConsignmentByVoucherIdAsync(voucher)
                .ConfigureAwait(true);

            AssertHttpRequest(cancelVoucherResponse);

            var branchesResponse = await speedexClient.GetBranchesAsync("36100")
                .ConfigureAwait(true);

            AssertHttpRequest(branchesResponse);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreateSessionAsync"/> is called, 
        /// it successfully returns a session id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCreateSessionMethodIsCalledItSuccessfullyReturns()
        {
            var response = await _speedexClient.CreateSessionAsync()
                .ConfigureAwait(true);

            AssertHttpRequest(response);

            Assert.False(string.IsNullOrWhiteSpace(response.Result));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CancelConsignmentByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCancelConsignmentByVoucherMethodIsCalledItSuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucher();

            var response = await _speedexClient.CancelConsignmentByVoucherIdAsync(voucher).ConfigureAwait(true);

            AssertHttpRequest(response);
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Disposes the managed and unmanaged resources that this objects uses
        /// </summary>
        /// <param name="disposing">A flag indicating whether the current object should be disposed</param>
        private void Dispose(bool disposing)
        {
            if (_isAlreadyDisposed)
                return;

            if (disposing)
            {
                _speedexClient.Dispose();

                _speedexClient = null!;
            }

            _isAlreadyDisposed = true;
        }

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