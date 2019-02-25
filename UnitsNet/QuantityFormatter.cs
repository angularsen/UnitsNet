// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

using System;

namespace UnitsNet
{
    public class QuantityFormatter
    {
        public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string format, IFormatProvider formatProvider)
            where TUnitType : Enum
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            var digits = 0;
            var formatString = format;

            if(string.IsNullOrEmpty(formatString))
                formatString = "G";

            formatString = formatString.ToUpperInvariant();

            if(formatString.StartsWith("A") || formatString.StartsWith("S"))
            {
                if(formatString.Length > 1 && !int.TryParse(formatString.Substring(1), out digits))
                    throw new FormatException($"The {format} format string is not supported.");

                formatString = formatString.Substring(0, 1);
            }

            switch(formatString)
            {
                case "G":
                    return quantity.ToString(formatProvider, 2);
                case "A":
                    var abbreviations = UnitAbbreviationsCache.Default.GetUnitAbbreviations(quantity.Unit, formatProvider);
                    return abbreviations[digits];
                case "V":
                    return quantity.Value.ToString(formatProvider);
                case "U":
                    return quantity.Unit.ToString();
                case "Q":
                    return quantity.QuantityInfo.Name;
                case "S":
                    return quantity.ToString(formatProvider, digits);
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }
    }
}
