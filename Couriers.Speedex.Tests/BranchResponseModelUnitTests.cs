using Couriers.Speedex.ResponseModels;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="BranchResponseModel"/>
    /// </summary>
    public sealed class BranchResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="BranchResponseModelUnitTests"/>
        /// </summary>
        public BranchResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="BranchResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void BranchResponseModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var address = TestHelpers.GenerateRandomString(50);

            var city = TestHelpers.GenerateRandomString(20);

            var id = TestHelpers.GenerateRandomString(30);

            var latitude = TestHelpers.GenerateRandomString(8);

            var longitude = TestHelpers.GenerateRandomString(8);

            var name = TestHelpers.GenerateRandomString(30);

            var telephoneNumber = TestHelpers.GenerateRandomString(10);

            var zipCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(value!, city, id, name, telephoneNumber, zipCode, latitude, longitude));

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(address, value!, id, name, telephoneNumber, zipCode, latitude, longitude));

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(address, city, value!, name, telephoneNumber, zipCode, latitude, longitude));

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(address, city, id, name, telephoneNumber, zipCode, value!, longitude));

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(address, city, id, name, telephoneNumber, zipCode, latitude, value!));

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(address, city, id, value!, telephoneNumber, zipCode, latitude, longitude));

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel(address, city, id, name, telephoneNumber, value!, latitude, longitude));
        }

        /// <summary>
        /// Validates that when <see cref="BranchResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void BranchResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var address = TestHelpers.GenerateRandomString(50);

            var city = TestHelpers.GenerateRandomString(20);

            var id = TestHelpers.GenerateRandomString(30);

            var latitude = TestHelpers.GenerateRandomString(8);

            var longitude = TestHelpers.GenerateRandomString(8);

            var name = TestHelpers.GenerateRandomString(30);

            var telephoneNumber = TestHelpers.GenerateRandomString(10);

            var zipCode = TestHelpers.GenerateRandomString(5);

            var result = new BranchResponseModel(address, city, id, name, telephoneNumber, zipCode,  latitude, longitude);

            Assert.NotNull(result);

            Assert.Equal(address, result.Address);

            Assert.Equal(city, result.City);

            Assert.Equal(id, result.Id);

            Assert.Equal(latitude, result.Latitude);

            Assert.Equal(longitude, result.Longitude);

            Assert.Equal(name, result.Name);

            Assert.Equal(telephoneNumber, result.TelephoneNumber);

            Assert.Equal(zipCode, result.ZipCode);
        }

        #endregion

        #endregion
    }
}