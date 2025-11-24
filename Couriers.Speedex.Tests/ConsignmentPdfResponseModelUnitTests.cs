using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentPdfResponseModel"/>
    /// </summary>
    public sealed class ConsignmentPdfResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModelUnitTests"/>
        /// </summary>
        public ConsignmentPdfResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentPdfResponseModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var base64String = TestHelpers.GenerateRandomString(200);

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfResponseModel()
            {
                Base64String = value!,
                VoucherId = voucherId
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfResponseModel()
            {
                Base64String = base64String,
                VoucherId = value!
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ClientReferencesRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var base64String = TestHelpers.GenerateRandomString(200);

            var result = new ConsignmentPdfResponseModel()
            {
                Base64String = base64String,
                VoucherId = voucherId
            };

            Assert.NotNull(result);

            Assert.Equal(voucherId, result.VoucherId);

            Assert.Equal(base64String, result.Base64String);
        }

        #endregion

        #endregion
    }
}