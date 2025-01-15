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
        /// The client
        /// </summary>
        private SpeedexClient _simulatedSpeedexClient;

        /// <summary>
        /// The HTTP handler that simulates the request
        /// </summary>
        private SimulationHttpHandler _simulatedHttpHandler;

        /// <summary>
        /// The HTTP client that simulates the request
        /// </summary>
        private HttpClient _simulatedHttpClient;

        /// <summary>
        /// A flag indicating whether the object is already disposed
        /// </summary>
        private bool _isAlreadyDisposed;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SpeedexClientUnitTests() : base()
        {
            _simulatedHttpHandler = new SimulationHttpHandler();

            _simulatedHttpClient = new HttpClient(_simulatedHttpHandler);

            _simulatedSpeedexClient = new(TestConstants.SpeedexCredentials, _simulatedHttpClient, true);
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

#pragma warning disable CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Validates that when every
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task APIMethodCalls()
        {
            using var speedexClient = new SpeedexClient(TestConstants.SpeedexCredentials, true);

            var sessionResponse = await speedexClient.CreateSessionAsync()
                .ConfigureAwait(true);

            AssertHttpRequest(sessionResponse);

            var createVoucherResponse = await speedexClient.CreateConsignmentAsync(TestConstants.TestConsignment);

            AssertHttpRequest(createVoucherResponse);

            var voucher = createVoucherResponse.Result.VoucherId;

            var pdfResponse = await speedexClient.GetConsignmentPdfAsync(voucher, PaperSize.A4)
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
        public async Task CreateSessionAsync_WithDemoCredentials_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateSessionAsync()
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
        public async Task CancelConsignmentByVoucherIdAsync_WithRandomVoucher_SuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.CancelConsignmentByVoucherIdAsync(voucher).ConfigureAwait(true);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreateConsignmentsAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentsAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentsAsync([ TestConstants.TestConsignment ]);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreateConsignmentAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentAsync(TestConstants.TestConsignment);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetConsignmentPdfsAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucherNumber()], PaperSize.A4, true);

            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(request);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetConsignmentPdfAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetConsignmentPdfAsync(TestHelpers.GenerateTestVoucherNumber(), PaperSize.A4, true);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetBranchesAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetBranchesAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetBranchesAsync("26441");

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetLastCheckPointAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastCheckPointAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetLastCheckPointAsync(TestHelpers.GenerateTestVoucherNumber());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetLastPickupCheckPointAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastPickupCheckPointAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(TestHelpers.GenerateTestVoucherNumber());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetTraceByClientReferencesAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByClientReferencesAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var request = new ClientReferencesRequestModel()
            {
                FirstClientReference = "Test"  
            };

            var response = await _simulatedSpeedexClient.GetTraceByClientReferencesAsync(request);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetTraceByTimeFrameAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByTimeFrameAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var dateto = DateTime.Now;

            var dateFrom = dateto.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetTraceByTimeFrameAsync(dateFrom, dateto);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetTraceByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByVoucherIdAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetTraceByVoucherIdAsync(TestHelpers.GenerateTestVoucherNumber());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CancelPickupByIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelPickupByIdAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(TestHelpers.GenerateTestVoucherNumber());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreatePickupAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var pickup = DateOnly.FromDateTime(DateTime.Now.AddDays(3));

            var request = new PickupRequestModel(TestHelpers.GenerateTestVoucherNumber(), pickup, DeliveryTimeLimit.NoLimit);

            var response = await _simulatedSpeedexClient.CreatePickupAsync(request);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetConsignmentsByDateRangeAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentsByDateRangeAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetConsignmentsByDateRangeAsync(dateFrom, dateTo);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetDepositedConsignmentsByDateRangeAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetDepositedConsignmentsByDateRangeAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(dateFrom, dateTo);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetPickupByIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPickupByIdAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(TestHelpers.GenerateTestVoucherNumber());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.ReschedulePickupAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReschedulePickupAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var pickupDate = DateTime.Now.AddDays(3);

            var request = new ReschedulePickupRequestModel(pickupDate, DeliveryTimeLimit.TenAMToOnePM);

            var response = await _simulatedSpeedexClient.ReschedulePickupAsync(request);

            AssertHttpRequest(response);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

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
                _simulatedSpeedexClient.Dispose();

                _simulatedSpeedexClient = null!;

                _simulatedHttpClient.Dispose();

                _simulatedHttpClient = null!;

                _simulatedHttpHandler.Dispose();

                _simulatedHttpHandler = null!;
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