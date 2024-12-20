namespace Couriers.Speedex
{
    /// <summary>
    /// Provides abstractions for a SOAP internal response model for the new web methods
    /// </summary>
    internal interface INewWebMethodSoapReturnMessageModel<T> : ISoapReturnMessageModel
    {
        #region Properties

        /// <summary>
        /// The return result
        /// </summary>
        public MessageInternalResponseModel<T> Result { get; set; }

        /// <summary>
        /// The return message
        /// </summary>
        string ISoapReturnMessageModel.Message { get => Result.Message; set { Result.Message = value; } }

        /// <summary>
        /// The return code
        /// </summary>
        uint ISoapReturnMessageModel.Code { get => Result.Code; set { Result.Code = value; } }

        #endregion
    }
}
