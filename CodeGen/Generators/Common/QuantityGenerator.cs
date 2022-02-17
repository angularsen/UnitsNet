// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.Common
{
    internal static class QuantityGenerator
    {
        internal static void GenerateConversionProperties(Quantity quantity, MyTextWriter Writer)
        {
            Writer.WL(@"
        #region Conversion Properties
");
            foreach (var unit in quantity.Units)
            {
                if (unit.SkipConversionGeneration)
                    continue;

                Writer.WL($@"
        /// <summary>
        ///     Gets this <see cref=""{quantity.Name}""/> converted into <see cref=""{quantity.Name}Unit.{unit.SingularName}"">{unit.PluralName}</see> as a <see cref=""double""/>.
        /// </summary>
        [Obsolete(""Use the To{unit.PluralName} property."")]");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public double {unit.PluralName} => As({quantity.Name}Unit.{unit.SingularName});
");
            }

            foreach (var unit in quantity.Units)
            {
                if (unit.SkipConversionGeneration)
                    continue;

                Writer.WL($@"
        /// <summary>
        ///     Gets this <see cref=""{quantity.Name}""/> converted into <see cref=""{quantity.Name}Unit.{unit.SingularName}"">{unit.PluralName}</see>.
        /// </summary>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public {quantity.Name} To{unit.PluralName} => ToUnit({quantity.Name}Unit.{unit.SingularName});
");
            }

            Writer.WL(@"

        #endregion
");
        }

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        internal static string? GetObsoleteAttributeOrNull(Quantity quantity) => GetObsoleteAttributeOrNull(quantity.ObsoleteText);

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        internal static string? GetObsoleteAttributeOrNull(Unit unit) => GetObsoleteAttributeOrNull(unit.ObsoleteText);

        /// <summary>
        /// Returns the Obsolete attribute if ObsoleteText has been defined on the JSON input - otherwise returns empty string
        /// It is up to the consumer to wrap any padding/new lines in order to keep to correct indentation formats
        /// </summary>
        private static string? GetObsoleteAttributeOrNull(string obsoleteText) => string.IsNullOrWhiteSpace(obsoleteText)
            ? null
            : $"[Obsolete(\"{obsoleteText}\")]";
    }
}
