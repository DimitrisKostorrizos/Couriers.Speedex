using Couriers.Common.ResultTypes;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;
using Couriers.Speedex.Services;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="BaseSpeedexClient"/>
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
        /// Validates that when <see cref="BaseSpeedexClient.CreateSessionAsync"/> is called, 
        /// with valid data, it successfully returns a session id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSessionAsync_WithDemoCredentials_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateSessionAsync(TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);

            Assert.False(string.IsNullOrWhiteSpace(response.Result));
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelConsignmentByVoucherIdAsync"/> is called, 
        /// with empty data, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task CancelConsignmentByVoucherIdAsync_WithEmptyVoucher_UnsuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.CancelConsignmentByVoucherIdAsync(voucher!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelConsignmentByVoucherIdAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelConsignmentByVoucherIdAsync_WithRandomVoucher_SuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.CancelConsignmentByVoucherIdAsync(voucher, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync"/> is called, 
        /// with empty data, it unsuccessfully returns
        /// </summary>
        /// <param name="consignments">The consignments</param>
        /// <returns></returns>
        [Theory]
        [ClassData<EmptyIEnumerableTestData<ConsignmentRequestModel>>]
        public async Task CreateConsignmentsAsync_WithEmptyData_UnsuccessfullyReturns(IEnumerable<ConsignmentRequestModel?> consignments)
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentsAsync(consignments!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentsAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentsAsync([TestConstants.TestConsignment], TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync"/> is called, 
        /// with empty data, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentAsync_WithEmptyData_UnuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentAsync(null!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentAsync(TestConstants.TestConsignment, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetConsignmentPdfsAsync_WithEmptyVoucher_UnuccessfullyReturns(string? voucher)
        {
            var request = new ConsignmentPdfRequestModel(voucher!, PaperSize.A4, true);

            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithMoqedData_SuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucherNumber()], PaperSize.A4, true);

            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetConsignmentPdfAsync_WithEmptyVoucher_UnuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.GetConsignmentPdfAsync(voucher!, PaperSize.A4, true, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetConsignmentPdfAsync(TestHelpers.GenerateTestVoucherNumber(), PaperSize.A4, true, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync"/> is called, 
        /// with an empty branch id, it unsuccessfully returns
        /// </summary>
        /// <param name="branchId">The branch id</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetBranchesAsync_WithEmptyBranch_UnsuccessfullyReturns(string? branchId)
        {
            var response = await _simulatedSpeedexClient.GetBranchesAsync(branchId!, SupportedLanguage.Greek, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetBranchesAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetBranchesAsync("26441", SupportedLanguage.Greek, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetLastCheckPointAsync_WithEmptyVouchera_UnuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.GetLastCheckPointAsync(voucher!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastCheckPointAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetLastCheckPointAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetLastPickupCheckPointAsync_WithEmptyVoucher_UnsuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(voucher!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastPickupCheckPointAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync"/> is called, 
        /// with <see langword="null"/> data, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByClientReferencesAsync_WithNullData_UnsuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetTraceByClientReferencesAsync(null!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByClientReferencesAsync_WithMoqedData_SuccessfullyReturns()
        {
            var request = new ClientReferencesRequestModel()
            {
                FirstClientReference = "Test"
            };

            var response = await _simulatedSpeedexClient.GetTraceByClientReferencesAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync"/> is called, 
        /// with invalid dates, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByTimeFrameAsync_WithInvalidDates_UnsuccessfullyReturns()
        {
            var dateto = DateTime.Now;

            var dateFrom = dateto.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetTraceByTimeFrameAsync(dateto, dateFrom, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByTimeFrameAsync_WithMoqedData_SuccessfullyReturns()
        {
            var startingDate = DateTime.Now;

            var endingDate = startingDate.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetTraceByTimeFrameAsync(endingDate, startingDate, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetTraceByVoucherIdAsync_WithEmptyVoucher_UnuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.GetTraceByVoucherIdAsync(voucher!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByVoucherIdAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetTraceByVoucherIdAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelPickupByIdAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task CancelPickupByIdAsync_WithEmptyVoucher_UnuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(voucher!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelPickupByIdAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelPickupByIdAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreatePickupAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickup = DateTime.Now.AddDays(3);

            var request = new PickupRequestModel(TestHelpers.GenerateTestVoucherNumber(), pickup);

            var response = await _simulatedSpeedexClient.CreatePickupAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync"/> is called, 
        /// with invalid dates, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentsByDateRangeAsync_WithInvalidDates_UnsuccessfullyReturns()
        {
            var startingDate = DateTime.Now;

            var endingDate = startingDate.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetConsignmentsByDateRangeAsync(startingDate, endingDate, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentsByDateRangeAsync_WithMoqedData_SuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetConsignmentsByDateRangeAsync(dateFrom, dateTo, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync"/> is called, 
        /// with invalid dates, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetDepositedConsignmentsByDateRangeAsync_WithInvalidDates_UnsuccessfullyReturns()
        {
            var startingDate = DateTime.Now;

            var endingDate = startingDate.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(startingDate, endingDate, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetDepositedConsignmentsByDateRangeAsync_WithMoqedData_SuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(dateFrom, dateTo, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync"/> is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="voucher">The voucher</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetPickupByIdAsync_WithEmptyVoucher_UnuccessfullyReturns(string? voucher)
        {
            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(voucher!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPickupByIdAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(TestHelpers.GenerateTestVoucherNumber(), TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.ReschedulePickupAsync"/> is called, 
        /// with empty data, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReschedulePickupAsync_WithEmptyData_UnuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.ReschedulePickupAsync(null!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.ReschedulePickupAsync"/> is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReschedulePickupAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickupDate = DateTime.Now.AddDays(3);

            var pickupId = TestHelpers.GenerateTestPickupId();

            var request = new ReschedulePickupRequestModel(pickupId, pickupDate);

            var response = await _simulatedSpeedexClient.ReschedulePickupAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
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
        private static void AssertValidHttpRequestResult<T>(IHttpRequestResult<T> httpRequestResult)
        {
            AssertValidHttpRequestResult((IHttpRequestResult)httpRequestResult);

            Assert.NotNull(httpRequestResult.Result);
        }

        /// <summary>
        /// Asserts the <paramref name="httpRequestResult"/> is valid
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result</param>
        private static void AssertValidHttpRequestResult(IHttpRequestResult httpRequestResult)
        {
            Assert.NotNull(httpRequestResult);

            Assert.True(httpRequestResult.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(httpRequestResult.RequestPayload));

            Assert.False(string.IsNullOrWhiteSpace(httpRequestResult.ResponsePayload));
        }

        /// <summary>
        /// Asserts the <paramref name="httpRequestResult"/> is invalid
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result</param>
        private static void AssertInvalidHttpRequestResult(IHttpRequestResult httpRequestResult)
        {
            Assert.NotNull(httpRequestResult);

            Assert.False(httpRequestResult.IsSuccessful);

            Assert.NotNull(httpRequestResult.ErrorMessage);
        }

        #endregion
    }
}