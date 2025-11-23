using Couriers.Speedex.Enums;
using Couriers.Speedex.InternalModels.RequestModels;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentPdfInternalRequestModel"/>
    /// </summary>
    public sealed class ConsignmentPdfInternalRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfInternalRequestModelUnitTests"/>
        /// </summary>
        public ConsignmentPdfInternalRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfInternalRequestModel.FromRequestModel(ConsignmentPdfRequestModel)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => ConsignmentPdfInternalRequestModel.FromRequestModel(null!));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfInternalRequestModel.FromRequestModel(ConsignmentPdfRequestModel)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var requestModel = new ConsignmentPdfRequestModel(TestHelpers.GenerateTestVoucherNumber(), PaperSize.A6)
            {
                ReturnMultipleVouchers = false
            };

            var result = ConsignmentPdfInternalRequestModel.FromRequestModel(requestModel);

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}