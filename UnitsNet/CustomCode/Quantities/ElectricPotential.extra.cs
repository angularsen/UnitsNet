// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct ElectricPotential<T>
    {
        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio{T}" /> in decibels (dB) relative to 1 volt RMS from this <see cref="ElectricPotential{T}" />.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a voltage to an amplitude ratio (relative to 1 volt RMS).
        ///     <example>
        ///         <c>var voltageRatio = voltage.ToAmplitudeRatio();</c>
        ///     </example>
        /// </remarks>
        public AmplitudeRatio<T> ToAmplitudeRatio()
        {
            return AmplitudeRatio<T>.FromElectricPotential(this);
        }
    }
}
