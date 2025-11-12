namespace Couriers.Speedex.Enums
{
    /// <summary>
    /// Provides enumeration for the available delivery time limits
    /// </summary>
    public enum DeliveryTimeLimit
    {
        /// <summary>
        /// Applies no limit to the delivery time
        /// </summary>
        NoLimit,
        /// <summary>
        /// Sets the delivery time window to 10:00 - 13:00
        /// </summary>
        TenAMToOnePM,
        /// <summary>
        /// Sets the delivery time window to 13:00 - 16:00
        /// </summary>
        OnePMMToFourPM,
        /// <summary>
        /// Sets the delivery time window to 16:00 - 19:00
        /// </summary>
        FourPMToSevenPM
    }
}
