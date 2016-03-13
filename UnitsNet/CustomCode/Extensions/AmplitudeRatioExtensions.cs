namespace UnitsNet.CustomCode.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="AmplitudeRatio" />.
    /// </summary>
    public static class AmplitudeRatioExtensions
    {
        /// <summary>
        ///     Gets an <see cref="ElectricPotential" /> from <see cref="AmplitudeRatio" />.
        /// </summary>
        /// <paramref name="amplitudeRatio">The amplitude ratio to convert.</paramref>
        /// <remarks>
        ///     Provides a nicer syntax for converting an amplitude ratio back to a voltage.
        ///     <example>
        ///         <c>var voltage = voltageRatio.ToElectricPotential();</c>
        ///     </example>
        /// </remarks>
        public static ElectricPotential ToElectricPotential(this AmplitudeRatio amplitudeRatio)
        {
            return AmplitudeRatio.ToElectricPotential(amplitudeRatio);
        }

        /// <summary>
        ///     Converts a <see cref="AmplitudeRatio" /> to a <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="amplitudeRatio">The amplitude ratio to convert.</param>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <remarks>http://www.maximintegrated.com/en/app-notes/index.mvp/id/808</remarks>
        public static PowerRatio ToPowerRatio(this AmplitudeRatio amplitudeRatio, ElectricResistance impedance)
        {
            return AmplitudeRatio.ToPowerRatio(amplitudeRatio, impedance);
        }
    }
}