using Couriers.Speedex.DependencyInjection;
using Couriers.Speedex.Services;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The unit tests for the <see cref="DependencyInjectionExtensions"/>
    /// </summary>
    public sealed class DependencyInjectionExtensionsUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DependencyInjectionExtensionsUnitTests"/>
        /// </summary>
        public DependencyInjectionExtensionsUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="DependencyInjectionExtensions.AddDemoSpeedexClient(IServiceCollection, SpeedexCredentials, object?)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void AddDemoSpeedexClient_WithInvalidArguments_ThrowsException()
        {
            var serviceCollection = default(IServiceCollection?);

            Assert.ThrowsAny<Exception>(() => new ServiceCollection().AddDemoSpeedexClient(null!));

            Assert.ThrowsAny<Exception>(() => serviceCollection!.AddDemoSpeedexClient(null!));
        }

        /// <summary>
        /// Validates that when <see cref="DependencyInjectionExtensions.AddDemoSpeedexClient(IServiceCollection, SpeedexCredentials, object?)"/> method is called, 
        /// with valid arguments, the valid service is resolved
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void AddDemoSpeedexClient_WithValidArguments_ValidServiceIsResolved()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDemoSpeedexClient(TestConstants.SpeedexCredentials);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var speedexClient = serviceProvider.GetService<ISpeedexClient>();

            var services = serviceProvider.GetServices<ISpeedexClient>();

            Assert.Single(services);

            Assert.NotNull(speedexClient);

            Assert.IsType<DemoSpeedexClient>(speedexClient);
        }

        /// <summary>
        /// Validates that when <see cref="DependencyInjectionExtensions.AddDemoSpeedexClient(IServiceCollection, SpeedexCredentials, object?)"/> method is called, 
        /// with valid arguments and a service key, the valid service is resolved
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void AddDemoSpeedexClient_WithServiceKey_ValidServiceIsResolved()
        {
            var key = "service";

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDemoSpeedexClient(TestConstants.SpeedexCredentials, key);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var speedexClient = serviceProvider.GetService<ISpeedexClient>();

            var services = serviceProvider.GetServices<ISpeedexClient>();

            var keyedServices = serviceProvider.GetKeyedServices<ISpeedexClient>(key);

            var keyedSpeedexClient = serviceProvider.GetKeyedService<ISpeedexClient>(key);

            Assert.Single(services);

            Assert.Single(keyedServices);

            Assert.NotNull(speedexClient);

            Assert.IsType<DemoSpeedexClient>(speedexClient);

            Assert.NotNull(keyedSpeedexClient);

            Assert.IsType<DemoSpeedexClient>(keyedSpeedexClient);
        }

        /// <summary>
        /// Validates that when <see cref="DependencyInjectionExtensions.AddSpeedexClient(IServiceCollection, SpeedexCredentials, object?)"/> method is called, 
        /// with invalid arguments, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void AddSpeedexClient_WithInvalidArguments_ThrowsException()
        {
            var serviceCollection = default(IServiceCollection?);

            Assert.ThrowsAny<Exception>(() => new ServiceCollection().AddSpeedexClient(null!));

            Assert.ThrowsAny<Exception>(() => serviceCollection!.AddSpeedexClient(null!));
        }

        /// <summary>
        /// Validates that when <see cref="DependencyInjectionExtensions.AddSpeedexClient(IServiceCollection, SpeedexCredentials, object?)"/> method is called, 
        /// with valid arguments, the valid service is resolved
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void AddSpeedexClient_WithValidArguments_ValidServiceIsResolved()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSpeedexClient(TestConstants.SpeedexCredentials);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var speedexClient = serviceProvider.GetService<ISpeedexClient>();

            var services = serviceProvider.GetServices<ISpeedexClient>();

            Assert.Single(services);

            Assert.NotNull(speedexClient);

            Assert.IsType<SpeedexClient>(speedexClient);
        }

        /// <summary>
        /// Validates that when <see cref="DependencyInjectionExtensions.AddSpeedexClient(IServiceCollection, SpeedexCredentials, object?)"/> method is called, 
        /// with valid arguments and a service key, the valid service is resolved
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void AddSpeedexClient_WithServiceKey_ValidServiceIsResolved()
        {
            var key = "service";

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSpeedexClient(TestConstants.SpeedexCredentials, key);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var speedexClient = serviceProvider.GetService<ISpeedexClient>();

            var services = serviceProvider.GetServices<ISpeedexClient>();

            var keyedServices = serviceProvider.GetKeyedServices<ISpeedexClient>(key);

            var keyedSpeedexClient = serviceProvider.GetKeyedService<ISpeedexClient>(key);

            Assert.Single(services);

            Assert.Single(keyedServices);

            Assert.NotNull(speedexClient);

            Assert.IsType<SpeedexClient>(speedexClient);

            Assert.NotNull(keyedSpeedexClient);

            Assert.IsType<SpeedexClient>(keyedSpeedexClient);
        }

        #endregion

        #endregion
    }
}