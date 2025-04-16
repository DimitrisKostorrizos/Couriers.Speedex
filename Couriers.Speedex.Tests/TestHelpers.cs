using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The helper methods related to the tests
    /// </summary>
    internal static class TestHelpers
    {
        #region Private Fields

        /// <summary>
        /// The digits
        /// </summary>
        private static readonly int[] _digits =
        [
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        ];

        /// <summary>
        /// The number of days per week
        /// </summary>
        private static readonly int NumberOfDays = Enum.GetValues<DayOfWeek>().Length;

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a new random voucher number
        /// </summary>
        /// <returns></returns>
        public static string GenerateTestVoucherNumber()
        {
#pragma warning disable CA5394 // Do not use insecure randomness

            var selectedDigits = Random.Shared.GetItems(_digits, 12);

#pragma warning restore CA5394 // Do not use insecure randomness

            return string.Join(string.Empty, selectedDigits);
        }

        /// <summary>
        /// Returns the day in the next week based on the specified <paramref name="dayOfWeek"/>
        /// </summary>
        /// <param name="dayOfWeek">The day of week</param>
        /// <returns></returns>
        public static DateTimeOffset GetNextDayOfWeek(DayOfWeek dayOfWeek)
        {
            var currentDay = DateTimeOffset.Now;

            var currentDayOfWeek = (int)currentDay.DayOfWeek;

            var nextDayOfWeek = (int)dayOfWeek;

            var dayDifference = nextDayOfWeek - currentDayOfWeek;

            if (dayDifference <= 0)
                dayDifference = NumberOfDays + dayDifference;

            return currentDay.AddDays(dayDifference);
        }

        /// <summary>
        /// Generates a new random pickup id
        /// </summary>
        /// <returns></returns>
        public static string GenerateTestPickupId()
            => Guid.NewGuid()
                .ToString("N");

        #endregion
    }
}
