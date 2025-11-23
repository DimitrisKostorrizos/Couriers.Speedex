using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;

using System;
using System.Linq;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentPdfRequestModel"/>
    /// </summary>
    public sealed class ConsignmentPdfRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfRequestModelUnitTests"/>
        /// </summary>
        public ConsignmentPdfRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfRequestModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentPdfRequestModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfRequestModel([value!], PaperSize.A6));

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfRequestModel(voucherIds: null!, PaperSize.A6));

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfRequestModel([], PaperSize.A6));

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfRequestModel(Enumerable.Repeat(voucherId, SpeedexConstants.MaximumNumberOfVouchers + 1), PaperSize.A6));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfRequestModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentPdfRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var result = new ConsignmentPdfRequestModel([voucherId], PaperSize.A6);

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}