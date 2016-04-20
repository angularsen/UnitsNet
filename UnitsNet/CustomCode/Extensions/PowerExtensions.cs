namespace UnitsNet.CustomCode.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="Power" />.
    /// </summary>
    public static class PowerExtensions
    {
        /// <summary>
        ///     Gets a <see cref="PowerRatio" /> from a <see cref="Power" /> relative to one watt.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power to a power ratio (relative to 1 watt).
        ///     <example>
        ///         <c>var powerRatio = power.ToPowerRatio();</c>
        ///     </example>
        /// </remarks>
        public static PowerRatio ToPowerRatio(this Power power)
        {
            return PowerRatio.FromPower(power);
        }
    }
}