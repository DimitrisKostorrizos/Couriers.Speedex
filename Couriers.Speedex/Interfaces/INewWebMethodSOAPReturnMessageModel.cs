namespace Couriers.Speedex
{
    /// <summary>
    /// Provides abstractions for a SOAP internal response model for the new web methods
    /// </summary>
    internal interface INewWebMethodSOAPReturnMessageModel<T> : ISOAPReturnMessageModel
    {
        #region Properties

        /// <summary>
        /// The return result
        /// </summary>
        public MessageInternalResponseModel<T> Result { get; set; }

        /// <summary>
        /// The return message
        /// </summary>
        string ISOAPReturnMessageModel.Message { get => Result.Message; set { Result.Message = value; } }

        /// <summary>
        /// The return code
        /// </summary>
        uint ISOAPReturnMessageModel.Code { get => Result.Code; set { Result.Code = value; } }

        #endregion
    }
}
