using Couriers.Speedex.ResponseModels;

using System;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="ConsignmentPdfResponseModel"/>
    /// </summary>
    public sealed class ConsignmentPdfResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ConsignmentPdfResponseModelUnitTests"/>
        /// </summary>
        public ConsignmentPdfResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void ConsignmentPdfResponseModel_WithInvalidArguments_ThrowsException(string? value)
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var base64String = TestHelpers.GenerateRandomString(200);

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfResponseModel()
            {
                Base64String = value!,
                VoucherId = voucherId
            });

            Assert.ThrowsAny<Exception>(() => new ConsignmentPdfResponseModel()
            {
                Base64String = base64String,
                VoucherId = value!
            });
        }

        /// <summary>
        /// Validates that when <see cref="ConsignmentPdfResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ClientReferencesRequestModel_WithValidArguments_ReturnsExpectedResult()
        {
            var voucherId = TestHelpers.GenerateTestVoucherNumber();

            var base64String = TestHelpers.GenerateRandomString(200);

            var result = new ConsignmentPdfResponseModel()
            {
                Base64String = base64String,
                VoucherId = voucherId
            };

            Assert.NotNull(result);

            Assert.Equal(voucherId, result.VoucherId);

            Assert.Equal(base64String, result.Base64String);
        }

        #endregion

        #endregion
    }

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

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = value!,
                City = city,
                Id = id,
                Latitude = latitude,
                Longitude = longitude,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = address,
                City = value!,
                Id = id,
                Latitude = latitude,
                Longitude = longitude,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = address,
                City = city,
                Id = value!,
                Latitude = latitude,
                Longitude = longitude,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = address,
                City = city,
                Id = id,
                Latitude = value!,
                Longitude = longitude,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = address,
                City = city,
                Id = id,
                Latitude = latitude,
                Longitude = value!,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = address,
                City = city,
                Id = id,
                Latitude = latitude,
                Longitude = longitude,
                Name = value!,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            });

            Assert.ThrowsAny<Exception>(() => new BranchResponseModel()
            {
                Address = address,
                City = city,
                Id = id,
                Latitude = latitude,
                Longitude = longitude,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = value!
            });
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

            var result = new BranchResponseModel()
            {
                Address = address,
                City = city,
                Id = id,
                Latitude = latitude,
                Longitude = longitude,
                Name = name,
                TelephoneNumber = telephoneNumber,
                ZipCode = zipCode
            };

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