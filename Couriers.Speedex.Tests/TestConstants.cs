using System;
using System.Collections.Frozen;
using System.Collections.Generic;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The constants for the tests
    /// </summary>
    public static class TestConstants
    {
        /// <summary>
        /// The response objects used for testing
        /// </summary>
        public static readonly IReadOnlyDictionary<Type, object> ResponseObjects = new Dictionary<Type, object>()
        {
            {
                typeof(SessionIdInternalResponseModel),
                new SoapEnvelopeDataModel<SessionIdInternalResponseModel>()
                {
                    Body = new SoapEnvelopeBodyDataModel<SessionIdInternalResponseModel>()
                    {
                        Model = new SessionIdInternalResponseModel()
                        {
                            ReturnCode = 1,
                            ReturnMessage = string.Empty,
                            SessionId = Guid.NewGuid().ToString("N")
                        }
                    }
                }
            },
            {
                typeof(CancelConsignmentByVoucherIdInternalResponseModel),
                new SoapEnvelopeDataModel<CancelConsignmentByVoucherIdInternalResponseModel>()
                {
                    Body = new SoapEnvelopeBodyDataModel<CancelConsignmentByVoucherIdInternalResponseModel>()
                    {
                        Model = new CancelConsignmentByVoucherIdInternalResponseModel()
                        {
                            ReturnCode = 1,
                            ReturnMessage = string.Empty
                        }
                    }
                }
            },
        }.ToFrozenDictionary();
    }
}
