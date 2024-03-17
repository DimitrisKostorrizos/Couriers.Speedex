using System;

namespace Couriers.Speedex.Tests
{
    public static class TestHelpers
    {
        #region Private Fields

        /// <summary>
        /// The digits
        /// </summary>
        private static readonly int[] _digits =
        [
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        ];

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a new random voucher number
        /// </summary>
        /// <returns></returns>
        public static string GenerateTestVoucher()
        {
            var selectedDigits = Random.Shared.GetItems(_digits, 12);

            return string.Join(string.Empty, selectedDigits);
        }

        #endregion
    }
}
