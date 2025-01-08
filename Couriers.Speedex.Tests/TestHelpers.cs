using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The helper methods for the tests
    /// </summary>
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
#pragma warning disable CA5394 // Do not use insecure randomness

            var selectedDigits = Random.Shared.GetItems(_digits, 12);

#pragma warning restore CA5394 // Do not use insecure randomness

            return string.Join(string.Empty, selectedDigits);
        }

        #endregion
    }
}
