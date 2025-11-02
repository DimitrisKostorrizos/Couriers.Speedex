namespace Couriers.Speedex.Enums
{
    /// <summary>
    /// Provides enumeration for the available charge types of the consignment
    /// </summary>
    public enum ChargeType
    {
        /// <summary>
        /// Charge the sender of the consignment
        /// </summary>
        Sender,
        /// <summary>
        /// Charge the recipient of the consignment
        /// </summary>
        Receiver,
        /// <summary>
        /// Charge the third party
        /// </summary>
        ThirdParty
    }
}
