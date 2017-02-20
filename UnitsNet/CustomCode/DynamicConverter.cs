// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
// https://github.com/anjdreas/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#if !(NETSTANDARD1_0)

using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitsNet
{
    /// <summary>
    /// This class provides runtime conversion of units within the same unit class.
    /// It uses a table of delegates to each unit class's DynamicConvert method, which is only built the first time
    /// a dynamic conversion is invoked. Thus, if dynamic conversions are never used this incurs no overhead, and when
    /// it is, the overhead of reflection occurs only once.
    /// </summary>
    internal class DynamicConverter
    {
        delegate double ConvertDelegate(double value, Enum fromUnit, Enum toUnit);

        /// <summary>
        /// Lookup table indexed by unit class enum type providing the conversion function for the unit class.
        /// </summary>
        static Dictionary<Type, ConvertDelegate> _convertersByUnitClass = new Dictionary<Type, ConvertDelegate>();

        /// <summary>
        /// Create the converter lookup table once, on first use of the Convert method.
        /// </summary>
        static DynamicConverter()
        {
            var unitClassEnumType = typeof(UnitClass);
           
            foreach (var unitClassName in Enum.GetNames(unitClassEnumType))
            {
                var unitClassType = Type.GetType(unitClassEnumType.Namespace + "." + unitClassName);

                if (unitClassType != null)
                {
                    AddConverterForUnitClass(unitClassType);
                }
            }
        }

        /// <summary>
        /// Give a unit class type, reflect it's DynamicConvert method and unit enum type and store it in the 
        /// conversion lookup table as a fast delegate.
        /// </summary>
        static void AddConverterForUnitClass(Type unitClassType)
        {
            var convertMethodInfo = unitClassType.GetMethod("DynamicConvert", BindingFlags.NonPublic | BindingFlags.Static);
            var convertMethod = (ConvertDelegate)Delegate.CreateDelegate(typeof(ConvertDelegate), null, convertMethodInfo);
            var unitEnumType = unitClassType.GetProperty("BaseUnit").PropertyType;

            _convertersByUnitClass.Add(unitEnumType, convertMethod);
        }

        /// <summary>
        /// Convert a value from one unit to another. Both units must be withing the same unit class.
        /// </summary>
        public static double Convert(double fromValue, Enum fromUnit, Enum toUnit)
        {
            var unitType = fromUnit.GetType();

            if (unitType != toUnit.GetType())
            {
                throw new ArgumentException("Cannot convert between unit classes.");
            }

            ConvertDelegate converterFunc;
            if(!_convertersByUnitClass.TryGetValue(unitType, out converterFunc))
            {
                throw new NotImplementedException("No dynamic conversion supported for " + unitType);
            }
            
            return converterFunc(fromValue, fromUnit, toUnit);
        }
    }
}

#endif