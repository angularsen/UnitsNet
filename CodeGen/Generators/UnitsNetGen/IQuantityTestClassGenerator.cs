// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class IQuantityTestClassGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public IQuantityTestClassGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{{
    public partial class IQuantityTests
    {{
        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {{
            void Assertion(int expectedValue, Enum expectedUnit, IQuantity quantity)
            {{
                Assert.Equal(expectedUnit, quantity.Unit);
                Assert.Equal(expectedValue, quantity.Value);
            }}
");
            foreach (var quantity in _quantities)
            {
                // Pick last one to maybe avoid getting the base unit
                var lastUnit = quantity.Units.Last();

                // Example: LengthUnit.Centimeter
                var unitEnumNameAndValue = $"{quantity.Name}Unit.{lastUnit.SingularName}";
                Writer.WL($@"
            Assertion(3, {unitEnumNameAndValue}, Quantity.From(3, {unitEnumNameAndValue}));");
            }
            Writer.WL($@"
        }}

        [Fact]
        public void QuantityInfo_IsSameAsStaticInfoProperty()
        {{
            void Assertion(QuantityInfo expected, IQuantity quantity) => Assert.Same(expected, quantity.QuantityInfo);
");
            foreach (var quantity in _quantities) Writer.WL($@"
            Assertion({quantity.Name}.Info, {quantity.Name}.Zero);");
            Writer.WL($@"
        }}

        [Fact]
        public void Type_EqualsStaticQuantityTypeProperty()
        {{
            void Assertion(QuantityType expected, IQuantity quantity) => Assert.Equal(expected, quantity.Type);
");
            foreach (var quantity in _quantities) Writer.WL($@"
            Assertion({quantity.Name}.QuantityType, {quantity.Name}.Zero);");
            Writer.WL($@"
        }}

        [Fact]
        public void Dimensions_IsSameAsStaticBaseDimensions()
        {{
            void Assertion(BaseDimensions expected, IQuantity quantity) => Assert.Equal(expected, quantity.Dimensions);
");
            foreach (var quantity in _quantities) Writer.WL($@"
            Assertion({quantity.Name}.BaseDimensions, {quantity.Name}.Zero);");
            Writer.WL($@"
        }}
    }}
}}");

            return Writer.ToString();
        }
    }
}
