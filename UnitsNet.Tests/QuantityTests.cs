// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
            var length = new Length(1.0, (LengthUnit)2);
            var area = new Area(1.0, (AreaUnit)2);

            Assert.NotEqual(length.GetHashCode(), area.GetHashCode());
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
            Assert.Equal(QuantityType.Length, quantityInfo.QuantityType);

            var lengthUnits = EnumUtils.GetEnumValues<LengthUnit>().Except(new[] {LengthUnit.Undefined}).ToArray();
            var lengthUnitNames = lengthUnits.Select(x => x.ToString());

            // Obsolete members
#pragma warning disable 618
            Assert.Equal(lengthUnits, quantityInfo.Units);
            Assert.Equal(lengthUnitNames, quantityInfo.UnitNames);
#pragma warning restore 618
        }
    }
}
