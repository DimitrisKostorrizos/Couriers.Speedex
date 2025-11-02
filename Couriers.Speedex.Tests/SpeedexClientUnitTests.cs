using Couriers.Shared.ResultTypes;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;
using Couriers.Speedex.Services;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="DemoSpeedexClient"/>
    /// </summary>
    public sealed class SpeedexClientUnitTests : IAsyncLifetime, IDisposable
    {
        #region Private Fields

        /// <summary>
        /// The client
        /// </summary>
        private DemoSpeedexClient _simulatedSpeedexClient;

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
        /// Creates a new instance of <see cref="SpeedexClientUnitTests"/>
        /// </summary>
        public SpeedexClientUnitTests() : base()
        {
            _simulatedHttpHandler = new SimulationHttpHandler();

            _simulatedHttpClient = new HttpClient(_simulatedHttpHandler);

            _simulatedSpeedexClient = new(TestConstants.SpeedexCredentials, _simulatedHttpClient);
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
        public ValueTask DisposeAsync()
        {
            Dispose(true);

            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public ValueTask InitializeAsync()
            => ValueTask.CompletedTask;

        #region Test Methods

#pragma warning disable CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Validates that when every
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task APIMethodCalls()
        {
            var cancellationToken = TestContext.Current
                                    .CancellationToken;

            var startingTime = DateTime.Now.AddHours(-10);

            using var speedexClient = new DemoSpeedexClient(TestConstants.SpeedexCredentials);

            var sessionResponse = await speedexClient.CreateSessionAsync(cancellationToken);

            AssertHttpRequest(sessionResponse);

            var createVoucherResponse = await speedexClient.CreateConsignmentAsync(TestConstants.TestConsignment, cancellationToken);

            AssertHttpRequest(createVoucherResponse);

            var endingTime = DateTime.Now.AddHours(1);

            var voucher = createVoucherResponse.Result.ConsignmentId;

            var getVoucherResponse = await speedexClient.GetConsignmentsByDateRangeAsync(startingTime, endingTime, cancellationToken);

            AssertHttpRequest(getVoucherResponse);

            var pdfResponse = await speedexClient.GetConsignmentPdfAsync(voucher, PaperSize.A4, false, cancellationToken);

            AssertHttpRequest(pdfResponse);

            var lastCheckpointResponse = await speedexClient.GetLastCheckPointAsync(voucher, cancellationToken);

            AssertHttpRequest(lastCheckpointResponse);

            var checkpointsResponse = await speedexClient.GetTraceByVoucherIdAsync(voucher, cancellationToken);

            AssertHttpRequest(checkpointsResponse);

            var cancelVoucherResponse = await speedexClient.CancelConsignmentByVoucherIdAsync(voucher, cancellationToken);

            AssertHttpRequest(cancelVoucherResponse);

            var branchesResponse = await speedexClient.GetBranchesAsync(TestConstants.BranchCode, SupportedLanguage.Greek, cancellationToken);

            AssertHttpRequest(branchesResponse);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateSessionAsync"/> is called, 
        /// it successfully returns a session id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSessionAsync_WithDemoCredentials_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateSessionAsync(TestContext.Current.CancellationToken);

            AssertHttpRequest(response);

            Assert.False(string.IsNullOrWhiteSpace(response.Result));
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelConsignmentByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelConsignmentByVoucherIdAsync_WithRandomVoucher_SuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.CancelConsignmentByVoucherIdAsync(voucher, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentsAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentsAsync([TestConstants.TestConsignment], TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentAsync(TestConstants.TestConsignment, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucherNumber()], PaperSize.A4, true);

            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(request, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetConsignmentPdfAsync(TestHelpers.GenerateTestVoucherNumber(), PaperSize.A4, true, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetBranchesAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetBranchesAsync("26441", SupportedLanguage.Greek, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastCheckPointAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetLastCheckPointAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastPickupCheckPointAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync"/> is called, 
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

            var response = await _simulatedSpeedexClient.GetTraceByClientReferencesAsync(request, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByTimeFrameAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var dateto = DateTime.Now;

            var dateFrom = dateto.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetTraceByTimeFrameAsync(dateFrom, dateto, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByVoucherIdAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetTraceByVoucherIdAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelPickupByIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelPickupByIdAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreatePickupAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var pickup = DateTime.Now.AddDays(3);

            var request = new PickupRequestModel(TestHelpers.GenerateTestVoucherNumber(), pickup, DeliveryTimeLimit.NoLimit);

            var response = await _simulatedSpeedexClient.CreatePickupAsync(request, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentsByDateRangeAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetConsignmentsByDateRangeAsync(dateFrom, dateTo, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetDepositedConsignmentsByDateRangeAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(dateFrom, dateTo, TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPickupByIdAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.ReschedulePickupAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReschedulePickupAsync_WithMoqedData_ItSuccessfullyReturns()
        {
            var pickupDate = DateTime.Now.AddDays(3);

            var request = new ReschedulePickupRequestModel(pickupDate, DeliveryTimeLimit.TenAMToOnePM);

            var response = await _simulatedSpeedexClient.ReschedulePickupAsync(request, TestContext.Current.CancellationToken);

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
        private static void AssertHttpRequest<T>(IHttpRequestResult<T> httpRequestResult)
        {
            AssertHttpRequest((IHttpRequestResult)httpRequestResult);

            Assert.NotNull(httpRequestResult.Result);
        }

        /// <summary>
        /// Asserts the <paramref name="httpRequestResult"/>
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result</param>
        private static void AssertHttpRequest(IHttpRequestResult httpRequestResult)
        {
            Assert.NotNull(httpRequestResult);

            Assert.True(httpRequestResult.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(httpRequestResult.RequestPayload));

            Assert.False(string.IsNullOrWhiteSpace(httpRequestResult.ResponsePayload));
        }

        #endregion
    }
}