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
using System.Linq;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public partial class QuantityTests
    {
        [Fact]
        public void GetHashCodeForDifferentQuantitiesWithSameValuesAreNotEqual()
        {
            var length = new Length( 1.0, (LengthUnit)2 );
            var area = new Area( 1.0, (AreaUnit)2 );

            Assert.NotEqual( length.GetHashCode(), area.GetHashCode() );
        }

        [Fact]
        public void Length_QuantityInfo_ReturnsQuantityInfoAboutLength()
        {
            var length = new Length(1, LengthUnit.Centimeter);

            QuantityInfo<LengthUnit> quantityInfo = length.QuantityInfo;

            AssertQuantityInfoRepresentsLength(quantityInfo);
        }

        [Fact]
        public void Length_Info_ReturnsQuantityInfoAboutLength()
        {
            QuantityInfo<LengthUnit> quantityInfo = Length.Info;

            AssertQuantityInfoRepresentsLength(quantityInfo);
        }

        private static void AssertQuantityInfoRepresentsLength(QuantityInfo<LengthUnit> quantityInfo)
        {
            Assert.Equal(Length.Zero, quantityInfo.Zero);
            Assert.Equal("Length", quantityInfo.Name);

            var lengthUnits = EnumUtils.GetEnumValues<LengthUnit>().Except(new[] {LengthUnit.Undefined}).ToArray();
            Assert.Equal(lengthUnits, quantityInfo.Units);
            Assert.Equal(QuantityType.Length, quantityInfo.QuantityType);

            var lengthUnitNames = lengthUnits.Select(x => x.ToString());
            Assert.Equal(lengthUnitNames, quantityInfo.UnitNames);
        }
    }
}
