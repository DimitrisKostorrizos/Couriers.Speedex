using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The <see cref="SimulationHttpHandler"/> implementation that throws an <see cref="Exception"/> during a HTTP requests
    /// </summary>
    internal sealed class ExceptionSimulationHttpHandler : SimulationHttpHandler
    {
        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ExceptionSimulationHttpHandler() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="innerHandler">The inner handler</param>
        public ExceptionSimulationHttpHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {

        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        protected sealed override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => throw new InvalidOperationException("An error occurred.");

        #endregion
    }
}