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

            _speedexClient = new(TestConstants.SpeedexCredentials, httpClient, true);
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
            using var newSpeedexClient = new SpeedexClient(TestConstants.SpeedexCredentials, true);

            var sessionResponse = await newSpeedexClient.CreateSessionAsync();

            AssertHttpRequest(sessionResponse);

            var createVoucherResponse = await newSpeedexClient.CreateConsignmentAsync(TestConstants.TestConsignment);

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

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreateConsignmentsAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCreateConsignmentsMethodIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.CreateConsignmentsAsync([ TestConstants.TestConsignment ]);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreateConsignmentAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCreateConsignmentMethodIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.CreateConsignmentAsync(TestConstants.TestConsignment);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetConsignmentPDFsAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetConsignmentPDFsIsCalled_ItSuccessfullyReturns()
        {
            var request = new ConsignmentPdfRequestModel([TestHelpers.GenerateTestVoucher()], PaperSize.A4, true);

            var response = await _speedexClient.GetConsignmentPDFsAsync(request);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetConsignmentPDFAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetConsignmentPDFIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.GetConsignmentPDFAsync(TestHelpers.GenerateTestVoucher(), PaperSize.A4, true);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetBranchesAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetBranchesIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.GetBranchesAsync("26441");

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetLastCheckPointAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetLastCheckPointIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.GetLastCheckPointAsync(TestHelpers.GenerateTestVoucher());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetLastPickupCheckPointAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetLastPickupCheckPointIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.GetLastPickupCheckPointAsync(TestHelpers.GenerateTestVoucher());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetTraceByClientReferencesAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetTraceByClientReferencesIsCalled_ItSuccessfullyReturns()
        {
            var request = new ClientReferencesRequestModel()
            {
                FirstClientReference = "Test"  
            };

            var response = await _speedexClient.GetTraceByClientReferencesAsync(request);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetTraceByTimeFrameAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetTraceByTimeFrameIsCalled_ItSuccessfullyReturns()
        {
            var dateto = DateTime.Now;

            var dateFrom = dateto.AddDays(-5);

            var response = await _speedexClient.GetTraceByTimeFrameAsync(dateFrom, dateto);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetTraceByVoucherIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetTraceByVoucherIdIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.GetTraceByVoucherIdAsync(TestHelpers.GenerateTestVoucher());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CancelPickupByIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCancelPickupByIdIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.CancelPickupByIdAsync(TestHelpers.GenerateTestVoucher());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.CreatePickupAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheCreatePickupIsCalled_ItSuccessfullyReturns()
        {
            var request = new PickupRequestModel([ TestHelpers.GenerateTestVoucher() ], DateTime.Now.AddDays(3), DeliveryTimeLimit.NoLimit);

            var response = await _speedexClient.CreatePickupAsync(request);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetConsignmentsByDateRangeAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetConsignmentsByDateRangeIsCalled_ItSuccessfullyReturns()
        {
            var dateto = DateTime.Now;

            var dateFrom = dateto.AddDays(-5);

            var response = await _speedexClient.GetConsignmentsByDateRangeAsync(dateFrom, dateto);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetDepositedConsignmentsByDateRangeAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetDepositedConsignmentsByDateRangeIsCalled_ItSuccessfullyReturns()
        {
            var dateto = DateTime.Now;

            var dateFrom = dateto.AddDays(-5);

            var response = await _speedexClient.GetDepositedConsignmentsByDateRangeAsync(dateFrom, dateto);

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.GetPickupByIdAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheGetPickupByIdIsCalled_ItSuccessfullyReturns()
        {
            var response = await _speedexClient.GetPickupByIdAsync(TestHelpers.GenerateTestVoucher());

            AssertHttpRequest(response);
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexClient.ReschedulePickupAsync"/> is called, 
        /// it successfully returns
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenTheReschedulePickupIsCalled_ItSuccessfullyReturns()
        {
            var request = new ReschedulePickupRequestModel(DateTime.Now.AddDays(3), DeliveryTimeLimit.TenAMToOnePM);

            var response = await _speedexClient.ReschedulePickupAsync(request);

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