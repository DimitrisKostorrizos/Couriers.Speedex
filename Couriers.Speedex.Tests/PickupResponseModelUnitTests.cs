using Couriers.Speedex.Constants;
using Couriers.Speedex.ResponseModels;

using System;
using System.Collections.Generic;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="PickupResponseModel"/>
    /// </summary>
    public sealed class PickupResponseModelUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="PickupResponseModelUnitTests"/>
        /// </summary>
        public PickupResponseModelUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with an invalid id, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupResponseModel_WithInvalidId_ThrowsException(string? value)
        {
            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = countryCode,
                Id = value!,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            });
        }

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void PickupResponseModel_WithInvalidConsignmentIds_ThrowsException()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                Comments = comments,
                ConsignmentIds = null!,
                CountryCode = countryCode,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            });
        }

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with an invalid checkpoint group code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupResponseModel_WithInvalidCheckpointGroupCode_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = value!,
                City = city,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = countryCode,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            });
        }

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with an invalid address, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupResponseModel_WithInvalidAddress_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = value!,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = countryCode,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            });
        }

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with an invalid city, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupResponseModel_WithInvalidCity_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = value!,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = countryCode,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            });
        }
        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with an invalid country code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupResponseModel_WithInvalidCountryCode_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = value!,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            });
        }

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with an invalid post code, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The empty <see cref="string"/> value</param>
        [Theory]
        [MemberData(nameof(TestHelpers.EmptyStringValues), MemberType = typeof(TestHelpers))]
        public void PickupResponseModel_WithInvalidPostCode_ThrowsException(string? value)
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            Assert.ThrowsAny<Exception>(() => new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = countryCode,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = value!
            });
        }

        /// <summary>
        /// Validates that when <see cref="PickupResponseModel"/> constructor is called, 
        /// with valid arguments, the expected result is returned
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void PickupResponseModel_WithValidArguments_ReturnsExpectedResult()
        {
            var pickupId = TestHelpers.GenerateTestPickupNumber();

            var address = TestHelpers.GenerateRandomString(20);

            var checkpointCode = TestHelpers.GenerateRandomString(6);

            var checkpointGroupCode = TestHelpers.GenerateRandomString(6);

            var city = TestHelpers.GenerateRandomString(8);

            var comments = TestHelpers.GenerateRandomString(20);

            var consignmentIds = new List<string>()
            {
                TestHelpers.GenerateTestVoucherNumber()
            };

            var countryCode = SpeedexConstants.GreeceCountryCode;

            var name = TestHelpers.GenerateRandomString(10);

            var phoneNumber = TestHelpers.GenerateRandomString(10);

            var pickupDate = DateOnly.FromDateTime(DateTime.Now);

            var pickupTimeFrom = new TimeOnly(13, 0);

            var pickupTimeTo = new TimeOnly(16, 0);

            var postCode = TestHelpers.GenerateRandomString(5);

            var result = new PickupResponseModel()
            {
                Address = address,
                CheckpointCode = checkpointCode,
                CheckpointGroupCode = checkpointGroupCode,
                City = city,
                Comments = comments,
                ConsignmentIds = consignmentIds,
                CountryCode = countryCode,
                Id = pickupId,
                Name = name,
                PhoneNumber = phoneNumber,
                PickupDate = pickupDate,
                PickupTimeFrom = pickupTimeFrom,
                PickupTimeTo = pickupTimeTo,
                PostCode = postCode
            };

            Assert.NotNull(result);

            Assert.Equal(address, result.Address);

            Assert.Equal(checkpointCode, result.CheckpointCode);

            Assert.Equal(checkpointGroupCode, result.CheckpointGroupCode);

            Assert.Equal(city, result.City);

            Assert.Equal(comments, result.Comments);

            Assert.Same(consignmentIds, result.ConsignmentIds);

            Assert.Equal(countryCode, result.CountryCode);

            Assert.Equal(pickupId, result.Id);

            Assert.Equal(name, result.Name);

            Assert.Equal(phoneNumber, result.PhoneNumber);

            Assert.Equal(pickupDate, result.PickupDate);

            Assert.Equal(pickupTimeFrom, result.PickupTimeFrom);

            Assert.Equal(pickupTimeTo, result.PickupTimeTo);

            Assert.Equal(postCode, result.PostCode);
        }

        #endregion

        #endregion
    }
}