// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct CoefficientOfThermalExpansion
    {
        /// <summary>Get a scalar from a <see cref="CoefficientOfThermalExpansion"/> multiplied by a <see cref="TemperatureDelta"/>.</summary>
        public static double operator *(CoefficientOfThermalExpansion cte, TemperatureDelta temperatureDelta) => cte.PerKelvin * temperatureDelta.Kelvins;
    }
}
