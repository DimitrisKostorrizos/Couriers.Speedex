namespace Couriers.Speedex.Interfaces
{
    /// <summary>
    /// Provides abstractions for a SOAP internal response model
    /// </summary>
    /// <typeparam name="TResponse">The type of the response model</typeparam>
    internal interface ISoapResponseModel<out TResponse>
    {
        #region Methods

        /// <summary>
        /// Creates and return the <typeparamref name="TResponse"/> from the current object
        /// </summary>
        /// <returns></returns>
        TResponse ToResponseModel();

        #endregion
    }
}
