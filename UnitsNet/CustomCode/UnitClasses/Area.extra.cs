using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;


namespace UnitsNet
{
    public partial struct Area
    {
        public static Length operator/(Area area, Length length)
        {
            return Length.FromMeters(area.SquareMeters / length.Meters);
        }

    }
}
