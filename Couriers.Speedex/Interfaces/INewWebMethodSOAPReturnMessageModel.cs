using Couriers.Speedex.InternalModels.ResponseModels;

using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex.Interfaces
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
        [ExcludeFromCodeCoverage]
        string ISoapReturnMessageModel.Message
        {
            get => Result.Message;
            set => Result.Message = value;
        }

        /// <summary>
        /// The return code
        /// </summary>
        [ExcludeFromCodeCoverage]
        uint ISoapReturnMessageModel.Code
        {
            get => Result.Code;
            set => Result.Code = value;
        }

        #endregion
    }
}