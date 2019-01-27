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
    public class QuantityTest
    {
        [Theory]
        [InlineData(QuantityType.Length, typeof(LengthUnit))]
        [InlineData(QuantityType.Mass, typeof(MassUnit))]
        [InlineData(QuantityType.Force, typeof(ForceUnit))]
        public void GetUnitType_ReturnsUnitTypeMatchingGivenQuantity(QuantityType quantityType, Type expectedUnitEnumType)
        {
            Assert.Equal(expectedUnitEnumType, Quantity.GetUnitType(quantityType));
        }

        [Fact]
        public void GetUnitEnumValuesForQuantity_ReturnsKnownValues()
        {
            var knownLengthUnits = new Enum[] {LengthUnit.Meter, LengthUnit.Centimeter, LengthUnit.Kilometer};
            var knownMassUnits = new Enum[] {MassUnit.Kilogram, MassUnit.Gram, MassUnit.Tonne};

            var lengthUnits = Quantity.GetUnitEnumValuesForQuantity(QuantityType.Length);
            var massUnits = Quantity.GetUnitEnumValuesForQuantity(QuantityType.Mass);

            Assert.Superset(knownLengthUnits.ToHashSet(), lengthUnits.ToHashSet());
            Assert.Superset(knownMassUnits.ToHashSet(), massUnits.ToHashSet());
        }

        [Fact]
        public void GetUnitNamesForQuantity_ReturnsKnownUnitNames()
        {
            var knownLengthUnitNames = new[] {"Meter", "Centimeter", "Kilometer"};
            var knownMassUnitNames = new[] {"Kilogram", "Gram", "Tonne"};

            var lengthUnitNames = Quantity.GetUnitNamesForQuantity(QuantityType.Length);
            var massUnitNames = Quantity.GetUnitNamesForQuantity(QuantityType.Mass);

            Assert.Superset(knownLengthUnitNames.ToHashSet(), lengthUnitNames.ToHashSet());
            Assert.Superset(knownMassUnitNames.ToHashSet(), massUnitNames.ToHashSet());
        }

        [Fact]
        public void QuantityNames_ReturnsKnownNames()
        {
            var knownNames = new[] {"Length", "Force", "Mass"};

            var names = Quantity.Names;

            Assert.Superset(knownNames.ToHashSet(), names.ToHashSet());
        }

        [Fact]
        public void Types_ReturnsKnownQuantityTypes()
        {
            var knownQuantities = new[] {QuantityType.Length, QuantityType.Force, QuantityType.Mass};

            var types = Quantity.Types;

            Assert.Superset(knownQuantities.ToHashSet(), types.ToHashSet());
        }
    }
}
