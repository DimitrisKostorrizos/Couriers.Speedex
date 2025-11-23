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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                NumberOfVouchers = 0,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 0,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = -1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = SpeedexConstants.MaximumNumberOfVouchers,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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
                        
            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = null,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() =>
            {
                var result = new ConsignmentRequestModel()
                {
                    CustomerFlag = 0,
                    BranchBankCode = string.Empty,
                    FirstCustomerReference = customerReference,
                    SecondCustomerReference = customerReference,
                    ThirdCustomerReference = customerReference,
                    NumberOfVouchers = 1,
                    FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                    SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                    ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                    ChargeType = ChargeType.Recipient,
                    PaymentType = PaymentType.Cash,
                    Cost = 5,
                    Address = TestHelpers.GenerateRandomString(10),
                    RecipientName = TestHelpers.GenerateRandomString(10),
                    RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                    ZipCode = TestHelpers.GenerateRandomString(5),
                    InsuranceAmount = 0,
                    ShouldBeDeliveredOnSaturday = false,
                    DeliveryTime = DeliveryTimeLimit.NoLimit,
                    Weight = 2
                };

                result.PaymentType = null;
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = -1,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = value!,
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumAddressLength + 1),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = value!,
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = value!,
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumPhoneNumberLength + 1),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = value!,
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1),
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumZipCodeLength + 1),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = -1,
                ShouldBeDeliveredOnSaturday = false,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                ShouldBeDeliveredOnSaturday = true,
                DeliveryTime = DeliveryTimeLimit.TenAMToOnePM,
                Weight = 2
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = 1,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                DeliveryTime = DeliveryTimeLimit.TenAMToOnePM,
                ShouldBeDeliveredOnSaturday = true,
                Weight = 2
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

            Assert.ThrowsAny<Exception>(() => new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                FirstCustomerReference = customerReference,
                SecondCustomerReference = customerReference,
                ThirdCustomerReference = customerReference,
                NumberOfVouchers = numberOfVouchers,
                FirstCommentsPart = TestHelpers.GenerateRandomString(10),
                SecondCommentsPart = TestHelpers.GenerateRandomString(10),
                ThirdCommentsPart = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Check,
                Cost = 5,
                Address = TestHelpers.GenerateRandomString(10),
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ZipCode = TestHelpers.GenerateRandomString(5),
                InsuranceAmount = 0,
                DeliveryTime = DeliveryTimeLimit.TenAMToOnePM,
                ShouldBeDeliveredOnSaturday = false,
                Weight = (numberOfVouchers - 1) * SpeedexConstants.MinimumWeightPerVoucher
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

            var result = new ConsignmentRequestModel()
            {
                CustomerFlag = 0,
                BranchBankCode = string.Empty,
                Address = TestHelpers.GenerateRandomString(10),
                ChargeType = ChargeType.Recipient,
                PaymentType = PaymentType.Cash,
                Cost = 5,
                DeliveryTime = DeliveryTimeLimit.NoLimit,
                InsuranceAmount = 0,
                NumberOfVouchers = 1,
                RecipientName = TestHelpers.GenerateRandomString(10),
                RecipientPhoneNumber = TestHelpers.GenerateRandomString(10),
                ShouldBeDeliveredOnSaturday = false,
                Weight = 2,
                ZipCode = TestHelpers.GenerateRandomString(5),
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