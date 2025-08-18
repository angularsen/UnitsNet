﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class QuantityGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;

        private readonly bool _isDimensionless;
        private readonly string _unitEnumName;
        private readonly string _valueType;
        private readonly Unit _baseUnit;

        public QuantityGenerator(Quantity quantity)
        {
            _quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));

            _baseUnit = quantity.Units.FirstOrDefault(u => u.SingularName == _quantity.BaseUnit) ??
                        throw new ArgumentException($"No unit found with SingularName equal to BaseUnit [{_quantity.BaseUnit}]. This unit must be defined.",
                            nameof(quantity));

            _valueType = quantity.ValueType;
            _unitEnumName = $"{quantity.Name}Unit";

            BaseDimensions baseDimensions = quantity.BaseDimensions;
            _isDimensionless = baseDimensions is { L: 0, M: 0, T: 0, I: 0, Θ: 0, N: 0, J: 0 };
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

#nullable enable

// ReSharper disable once CheckNamespace

namespace UnitsNet
{");
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
            Writer.WL(@$"
    [DataContract]
    [DebuggerTypeProxy(typeof(QuantityDisplay))]
    public readonly partial struct {_quantity.Name} :
        {(_quantity.GenerateArithmetic ? "IArithmeticQuantity" : "IQuantity")}<{_quantity.Name}, {_unitEnumName}, {_quantity.ValueType}>,");

            if (_quantity.ValueType == "decimal") Writer.WL(@$"
        IDecimalQuantity,");

            Writer.WL(@$"
        IComparable,
        IComparable<{_quantity.Name}>,
        IConvertible,
        IEquatable<{_quantity.Name}>,
        IFormattable");

            Writer.WL($@"
    {{
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        [DataMember(Name = ""Value"", Order = 1)]
        private readonly {_quantity.ValueType} _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        [DataMember(Name = ""Unit"", Order = 2)]
        private readonly {_unitEnumName}? _unit;
");
            GenerateStaticConstructor();
            GenerateInstanceConstructors();
            GenerateStaticProperties();
            GenerateProperties();
            GenerateConversionProperties();
            GenerateStaticMethods();
            GenerateStaticFactoryMethods();
            GenerateStaticParseMethods();
            GenerateArithmeticOperators();
            GenerateEqualityAndComparison();
            GenerateConversionMethods();
            GenerateToString();
            GenerateIConvertibleMethods();

            Writer.WL($@"
    }}
}}");
            return Writer.ToString();
        }

        private void GenerateStaticConstructor()
        {
            BaseDimensions baseDimensions = _quantity.BaseDimensions;
            Writer.WL($@"
        static {_quantity.Name}()
        {{");
            Writer.WL(_isDimensionless ? $@"
            BaseDimensions = BaseDimensions.Dimensionless;" : $@"
            BaseDimensions = new BaseDimensions({baseDimensions.L}, {baseDimensions.M}, {baseDimensions.T}, {baseDimensions.I}, {baseDimensions.Θ}, {baseDimensions.N}, {baseDimensions.J});");

            Writer.WL($@"
            BaseUnit = {_unitEnumName}.{_quantity.BaseUnit};
            Units = Enum.GetValues(typeof({_unitEnumName})).Cast<{_unitEnumName}>().ToArray();
            Zero = new {_quantity.Name}(0, BaseUnit);
            Info = new QuantityInfo<{_unitEnumName}>(""{_quantity.Name}"",
                new UnitInfo<{_unitEnumName}>[]
                {{");

            foreach (Unit unit in _quantity.Units)
            {
                BaseUnits? baseUnits = unit.BaseUnits;
                if (baseUnits == null)
                {
                    Writer.WL($@"
                    new UnitInfo<{_unitEnumName}>({_unitEnumName}.{unit.SingularName}, ""{unit.PluralName}"", BaseUnits.Undefined, ""{_quantity.Name}""),");
                }
                else
                {
                    var baseUnitsCtorArgs = string.Join(", ",
                        new[]
                        {
                            baseUnits.L != null ? $"length: LengthUnit.{baseUnits.L}" : null,
                            baseUnits.M != null ? $"mass: MassUnit.{baseUnits.M}" : null,
                            baseUnits.T != null ? $"time: DurationUnit.{baseUnits.T}" : null,
                            baseUnits.I != null ? $"current: ElectricCurrentUnit.{baseUnits.I}" : null,
                            baseUnits.Θ != null ? $"temperature: TemperatureUnit.{baseUnits.Θ}" : null,
                            baseUnits.N != null ? $"amount: AmountOfSubstanceUnit.{baseUnits.N}" : null,
                            baseUnits.J != null ? $"luminousIntensity: LuminousIntensityUnit.{baseUnits.J}" : null
                        }.Where(str => str != null));

                    Writer.WL($@"
                    new UnitInfo<{_unitEnumName}>({_unitEnumName}.{unit.SingularName}, ""{unit.PluralName}"", new BaseUnits({baseUnitsCtorArgs}), ""{_quantity.Name}""),");
                }
            }

            Writer.WL($@"
                }},
                BaseUnit, Zero, BaseDimensions);

            DefaultConversionFunctions = new UnitConverter();
            RegisterDefaultConversions(DefaultConversionFunctions);
        }}
");
        }

        private void GenerateInstanceConstructors()
        {
            Writer.WL($@"
        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name=""value"">The numeric value to construct this quantity with.</param>
        /// <param name=""unit"">The unit representation to construct this quantity with.</param>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>
        public {_quantity.Name}({_quantity.ValueType} value, {_unitEnumName} unit)
        {{");
            Writer.WL(_quantity.ValueType == "double"
                ? @"
            _value = Guard.EnsureValidNumber(value, nameof(value));"
                : @"
            _value = value;");
            Writer.WL($@"
            _unit = unit;
        }}

        /// <summary>
        /// Creates an instance of the quantity with the given numeric value in units compatible with the given <see cref=""UnitSystem""/>.
        /// If multiple compatible units were found, the first match is used.
        /// </summary>
        /// <param name=""value"">The numeric value to construct this quantity with.</param>
        /// <param name=""unitSystem"">The unit system to create the quantity with.</param>
        /// <exception cref=""ArgumentNullException"">The given <see cref=""UnitSystem""/> is null.</exception>
        /// <exception cref=""ArgumentException"">No unit was found for the given <see cref=""UnitSystem""/>.</exception>
        public {_quantity.Name}({_valueType} value, UnitSystem unitSystem)
        {{
            if (unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();
");

            Writer.WL(_quantity.ValueType == "double"
                ? @"
            _value = Guard.EnsureValidNumber(value, nameof(value));"
                : @"
            _value = value;");
            Writer.WL($@"
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException(""No units were found for the given UnitSystem."", nameof(unitSystem));
        }}
");
        }

        private void GenerateStaticProperties()
        {
            Writer.WL($@"
        #region Static Properties

        /// <summary>
        ///     The <see cref=""UnitConverter"" /> containing the default generated conversion functions for <see cref=""{_quantity.Name}"" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions {{ get; }}

        /// <inheritdoc cref=""IQuantity.QuantityInfo""/>
        public static QuantityInfo<{_unitEnumName}> Info {{ get; }}

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions {{ get; }}

        /// <summary>
        ///     The base unit of {_quantity.Name}, which is {_quantity.BaseUnit}. All conversions go via this value.
        /// </summary>
        public static {_unitEnumName} BaseUnit {{ get; }}

        /// <summary>
        ///     All units of measurement for the {_quantity.Name} quantity.
        /// </summary>
        public static {_unitEnumName}[] Units {{ get; }}

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit {_quantity.BaseUnit}.
        /// </summary>
        public static {_quantity.Name} Zero {{ get; }}
");

            if (_quantity.GenerateArithmetic)
            {
                Writer.WL($@"
        /// <inheritdoc cref=""Zero""/>
        public static {_quantity.Name} AdditiveIdentity => Zero;
");
            }

            Writer.WL($@"
        #endregion
");
        }

        private void GenerateProperties()
        {
            Writer.WL($@"
        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public {_valueType} Value => _value;

        /// <inheritdoc />
        QuantityValue IQuantity.Value => _value;

        Enum IQuantity.Unit => Unit;

        /// <inheritdoc />
        public {_unitEnumName} Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<{_unitEnumName}> QuantityInfo => Info;

        /// <inheritdoc cref=""IQuantity.QuantityInfo""/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <inheritdoc />
        [Obsolete(""This property will be removed in the next major release. Consider using {_quantity.Name}.BaseDimensions instead."")]
        public BaseDimensions Dimensions => {_quantity.Name}.BaseDimensions;

        #endregion
");
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
        ///     Gets a <see cref=""{_quantity.ValueType}""/> value of this quantity converted into <see cref=""{_unitEnumName}.{unit.SingularName}""/>
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

        private void GenerateStaticMethods()
        {
            Writer.WL($@"

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref=""UnitConverter""/> instance.
        /// </summary>
        /// <param name=""unitConverter"">The <see cref=""UnitConverter""/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {{
            // Register in unit converter: {_unitEnumName} -> BaseUnit");

            foreach (Unit unit in _quantity.Units)
            {
                if (unit.SingularName == _quantity.BaseUnit) continue;

                Writer.WL($@"
            unitConverter.SetConversionFunction<{_quantity.Name}>({_unitEnumName}.{unit.SingularName}, {_unitEnumName}.{_quantity.BaseUnit}, quantity => quantity.ToUnit({_unitEnumName}.{_quantity.BaseUnit}));");
            }

            Writer.WL();
            Writer.WL($@"

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<{_quantity.Name}>({_unitEnumName}.{_quantity.BaseUnit}, {_unitEnumName}.{_quantity.BaseUnit}, quantity => quantity);

            // Register in unit converter: BaseUnit -> {_unitEnumName}");

            foreach (Unit unit in _quantity.Units)
            {
                if (unit.SingularName == _quantity.BaseUnit) continue;

                Writer.WL($@"
            unitConverter.SetConversionFunction<{_quantity.Name}>({_unitEnumName}.{_quantity.BaseUnit}, {_unitEnumName}.{unit.SingularName}, quantity => quantity.ToUnit({_unitEnumName}.{unit.SingularName}));");
            }

            Writer.WL($@"
        }}

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name=""unit"">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation({_unitEnumName} unit)
        {{
            return GetAbbreviation(unit, null);
        }}

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name=""unit"">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name=""provider"">Format to use for localization. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public static string GetAbbreviation({_unitEnumName} unit, IFormatProvider? provider)
        {{
            return UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit, provider);
        }}

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
        public static {_quantity.Name} From{unit.PluralName}(QuantityValue {valueParamName})
        {{
            {_valueType} value = ({_valueType}) {valueParamName};
            return new {_quantity.Name}(value, {_unitEnumName}.{unit.SingularName});
        }}
");
            }

            Writer.WL($@"
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref=""{_unitEnumName}"" /> to <see cref=""{_quantity.Name}"" />.
        /// </summary>
        /// <param name=""value"">Value to convert from.</param>
        /// <param name=""fromUnit"">Unit to convert from.</param>
        /// <returns>{_quantity.Name} unit value.</returns>
        public static {_quantity.Name} From(QuantityValue value, {_unitEnumName} fromUnit)
        {{
            return new {_quantity.Name}(({_valueType})value, fromUnit);
        }}

        #endregion
");
        }

        private void GenerateStaticParseMethods()
        {
            Writer.WL($@"
        #region Static Parse Methods

        /// <summary>
        ///     Parse a string with one or two quantities of the format ""&lt;quantity&gt; &lt;unit&gt;"".
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <example>
        ///     Length.Parse(""5.5 m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""ArgumentException"">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     ""&lt;quantity&gt; &lt;unit&gt;"". Eg. ""5.5 m"" or ""1ft 2in""
        /// </exception>
        /// <exception cref=""AmbiguousUnitParseException"">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse(""1 cup"") will throw, because it can refer to any of
        ///     <see cref=""VolumeUnit.MetricCup"" />, <see cref=""VolumeUnit.UsLegalCup"" /> and <see cref=""VolumeUnit.UsCustomaryCup"" />.
        /// </exception>
        /// <exception cref=""UnitsNetException"">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref=""UnitsNetException"" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static {_quantity.Name} Parse(string str)
        {{
            return Parse(str, null);
        }}

        /// <summary>
        ///     Parse a string with one or two quantities of the format ""&lt;quantity&gt; &lt;unit&gt;"".
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <example>
        ///     Length.Parse(""5.5 m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""ArgumentException"">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     ""&lt;quantity&gt; &lt;unit&gt;"". Eg. ""5.5 m"" or ""1ft 2in""
        /// </exception>
        /// <exception cref=""AmbiguousUnitParseException"">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse(""1 cup"") will throw, because it can refer to any of
        ///     <see cref=""VolumeUnit.MetricCup"" />, <see cref=""VolumeUnit.UsLegalCup"" /> and <see cref=""VolumeUnit.UsCustomaryCup"" />.
        /// </exception>
        /// <exception cref=""UnitsNetException"">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref=""UnitsNetException"" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public static {_quantity.Name} Parse(string str, IFormatProvider? provider)
        {{
            return UnitsNetSetup.Default.QuantityParser.Parse<{_quantity.Name}, {_unitEnumName}>(
                str,
                provider,
                From);
        }}

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format ""&lt;quantity&gt; &lt;unit&gt;"".
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <param name=""result"">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse(""5.5 m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        public static bool TryParse(string? str, out {_quantity.Name} result)
        {{
            return TryParse(str, null, out result);
        }}

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format ""&lt;quantity&gt; &lt;unit&gt;"".
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <param name=""result"">Resulting unit quantity if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.Parse(""5.5 m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public static bool TryParse(string? str, IFormatProvider? provider, out {_quantity.Name} result)
        {{
            return UnitsNetSetup.Default.QuantityParser.TryParse<{_quantity.Name}, {_unitEnumName}>(
                str,
                provider,
                From,
                out result);
        }}

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <example>
        ///     Length.ParseUnit(""m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""UnitsNetException"">Error parsing string.</exception>
        public static {_unitEnumName} ParseUnit(string str)
        {{
            return ParseUnit(str, null);
        }}

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        /// <example>
        ///     Length.ParseUnit(""m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""UnitsNetException"">Error parsing string.</exception>
        public static {_unitEnumName} ParseUnit(string str, IFormatProvider? provider)
        {{
            return UnitsNetSetup.Default.UnitParser.Parse<{_unitEnumName}>(str, provider);
        }}

        /// <inheritdoc cref=""TryParseUnit(string,IFormatProvider,out UnitsNet.Units.{_unitEnumName})""/>
        public static bool TryParseUnit(string str, out {_unitEnumName} unit)
        {{
            return TryParseUnit(str, null, out unit);
        }}

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <param name=""unit"">The parsed unit if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.TryParseUnit(""m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public static bool TryParseUnit(string str, IFormatProvider? provider, out {_unitEnumName} unit)
        {{
            return UnitsNetSetup.Default.UnitParser.TryParse<{_unitEnumName}>(str, provider, out unit);
        }}

        #endregion
");
        }

        private void GenerateArithmeticOperators()
        {
            if (!_quantity.GenerateArithmetic) return;

            // Logarithmic units required different arithmetic
            if (_quantity.Logarithmic)
            {
                GenerateLogarithmicArithmeticOperators();
                return;
            }

            Writer.WL($@"
        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static {_quantity.Name} operator -({_quantity.Name} right)
        {{
            return new {_quantity.Name}(-right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from adding two <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator +({_quantity.Name} left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}(left.Value + right.ToUnit(left.Unit).Value, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from subtracting two <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator -({_quantity.Name} left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}(left.Value - right.ToUnit(left.Unit).Value, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from multiplying value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_valueType} left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}(left * right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from multiplying value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_quantity.Name} left, {_valueType} right)
        {{
            return new {_quantity.Name}(left.Value * right, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from dividing <see cref=""{_quantity.Name}""/> by value.</summary>
        public static {_quantity.Name} operator /({_quantity.Name} left, {_valueType} right)
        {{
            return new {_quantity.Name}(left.Value / right, left.Unit);
        }}

        /// <summary>Get ratio value from dividing <see cref=""{_quantity.Name}""/> by <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.ValueType} operator /({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.{_baseUnit.PluralName} / right.{_baseUnit.PluralName};
        }}

        #endregion
");
        }

        private void GenerateLogarithmicArithmeticOperators()
        {
            var scalingFactor = _quantity.LogarithmicScalingFactor;
            // Most logarithmic operators need a simple scaling factor of 10. However, certain units such as voltage ratio need to use 20 instead.
            var x = (10 * scalingFactor).ToString();
            Writer.WL($@"
        #region Logarithmic Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static {_quantity.Name} operator -({_quantity.Name} right)
        {{
            return new {_quantity.Name}(-right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic addition of two <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator +({_quantity.Name} left, {_quantity.Name} right)
        {{
            // Logarithmic addition
            // Formula: {x} * log10(10^(x/{x}) + 10^(y/{x}))
            return new {_quantity.Name}({x} * Math.Log10(Math.Pow(10, left.Value / {x}) + Math.Pow(10, right.ToUnit(left.Unit).Value / {x})), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic subtraction of two <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator -({_quantity.Name} left, {_quantity.Name} right)
        {{
            // Logarithmic subtraction
            // Formula: {x} * log10(10^(x/{x}) - 10^(y/{x}))
            return new {_quantity.Name}({x} * Math.Log10(Math.Pow(10, left.Value / {x}) - Math.Pow(10, right.ToUnit(left.Unit).Value / {x})), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_valueType} left, {_quantity.Name} right)
        {{
            // Logarithmic multiplication = addition
            return new {_quantity.Name}(left + right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_quantity.Name} left, double right)
        {{
            // Logarithmic multiplication = addition
            return new {_quantity.Name}(left.Value + ({_valueType})right, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic division of <see cref=""{_quantity.Name}""/> by value.</summary>
        public static {_quantity.Name} operator /({_quantity.Name} left, double right)
        {{
            // Logarithmic division = subtraction
            return new {_quantity.Name}(left.Value - ({_valueType})right, left.Unit);
        }}

        /// <summary>Get ratio value from logarithmic division of <see cref=""{_quantity.Name}""/> by <see cref=""{_quantity.Name}""/>.</summary>
        public static double operator /({_quantity.Name} left, {_quantity.Name} right)
        {{
            // Logarithmic division = subtraction
            return Convert.ToDouble(left.Value - right.ToUnit(left.Unit).Value);
        }}

        #endregion
" );
        }

        private void GenerateEqualityAndComparison()
        {
            Writer.WL($@"
        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value <= right.ToUnit(left.Unit).Value;
        }}

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value >= right.ToUnit(left.Unit).Value;
        }}

        /// <summary>Returns true if less than.</summary>
        public static bool operator <({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value < right.ToUnit(left.Unit).Value;
        }}

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value > right.ToUnit(left.Unit).Value;
        }}

        // We use obsolete attribute to communicate the preferred equality members to use.
        // CS0809: Obsolete member 'memberA' overrides non-obsolete member 'memberB'.
        #pragma warning disable CS0809

        /// <summary>Indicates strict equality of two <see cref=""{_quantity.Name}""/> quantities, where both <see cref=""Value"" /> and <see cref=""Unit"" /> are exactly equal.</summary>
        [Obsolete(""For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals({_quantity.Name} other, {_quantity.Name} tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units."")]
        public static bool operator ==({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Equals(right);
        }}

        /// <summary>Indicates strict inequality of two <see cref=""{_quantity.Name}""/> quantities, where both <see cref=""Value"" /> and <see cref=""Unit"" /> are exactly equal.</summary>
        [Obsolete(""For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals({_quantity.Name} other, {_quantity.Name} tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units."")]
        public static bool operator !=({_quantity.Name} left, {_quantity.Name} right)
        {{
            return !(left == right);
        }}

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref=""{_quantity.Name}""/> quantities, where both <see cref=""Value"" /> and <see cref=""Unit"" /> are exactly equal.</summary>
        [Obsolete(""Use Equals({_quantity.Name} other, {_quantity.Name} tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units."")]
        public override bool Equals(object? obj)
        {{
            if (obj is null || !(obj is {_quantity.Name} otherQuantity))
                return false;

            return Equals(otherQuantity);
        }}

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref=""{_quantity.Name}""/> quantities, where both <see cref=""Value"" /> and <see cref=""Unit"" /> are exactly equal.</summary>
        [Obsolete(""Use Equals({_quantity.Name} other, {_quantity.Name} tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units."")]
        public bool Equals({_quantity.Name} other)
        {{
            return new {{ Value, Unit }}.Equals(new {{ other.Value, other.Unit }});
        }}

        #pragma warning restore CS0809

        /// <summary>Compares the current <see cref=""{_quantity.Name}""/> with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
        /// <param name=""obj"">An object to compare with this instance.</param>
        /// <exception cref=""T:System.ArgumentException"">
        ///    <paramref name=""obj"" /> is not the same type as this instance.
        /// </exception>
        /// <returns>A value that indicates the relative order of the quantities being compared. The return value has these meanings:
        ///     <list type=""table"">
        ///         <listheader><term> Value</term><description> Meaning</description></listheader>
        ///         <item><term> Less than zero</term><description> This instance precedes <paramref name=""obj"" /> in the sort order.</description></item>
        ///         <item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name=""obj"" />.</description></item>
        ///         <item><term> Greater than zero</term><description> This instance follows <paramref name=""obj"" /> in the sort order.</description></item>
        ///     </list>
        /// </returns>
        public int CompareTo(object? obj)
        {{
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is {_quantity.Name} otherQuantity)) throw new ArgumentException(""Expected type {_quantity.Name}."", nameof(obj));

            return CompareTo(otherQuantity);
        }}

        /// <summary>Compares the current <see cref=""{_quantity.Name}""/> with another <see cref=""{_quantity.Name}""/> and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
        /// <param name=""other"">A quantity to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the quantities being compared. The return value has these meanings:
        ///     <list type=""table"">
        ///         <listheader><term> Value</term><description> Meaning</description></listheader>
        ///         <item><term> Less than zero</term><description> This instance precedes <paramref name=""other"" /> in the sort order.</description></item>
        ///         <item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name=""other"" />.</description></item>
        ///         <item><term> Greater than zero</term><description> This instance follows <paramref name=""other"" /> in the sort order.</description></item>
        ///     </list>
        /// </returns>
        public int CompareTo({_quantity.Name} other)
        {{
            return _value.CompareTo(other.ToUnit(this.Unit).Value);
        }}

        /// <summary>
        ///     <para>
        ///     Compare equality to another {_quantity.Name} within the given absolute or relative tolerance.
        ///     </para>
        ///     <para>
        ///     Relative tolerance is defined as the maximum allowable absolute difference between this quantity's value and
        ///     <paramref name=""other""/> as a percentage of this quantity's value. <paramref name=""other""/> will be converted into
        ///     this quantity's unit for comparison. A relative tolerance of 0.01 means the absolute difference must be within +/- 1% of
        ///     this quantity's value to be considered equal.
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within +/- 1% of a (0.02m or 2cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromInches(50.0);
        ///     a.Equals(b, 0.01, ComparisonType.Relative);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Absolute tolerance is defined as the maximum allowable absolute difference between this quantity's value and
        ///     <paramref name=""other""/> as a fixed number in this quantity's unit. <paramref name=""other""/> will be converted into
        ///     this quantity's unit for comparison.
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromInches(50.0);
        ///     a.Equals(b, 0.01, ComparisonType.Absolute);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Note that it is advised against specifying zero difference, due to the nature
        ///     of floating-point operations and using {_valueType} internally.
        ///     </para>
        /// </summary>
        /// <param name=""other"">The other quantity to compare to.</param>
        /// <param name=""tolerance"">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name=""comparisonType"">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        [Obsolete(""Use Equals({_quantity.Name} other, {_quantity.Name} tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units."")]
        public bool Equals({_quantity.Name} other, {_quantity.ValueType} tolerance, ComparisonType comparisonType)
        {{
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException(nameof(tolerance), ""Tolerance must be greater than or equal to 0."");

            return UnitsNet.Comparison.Equals(
                referenceValue: this.Value,
                otherValue: other.As(this.Unit),
                tolerance: tolerance,
                comparisonType: comparisonType);
        }}

        /// <inheritdoc />
        public bool Equals(IQuantity? other, IQuantity tolerance)
        {{
            return other is {_quantity.Name} otherTyped
                   && (tolerance is {_quantity.Name} toleranceTyped
                       ? true
                       : throw new ArgumentException($""Tolerance quantity ({{tolerance.QuantityInfo.Name}}) did not match the other quantities of type '{_quantity.Name}'."", nameof(tolerance)))
                   && Equals(otherTyped, toleranceTyped);
        }}

        /// <inheritdoc />
        public bool Equals({_quantity.Name} other, {_quantity.Name} tolerance)
        {{
            return UnitsNet.Comparison.Equals(
                referenceValue: this.Value,
                otherValue: other.As(this.Unit),
                tolerance: tolerance.As(this.Unit),
                comparisonType: ComparisonType.Absolute);
        }}

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current {_quantity.Name}.</returns>
        public override int GetHashCode()
        {{
            return new {{ Info.Name, Value, Unit }}.GetHashCode();
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
        public {_quantity.ValueType} As({_unitEnumName} unit)
        {{
            if (Unit == unit)
                return Value;

            return ToUnit(unit).Value;
        }}
");

            if (_quantity.ValueType == "decimal")
            {
                Writer.WL($@"

        double IQuantity<{_unitEnumName}>.As({_unitEnumName} unit)
        {{
            return (double)As(unit);
        }}
");
            }

            Writer.WL($@"

        /// <inheritdoc cref=""IQuantity.As(UnitSystem)""/>
        public {_quantity.ValueType} As(UnitSystem unitSystem)
        {{
            if (unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if (firstUnitInfo == null)
                throw new ArgumentException(""No units were found for the given UnitSystem."", nameof(unitSystem));

            return As(firstUnitInfo.Value);
        }}
");

            if (_quantity.ValueType == "decimal")
            {
                Writer.WL($@"
         /// <inheritdoc cref=""IQuantity.As(UnitSystem)""/>
        double IQuantity.As(UnitSystem unitSystem)
        {{
            return (double)As(unitSystem);
        }}
");
            }

            Writer.WL($@"
        /// <inheritdoc />
        double IQuantity.As(Enum unit)
        {{
            if (!(unit is {_unitEnumName} typedUnit))
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return (double)As(typedUnit);
        }}

        /// <inheritdoc />
        {_quantity.ValueType} IValueQuantity<{_quantity.ValueType}>.As(Enum unit)
        {{
            if (!(unit is {_unitEnumName} typedUnit))
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return As(typedUnit);
        }}

        /// <summary>
        ///     Converts this {_quantity.Name} to another {_quantity.Name} with the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <param name=""unit"">The unit to convert to.</param>
        /// <returns>A {_quantity.Name} with the specified unit.</returns>
        public {_quantity.Name} ToUnit({_unitEnumName} unit)
        {{
            return ToUnit(unit, DefaultConversionFunctions);
        }}

        /// <summary>
        ///     Converts this <see cref=""{_quantity.Name}""/> to another <see cref=""{_quantity.Name}""/> using the given <paramref name=""unitConverter""/> with the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <param name=""unit"">The unit to convert to.</param>
        /// <param name=""unitConverter"">The <see cref=""UnitConverter""/> to use for the conversion.</param>
        /// <returns>A {_quantity.Name} with the specified unit.</returns>
        public {_quantity.Name} ToUnit({_unitEnumName} unit, UnitConverter unitConverter)
        {{
            if (TryToUnit(unit, out var converted))
            {{
                // Try to convert using the auto-generated conversion methods.
                return converted!.Value;
            }}
            else if (unitConverter.TryGetConversionFunction((typeof({_quantity.Name}), Unit, typeof({_quantity.Name}), unit), out var conversionFunction))
            {{
                // See if the unit converter has an extensibility conversion registered.
                return ({_quantity.Name})conversionFunction(this);
            }}
            else if (Unit != BaseUnit)
            {{
                // Conversion to requested unit NOT found. Try to convert to BaseUnit, and then from BaseUnit to requested unit.
                var inBaseUnits = ToUnit(BaseUnit);
                return inBaseUnits.ToUnit(unit);
            }}
            else
            {{
                // No possible conversion
                throw new NotImplementedException($""Can not convert {{Unit}} to {{unit}}."");
            }}
        }}

        /// <summary>
        ///     Attempts to convert this <see cref=""{_quantity.Name}""/> to another <see cref=""{_quantity.Name}""/> with the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <param name=""unit"">The unit to convert to.</param>
        /// <param name=""converted"">The converted <see cref=""{_quantity.Name}""/> in <paramref name=""unit""/>, if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        private bool TryToUnit({_unitEnumName} unit, [NotNullWhen(true)] out {_quantity.Name}? converted)
        {{
            if (Unit == unit)
            {{
                converted = this;
                return true;
            }}

            {_quantity.Name}? convertedOrNull = (Unit, unit) switch
            {{
                // {_unitEnumName} -> BaseUnit");

            foreach (Unit unit in _quantity.Units)
            {
                if (unit.SingularName == _quantity.BaseUnit) continue;

                var func = unit.FromUnitToBaseFunc.Replace("{x}", "_value");
                Writer.WL($@"
                ({_unitEnumName}.{unit.SingularName}, {_unitEnumName}.{_quantity.BaseUnit}) => new {_quantity.Name}({func}, {_unitEnumName}.{_quantity.BaseUnit}),");
            }

            Writer.WL();
            Writer.WL($@"

                // BaseUnit -> {_unitEnumName}");
            foreach(Unit unit in _quantity.Units)
            {
                if (unit.SingularName == _quantity.BaseUnit) continue;

                var func = unit.FromBaseToUnitFunc.Replace("{x}", "_value");
                Writer.WL($@"
                ({_unitEnumName}.{_quantity.BaseUnit}, {_unitEnumName}.{unit.SingularName}) => new {_quantity.Name}({func}, {_unitEnumName}.{unit.SingularName}),");
            }

            Writer.WL();
            Writer.WL($@"
                _ => null
            }};

            if (convertedOrNull is null)
            {{
                converted = default;
                return false;
            }}

            converted = convertedOrNull.Value;
            return true;
        }}

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {{
            if (!(unit is {_unitEnumName} typedUnit))
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }}

        /// <inheritdoc cref=""IQuantity.ToUnit(UnitSystem)""/>
        public {_quantity.Name} ToUnit(UnitSystem unitSystem)
        {{
            if (unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if (firstUnitInfo == null)
                throw new ArgumentException(""No units were found for the given UnitSystem."", nameof(unitSystem));

            return ToUnit(firstUnitInfo.Value);
        }}

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<{_unitEnumName}> IQuantity<{_unitEnumName}>.ToUnit({_unitEnumName} unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<{_unitEnumName}> IQuantity<{_unitEnumName}>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IValueQuantity<{_quantity.ValueType}> IValueQuantity<{_quantity.ValueType}>.ToUnit(Enum unit)
        {{
            if (unit is not {_unitEnumName} typedUnit)
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return ToUnit(typedUnit);
        }}

        /// <inheritdoc />
        IValueQuantity<{_quantity.ValueType}> IValueQuantity<{_quantity.ValueType}>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        #endregion
");
        }

        private void GenerateToString()
        {
            Writer.WL($@"
        #region ToString Methods

        /// <summary>
        ///     Gets the default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {{
            return ToString(""g"");
        }}

        /// <summary>
        ///     Gets the default string representation of value and unit using the given format provider.
        /// </summary>
        /// <returns>String representation.</returns>
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public string ToString(IFormatProvider? provider)
        {{
            return ToString(""g"", provider);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TUnitType}}(IQuantity{{TUnitType}}, string, IFormatProvider)""/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using <see cref=""CultureInfo.CurrentCulture"" />.
        /// </summary>
        /// <param name=""format"">The format string.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string? format)
        {{
            return ToString(format, CultureInfo.CurrentCulture);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TUnitType}}(IQuantity{{TUnitType}}, string, IFormatProvider)""/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using the specified format provider, or <see cref=""CultureInfo.CurrentCulture"" /> if null.
        /// </summary>
        /// <param name=""format"">The format string.</param>
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string? format, IFormatProvider? provider)
        {{
            return QuantityFormatter.Format<{_unitEnumName}>(this, format, provider);
        }}

        #endregion
" );
        }

        private void GenerateIConvertibleMethods()
        {
            Writer.WL($@"
        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {{
            return TypeCode.Object;
        }}

        bool IConvertible.ToBoolean(IFormatProvider? provider)
        {{
            throw new InvalidCastException($""Converting {{typeof({_quantity.Name})}} to bool is not supported."");
        }}

        byte IConvertible.ToByte(IFormatProvider? provider)
        {{
            return Convert.ToByte(_value);
        }}

        char IConvertible.ToChar(IFormatProvider? provider)
        {{
            throw new InvalidCastException($""Converting {{typeof({_quantity.Name})}} to char is not supported."");
        }}

        DateTime IConvertible.ToDateTime(IFormatProvider? provider)
        {{
            throw new InvalidCastException($""Converting {{typeof({_quantity.Name})}} to DateTime is not supported."");
        }}

        decimal IConvertible.ToDecimal(IFormatProvider? provider)
        {{
            return Convert.ToDecimal(_value);
        }}

        double IConvertible.ToDouble(IFormatProvider? provider)
        {{
            return Convert.ToDouble(_value);
        }}

        short IConvertible.ToInt16(IFormatProvider? provider)
        {{
            return Convert.ToInt16(_value);
        }}

        int IConvertible.ToInt32(IFormatProvider? provider)
        {{
            return Convert.ToInt32(_value);
        }}

        long IConvertible.ToInt64(IFormatProvider? provider)
        {{
            return Convert.ToInt64(_value);
        }}

        sbyte IConvertible.ToSByte(IFormatProvider? provider)
        {{
            return Convert.ToSByte(_value);
        }}

        float IConvertible.ToSingle(IFormatProvider? provider)
        {{
            return Convert.ToSingle(_value);
        }}

        string IConvertible.ToString(IFormatProvider? provider)
        {{
            return ToString(""g"", provider);
        }}

        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {{
            if (conversionType == typeof({_quantity.Name}))
                return this;
            else if (conversionType == typeof({_unitEnumName}))
                return Unit;
            else if (conversionType == typeof(QuantityInfo))
                return {_quantity.Name}.Info;
            else if (conversionType == typeof(BaseDimensions))
                return {_quantity.Name}.BaseDimensions;
            else
                throw new InvalidCastException($""Converting {{typeof({_quantity.Name})}} to {{conversionType}} is not supported."");
        }}

        ushort IConvertible.ToUInt16(IFormatProvider? provider)
        {{
            return Convert.ToUInt16(_value);
        }}

        uint IConvertible.ToUInt32(IFormatProvider? provider)
        {{
            return Convert.ToUInt32(_value);
        }}

        ulong IConvertible.ToUInt64(IFormatProvider? provider)
        {{
            return Convert.ToUInt64(_value);
        }}

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
