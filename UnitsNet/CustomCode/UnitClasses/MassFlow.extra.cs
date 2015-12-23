using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct MassFlow
    {

        public static Mass operator *(MassFlow massFlow, TimeSpan time)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }
        public static Mass operator *(TimeSpan time, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }
    }
}
