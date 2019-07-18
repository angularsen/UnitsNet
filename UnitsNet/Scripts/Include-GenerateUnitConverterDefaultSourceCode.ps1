function GenerateUnitConverterDefaultSourceCode($quantities)
{
@"
// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

// ReSharper disable RedundantCommaInArrayInitializer
// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    public sealed partial class UnitConverter
    {
        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        public static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
"@;
foreach ($quantity in $quantities)
{
    $quantityName = $quantity.Name;
    $unitEnumName = "$quantityName" + "Unit";

    foreach ($unit in $quantity.Units)
    {
        $enumValue = $unit.SingularName;

        if( $quantity.BaseUnit -eq $enumValue )
        {
@"
            unitConverter.SetConversionFunction<$quantityName>($quantityName.BaseUnit, $quantityName.BaseUnit, q => q);
"@;
        }
        else
        {
@"
            unitConverter.SetConversionFunction<$quantityName>($quantityName.BaseUnit, $unitEnumName.$enumValue, q => q.ToUnit($unitEnumName.$enumValue));
            unitConverter.SetConversionFunction<$quantityName>($unitEnumName.$enumValue, $quantityName.BaseUnit, q => q.ToBaseUnit());
"@;
        }
    }
}
@"
        }
    }
}
"@;
}
