using Couriers.Speedex.Constants;
using Couriers.Speedex.InternalModels.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="GetDepositedConsignmentsByDateInternalResponseModel"/>
    /// </summary>
    public sealed class GetDepositedConsignmentsByDateInternalResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetDepositedConsignmentsByDateInternalResponseModelUnitTests"/>
        /// </summary>
        public GetDepositedConsignmentsByDateInternalResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="GetDepositedConsignmentsByDateInternalResponseModel.ToResponseModel()"/> method is called, 
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

            var responseModel = new GetDepositedConsignmentsByDateInternalResponseModel()
            {
                Result = new GetDepositedConsignmentsByDateResult()
                {
                    Results = [depositedConsignment]
                }
            };

            var result = responseModel.ToResponseModel();

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}