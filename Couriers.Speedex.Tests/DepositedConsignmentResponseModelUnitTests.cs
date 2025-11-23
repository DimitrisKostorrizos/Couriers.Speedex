using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="DepositedConsignmentResponseModel"/>
    /// </summary>
    public sealed class DepositedConsignmentResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DepositedConsignmentResponseModelUnitTests"/>
        /// </summary>
        public DepositedConsignmentResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="DepositedConsignmentResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void DepositedConsignmentResponseModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            Assert.ThrowsAny<Exception>(() => new DepositedConsignmentResponseModel(value!, 5, DateTime.Now));

            Assert.ThrowsAny<Exception>(() => new DepositedConsignmentResponseModel(voucherId, -1, DateTime.Now));
        }

        /// <summary>
        /// Validates that when <see cref="DepositedConsignmentResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void DepositedConsignmentResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var amount = 5;

            var dateDeposited = DateTime.Now;

            var result = new DepositedConsignmentResponseModel(voucherId, amount, dateDeposited);

            Assert.NotNull(result);

            Assert.Equal(voucherId, result.Id);

            Assert.Equal(amount, result.Amount);

            Assert.Equal(dateDeposited, result.DateDeposited);
        }

        #endregion

        #endregion
    }
}