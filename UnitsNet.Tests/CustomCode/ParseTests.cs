// Copyright(c) 2007 Andreas Gullberg Larsen
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

using System.Globalization;
using NUnit.Framework;
using UnitsNet.Units;

namespace UnitsNet.Tests.CustomCode
{
    /// <remarks>
    ///     These test methods would ideally be generated for each unit class,
    ///     but that was not trivial to do. At the time of writing this,
    ///     all unit classes are generated using the same scripts, so it is
    ///     reasonable to assume that testing one unit class would cover
    ///     all of them. Obviously, that can change in the future.
    /// </remarks>
    [TestFixture]
    public class ParseTests
    {
        [TestCase("1km", Result = 1000)]
        [TestCase("1 km", Result = 1000)]
        [TestCase("1e-3 km", Result = 1)]
        [TestCase("5.5 m", Result = 5.5)]
        [TestCase("500,005 m", Result = 500005)]
        [TestCase(null, ExpectedExceptionName = "System.ArgumentNullException")]
        [TestCase("1", ExpectedExceptionName = "System.ArgumentException")]
        [TestCase("km", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        [TestCase("1 kg", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        public double ParseLengthToMetersUsEnglish(string s)
        {
            CultureInfo usEnglish = CultureInfo.GetCultureInfo("en-US");

            return Length.Parse(s, usEnglish).Meters;
        }

        [TestCase("1 ft 1 in", Result = 13)]
        [TestCase("1ft 1in", Result = 13)]
        [TestCase("1' 1\"", Result = 13)]
        [TestCase("1'1\"", Result = 13)]
        [TestCase("1ft1in", Result = 13)]
        [TestCase("1ft and 1in", Result = 13)]
        [TestCase("1ft monkey 1in", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        [TestCase("1ft 1invalid", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        public double ParseImperialLengthInchesUsEnglish(string s)
        {
            CultureInfo usEnglish = CultureInfo.GetCultureInfo("en-US");

            return Length.Parse(s, usEnglish).Inches;
        }

        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [TestCase("5.5 m", Result = 5.5)]
        [TestCase("500 005 m", Result = 500005)]
        [TestCase("500.005.050,001 m", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        // quantity doesn't match number format
        public double ParseWithCultureUsingSpaceAsThousandSeparators(string s)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = " ";
            numberFormat.NumberDecimalSeparator = ".";

            return Length.Parse(s, numberFormat).Meters;
        }

        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [TestCase("5,5 m", Result = 5.5)]
        [TestCase("500.005.050,001 m", Result = 500005050.001)]
        [TestCase("5.555 m", Result = 5555)] // dot is group separator not decimal
        [TestCase("500 005 m", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        // quantity doesn't match number format
        public double ParseWithCultureUsingDotAsThousandSeparators(string s)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = ".";
            numberFormat.NumberDecimalSeparator = ",";

            return Length.Parse(s, numberFormat).Meters;
        }

        [TestCase("m", Result = LengthUnit.Meter)]
        [TestCase("kg", ExpectedExceptionName = "UnitsNet.UnitsNetException")]
        [TestCase(null, ExpectedExceptionName = "System.ArgumentNullException")]
        public LengthUnit ParseLengthUnitUsEnglish(string s)
        {
            CultureInfo usEnglish = CultureInfo.GetCultureInfo("en-US");

            return Length.ParseUnit(s, usEnglish);
        }
    }
}