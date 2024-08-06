using System;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.NanoFrameworkGen
{
    internal class QuantityGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;
        private readonly string _unitEnumName;

        public QuantityGenerator(Quantity quantity)
        {
            _quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
            _unitEnumName = $"{quantity.Name}Unit";
        }

        public string Generate()
        {
            // Auto generated header
            Writer.WL(GeneratedFileHeader);
            // Usings, properties
            Writer.WL($@"using System;
using UnitsNet.Units;

namespace UnitsNet
{{");
            Writer.WL($@"
    /// <inheritdoc />
    /// <summary>
    ///     {_quantity.XmlDocSummary}
    /// </summary>");

            Writer.WLCondition(_quantity.XmlDocRemarks.HasText(), $@"
    /// <remarks>
    ///     {_quantity.XmlDocRemarks}
    /// </remarks>");
            Writer.WLIfText(1, GetObsoleteAttributeOrNull(_quantity));

            Writer.WL($@"
    public struct  {_quantity.Name}
    {{
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly {_quantity.ValueType} _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly {_unitEnumName} _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public {_quantity.ValueType} Value => _value;

        /// <inheritdoc />
        public {_unitEnumName} Unit => _unit;
");

            // Constructor and static properties
            Writer.WL($@"        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name=""value"">The numeric value to construct this quantity with.</param>
        /// <param name=""unit"">The unit representation to construct this quantity with.</param>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>
        public {_quantity.Name}({_quantity.ValueType} value, {_unitEnumName} unit)
        {{
            _value = value;
            _unit = unit;
        }}

        /// <summary>
        ///     The base unit of {_quantity.Name}, which is Second. All conversions go via this value.
        /// </summary>
        public static {_unitEnumName} BaseUnit {{ get; }} = {_unitEnumName}.{_quantity.BaseUnit};

        /// <summary>
        /// Represents the largest possible value of {_quantity.Name}.
        /// </summary>");

            // Non decimal
            Writer.WLCondition(_quantity.ValueType != "decimal", $@"
        public static {_quantity.Name} MaxValue {{ get; }} = new {_quantity.Name}({_quantity.ValueType}.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of {_quantity.Name}.
        /// </summary>
        public static {_quantity.Name} MinValue {{ get; }} = new {_quantity.Name}({_quantity.ValueType}.MinValue, BaseUnit);
");

            // Decimal MaxValue = 79228162514264337593543950335M
            Writer.WLCondition(_quantity.ValueType == "decimal", $@"
        public static {_quantity.Name} MaxValue {{ get; }} = new {_quantity.Name}(79228162514264337593543950335M, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of {_quantity.Name}.
        /// </summary>
        public static {_quantity.Name} MinValue {{ get; }} = new {_quantity.Name}(-79228162514264337593543950335M, BaseUnit);
");

            Writer.WL($@"
        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static {_quantity.Name} Zero {{ get; }} = new {_quantity.Name}(0, BaseUnit);");

            GenerateConversionProperties();
            GenerateStaticFactoryMethods();
            GenerateConversionMethods();

            Writer.WL(@"
    }
}
");

            return Writer.ToString();
        }

        private void GenerateConversionProperties()
        {
            Writer.WL(@"
        #region Conversion Properties
");
            foreach (Unit unit in _quantity.Units)
            {
                if (unit.SkipConversionGeneration) continue;

                Writer.WL($@"
        /// <summary>
        ///     Gets a <see cref=""double""/> value of this quantity converted into <see cref=""{_unitEnumName}.{unit.SingularName}""/>
        /// </summary>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public {_quantity.ValueType} {unit.PluralName} => As({_unitEnumName}.{unit.SingularName});
");
            }

            Writer.WL(@"

        #endregion
");
        }

        private void GenerateStaticFactoryMethods()
        {
            Writer.WL(@"
        #region Static Factory Methods
");
            foreach (Unit unit in _quantity.Units)
            {
                if (unit.SkipConversionGeneration) continue;

                var valueParamName = unit.PluralName.ToLowerInvariant();
                Writer.WL($@"
        /// <summary>
        ///     Creates a <see cref=""{_quantity.Name}""/> from <see cref=""{_unitEnumName}.{unit.SingularName}""/>.
        /// </summary>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public static {_quantity.Name} From{unit.PluralName}({_quantity.ValueType} {valueParamName}) => new {_quantity.Name}({valueParamName}, {_unitEnumName}.{unit.SingularName});
");
            }

            Writer.WL($@"
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref=""{_unitEnumName}"" /> to <see cref=""{_quantity.Name}"" />.
        /// </summary>
        /// <param name=""value"">Value to convert from.</param>
        /// <param name=""fromUnit"">Unit to convert from.</param>
        /// <returns>{_quantity.Name} unit value.</returns>
        public static {_quantity.Name} From({_quantity.ValueType} value, {_unitEnumName} fromUnit)
        {{
            return new {_quantity.Name}(value, fromUnit);
        }}

        #endregion
");
        }

        private void GenerateConversionMethods()
        {
            Writer.WL($@"
                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name=""unit"" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public {_quantity.ValueType} As({_unitEnumName} unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this {_quantity.Name} to another {_quantity.Name} with the unit representation <paramref name=""unit"" />.
                /// </summary>
                /// <returns>A {_quantity.Name} with the specified unit.</returns>
                public {_quantity.Name} ToUnit({_unitEnumName} unit)
                {{
                    var convertedValue = GetValueAs(unit);
                    return new {_quantity.Name}(convertedValue, unit);
                }}

                /// <summary>
                ///     Converts the current value + unit to the base unit.
                ///     This is typically the first step in converting from one unit to another.
                /// </summary>
                /// <returns>The value in the base unit representation.</returns>
                private {_quantity.ValueType} GetValueInBaseUnit()
                {{
                    return Unit switch
                    {{");
            foreach (Unit unit in _quantity.Units)
            {
                var func = unit.FromUnitToBaseFunc.Replace("{x}", "_value");
                Writer.WL($@"
                        {_unitEnumName}.{unit.SingularName} => {func},");
            }

            Writer.WL($@"
                        _ => throw new NotImplementedException($""Can not convert {{Unit}} to base units."")
                    }};
                    }}

                private {_quantity.ValueType} GetValueAs({_unitEnumName} unit)
                {{
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {{");
            foreach (Unit unit in _quantity.Units)
            {
                var func = unit.FromBaseToUnitFunc.Replace("{x}", "baseUnitValue");
                Writer.WL($@"
                        {_unitEnumName}.{unit.SingularName} => {func},");
            }

            Writer.WL(@"
                        _ => throw new NotImplementedException($""Can not convert {Unit} to {unit}."")
                    };
                    }

                #endregion");
        }

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        private static string? GetObsoleteAttributeOrNull(Quantity quantity) => GetObsoleteAttributeOrNull(quantity.ObsoleteText);

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        private static string? GetObsoleteAttributeOrNull(Unit unit) => GetObsoleteAttributeOrNull(unit.ObsoleteText);

        /// <summary>
        /// Returns the Obsolete attribute if ObsoleteText has been defined on the JSON input - otherwise returns empty string
        /// It is up to the consumer to wrap any padding/new lines in order to keep to correct indentation formats
        /// </summary>
        private static string? GetObsoleteAttributeOrNull(string? obsoleteText) => string.IsNullOrWhiteSpace(obsoleteText)
            ? null
            : $"[Obsolete(\"{obsoleteText}\")]";

    }
}
