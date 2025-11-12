using Couriers.Common.Xml;
using Couriers.Speedex.Constants;
using Couriers.Speedex.Enums;
using Couriers.Speedex.Structs;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Couriers.Speedex
{
    /// <summary>
    /// The helper methods for enums
    /// </summary>
    public static class SpeedexHelpers
    {
        #region Private Fields

        /// <summary>
        /// Contains the mappings between the <see cref="DeliveryTimeLimit"/> and the respective <see cref="DeliveryTimeWindow"/>
        /// </summary>
        private static readonly Dictionary<DeliveryTimeLimit, DeliveryTimeWindow> _deliveryTimeMappings = new()
        {
            { DeliveryTimeLimit.NoLimit, new DeliveryTimeWindow() },
            { DeliveryTimeLimit.TenAMToOnePM, new DeliveryTimeWindow(DateTime.MinValue.AddHours(10), DateTime.MinValue.AddHours(13)) },
            { DeliveryTimeLimit.OnePMMToFourPM, new DeliveryTimeWindow(DateTime.MinValue.AddHours(13), DateTime.MinValue.AddHours(16)) },
            { DeliveryTimeLimit.FourPMToSevenPM, new DeliveryTimeWindow(DateTime.MinValue.AddHours(16), DateTime.MinValue.AddHours(19)) }
        };

        #endregion

        #region Public Methods

        #region Charge Type

        /// <summary>
        /// Return the <see cref="ChargeType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static ChargeType ToChargeType(uint value)
            => value switch
            {
                1 => ChargeType.Sender,
                2 => ChargeType.Recipient,
                3 => ChargeType.ThirdParty,
                4 => ChargeType.Receiver,
                _ => throw new InvalidOperationException($"The {value} is not a valid charge type.")
            };

        /// <summary>
        /// Return the <see cref="ChargeType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static ChargeType ToChargeType(string value)
            => value switch
            {
                "Sender" => ChargeType.Sender,
                "Recipient" => ChargeType.Recipient,
                "Receiver" => ChargeType.Receiver,
                "Third Party" => ChargeType.ThirdParty,
                _ => throw new InvalidOperationException($"The {value} is not a valid charge type.")
            };

        /// <summary>
        /// Return the <see cref="uint"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static uint FromChargeType(ChargeType value)
            => value switch
            {
                ChargeType.Sender => 1,
                ChargeType.Recipient => 2,
                ChargeType.ThirdParty => 3,
                ChargeType.Receiver => 4,
                _ => throw new InvalidOperationException($"The {value} is not a valid charge type.")
            };

        #endregion

        #region Payment Type

        /// <summary>
        /// Return the <see cref="PaymentType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static PaymentType ToPaymentType(string value)
            => value switch
            {
                "M" => PaymentType.Cash,
                "E" => PaymentType.Check,
                _ => throw new InvalidOperationException($"The {value} is not a valid payment type.")
            };

        /// <summary>
        /// Return the <see cref="char"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static string FromPaymentType(PaymentType value)
            => value switch
            {
                PaymentType.Cash => "M",
                PaymentType.Check => "E",
                _ => throw new InvalidOperationException($"The {value} is not a valid payment type.")
            };

        #endregion

        #region Delivery Time Limit

        /// <summary>
        /// Throws a <see cref="InvalidOperationException"/> if the <paramref name="value"/>
        /// is not valid a customer reference
        /// </summary>
        /// <param name="value">The value</param>
        public static void ThrowIfInvalidCustomerReference(string? value)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length > SpeedexConstants.MaximumCustomerReferenceLength)
                throw new InvalidOperationException($"The '{nameof(value)}' is not a valid customer reference. The maximum length for a customer reference field is {SpeedexConstants.MaximumCustomerReferenceLength}.");
        }

        /// <summary>
        /// Throws a <see cref="InvalidOperationException"/> if the <paramref name="value"/>
        /// is not valid a comment
        /// </summary>
        /// <param name="value">The value</param>
        public static void ThrowIfInvalidComments(string? value)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length > SpeedexConstants.MaximumCommentLength)
                throw new InvalidOperationException($"The '{nameof(value)}' is not a valid comment. The maximum length for a comment field is {SpeedexConstants.MaximumCommentLength}.");
        }

        /// <summary>
        /// Throws a <see cref="InvalidOperationException"/> if the <paramref name="value"/>
        /// is not valid zip code
        /// </summary>
        /// <param name="value">The value</param>
        public static void ThrowIfInvalidZipCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));

            if (value.Length > SpeedexConstants.MaximumZipCodeLength)
                throw new InvalidOperationException($"The '{nameof(value)}' is not a valid zip code. The maximum length for a zip code field is {SpeedexConstants.MaximumZipCodeLength}.");
        }

        /// <summary>
        /// Return the <see cref="DeliveryTimeLimit"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static DeliveryTimeLimit ToDeliveryTimeLimit(string value)
            => value switch
            {
                "0" => DeliveryTimeLimit.NoLimit,
                "2" => DeliveryTimeLimit.TenAMToOnePM,
                "3" => DeliveryTimeLimit.OnePMMToFourPM,
                "4" => DeliveryTimeLimit.FourPMToSevenPM,
                _ => throw new InvalidOperationException($"The {value} is not a valid delivery time limit.")
            };

        /// <summary>
        /// Return the <see cref="char"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static string FromDeliveryTimeLimit(DeliveryTimeLimit value)
            => value switch
            {
                DeliveryTimeLimit.NoLimit => "0",
                DeliveryTimeLimit.TenAMToOnePM => "2",
                DeliveryTimeLimit.OnePMMToFourPM => "3",
                DeliveryTimeLimit.FourPMToSevenPM => "4",
                _ => throw new InvalidOperationException($"The {value} is not a valid delivery time limit.")
            };

        /// <summary>
        /// Returns the delivery time window based on the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The delivery time limit</param>
        public static DeliveryTimeWindow ToDeliveryTimeWindow(DeliveryTimeLimit value)
            => _deliveryTimeMappings[value];

        /// <summary>
        /// Returns the related <see cref="DeliveryTimeLimit"/> for the specified <paramref name="startingTime"/> and <paramref name="endingTime"/>
        /// </summary>
        /// <param name="startingTime">The starting time of the delivery time</param>
        /// <param name="endingTime">The ending time of the delivery time</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">An exception is thrown the specified parameters don't match a valid <see cref="DeliveryTimeLimit"/></exception>
        public static DeliveryTimeLimit GetDeliveryTimeLimitByTimeRange(DateTime? startingTime, DateTime? endingTime)
        {
            DateTime? startingTimeValue = startingTime.HasValue ? DateTime.MinValue.Add(startingTime.Value.TimeOfDay) : null;

            DateTime? endingTimeValue = endingTime.HasValue ? DateTime.MinValue.Add(endingTime.Value.TimeOfDay) : null;

            foreach (var pair in _deliveryTimeMappings)
                if (pair.Value.StartingTime == startingTimeValue && pair.Value.EndingTime == endingTimeValue)
                    return pair.Key;

            throw new InvalidOperationException($"No mapping exists for {nameof(startingTime)}:{startingTime} and {nameof(endingTime)}:{endingTime}.");
        }

        #endregion

        #region Paper Size

        /// <summary>
        /// Return the <see cref="PaperSize"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static PaperSize ToPaperType(uint value)
            => value switch
            {
                1 => PaperSize.A4,
                2 => PaperSize.A5,
                3 => PaperSize.TenOnTwentyOneCentimeters,
                4 => PaperSize.A6,
                _ => throw new InvalidOperationException($"The {value} is not a valid paper size.")
            };

        /// <summary>
        /// Return the <see cref="uint"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static uint FromPaperType(PaperSize value)
            => value switch
            {
                PaperSize.A4 => 1,
                PaperSize.A5 => 2,
                PaperSize.TenOnTwentyOneCentimeters => 3,
                PaperSize.A6 => 4,
                _ => throw new InvalidOperationException($"The {value} is not a valid paper size.")
            };

        #endregion

        #region Supported Language

        /// <summary>
        /// Return the <see cref="ChargeType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static SupportedLanguage ToSupportedLanguage(uint value)
            => value switch
            {
                1 => SupportedLanguage.Greek,
                2 => SupportedLanguage.English,
                _ => throw new InvalidOperationException($"The {value} is not a valid supported language.")
            };

        /// <summary>
        /// Return the <see cref="SupportedLanguage"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static uint FromSupportedLanguage(SupportedLanguage value)
            => value switch
            {
                SupportedLanguage.Greek => 1,
                SupportedLanguage.English => 2,
                _ => throw new InvalidOperationException($"The {value} is not a valid supported language.")
            };
        #endregion

        #endregion

        #region Internal Methods

        /// <summary>
        /// Serializes the <paramref name="obj"/> to the specified <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="obj">The object</param>
        /// <returns></returns>
        internal static XElement SerializeToSpeedexXElement<T>([NotNull] this T obj)
            => XmlHelpers.SerializeToXElement(obj, SpeedexXmlNamespaces.DefaultPrefix, SpeedexXmlNamespaces.DefaultNamespace);

        #endregion
    }
}
