namespace UnitsNet.CustomCode.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="PowerRatio" />.
    /// </summary>
    public static class PowerRatioExtensions
    {
        /// <summary>
        ///     Gets a <see cref="Power" /> from a <see cref="PowerRatio" />.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power ratio back to a power.
        ///     <example>
        ///         <c>var power = powerRatio.ToPower();</c>
        ///     </example>
        /// </remarks>
        public static Power ToPower(this PowerRatio powerRatio)
        {
            return PowerRatio.ToPower(powerRatio);
        }

        /// <summary>
        ///     Gets a <see cref="AmplitudeRatio" /> from a <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="powerRatio">The power ratio.</param>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        public static AmplitudeRatio ToAmplitudeRatio(this PowerRatio powerRatio, ElectricResistance impedance)
        {
            return PowerRatio.ToAmplitudeRatio(powerRatio, impedance);
        }
    }
}