using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="SpeedexHelpers"/>
    /// </summary>
    public sealed class SpeedexHelpersUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SpeedexHelpersUnitTests"/>
        /// </summary>
        public SpeedexHelpersUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToChargeType(uint)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToChargeTypeUnit_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToChargeType(0));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToChargeType(5));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToChargeType(uint)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void ToChargeTypeUnit_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<uint, ChargeType>()
            {
                { 1, ChargeType.Sender },
                { 2, ChargeType.Recipient },
                { 3, ChargeType.ThirdParty },
                { 4, ChargeType.Receiver }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.ToChargeType(supportedChargeType.Key);

                Assert.Equal(supportedChargeType.Value, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToChargeType(string)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ToChargeTypeString_WithInvalidArguments_ThrowsException(string? value)
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToChargeType("test"));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToChargeType(value!));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToChargeType(string)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void ToChargeTypeString_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<string, ChargeType>()
            {
                { "Sender", ChargeType.Sender },
                { "Recipient", ChargeType.Recipient },
                { "Third Party", ChargeType.ThirdParty },
                { "Receiver", ChargeType.Receiver }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.ToChargeType(supportedChargeType.Key);

                Assert.Equal(supportedChargeType.Value, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromChargeType(ChargeType)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void FromChargeType_WithInvalidArguments_ThrowsException()
        {
            var undefinedEnum = (ChargeType)5;

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.FromChargeType(undefinedEnum));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromChargeType(ChargeType)"/> method is called, 
        /// using every available value for <see cref="ChargeType"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromChargeType_AllAvailableArguments_NoExceptionIsThrown()
        {
            AssertAvailableEnumValueSupport<ChargeType>((element) => SpeedexHelpers.FromChargeType(element));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromChargeType(ChargeType)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void FromChargeType_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<uint, ChargeType>()
            {
                { 1, ChargeType.Sender },
                { 2, ChargeType.Recipient },
                { 3, ChargeType.ThirdParty },
                { 4, ChargeType.Receiver }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.FromChargeType(supportedChargeType.Value);

                Assert.Equal(supportedChargeType.Key, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToPaymentType(string)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ToPaymentType_WithInvalidArguments_ThrowsException(string? value)
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToPaymentType("test"));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToPaymentType(value!));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToPaymentType(string)"/> method is called,
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void ToPaymentType_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<string, PaymentType>()
            {
                { "M", PaymentType.Cash },
                { "E", PaymentType.Check }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.ToPaymentType(supportedChargeType.Key);

                Assert.Equal(supportedChargeType.Value, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromPaymentType(PaymentType)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void FromPaymentType_WithInvalidArguments_ThrowsException()
        {
            var undefinedEnum = (PaymentType)2;

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.FromPaymentType(undefinedEnum));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromPaymentType(PaymentType)"/> method is called, 
        /// using every available value for <see cref="PaymentType"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromPaymentType_AllAvailableArguments_NoExceptionIsThrown()
        {
            AssertAvailableEnumValueSupport<PaymentType>((element) => SpeedexHelpers.FromPaymentType(element));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromPaymentType(PaymentType)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void FromPaymentType_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<string, PaymentType>()
            {
                { "M", PaymentType.Cash },
                { "E", PaymentType.Check }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.FromPaymentType(supportedChargeType.Value);

                Assert.Equal(supportedChargeType.Key, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ThrowIfInvalidCustomerReference(string?)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void ThrowIfInvalidCustomerReference_WithInvalidArguments_ThrowsException()
        {
            var value = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength + 1);

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ThrowIfInvalidCustomerReference(value));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ThrowIfInvalidCustomerReference(string?)"/> method is called, 
        /// with valid arguments, no <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ThrowIfInvalidCustomerReference_WithValidArguments_NoExceptionIsThrown(string? value)
        {
            Assert.Multiple(() =>
            {
                SpeedexHelpers.ThrowIfInvalidCustomerReference(TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCustomerReferenceLength - 1));

                SpeedexHelpers.ThrowIfInvalidCustomerReference(value);
            });
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ThrowIfInvalidComments(string?)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void ThrowIfInvalidComments_WithInvalidArguments_ThrowsException()
        {
            var value = TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength + 1);

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ThrowIfInvalidComments(value));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ThrowIfInvalidComments(string?)"/> method is called, 
        /// with valid arguments, no <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ThrowIfInvalidComments_WithValidArguments_NoExceptionIsThrown(string? value)
        {
            Assert.Multiple(() =>
            {
                SpeedexHelpers.ThrowIfInvalidComments(TestHelpers.GenerateRandomString(SpeedexConstants.MaximumCommentLength - 1));

                SpeedexHelpers.ThrowIfInvalidComments(value);
            });
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ThrowIfInvalidZipCode(string?)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ThrowIfInvalidZipCode_WithInvalidArguments_ThrowsException(string? value)
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ThrowIfInvalidZipCode(value!));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ThrowIfInvalidZipCode(TestHelpers.GenerateRandomString(SpeedexConstants.MaximumZipCodeLength + 1)));

            SpeedexHelpers.ThrowIfInvalidZipCode(TestHelpers.GenerateRandomString(SpeedexConstants.MaximumZipCodeLength - 1));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToDeliveryTimeLimit(string)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ToDeliveryTimeLimit_WithInvalidArguments_ThrowsException(string? value)
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToDeliveryTimeLimit("test"));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToDeliveryTimeLimit(value!));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToDeliveryTimeLimit(string)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void ToDeliveryTimeLimit_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<string, DeliveryTimeLimit>()
            {
                { "0", DeliveryTimeLimit.NoLimit },
                { "2", DeliveryTimeLimit.TenAMToOnePM },
                { "3", DeliveryTimeLimit.OnePMMToFourPM },
                { "4", DeliveryTimeLimit.FourPMToSevenPM }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.ToDeliveryTimeLimit(supportedChargeType.Key);

                Assert.Equal(supportedChargeType.Value, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromDeliveryTimeLimit(DeliveryTimeLimit)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void FromDeliveryTimeLimit_WithInvalidArguments_ThrowsException()
        {
            var undefinedEnum = (DeliveryTimeLimit)4;

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.FromDeliveryTimeLimit(undefinedEnum));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromDeliveryTimeLimit(DeliveryTimeLimit)"/> method is called, 
        /// using every available value for <see cref="DeliveryTimeLimit"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromDeliveryTimeLimit_AllAvailableArguments_NoExceptionIsThrown()
        {
            AssertAvailableEnumValueSupport<DeliveryTimeLimit>((element) => SpeedexHelpers.FromDeliveryTimeLimit(element));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromDeliveryTimeLimit(DeliveryTimeLimit)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void FromDeliveryTimeLimit_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<string, DeliveryTimeLimit>()
            {
                { "0", DeliveryTimeLimit.NoLimit },
                { "2", DeliveryTimeLimit.TenAMToOnePM },
                { "3", DeliveryTimeLimit.OnePMMToFourPM },
                { "4", DeliveryTimeLimit.FourPMToSevenPM }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.FromDeliveryTimeLimit(supportedChargeType.Value);

                Assert.Equal(supportedChargeType.Key, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToDeliveryTimeWindow(DeliveryTimeLimit)"/> method is called, 
        /// using every available value for <see cref="DeliveryTimeLimit"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToDeliveryTimeWindow_AllAvailableArguments_NoExceptionIsThrown()
        {
            AssertAvailableEnumValueSupport<DeliveryTimeLimit>((element) => SpeedexHelpers.ToDeliveryTimeWindow(element));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(TimeOnly?, TimeOnly?)"/> method is called, 
        /// using every available value for <see cref="DeliveryTimeLimit"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void GetDeliveryTimeLimitByTimeRange_AllAvailableArguments_NoExceptionIsThrown()
        {
            var deliveryTimeLimit = SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(null, null);

            Assert.Equal(DeliveryTimeLimit.NoLimit, deliveryTimeLimit);

            deliveryTimeLimit = SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(new TimeOnly(10, 0), new TimeOnly(13, 0));

            Assert.Equal(DeliveryTimeLimit.TenAMToOnePM, deliveryTimeLimit);

            deliveryTimeLimit = SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(new TimeOnly(13, 0), new TimeOnly(16, 0));

            Assert.Equal(DeliveryTimeLimit.OnePMMToFourPM, deliveryTimeLimit);

            deliveryTimeLimit = SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(new TimeOnly(16, 0), new TimeOnly(19, 0));

            Assert.Equal(DeliveryTimeLimit.FourPMToSevenPM, deliveryTimeLimit);

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.GetDeliveryTimeLimitByTimeRange(null, new TimeOnly(19, 0)));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToPaperType(uint)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToPaperType_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToPaperType(0));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToPaperType(5));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToPaperType(uint)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void ToPaperType_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<uint, PaperSize>()
            {
                { 1, PaperSize.A4 },
                { 2, PaperSize.A5 },
                { 3, PaperSize.TenOnTwentyOneCentimeters },
                { 4, PaperSize.A6 }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.ToPaperType(supportedChargeType.Key);

                Assert.Equal(supportedChargeType.Value, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromPaperType(PaperSize)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void FromPaperType_WithInvalidArguments_ThrowsException()
        {
            var undefinedEnum = (PaperSize)4;

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.FromPaperType(undefinedEnum));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromPaperType(PaperSize)"/> method is called, 
        /// using every available value for <see cref="PaperSize"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromPaperType_AllAvailableArguments_NoExceptionIsThrown()
        {
            AssertAvailableEnumValueSupport<PaperSize>((element) => SpeedexHelpers.FromPaperType(element));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromPaperType(PaperSize)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void FromPaperType_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<uint, PaperSize>()
            {
                { 1, PaperSize.A4 },
                { 2, PaperSize.A5 },
                { 3, PaperSize.TenOnTwentyOneCentimeters },
                { 4, PaperSize.A6 }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.FromPaperType(supportedChargeType.Value);

                Assert.Equal(supportedChargeType.Key, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToSupportedLanguage(uint)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ToSupportedLanguage_WithInvalidArguments_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToSupportedLanguage(0));

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.ToSupportedLanguage(3));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.ToSupportedLanguage(uint)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void ToSupportedLanguage_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<uint, SupportedLanguage>()
            {
                { 1, SupportedLanguage.Greek },
                { 2, SupportedLanguage.English }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.ToSupportedLanguage(supportedChargeType.Key);

                Assert.Equal(supportedChargeType.Value, result);
            }
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromSupportedLanguage(SupportedLanguage)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void FromSupportedLanguage_WithInvalidArguments_ThrowsException()
        {
            var undefinedEnum = (SupportedLanguage)2;

            Assert.ThrowsAny<Exception>(() => SpeedexHelpers.FromSupportedLanguage(undefinedEnum));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromSupportedLanguage(SupportedLanguage)"/> method is called, 
        /// using every available value for <see cref="SupportedLanguage"/>, no exception is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void FromSupportedLanguage_AllAvailableArguments_NoExceptionIsThrown()
        {
            AssertAvailableEnumValueSupport<SupportedLanguage>((element) => SpeedexHelpers.FromSupportedLanguage(element));
        }

        /// <summary>
        /// Validates that when <see cref="SpeedexHelpers.FromSupportedLanguage(SupportedLanguage)"/> method is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        [Fact]
        public void FromSupportedLanguage_WithValidArguments_ReturnsExpectedResul()
        {
            var supportedChargeTypes = new Dictionary<uint, SupportedLanguage>()
            {
                { 1, SupportedLanguage.Greek },
                { 2, SupportedLanguage.English }
            };

            foreach (var supportedChargeType in supportedChargeTypes)
            {
                var result = SpeedexHelpers.FromSupportedLanguage(supportedChargeType.Value);

                Assert.Equal(supportedChargeType.Key, result);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Asserts whether all the values of the <typeparamref name="TEnum"/>
        /// are supported when calling the specified<paramref name="function"/>
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum</typeparam>
        /// <param name="function">The function that uses the <typeparamref name="TEnum"/></param>
        private static void AssertAvailableEnumValueSupport<TEnum>(Action<TEnum> function)
            where TEnum : struct, Enum
        {
            var availableChargeTypes = Enum.GetValues<TEnum>();

            var elementInspectors = Enumerable.Repeat<Action<TEnum>>((element) => function(element), availableChargeTypes.Length).ToArray();

            Assert.Collection(availableChargeTypes, elementInspectors);
        }

        #endregion
    }
}