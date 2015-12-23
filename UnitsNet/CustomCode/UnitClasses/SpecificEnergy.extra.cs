using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct SpecificEnergy
    {
        public static Energy operator*(SpecificEnergy specificEnergy, Mass mass)
        {
            return Energy.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }
        public static Energy operator *(Mass mass, SpecificEnergy specificEnergy)
        {
            return Energy.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }
    }
}
