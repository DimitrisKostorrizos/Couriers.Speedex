using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// The constants for the tests
    /// </summary>
    internal static class TestConstants
    {
        #region Private Fields

        /// <summary>
        /// The private field for the <see cref="ResponseObjects"/>
        /// </summary>
        private static readonly Lazy<IReadOnlyDictionary<Type, object>> _instance = new(() =>
        {
            var primaryVoucherId = TestHelpers.GenerateTestVoucherNumber();

            var secondaryVoucherId = TestHelpers.GenerateTestVoucherNumber();

            var primaryConsignment = new ConsignmentInternalResponseModel()
            {
                Address = "Test",
                AgreementCode = AgreementCode,
                BranchBankCode = "Test",
                ChargeType = SpeedexHelpers.FromChargeType(ChargeType.Sender),
                Cost = 5,
                CustomerCode = CustomerCode,
                CustomerFlag = 0,
                ItemCount = 1,
                PaymentType = SpeedexHelpers.FromPaymentType(PaymentType.Cash),
                RecipientName = "Test",
                RecipientPhoneNumber = "Test",
                VoucherId = primaryVoucherId,
                DeliveryTime = "0",
                Weight = 5,
                ZipCode = "26441"
            };

            var secondaryConsignment = new ConsignmentInternalResponseModel()
            {
                Address = "Test",
                AgreementCode = AgreementCode,
                BranchBankCode = "Test",
                ChargeType = SpeedexHelpers.FromChargeType(ChargeType.Sender),
                Cost = 5,
                CustomerCode = CustomerCode,
                CustomerFlag = 0,
                ItemCount = 1,
                PaymentType = SpeedexHelpers.FromPaymentType(PaymentType.Cash),
                DeliveryTime = "0",
                RecipientName = "Test",
                RecipientPhoneNumber = "Test",
                VoucherId = secondaryVoucherId,
                Weight = 5,
                ZipCode = "26441"
            };

            var pdfArray = new byte[130];

#pragma warning disable CA5394 // Do not use insecure randomness
            Random.Shared.NextBytes(pdfArray);
#pragma warning restore CA5394 // Do not use insecure randomness

            return new Dictionary<Type, object>()
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
                                SessionId = TestHelpers.GenerateTestPickupId()
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
                {
                    typeof(CreateConsignmentsInternalResponseModel),
                    new SoapEnvelopeDataModel<CreateConsignmentsInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<CreateConsignmentsInternalResponseModel>()
                        {
                            Model = new CreateConsignmentsInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                Consignments =
                                [
                                    primaryConsignment,
                                    secondaryConsignment
                                ],
                                Statuses = [ primaryVoucherId, secondaryVoucherId ]
                            }
                        }
                    }
                },
                {
                    typeof(GetConsignmentPdfInternalResponseModel),
                    new SoapEnvelopeDataModel<GetConsignmentPdfInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetConsignmentPdfInternalResponseModel>()
                        {
                            Model = new GetConsignmentPdfInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                Vouchers =
                                [
                                    new ConsignmentPdfInternalResponseModel()
                                    {
                                        VoucherId = primaryVoucherId,
                                        Voucher = Convert.ToBase64String(pdfArray)
                                    }
                                ]
                            }
                        }
                    }
                },
                {
                    typeof(GetBranchesInternalResponseModel),
                    new SoapEnvelopeDataModel<GetBranchesInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetBranchesInternalResponseModel>()
                        {
                            Model = new GetBranchesInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                BranchDepots =
                                [
                                    new BranchInternalResponseModel()
                                    {
                                        Address = "Test",
                                        City = "Test",
                                        Id = "Test",
                                        Latitude = "Test",
                                        Longitude = "Test",
                                        Name = "Test",
                                        TelephoneNumber = "Test",
                                        ZipCode = "Test"
                                    }
                                ]
                            }
                        }
                    }
                },
                {
                    typeof(GetLastCheckpointInternalResponseModel),
                    new SoapEnvelopeDataModel<GetLastCheckpointInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetLastCheckpointInternalResponseModel>()
                        {
                            Model = new GetLastCheckpointInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                LastCheckPoint = new CheckpointInternalResponseModel()
                                {
                                    VoucherId = primaryVoucherId,
                                    BranchDepot = "Test",
                                    BranchId = "Test",
                                    CheckpointDate = DateTime.Now.AddDays(-2),
                                    RecipientName = "Test",
                                    StatusCode = "Test",
                                    StatusDescription = "Test"
                                }
                            }
                        }
                    }
                },
                {
                    typeof(GetLastPickupCheckpointInternalResponseModel),
                    new SoapEnvelopeDataModel<GetLastPickupCheckpointInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetLastPickupCheckpointInternalResponseModel>()
                        {
                            Model = new GetLastPickupCheckpointInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                LastCheckpoint = new PickupCheckpointInternalResponseModel()
                                {
                                    PickupId = TestHelpers.GenerateTestPickupId(),
                                    BranchDepot = "Test",
                                    CheckpointDate = DateTime.Now.AddDays(-2),
                                    StatusCode = "Test"
                                }
                            }
                        }
                    }
                },
                {
                    typeof(GetTraceByClientReferencesInternalResponseModel),
                    new SoapEnvelopeDataModel<GetTraceByClientReferencesInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetTraceByClientReferencesInternalResponseModel>()
                        {
                            Model = new GetTraceByClientReferencesInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                Checkpoints =
                                [
                                    new CheckpointInternalResponseModel()
                                    {
                                        BranchId = "Test",
                                        BranchDepot = "Test",
                                        CheckpointDate = DateTime.Now.AddDays(-2),
                                        RecipientName = "Test",
                                        VoucherId = primaryVoucherId,
                                        StatusCode = "Test",
                                        StatusDescription = "Test"
                                    }
                                ]
                            }
                        }
                    }
                },
                {
                    typeof(GetTraceByTimeFrameInternalResponseModel),
                    new SoapEnvelopeDataModel<GetTraceByTimeFrameInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetTraceByTimeFrameInternalResponseModel>()
                        {
                            Model = new GetTraceByTimeFrameInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                Checkpoints =
                                [
                                    new CheckpointInternalResponseModel()
                                    {
                                        BranchId = "Test",
                                        BranchDepot = "Test",
                                        CheckpointDate = DateTime.Now.AddDays(-2),
                                        RecipientName = "Test",
                                        VoucherId = primaryVoucherId,
                                        StatusCode = "Test",
                                        StatusDescription = "Test"
                                    }
                                ]
                            }
                        }
                    }
                },
                {
                    typeof(GetTraceByVoucherIdInternalResponseModel),
                    new SoapEnvelopeDataModel<GetTraceByVoucherIdInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetTraceByVoucherIdInternalResponseModel>()
                        {
                            Model = new GetTraceByVoucherIdInternalResponseModel()
                            {
                                ReturnCode = 1,
                                ReturnMessage = string.Empty,
                                Checkpoints =
                                [
                                    new CheckpointInternalResponseModel()
                                    {
                                        BranchId = "Test",
                                        BranchDepot = "Test",
                                        CheckpointDate = DateTime.Now.AddDays(-2),
                                        RecipientName = "Test",
                                        VoucherId = primaryVoucherId,
                                        StatusCode = "Test",
                                        StatusDescription = "Test"
                                    }
                                ]
                            }
                        }
                    }
                },
                {
                    typeof(CancelPickupInternalResponseModel),
                    new SoapEnvelopeDataModel<CancelPickupInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<CancelPickupInternalResponseModel>()
                        {
                            Model = new CancelPickupInternalResponseModel()
                            {
                                Result = new MessageInternalResponseModel<bool>
                                {
                                    Code = 1,
                                    Message = string.Empty,
                                    Result = true
                                }
                            }
                        }
                    }
                },
                {
                    typeof(CreatePickupInternalResponseModel),
                    new SoapEnvelopeDataModel<CreatePickupInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<CreatePickupInternalResponseModel>()
                        {
                            Model = new CreatePickupInternalResponseModel()
                            {
                                Result = new MessageInternalResponseModel<string>()
                                {
                                    Code = 1,
                                    Message = string.Empty,
                                    Result = TestHelpers.GenerateTestPickupId()
                                }
                            }
                        }
                    }
                },
                {
                    typeof(GetConsignmentsByDateInternalResponseModel),
                    new SoapEnvelopeDataModel<GetConsignmentsByDateInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetConsignmentsByDateInternalResponseModel>()
                        {
                            Model = new GetConsignmentsByDateInternalResponseModel()
                            {
                                Result = new GetConsignmentsByDateResult()
                                {
                                    Code= 1,
                                    Message = string.Empty,
                                    Results =
                                    [
                                        new ConsignmentDetailsInternalResponseModel()
                                        {
                                            Address = "Test",
                                            AgreementCode = AgreementCode,
                                            CashAmount = 5,
                                            ChargeType = "Recipient",
                                            CheckpointCode = "Test",
                                            CheckpointGroupCode = "Test",
                                            City = "Test",
                                            ConsignmentId = primaryVoucherId,
                                            CountryCode = "GR",
                                            CustomerCode = CustomerCode,
                                            MasterConsignmentId = primaryVoucherId,
                                            ParcelCount = 1,
                                            PickupAddress = "Test",
                                            PickupCity = "Test",
                                            PickupName = "Test",
                                            PickupCountryCode = "GR",
                                            PickupPhoneNumber = "Test",
                                            RecipientName = "Test",
                                            PickupPostCode = "26441",
                                            RecipientPhoneNumber = "Test",
                                            Weight = 2
                                        }
                                    ]
                                }
                            }
                        }
                    }
                },
                {
                    typeof(GetDepositedConsignmentsByDateInternalResponseModel),
                    new SoapEnvelopeDataModel<GetDepositedConsignmentsByDateInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetDepositedConsignmentsByDateInternalResponseModel>()
                        {
                            Model = new GetDepositedConsignmentsByDateInternalResponseModel()
                            {
                                Result = new GetDepositedConsignmentsByDateResult()
                                {
                                    Code = 1,
                                    Message = string.Empty,
                                    Results =
                                    [
                                        new DepositedConsignmentInternalResponseModel()
                                        {
                                            Amount = 6,
                                            DateDeposited = DateTime.Now.AddDays(-4).ToString(CultureInfo.InvariantCulture),
                                            Id = TestHelpers.GenerateTestPickupId()
                                        }
                                    ]
                                }
                            }
                        }
                    }
                },
                {
                    typeof(GetPickupInternalResponseModel),
                    new SoapEnvelopeDataModel<GetPickupInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<GetPickupInternalResponseModel>()
                        {
                            Model = new GetPickupInternalResponseModel()
                            {
                                Result = new MessageInternalResponseModel<PickupInternalResponseModel>()
                                {
                                    Code = 1,
                                    Message = string.Empty,
                                    Result = new PickupInternalResponseModel()
                                    {
                                        Address = "Test",
                                        Id = TestHelpers.GenerateTestPickupId(),
                                        CheckpointCode = "Test",
                                        CheckpointGroupCode = "Test",
                                        City = "Test",
                                        CountryCode = "GR",
                                        ConsignmentIds = [ primaryVoucherId, secondaryVoucherId ],
                                        Name = "Test",
                                        PhoneNumber = "Test",
                                        PickupDate = DateTime.Now.AddDays(-4).ToString(CultureInfo.InvariantCulture),
                                        PostCode = "Test"
                                    }
                                }
                            }
                        }
                    }
                },
                {
                    typeof(ReschedulePickupInternalResponseModel),
                    new SoapEnvelopeDataModel<ReschedulePickupInternalResponseModel>()
                    {
                        Body = new SoapEnvelopeBodyDataModel<ReschedulePickupInternalResponseModel>()
                        {
                            Model = new ReschedulePickupInternalResponseModel()
                            {
                                Result = new MessageInternalResponseModel<bool>()
                                {
                                    Code = 1,
                                    Message = string.Empty,
                                    Result = true
                                }
                            }
                        }
                    }
                }

            }.ToFrozenDictionary();
        });

        #endregion

        #region Public Properties

        /// <summary>
        /// The response objects used for testing
        /// </summary>
        public static IReadOnlyDictionary<Type, object> ResponseObjects => _instance.Value;

        /// <summary>
        /// The test credentials
        /// </summary>
        public static readonly SpeedexCredentials SpeedexCredentials = new("demoapi", "GOOD-GO-HOME-GUYS", AgreementCode, CustomerCode);

        /// <summary>
        /// The agreement code
        /// </summary>
        public const string AgreementCode = "002";

        /// <summary>
        /// The customer code
        /// </summary>
        public const string CustomerCode = "DEMO";

        /// <summary>
        /// The consignment used for testing
        /// </summary>
        public static readonly ConsignmentRequestModel TestConsignment = new(0, 2, ChargeType.Recipient, PaymentType.Cash, 2, "Test", "Test", "1234567890", "12345", 4);

        #endregion
    }
}
