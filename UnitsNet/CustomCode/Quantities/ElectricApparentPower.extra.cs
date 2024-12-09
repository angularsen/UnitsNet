// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct ElectricApparentPower
    {
        /// <summary>Calculate <see cref="ElectricCurrent"/> from <see cref="ElectricApparentPower"/> divided by <see cref="ElectricPotential"/>.</summary>
        /// <remarks>Electric apparent power is defined as S = voltage RMS * current RMS, so current RMS = S / voltage RMS.</remarks>
        public static ElectricCurrent operator /(ElectricApparentPower power, ElectricPotential potential)
        {
            return ElectricCurrent.FromAmperes(power.Voltamperes / potential.Volts);
        }

        /// <summary>Calculate <see cref="ElectricPotential"/> from <see cref="ElectricApparentPower"/> divided by <see cref="ElectricCurrent"/>.</summary>
        /// <remarks>Electric apparent power is defined as S = voltage RMS * current RMS, so voltage RMS = S / current RMS.</remarks>
        public static ElectricPotential operator /(ElectricApparentPower power, ElectricCurrent current)
        {
            return ElectricPotential.FromVolts(power.Voltamperes / current.Amperes);
        }
    }
}
