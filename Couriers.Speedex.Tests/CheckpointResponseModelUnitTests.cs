using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="CheckpointResponseModel"/>
    /// </summary>
    public sealed class CheckpointResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CheckpointResponseModelUnitTests"/>
        /// </summary>
        public CheckpointResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="CheckpointResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void CheckpointResponseModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var branchDepot = TestHelpers.GenerateRandomString(10);

            var branchId = TestHelpers.GenerateRandomString(10);

            var checkpointDate = DateTime.Now;

            var customerComments = TestHelpers.GenerateRandomString(20);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var statusCode = TestHelpers.GenerateRandomString(5);

            var statusDescription = TestHelpers.GenerateRandomString(20);

            Assert.ThrowsAny<Exception>(() => new CheckpointResponseModel(branchDepot, branchId, checkpointDate, customerComments, customerReference, customerReference,
                customerReference, recipientName, value!, statusDescription, voucherId));

            Assert.ThrowsAny<Exception>(() => new CheckpointResponseModel(branchDepot, branchId, checkpointDate, customerComments, customerReference, customerReference,
                customerReference, recipientName, statusCode, value!, voucherId));

            Assert.ThrowsAny<Exception>(() => new CheckpointResponseModel(branchDepot, branchId, checkpointDate, customerComments, customerReference, customerReference,
                customerReference, recipientName, statusCode, statusDescription, value!));
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void CheckpointResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var branchDepot = TestHelpers.GenerateRandomString(10);

            var branchId = TestHelpers.GenerateRandomString(10);

            var checkpointDate = DateTime.Now;

            var customerComments = TestHelpers.GenerateRandomString(20);

            var customerReference = TestHelpers.GenerateRandomString(10);

            var recipientName = TestHelpers.GenerateRandomString(10);

            var statusCode = TestHelpers.GenerateRandomString(5);

            var statusDescription = TestHelpers.GenerateRandomString(20);

            var result = new CheckpointResponseModel(branchDepot, branchId, checkpointDate, customerComments, customerReference, customerReference, 
                customerReference, recipientName, statusCode, statusDescription, voucherId);

            Assert.NotNull(result);

            Assert.Equal(branchDepot, result.BranchDepot);

            Assert.Equal(branchId, result.BranchId);

            Assert.Equal(branchDepot, result.BranchDepot);

            Assert.Equal(checkpointDate, result.CheckpointDate);

            Assert.Equal(customerComments, result.CustomerComments);

            Assert.Equal(customerReference, result.FirstCustomerReference);

            Assert.Equal(customerReference, result.SecondCustomerReference);

            Assert.Equal(customerReference, result.ThirdCustomerReference);

            Assert.Equal(recipientName, result.RecipientName);

            Assert.Equal(statusCode, result.StatusCode);

            Assert.Equal(statusDescription, result.StatusDescription);

            Assert.Equal(voucherId, result.VoucherId);
        }

        #endregion

        #endregion
    }
}