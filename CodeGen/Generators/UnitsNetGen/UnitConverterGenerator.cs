﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitConverterGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public UnitConverterGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using UnitsNet.Units;

// ReSharper disable RedundantCommaInArrayInitializer
// ReSharper disable once CheckNamespace

namespace UnitsNet
{{
    public sealed partial class UnitConverter<T>
    {{
        /// <summary>
        /// Registers the default conversion functions in the given <see cref=""UnitConverter{{T}}""/> instance.
        /// </summary>
        /// <param name=""unitConverter"">The <see cref=""UnitConverter{{T}}""/> to register the default conversion functions in.</param>
        public static void RegisterDefaultConversions(UnitConverter<T> unitConverter)
        {{" );
            foreach (Quantity quantity in _quantities)
            foreach (Unit unit in quantity.Units)
            {
                Writer.WL(quantity.BaseUnit == unit.SingularName
                    ? $@"
            unitConverter.SetConversionFunction<{quantity.Name}<T>>({quantity.Name}<T>.BaseUnit, {quantity.Name}<T>.BaseUnit, q => q);"
                    : $@"
            unitConverter.SetConversionFunction<{quantity.Name}<T>>({quantity.Name}<T>.BaseUnit, {quantity.Name}Unit.{unit.SingularName}, q => q.ToUnit({quantity.Name}Unit.{unit.SingularName}));
            unitConverter.SetConversionFunction<{quantity.Name}<T>>({quantity.Name}Unit.{unit.SingularName}, {quantity.Name}<T>.BaseUnit, q => q.ToBaseUnit());");
            }

            Writer.WL($@"
        }}
    }}
}}");

            return Writer.ToString();
        }
    }
}
