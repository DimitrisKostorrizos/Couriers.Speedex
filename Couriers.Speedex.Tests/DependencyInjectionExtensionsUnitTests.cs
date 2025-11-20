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
        /// Validates that when <see cref="DependencyInjectionExtensions.AddDemoSpeedexClient(IServiceCollection, SpeedexCredentials)"/> method is called, 
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
        /// Validates that when <see cref="DependencyInjectionExtensions.AddDemoSpeedexClient(IServiceCollection, SpeedexCredentials)"/> method is called, 
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
        /// Validates that when <see cref="DependencyInjectionExtensions.AddSpeedexClient(IServiceCollection, SpeedexCredentials)"/> method is called, 
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
        /// Validates that when <see cref="DependencyInjectionExtensions.AddSpeedexClient(IServiceCollection, SpeedexCredentials)"/> method is called, 
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

        #endregion

        #endregion
    }
}