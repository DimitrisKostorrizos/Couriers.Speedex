using Couriers.Speedex.Constants;
using Couriers.Speedex.InternalModels.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="GetDepositedConsignmentsByDateResult"/>
    /// </summary>
    public sealed class GetDepositedConsignmentsByDateResultUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetDepositedConsignmentsByDateResultUnitTests"/>
        /// </summary>
        public GetDepositedConsignmentsByDateResultUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="GetDepositedConsignmentsByDateResult.ToResponseModel()"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToResponseModel_WithValidValues_ReturnsExpectedResult()
        {
            var depositedConsignment = new DepositedConsignmentInternalResponseModel()
            {
                Amount = 6,
                DateDeposited = DateTime.Now.ToString(SpeedexConstants.SpeedexCultureInfo),
                Id = TestHelpers.GenerateTestVoucherNumber()
            };

            var responseModel = new GetDepositedConsignmentsByDateResult()
            {
                Results = [depositedConsignment]
            };

            var result = responseModel.ToResponseModel();

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}