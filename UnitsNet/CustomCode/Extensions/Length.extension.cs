using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitsNet;

namespace UnitsNet.Extension
{
    public static class Length
    {
        // Metric Units

        public static UnitsNet.Length Meters(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength);
        }

        public static UnitsNet.Length Kilometers(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength * 1000);
        }

        public static UnitsNet.Length Centimeters(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength / 100);
        }

        public static UnitsNet.Length Millimeters(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength / 1000);
        }

        // Imperal Units

        public static UnitsNet.Length Yards(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength * 0.3048);
        }

        public static UnitsNet.Length Feet(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength * 0.0254);
        }

        public static UnitsNet.Length Mile(this int _inputLength)
        {
            return new UnitsNet.Length(_inputLength * 1609.344);
        }
    }
}
