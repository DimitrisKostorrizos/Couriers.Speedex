using Couriers.Speedex.Constants;

using System.Globalization;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="SpeedexConstants"/>
    /// </summary>
    public sealed class SpeedexConstantsUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SpeedexConstantsUnitTests"/>
        /// </summary>
        public SpeedexConstantsUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="SpeedexConstants.SpeedexCultureInfo"/> is accessed, 
        /// the expected value is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void SpeedexCultureInfo_FieldValue_ExpectedValueIsReturned()
        {
            Assert.Equal(SpeedexConstants.SpeedexCultureInfo, CultureInfo.GetCultureInfo("el-GR"));
        }

        #endregion

        #endregion
    }
}