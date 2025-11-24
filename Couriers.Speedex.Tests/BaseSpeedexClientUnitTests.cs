using Couriers.Common.ResultTypes;
using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;
using Couriers.Speedex.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="BaseSpeedexClient"/>
    /// </summary>
    public sealed class BaseSpeedexClientUnitTests : IAsyncLifetime, IDisposable
    {
        #region Private Fields

        /// <summary>
        /// The client
        /// </summary>
        private BaseSpeedexClient _simulatedSpeedexClient;

        /// <summary>
        /// The client that mocks every HTTP call as a Bad Gateway request
        /// </summary>
        private BaseSpeedexClient _badGatewaySpeedexClient;

        /// <summary>
        /// A flag indicating whether the object is already disposed
        /// </summary>
        private bool _isAlreadyDisposed;

        /// <summary>
        /// A <see cref="CancellationToken"/> that is already cancelled
        /// </summary>
        private readonly CancellationToken _cancelledToken;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BaseSpeedexClientUnitTests"/>
        /// </summary>
        public BaseSpeedexClientUnitTests() : base()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            _cancelledToken = cancellationTokenSource.Token;

            cancellationTokenSource.Cancel();

            var simulatedHttpHandler = new SimulationHttpHandler();

            var simulatedHttpClient = new HttpClient(simulatedHttpHandler);

            _simulatedSpeedexClient = new DemoSpeedexClient(TestConstants.SpeedexCredentials, simulatedHttpClient);

            var badGatewaySimulatedHttpHandler = new BadGatewaySimulationHttpHandler();

            var badGatewayHttpClient = new HttpClient(badGatewaySimulatedHttpHandler);

            _badGatewaySpeedexClient = new DemoSpeedexClient(TestConstants.SpeedexCredentials, badGatewayHttpClient);
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

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.Dispose()"/> method is called, 
        /// while the instance is already disposed, no <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void Dispose_WhenAlreadyDisposed_NoExceptionIsThrown()
        {
            var client = new DemoSpeedexClient(TestConstants.SpeedexCredentials);

            client.Dispose();

            client.Dispose();

            Assert.NotNull(client);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient"/> encounters an authorization issue, 
        /// it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BaseSpeedexClient_WhenUnauthorized_UnsuccessfullyReturns()
        {
            using var simulatedHttpHandler = new UnauthorizedSimulationHttpHandler();

            using var httpClient = new HttpClient(simulatedHttpHandler);

            using var client = new DemoSpeedexClient(TestConstants.SpeedexCredentials, httpClient);

            var branchesResponse = await client.GetBranchesAsync(TestConstants.BranchCode, SupportedLanguage.Greek, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(branchesResponse);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient"/> encounters an unhandled <see cref="Exception"/>, 
        /// it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BaseSpeedexClient_WhenUnhandledExceptionOccurs_UnsuccessfullyReturns()
        {
            using var simulatedHttpHandler = new ExceptionSimulationHttpHandler();

            using var httpClient = new HttpClient(simulatedHttpHandler);

            using var client = new DemoSpeedexClient(TestConstants.SpeedexCredentials, httpClient);

            var response = await client.CreateSessionAsync(TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateSessionAsync(CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSessionAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateSessionAsync(_cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateSessionAsync(CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSessionAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var response = await _badGatewaySpeedexClient.CreateSessionAsync(TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateSessionAsync(CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns a session id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSessionAsync_WithDemoCredentials_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateSessionAsync(TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelConsignmentByVoucherIdAsync(string, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.CancelConsignmentByVoucherIdAsync(string, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelConsignmentByVoucherIdAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.CancelConsignmentByVoucherIdAsync(voucher, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelConsignmentByVoucherIdAsync(string, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync(IEnumerable{ConsignmentRequestModel}, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync(IEnumerable{ConsignmentRequestModel}, CancellationToken)"/> method is called, 
        /// with invalid arguments, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentsAsync_WithInvalidArguments_UnsuccessfullyReturns()
        {
            var vouchers = Enumerable.Repeat(TestConstants.TestConsignment, SpeedexConstants.MaximumNumberOfConsignments + 1);

            var response = await _simulatedSpeedexClient.CreateConsignmentsAsync(vouchers, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync(IEnumerable{ConsignmentRequestModel}, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentsAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentsAsync([TestConstants.TestConsignment], _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync(IEnumerable{ConsignmentRequestModel}, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentsAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var response = await _badGatewaySpeedexClient.CreateConsignmentsAsync([TestConstants.TestConsignment], TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentsAsync(IEnumerable{ConsignmentRequestModel}, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync(ConsignmentRequestModel, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync(ConsignmentRequestModel, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreateConsignmentAsync(TestConstants.TestConsignment, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync(ConsignmentRequestModel, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsignmentAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var response = await _badGatewaySpeedexClient.CreateConsignmentAsync(TestConstants.TestConsignment, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreateConsignmentAsync(ConsignmentRequestModel, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync(ConsignmentPdfRequestModel, CancellationToken)"/> method is called, 
        /// with empty data, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithEmptyData_UnuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(null!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync(ConsignmentPdfRequestModel, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucherNumber()], PaperSize.A4)
            {
                ReturnMultipleVouchers = true
            };

            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(request, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync(ConsignmentPdfRequestModel, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucherNumber()], PaperSize.A4)
            {
                ReturnMultipleVouchers = true
            };

            var response = await _badGatewaySpeedexClient.GetConsignmentPdfsAsync(request, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfsAsync(ConsignmentPdfRequestModel, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfsAsync_WithMoqedData_SuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucherNumber()], PaperSize.A4)
            {
                ReturnMultipleVouchers = true
            };

            var response = await _simulatedSpeedexClient.GetConsignmentPdfsAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync(string, PaperSize, bool, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync(string, PaperSize, bool, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.GetConsignmentPdfAsync(voucher, PaperSize.A4, true, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync(string, PaperSize, bool, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _badGatewaySpeedexClient.GetConsignmentPdfAsync(voucher, PaperSize.A4, true, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentPdfAsync(string, PaperSize, bool, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentPdfAsync_WithMoqedData_SuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.GetConsignmentPdfAsync(voucher, PaperSize.A4, true, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync(string, SupportedLanguage, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync(string, SupportedLanguage, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetBranchesAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetBranchesAsync(TestConstants.BranchCode, SupportedLanguage.Greek, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync(string, SupportedLanguage, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetBranchesAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var response = await _badGatewaySpeedexClient.GetBranchesAsync(TestConstants.BranchCode, SupportedLanguage.Greek, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetBranchesAsync(string, SupportedLanguage, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetBranchesAsync_WithMoqedData_SuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.GetBranchesAsync(TestConstants.BranchCode, SupportedLanguage.Greek, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync(string, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastCheckPointAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.GetLastCheckPointAsync(voucher, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastCheckPointAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _badGatewaySpeedexClient.GetLastCheckPointAsync(voucher, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastCheckPointAsync_WithMoqedData_SuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.GetLastCheckPointAsync(voucher, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="pickupId">The pickup id</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetLastPickupCheckPointAsync_WithEmptyVoucher_UnsuccessfullyReturns(string? pickupId)
        {
            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(pickupId!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastPickupCheckPointAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(pickupId, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastPickupCheckPointAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _badGatewaySpeedexClient.GetLastPickupCheckPointAsync(pickupId, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetLastPickupCheckPointAsync(string, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLastPickupCheckPointAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _simulatedSpeedexClient.GetLastPickupCheckPointAsync(pickupId, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync(ClientReferencesRequestModel, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync(ClientReferencesRequestModel, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByClientReferencesAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var request = new ClientReferencesRequestModel()
            {
                FirstClientReference = "Test"
            };

            var response = await _simulatedSpeedexClient.GetTraceByClientReferencesAsync(request, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync(ClientReferencesRequestModel, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByClientReferencesAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var request = new ClientReferencesRequestModel()
            {
                FirstClientReference = "Test"
            };

            var response = await _badGatewaySpeedexClient.GetTraceByClientReferencesAsync(request, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByClientReferencesAsync(ClientReferencesRequestModel, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByTimeFrameAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var startingDate = DateTime.Now;

            var endingDate = startingDate.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetTraceByTimeFrameAsync(startingDate, endingDate, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByTimeFrameAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var startingDate = DateTime.Now;

            var endingDate = startingDate.AddDays(-5);

            var response = await _badGatewaySpeedexClient.GetTraceByTimeFrameAsync(endingDate, startingDate, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByTimeFrameAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync(string, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync(string, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByVoucherIdAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.GetTraceByVoucherIdAsync(voucher, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync(string, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByVoucherIdAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _badGatewaySpeedexClient.GetTraceByVoucherIdAsync(voucher, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetTraceByVoucherIdAsync(string, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTraceByVoucherIdAsync_WithMoqedData_SuccessfullyReturns()
        {
            var voucher = TestHelpers.GenerateTestVoucherNumber();

            var response = await _simulatedSpeedexClient.GetTraceByVoucherIdAsync(voucher, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="pickupId">The pickup id</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task CancelPickupByIdAsync_WithEmptyVoucher_UnuccessfullyReturns(string? pickupId)
        {
            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(pickupId!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelPickupByIdAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(pickupId, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CancelPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CancelPickupByIdAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _simulatedSpeedexClient.CancelPickupByIdAsync(pickupId, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreatePickupAsync(PickupRequestModel, CancellationToken)"/> method is called, 
        /// with <see langword="null"/> data, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithNullData_UnsuccessfullyReturns()
        {
            var response = await _simulatedSpeedexClient.CreatePickupAsync(null!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreatePickupAsync(PickupRequestModel, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3));

            var request = new PickupRequestModel(TestHelpers.GenerateTestVoucherNumber(), pickupDate);

            var response = await _simulatedSpeedexClient.CreatePickupAsync(request, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreatePickupAsync(PickupRequestModel, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3));

            var request = new PickupRequestModel(TestHelpers.GenerateTestVoucherNumber(), pickupDate);

            var response = await _simulatedSpeedexClient.CreatePickupAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.CreatePickupAsync(PickupRequestModel, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePickupAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3));

            var request = new PickupRequestModel(TestHelpers.GenerateTestVoucherNumber(), pickupDate);

            var response = await _badGatewaySpeedexClient.CreatePickupAsync(request, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentsByDateRangeAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetConsignmentsByDateRangeAsync(dateFrom, dateTo, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetConsignmentsByDateRangeAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _badGatewaySpeedexClient.GetConsignmentsByDateRangeAsync(dateFrom, dateTo, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetDepositedConsignmentsByDateRangeAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _simulatedSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(dateFrom, dateTo, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.GetDepositedConsignmentsByDateRangeAsync(DateTime, DateTime, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetDepositedConsignmentsByDateRangeAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var dateTo = DateTime.Now;

            var dateFrom = dateTo.AddDays(-5);

            var response = await _badGatewaySpeedexClient.GetDepositedConsignmentsByDateRangeAsync(dateFrom, dateTo, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with an empty voucher, it unsuccessfully returns
        /// </summary>
        /// <param name="pickupId">The pickup id</param>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public async Task GetPickupByIdAsync_WithEmptyVoucher_UnuccessfullyReturns(string? pickupId)
        {
            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(pickupId!, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPickupByIdAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(pickupId, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with failed HTTP call, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPickupByIdAsync_WithFailedHttpCall_UnsuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _badGatewaySpeedexClient.GetPickupByIdAsync(pickupId, TestContext.Current.CancellationToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.GetPickupByIdAsync(string, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPickupByIdAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var response = await _simulatedSpeedexClient.GetPickupByIdAsync(pickupId, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.ReschedulePickupAsync(ReschedulePickupRequestModel, CancellationToken)"/> method is called, 
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
        /// Validates that when <see cref="BaseSpeedexClient.ReschedulePickupAsync(ReschedulePickupRequestModel, CancellationToken)"/> method is called, 
        /// with a cancelled token, it unsuccessfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReschedulePickupAsync_WithCancelledToken_UnsuccessfullyReturns()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3));

            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var request = new ReschedulePickupRequestModel(pickupId, pickupDate);

            var response = await _simulatedSpeedexClient.ReschedulePickupAsync(request, _cancelledToken);

            AssertInvalidHttpRequestResult(response);
        }

        /// <summary>
        /// Validates that when <see cref="BaseSpeedexClient.ReschedulePickupAsync(ReschedulePickupRequestModel, CancellationToken)"/> method is called, 
        /// with valid data, it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReschedulePickupAsync_WithMoqedData_SuccessfullyReturns()
        {
            var pickupDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3));

            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var request = new ReschedulePickupRequestModel(pickupId, pickupDate);

            var response = await _simulatedSpeedexClient.ReschedulePickupAsync(request, TestContext.Current.CancellationToken);

            AssertValidHttpRequestResult(response);
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
                _simulatedSpeedexClient.Dispose();

                _simulatedSpeedexClient = null!;

                _badGatewaySpeedexClient.Dispose();

                _badGatewaySpeedexClient = null!;
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