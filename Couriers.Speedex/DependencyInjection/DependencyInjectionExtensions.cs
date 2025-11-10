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
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">An exception is thrown if any of the arguments is <see langword="null"/></exception>
        public static IServiceCollection AddSpeedexClient([NotNull] this IServiceCollection services, [NotNull] SpeedexCredentials speedexCredentials)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (speedexCredentials is null)
                throw new ArgumentNullException(nameof(speedexCredentials));

            services.AddHttpClient();

            services.AddScoped<ISpeedexClient>(serviceProvider => new SpeedexClient(speedexCredentials, serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient()));

            return services;
        }

        /// <summary>
        /// Adds a <see cref="DemoSpeedexClient"/> as, a scoped service using the <paramref name="speedexCredentials"/>,in the specified <paramref name="services"/>
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="speedexCredentials">The Speedex credentials</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">An exception is thrown if any of the arguments is <see langword="null"/></exception>
        public static IServiceCollection AddDemoSpeedexClient([NotNull] this IServiceCollection services, [NotNull] SpeedexCredentials speedexCredentials)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (speedexCredentials is null)
                throw new ArgumentNullException(nameof(speedexCredentials));

            services.AddHttpClient();

            services.AddScoped<ISpeedexClient>(serviceProvider => new DemoSpeedexClient(speedexCredentials, serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient()));

            return services;
        }
    }
}
