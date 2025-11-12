using Couriers.Common;
using Couriers.Common.Xml;

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The <see cref="DelegatingHandler"/> implementation that simulates the HTTP requests 
    /// </summary>
    internal sealed class SimulationHttpHandler : DelegatingHandler
    {
        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SimulationHttpHandler()
        {
            InnerHandler = new HttpClientHandler();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="innerHandler">The inner handler</param>
        public SimulationHttpHandler(HttpMessageHandler innerHandler) : base(innerHandler)
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
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content is not TypedStringContent requestContent)
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var responseType = requestContent.ResponseType;

            var responseModel = TestConstants.ResponseObjects[responseType];

            var responsePayload = XmlHelpers.ToXml(responseModel, SpeedexXmlNamespaces.SpeedexNamespaces);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responsePayload)
            };
        }

        #endregion
    }
}