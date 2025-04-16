namespace Couriers.Speedex.Interfaces
{
    /// <summary>
    /// Provides abstractions for a SOAP internal response model
    /// </summary>
    internal interface ISoapReturnMessageModel
    {
        #region Properties

        /// <summary>
        /// The return message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The return code
        /// </summary>
        uint Code { get; set; }

        #endregion
    }
}
