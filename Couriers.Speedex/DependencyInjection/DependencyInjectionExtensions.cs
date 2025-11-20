using Couriers.Speedex.Services;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Couriers.Speedex.DependencyInjection
{
    /// <summary>
    /// Contains the extensions methods for the <see cref="IServiceCollection"/>
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adds a <see cref="SpeedexClient"/> as, a scoped service using the <paramref name="speedexCredentials"/>,in the specified <paramref name="services"/>
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="speedexCredentials">The Speedex credentials</param>
        /// <param name="serviceKey">An key used to identify the service</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">An exception is thrown if any of the arguments is <see langword="null"/></exception>
        public static IServiceCollection AddSpeedexClient([NotNull] this IServiceCollection services, [NotNull] SpeedexCredentials speedexCredentials, object? serviceKey = null)
        {
            ArgumentNullException.ThrowIfNull(services);

            ArgumentNullException.ThrowIfNull(speedexCredentials);

            services.AddHttpClient();

            services.AddScoped<ISpeedexClient>(serviceProvider => new SpeedexClient(speedexCredentials, serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient()));

            if (serviceKey is not null)
                services.AddKeyedScoped<ISpeedexClient>(serviceKey, (serviceProvider, _) => new SpeedexClient(speedexCredentials, serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient()));

            return services;
        }

        /// <summary>
        /// Adds a <see cref="DemoSpeedexClient"/> as, a scoped service using the <paramref name="speedexCredentials"/>,in the specified <paramref name="services"/>
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="speedexCredentials">The Speedex credentials</param>
        /// <param name="serviceKey">An key used to identify the service</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">An exception is thrown if any of the arguments is <see langword="null"/></exception>
        public static IServiceCollection AddDemoSpeedexClient([NotNull] this IServiceCollection services, [NotNull] SpeedexCredentials speedexCredentials, object? serviceKey = null)
        {
            ArgumentNullException.ThrowIfNull(services);

            ArgumentNullException.ThrowIfNull(speedexCredentials);

            services.AddHttpClient();

            services.AddScoped<ISpeedexClient>(serviceProvider => new DemoSpeedexClient(speedexCredentials, serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient()));

            if (serviceKey is not null)
                services.AddKeyedScoped<ISpeedexClient>(serviceKey, (serviceProvider, _) => new DemoSpeedexClient(speedexCredentials, serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient()));

            return services;
        }
    }
}