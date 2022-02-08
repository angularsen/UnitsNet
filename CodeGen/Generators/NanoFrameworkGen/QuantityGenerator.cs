using System;
using System.Collections.Generic;
using System.Text;
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
        public {_unitEnumName} Unit => _unit;");

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
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static {_unitEnumName} ConversionBaseUnit {{ get; }} = {_unitEnumName}.{_quantity.ConversionBaseUnit};

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>");

            // Non decimal
            Writer.WLCondition(_quantity.ValueType != "decimal", $@"
        public static {_quantity.Name} MaxValue {{ get; }} = new {_quantity.Name}({_quantity.ValueType}.MaxValue, ConversionBaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static {_quantity.Name} MinValue {{ get; }} = new {_quantity.Name}({_quantity.ValueType}.MinValue, ConversionBaseUnit);");

            // Decimal MaxValue = 79228162514264337593543950335M
            Writer.WLCondition(_quantity.ValueType == "decimal", $@"
        public static {_quantity.Name} MaxValue {{ get; }} = new {_quantity.Name}(79228162514264337593543950335M, ConversionBaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static {_quantity.Name} MinValue {{ get; }} = new {_quantity.Name}(-79228162514264337593543950335M, ConversionBaseUnit);");

            Writer.WL($@"
        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static {_quantity.Name} Zero {{ get; }} = new {_quantity.Name}(0, ConversionBaseUnit);");

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
            foreach (var unit in _quantity.Units)
            {
                Writer.WL($@"
        /// <summary>
        ///     Get {_quantity.Name} in {unit.PluralName}.
        /// </summary>");
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
            foreach (var unit in _quantity.Units)
            {
                var valueParamName = unit.PluralName.ToLowerInvariant();
                Writer.WL($@"
        /// <summary>
        ///     Get {_quantity.Name} from {unit.PluralName}.
        /// </summary>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>");
                Writer.WL($@"
        public static {_quantity.Name} From{unit.PluralName}({_quantity.ValueType} {valueParamName}) => new {_quantity.Name}({valueParamName}, {_unitEnumName}.{unit.SingularName});
");
            }

            Writer.WL();
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
        ///     Converts this Duration to another Duration with the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
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
            switch(Unit)
            {{");
            foreach (var unit in _quantity.Units)
            {
                var func = unit.FromUnitToBaseFunc.Replace("{x}", "_value");
                Writer.WL($@"
                case {_unitEnumName}.{unit.SingularName}: return {func};");
            }

            Writer.WL($@"
                default:
                    throw new NotImplementedException($""Can not convert {{Unit}} to base units."");
            }}
        }}

        private {_quantity.ValueType} GetValueAs({_unitEnumName} unit)
        {{
            if(Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch(unit)
            {{");
            foreach (var unit in _quantity.Units)
            {
                var func = unit.FromBaseToUnitFunc.Replace("{x}", "baseUnitValue");
                Writer.WL($@"
                case {_unitEnumName}.{unit.SingularName}: return {func};");
            }

            Writer.WL(@"
                default:
                    throw new NotImplementedException($""Can not convert {Unit} to {unit}."");
            }
        }

        #endregion
");
        }

    }
}
