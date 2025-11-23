using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="PickupCheckpointResponseModel"/>
    /// </summary>
    public sealed class PickupCheckpointResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupCheckpointResponseModelUnitTests"/>
        /// </summary>
        public PickupCheckpointResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="PickupCheckpointResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupCheckpointResponseModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestVoucherNumber();

            var branchDepot = TestHelpers.GenerateRandomString(30);

            var statusCode = TestHelpers.GenerateRandomString(30);

            Assert.ThrowsAny<Exception>(() => new PickupCheckpointResponseModel()
            {
                BranchDepot = value!,
                CheckpointDate = DateTime.Now,
                PickupId = pickupId,
                StatusCode = statusCode
            });

            Assert.ThrowsAny<Exception>(() => new PickupCheckpointResponseModel()
            {
                BranchDepot = branchDepot,
                CheckpointDate = DateTime.Now,
                PickupId = value!,
                StatusCode = statusCode
            });

            Assert.ThrowsAny<Exception>(() => new PickupCheckpointResponseModel()
            {
                BranchDepot = branchDepot,
                CheckpointDate = DateTime.Now,
                PickupId = pickupId,
                StatusCode = value!
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void PickupCheckpointResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var pickupId = TestHelpers.GenerateTestVoucherNumber();

            var branchDepot = TestHelpers.GenerateRandomString(30);

            var statusCode = TestHelpers.GenerateRandomString(30);

            var checkpointDate = DateTime.Now;

            var result = new PickupCheckpointResponseModel()
            {
                BranchDepot = branchDepot,
                CheckpointDate = checkpointDate,
                PickupId = pickupId,
                StatusCode = statusCode
            };

            Assert.NotNull(result);

            Assert.Equal(pickupId, result.PickupId);

            Assert.Equal(checkpointDate, result.CheckpointDate);

            Assert.Equal(branchDepot, result.BranchDepot);

            Assert.Equal(statusCode, result.StatusCode);
        }

        #endregion

        #endregion
    }
}