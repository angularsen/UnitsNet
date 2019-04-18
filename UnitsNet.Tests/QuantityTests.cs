// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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


        public enum MyQuantityUnit
        {
            MyUnit1,
            MyUnit2,
        }

        private struct MyQuantity : IQuantity<MyQuantityUnit>
        {
            public MyQuantity(double value, MyQuantityUnit unit) : this()
            {
                Unit = unit;
                Value = value;
            }

            public string ToString(string format, IFormatProvider formatProvider)
            {
                throw new NotImplementedException();
            }

            public QuantityType Type { get; }
            public BaseDimensions Dimensions { get; }
            public QuantityInfo<MyQuantityUnit> QuantityInfo { get; }

            QuantityInfo IQuantity.QuantityInfo => QuantityInfo;

            public double As(Enum unit)
            {
                throw new NotImplementedException();
            }

            public double As(UnitSystem unitSystem)
            {
                throw new NotImplementedException();
            }

            public MyQuantityUnit Unit { get; }

            public double As(MyQuantityUnit unit)
            {
                throw new NotImplementedException();
            }

            Enum IQuantity.Unit => Unit;

            public double Value { get; }
            public IQuantity ToUnit(Enum unit)
            {
                throw new NotImplementedException();
            }

            public IQuantity<MyQuantityUnit> ToUnit(UnitSystem unitSystem)
            {
                throw new NotImplementedException();
            }

            public IQuantity<MyQuantityUnit> ToUnit(MyQuantityUnit unit)
            {
                throw new NotImplementedException();
            }

            IQuantity IQuantity.ToUnit(UnitSystem unitSystem)
            {
                return ToUnit(unitSystem);
            }

            public string ToString(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public string ToString(IFormatProvider provider, int significantDigitsAfterRadix)
            {
                throw new NotImplementedException();
            }

            public string ToString(IFormatProvider provider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
        }
        [Fact]
        public void Parse_CustomMappedQuantity()
        {
            UnitAbbreviationsCache.Default.MapUnitToAbbreviation(MyQuantityUnit.MyUnit1, "myUnitAbbreviation1");
            bool success = QuantityParser.Default.TryParse<MyQuantity, MyQuantityUnit>("1 myUnitAbbreviation1",
                null,
                (value, unit) => new MyQuantity((double)value, unit),
                out MyQuantity q);
            Assert.Equal(MyQuantityUnit.MyUnit1, q.Unit);
            Assert.Equal(1, q.Value);
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
