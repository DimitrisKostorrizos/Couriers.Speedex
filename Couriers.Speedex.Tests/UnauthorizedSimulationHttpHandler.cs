using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The <see cref="SimulationHttpHandler"/> implementation that simulates unauthorized HTTP requests 
    /// </summary>
    internal sealed class UnauthorizedSimulationHttpHandler : SimulationHttpHandler
    {
        #region Internal Properties

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        internal sealed override IReadOnlyDictionary<Type, object> ResponseObjects { get; } = TestConstants.UnauthorizedResponseObjects;

        #endregion

        #region Constructors

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public UnauthorizedSimulationHttpHandler() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="innerHandler">The inner handler</param>
        public UnauthorizedSimulationHttpHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {

        }

        #endregion
    }
}