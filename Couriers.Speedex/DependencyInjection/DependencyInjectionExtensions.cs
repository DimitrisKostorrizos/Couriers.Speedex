using Couriers.Speedex.Services;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Couriers.Speedex.DependencyInjection
{
    /// <summary>
    /// Contains the extensions methods for the <see cref="IServiceCollection"/>
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="speedexCredentials">The Speedex credentials</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">An exception is thrown if any of the arguments is <see langword="null"/></exception>
        public static IServiceCollection AddSpeedexClient([NotNull] this IServiceCollection services, [NotNull] SpeedexCredentials speedexCredentials)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(services);

            ArgumentNullException.ThrowIfNull(speedexCredentials);
#else
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (speedexCredentials is null)
                throw new ArgumentNullException(nameof(speedexCredentials));
#endif
            services.AddScoped(serviceProvider => new SpeedexClient(speedexCredentials));

            services.AddKeyedScoped(speedexCredentials.Username, (serviceProvider, key) => new SpeedexClient(speedexCredentials));

            return services;
        }
    }
}
