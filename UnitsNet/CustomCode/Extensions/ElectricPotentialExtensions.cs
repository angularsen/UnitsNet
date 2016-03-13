namespace UnitsNet.CustomCode.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="ElectricPotential" />.
    /// </summary>
    public static class ElectricPotentialExtensions
    {
        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio" /> in decibels (dB) relative to 1 volt RMS from an
        ///     <see cref="ElectricPotential" />.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a voltage to an amplitude ratio (relative to 1 volt RMS).
        ///     <example>
        ///         <c>var voltageRatio = voltage.ToAmplitudeRatio();</c>
        ///     </example>
        /// </remarks>
        public static AmplitudeRatio ToAmplitudeRatio(this ElectricPotential voltage)
        {
            return AmplitudeRatio.FromElectricPotential(voltage);
        }
    }
}