// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [Test]
        public void ParseWithUsEnglishCulture()
        {
            var usEnglish = CultureInfo.GetCultureInfo("en-US");
            Assert.AreEqual(5.5, Length.Parse("5.5 m", usEnglish).Meters);
            Assert.AreEqual(500005, Length.Parse("500,005 m", usEnglish).Meters);
        }

        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [Test]
        public void ParseWithCultureUsingSpaceAsThousandSeparators()
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = " ";

            Assert.AreEqual(5.5, Length.Parse("5.5 m", numberFormat).Meters);
            Assert.AreEqual(500005, Length.Parse("500 005 m", numberFormat).Meters);
        }
    }
}