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
            IQuantity q;");
            foreach (var quantity in _quantities)
            {
                // Pick last one to maybe avoid getting the base unit
                var lastUnit = quantity.Units.Last();

                // Example: LengthUnit.Centimeter
                var unitEnumNameAndValue = $"{quantity.Name}Unit.{lastUnit.SingularName}";
                Writer.WL($@"
            q = Quantity.From(3, {unitEnumNameAndValue});
            Assert.Equal({unitEnumNameAndValue}, q.Unit);
            Assert.Equal(3, q.Value);
");
            }

            Writer.WL($@"
        }}
    }}
}}");

            return Writer.ToString();
        }
    }
}
