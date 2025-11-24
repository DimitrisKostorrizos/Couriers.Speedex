using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The <see cref="SimulationHttpHandler"/> implementation that simulates <see cref="HttpStatusCode.BadGateway"/> HTTP requests 
    /// </summary>
    internal sealed class BadGatewaySimulationHttpHandler : SimulationHttpHandler
    {
        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public BadGatewaySimulationHttpHandler() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="innerHandler">The inner handler</param>
        public BadGatewaySimulationHttpHandler(HttpMessageHandler innerHandler) : base(innerHandler)
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
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadGateway)
            {
                Content = new StringContent("Bad Gateway")
            };

            return Task.FromResult(response);
        }

        #endregion
    }
}