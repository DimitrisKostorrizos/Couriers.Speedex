using Couriers.Speedex.Constants;
using Couriers.Speedex.InternalModels.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="GetConsignmentsByDateInternalResponseModel"/>
    /// </summary>
    public sealed class GetConsignmentsByDateInternalResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="GetConsignmentsByDateInternalResponseModelUnitTests"/>
        /// </summary>
        public GetConsignmentsByDateInternalResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="GetConsignmentsByDateInternalResponseModel.ToResponseModel()"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToResponseModel_WithValidValues_ReturnsExpectedResult()
        {
            var responseModel = new GetConsignmentsByDateInternalResponseModel()
            {
                Result = new GetConsignmentsByDateResult()
                {
                    Results =
                    [
                        new ConsignmentDetailsInternalResponseModel()
                        {
                            Address = TestHelpers.GenerateRandomString(15),
                            AgreementCode = TestHelpers.GenerateRandomString(6),
                            ChargeType = "Sender",
                            CashAmount = 0,
                            CheckAmount = 0,
                            CheckpointCode = TestHelpers.GenerateRandomString(7),
                            CheckpointGroupCode = TestHelpers.GenerateRandomString(7),
                            City = TestHelpers.GenerateRandomString(7),
                            ConsignmentId = TestHelpers.GenerateTestVoucherNumber(),
                            CountryCode = SpeedexConstants.GreeceCountryCode,
                            CustomerCode = TestHelpers.GenerateRandomString(6),
                            CustomerComments = TestHelpers.GenerateRandomString(15),
                            DeliveryPostCode = TestHelpers.GenerateRandomString(5),
                            DeliveryTimeFrom = new TimeOnly(10,  0, 0).ToString(SpeedexConstants.SpeedexCultureInfo),
                            DeliveryTimeTo = new TimeOnly(13, 0, 0).ToString(SpeedexConstants.SpeedexCultureInfo),
                            FirstCustomerReference = TestHelpers.GenerateRandomString(7),
                            InsuranceAmount = 0,
                            IsReturnItem = false,
                            IsSaturdayDelivery = false,
                            MasterConsignmentId = TestHelpers.GenerateTestVoucherNumber(),
                            ParcelCount = 2,
                            PickupAddress = TestHelpers.GenerateRandomString(20),
                            PickupCity = TestHelpers.GenerateRandomString(20),
                            PickupCountryCode = SpeedexConstants.GreeceCountryCode,
                            PickupName = TestHelpers.GenerateTestPickupNumber(),
                            PickupPhoneNumber = TestHelpers.GenerateRandomString(10),
                            PickupPostCode = TestHelpers.GenerateRandomString(5),
                            RecipientName = TestHelpers.GenerateRandomString(20),
                            RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                            SecondCustomerReference = TestHelpers.GenerateRandomString(7),
                            ThirdCustomerReference = TestHelpers.GenerateRandomString(7),
                            Weight = 1
                        }
                    ]
                }
            };

            var result = responseModel.ToResponseModel();

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}