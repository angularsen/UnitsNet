using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Temperature
    {
        // http://i.imgur.com/ucOQh.jpg

        public static UnitsNet.Temperature Kelvin(this double _inputTemperature)
        {
            return new UnitsNet.Temperature(_inputTemperature);
        }

        public static UnitsNet.Temperature Celsius(this double _inputTemperature)
        {
            return new UnitsNet.Temperature(new UnitsNet.Temperature(_inputTemperature).DegreesCelsius);
        }

        public static UnitsNet.Temperature Fahrenheit(this double _inputTemperature)
        {
            return new UnitsNet.Temperature(new UnitsNet.Temperature(_inputTemperature).DegreesFahrenheit);
        }
    }
}
