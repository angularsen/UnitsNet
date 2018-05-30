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

using Xunit;
using UnitsNet.Extensions.NumberToAngle;
using UnitsNet.Extensions.NumberToForce;
using UnitsNet.Extensions.NumberToLength;
using UnitsNet.Extensions.NumberToMass;

namespace UnitsNet.Tests
{
    public class NumberExtensionsTest
    {
        [Fact]
        public void SomeArbitraryExtensionMethods_CreatesCorrectValue()
        {
            Assert.Equal(Length.FromMeters(1), 1.Meters());
            Assert.Equal(Mass.FromTonnes(2), 2.Tonnes());
            Assert.Equal(Force.FromKiloPonds(3), 3.KiloPonds());
            Assert.Equal(Angle.FromRadians(3), 3.Radians());
        }
    }
}
