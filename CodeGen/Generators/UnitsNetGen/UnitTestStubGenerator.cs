// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitTestStubGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;

        public UnitTestStubGenerator(Quantity quantity)
        {
            _quantity = quantity;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;

namespace UnitsNet.Tests.CustomCode
{{
    public class {_quantity.Name}Tests : {_quantity.Name}TestsBase
    {{
        // Override properties in base class here
    }}
}}");
            return Writer.ToString();
        }
    }
}
