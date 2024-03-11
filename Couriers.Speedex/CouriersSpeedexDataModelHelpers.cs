using System;

namespace Couriers.Speedex
{
    /// <summary>
    /// The helper methods for enums
    /// </summary>
    internal static class CouriersSpeedexDataModelHelpers
    {
        #region Charge Type

        /// <summary>
        /// Return the <see cref="ChargeType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static ChargeType ToChargeType(uint value)
        {
            return value switch
            {
                1 => ChargeType.Sender,
                2 => ChargeType.Recipient,
                3 => ChargeType.ThirdParty,
                _ => throw new InvalidOperationException($"The {value} is not a valid charge type.")
            };
        }

        /// <summary>
        /// Return the <see cref="ChargeType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static ChargeType ToChargeType(string value)
        {
            return value switch
            {
                "Sender" => ChargeType.Sender,
                "Recipient" => ChargeType.Recipient,
                "ThirdParty" => ChargeType.ThirdParty,
                _ => throw new InvalidOperationException($"The {value} is not a valid charge type.")
            };
        }
        /// <summary>
        /// Return the <see cref="uint"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static uint FromChargeType(ChargeType value)
        {
            return value switch
            {
                ChargeType.Sender => 1,
                ChargeType.Recipient => 2,
                ChargeType.ThirdParty => 3,
                _ => throw new InvalidOperationException($"The {value} is not a valid charge type.")
            };
        }

        #endregion

        #region Payment Type

        /// <summary>
        /// Return the <see cref="PaymentType"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static PaymentType ToPaymentType(string value)
        {
            return value switch
            {
                "M" => PaymentType.Cash,
                "E" => PaymentType.Check,
                _ => throw new InvalidOperationException($"The {value} is not a valid payment type.")
            };
        }

        /// <summary>
        /// Return the <see cref="char"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static string FromPaymentType(PaymentType value)
        {
            return value switch
            {
                PaymentType.Cash => "M",
                PaymentType.Check => "E",
                _ => throw new InvalidOperationException($"The {value} is not a valid payment type.")
            };
        }

        #endregion

        #region Delivery Time Limit

        /// <summary>
        /// Return the <see cref="DeliveryTimeLimit"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static DeliveryTimeLimit ToDeliveryTimeLimit(string value)
        {
            return value switch
            {
                "0" => DeliveryTimeLimit.NoLimit,
                "2" => DeliveryTimeLimit.TenAMToOnePM,
                "3" => DeliveryTimeLimit.OnePMMToFourPM,
                "4" => DeliveryTimeLimit.FourPMToSevenPM,
                _ => throw new InvalidOperationException($"The {value} is not a valid delivery time limit.")
            };
        }

        /// <summary>
        /// Return the <see cref="char"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static string FromDeliveryTimeLimit(DeliveryTimeLimit value)
        {
            return value switch
            {
                DeliveryTimeLimit.NoLimit => "0",
                DeliveryTimeLimit.TenAMToOnePM => "2",
                DeliveryTimeLimit.OnePMMToFourPM => "3",
                DeliveryTimeLimit.FourPMToSevenPM => "4",
                _ => throw new InvalidOperationException($"The {value} is not a valid delivery time limit.")
            };
        }

        /// <summary>
        /// Returns the <paramref name="deliveryTimeFrom"/> and the <paramref name="deliveryTimeTo"/> based on the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The delivery time limit</param>
        /// <param name="deliveryTimeFrom">The starting delivery time</param>
        /// <param name="deliveryTimeTo">The ending delivery time</param>
        public static void ToTimeLimit(DeliveryTimeLimit value, out DateTime? deliveryTimeFrom, out DateTime? deliveryTimeTo)
        {
            deliveryTimeFrom = null;

            deliveryTimeTo = null;

            if (value == DeliveryTimeLimit.NoLimit)
                return;
            else
            {
                var timeFrom = new DateTime();

                var timeTo = new DateTime();

                if (value == DeliveryTimeLimit.TenAMToOnePM)
                {
                    deliveryTimeFrom = timeFrom.AddHours(10);

                    deliveryTimeTo = timeTo.AddHours(13);
                }
                else if (value == DeliveryTimeLimit.OnePMMToFourPM)
                {
                    deliveryTimeFrom = timeFrom.AddHours(13);

                    deliveryTimeTo = timeTo.AddHours(16);
                }
                else if (value == DeliveryTimeLimit.FourPMToSevenPM)
                {
                    deliveryTimeFrom = timeFrom.AddHours(16);

                    deliveryTimeTo = timeTo.AddHours(19);
                }
            }
            return;
        }

        #endregion

        #region Paper Size

        /// <summary>
        /// Return the <see cref="PaperSize"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static PaperSize ToPaperType(uint value)
        {
            return value switch
            {
                1 => PaperSize.A4,
                2 => PaperSize.A5,
                3 => PaperSize.TenOnTwentyOneCentimeters,
                4 => PaperSize.A6,
                _ => throw new InvalidOperationException($"The {value} is not a valid paper size.")
            };
        }

        /// <summary>
        /// Return the <see cref="uint"/> that corresponds to the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static uint FromPaperType(PaperSize value)
        {
            return value switch
            {
                PaperSize.A4 => 1,
                PaperSize.A5 => 2,
                PaperSize.TenOnTwentyOneCentimeters => 3,
                PaperSize.A6 => 4,
                _ => throw new InvalidOperationException($"The {value} is not a valid paper size.")
            };
        }

        #endregion
    }
}
