// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ElectricConductancePerArea
    {
        /// <summary>Get <see cref="ElectricConductancePerArea"/> from <see cref="ElectricConductance"/> divided by <see cref="Area"/>.</summary>
        public static ElectricConductancePerArea FromElectricConductanceByArea(ElectricConductance ec, Area area)
        {
            if(area.SquareMeters == 0.0)
                return new ElectricConductancePerArea(0.0, ElectricConductancePerAreaUnit.SiemensPerSquareMeter);
            
            double ecpa = ec.Siemens / area.SquareMeters;
            return new ElectricConductancePerArea(ecpa, ElectricConductancePerAreaUnit.SiemensPerSquareMeter);
        }

        /// <summary>Get <see cref="ElectricConductance"/> from <see cref="ElectricConductancePerArea"/> times <see cref="Area"/>.</summary>
        public static ElectricConductance operator *(ElectricConductancePerArea ecpa, Area area)
        {
            return ElectricConductance.FromSiemens(ecpa.SiemensPerSquareMeter * area.SquareMeters);
        }
    }
}