using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.RequestModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentRequestModel"/>
    /// </summary>
    public sealed class ConsignmentRequestModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentRequestModelUnitTests"/>
        /// </summary>
        public ConsignmentRequestModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with an invalid customer reference, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidCustomerReference_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with an invalid number of vouchers, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidNumberOfVouchers_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 0, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, -1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, SpeedexConstants.MaximumNumberOfVouchers + 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with invalid comments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidComments_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);
                        
            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1)
            });
        }
        
        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with invalid payment details, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidPaymentDetails_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, null, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, -1, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with an invalid address, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentRequestModel_WithInvalidAddress_ThrowsException(string? value)
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, value!,
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(SpeedexConstants.MaximumAddressLength + 1),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with an invalid recipient name, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentRequestModel_WithInvalidRecipientName_ThrowsException(string? value)
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                value!, TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with an invalid recipient phone number, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentRequestModel_WithInvalidRecipientPhoneNumber_ThrowsException(string? value)
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), value!, TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(SpeedexConstants.MaximumPhoneNumberLength + 1), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with an invalid zip code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentRequestModel_WithInvalidZipCode_ThrowsException(string? value)
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), value!, 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(SpeedexConstants.MaximumZipCodeLength + 1), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with invalid insurance amount, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidInsuranceAmount_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, -1, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with invalid delivery details, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidDeliveryDetails_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, true, DeliveryTimeLimit.TenAMToOnePM)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with invalid weight, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithInvalidWeight_ThrowsException()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            var numberOfVouchers = 2;

            var weight = (numberOfVouchers - 1) * SpeedexConstants.MinimumWeightPerVoucher;

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel(0, numberOfVouchers, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), weight, 0, false, DeliveryTimeLimit.NoLimit)
            {
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10)
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentRequestModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ConsignmentRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var customerReference = TestHelpers.GenerateRandomString(10);

            var result = new ConsignmentRequestModel(0, 1, ChargeType.Recipient, PaymentType.Cash, 5, TestHelpers.GenerateRandomString(10),
                TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(10), TestHelpers.GenerateRandomString(5), 2, 0, false, DeliveryTimeLimit.NoLimit)
            {
                FirstCustomerReference = customerReference,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference
            };

            Assert.NotNull(result);
        }

        #endregion

        #endregion
    }
}