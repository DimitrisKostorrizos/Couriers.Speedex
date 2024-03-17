namespace Couriers.Speedex
{
    /// <summary>
    /// The constants used across the <see cref="SpeedexClient"/>
    /// </summary>
    public static class SpeedexConstants
    {
        /// <summary>
        /// The maximum number of vouchers for a consignment
        /// </summary>
        public const int MaximumNumberOfVouchers = 20;

        /// <summary>
        /// The maximum length for the comments
        /// </summary>
        public const int MaximumCommentLength = 40;

        /// <summary>
        /// The maximum length for the customer reference
        /// </summary>
        public const int MaximumCustomerReferenceLength = 50;

        /// <summary>
        /// The maximum length for the address
        /// </summary>
        public const int MaximumAddressLength = 50;

        /// <summary>
        /// The maximum length for the recipient name
        /// </summary>
        public const int MaximumRecipientNameLength = 50;

        /// <summary>
        /// The maximum length for the recipient phone number
        /// </summary>
        public const int MaximumPhoneNumberLength = 30;

        /// <summary>
        /// The maximum length for the zip code
        /// </summary>
        public const int MaximumZipCodeLength = 5;

        /// <summary>
        /// The maximum length for the agreement code
        /// </summary>
        public const int MaximumAgreementCodeLength = 6;

        /// <summary>
        /// The maximum length for the customer code
        /// </summary>
        public const int MaximumCustomerCodeLength = 8;

        /// <summary>
        /// The maximum number of consignment numbers for a pickup
        /// </summary>
        public const int MaximumNumberOfConsignmentsForPickup = 5;

        /// <summary>
        /// The maximum number of consignments
        /// </summary>
        public const int MaximumNumberOfConsignments = 10;

        /// <summary>
        /// The minimum weight in kilos for a voucher
        /// </summary>
        public const double MinimumWeightPerVoucher = 0.5;
    }
}
