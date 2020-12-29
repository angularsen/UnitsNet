// Licensed under MIT No Attribution, see LICENSE file at the root.
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

            _valueType = quantity.BaseType;
            _unitEnumName = $"{quantity.Name}Unit";

            BaseDimensions baseDimensions = quantity.BaseDimensions;
            _isDimensionless = baseDimensions == null ||
                              baseDimensions.L == 0 &&
                              baseDimensions.M == 0 &&
                              baseDimensions.T == 0 &&
                              baseDimensions.I == 0 &&
                              baseDimensions.Θ == 0 &&
                              baseDimensions.N == 0 &&
                              baseDimensions.J == 0;

        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

#nullable enable

// ReSharper disable once CheckNamespace

namespace UnitsNet
{");
            Writer.WLIfText(1, GetObsoleteAttributeOrNull(_quantity));
            Writer.WL($@"
    /// <inheritdoc />
    /// <summary>
    ///     {_quantity.XmlDoc}
    /// </summary>");

            Writer.WLCondition(_quantity.XmlDocRemarks.HasText(), $@"
    /// <remarks>
    ///     {_quantity.XmlDocRemarks}
    /// </remarks>");

            Writer.W(@$"
    public partial struct {_quantity.Name}<T> : IQuantityT<{_unitEnumName}, T>, ");
            if (_quantity.BaseType == "decimal")
            {
                Writer.W("IDecimalQuantity, ");
            }

            Writer.WL($"IEquatable<{_quantity.Name}<T>>, IComparable, IComparable<{_quantity.Name}<T>>, IConvertible, IFormattable");
            Writer.WL($@"
    {{
        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
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
            var baseDimensions = _quantity.BaseDimensions;
            Writer.WL($@"
        static {_quantity.Name}()
        {{");
            Writer.WL(_isDimensionless
                ? @"
            BaseDimensions = BaseDimensions.Dimensionless;
"
                : $@"
            BaseDimensions = new BaseDimensions({baseDimensions.L}, {baseDimensions.M}, {baseDimensions.T}, {baseDimensions.I}, {baseDimensions.Θ}, {baseDimensions.N}, {baseDimensions.J});
");

            Writer.WL($@"
            Info = new QuantityInfo<{_unitEnumName}>(""{_quantity.Name}"",
                new UnitInfo<{_unitEnumName}>[] {{");

            foreach (var unit in _quantity.Units)
            {
                var baseUnits = unit.BaseUnits;
                if (baseUnits == null)
                {
                    Writer.WL($@"
                    new UnitInfo<{_unitEnumName}>({_unitEnumName}.{unit.SingularName}, BaseUnits.Undefined),");
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
                    new UnitInfo<{_unitEnumName}>({_unitEnumName}.{unit.SingularName}, new BaseUnits({baseUnitsCtorArgs})),");
                }
            }

            Writer.WL($@"
                }},
                BaseUnit, Zero, BaseDimensions, QuantityType.{_quantity.Name});
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
        public {_quantity.Name}(T value, {_unitEnumName} unit)
        {{
            if(unit == {_unitEnumName}.Undefined)
              throw new ArgumentException(""The quantity can not be created with an undefined unit."", nameof(unit));

            Value = value;
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
        public {_quantity.Name}(T value, UnitSystem unitSystem)
        {{
            if(unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();

            Value = value;
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException(""No units were found for the given UnitSystem."", nameof(unitSystem));
        }}
");
        }

        private void GenerateStaticProperties()
        {
            Writer.WL($@"
        #region Static Properties

        /// <inheritdoc cref=""IQuantity.QuantityInfo""/>
        public static QuantityInfo<{_unitEnumName}> Info {{ get; }}

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions {{ get; }}

        /// <summary>
        ///     The base unit of <see cref=""{_quantity.Name}{{T}}"" />, which is {_quantity.BaseUnit}. All conversions go via this value.
        /// </summary>
        public static {_unitEnumName} BaseUnit {{ get; }} = {_unitEnumName}.{_quantity.BaseUnit};

        /// <summary>
        /// Represents the largest possible value of <see cref=""{_quantity.Name}{{T}}"" />
        /// </summary>
        public static {_quantity.Name}<T> MaxValue {{ get; }} = new {_quantity.Name}<T>({_valueType}.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of <see cref=""{_quantity.Name}{{T}}"" />
        /// </summary>
        public static {_quantity.Name}<T> MinValue {{ get; }} = new {_quantity.Name}<T>({_valueType}.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref=""QuantityType"" /> of this quantity.
        /// </summary>
        [Obsolete(""QuantityType will be removed in the future. Use Info property instead."")]
        public static QuantityType QuantityType {{ get; }} = QuantityType.{_quantity.Name};

        /// <summary>
        ///     All units of measurement for the <see cref=""{_quantity.Name}{{T}}"" /> quantity.
        /// </summary>
        public static {_unitEnumName}[] Units {{ get; }} = Enum.GetValues(typeof({_unitEnumName})).Cast<{_unitEnumName}>().Except(new {_unitEnumName}[]{{ {_unitEnumName}.Undefined }}).ToArray();

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit {_quantity.BaseUnit}.
        /// </summary>
        public static {_quantity.Name}<T> Zero {{ get; }} = new {_quantity.Name}<T>((T)0, BaseUnit);

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
        public T Value{{ get; }}

        double IQuantity.Value => Convert.ToDouble(Value);
");
        if (_quantity.BaseType == "decimal")
                Writer.WL(@"
        /// <inheritdoc cref=""IDecimalQuantity.Value""/>
        decimal IDecimalQuantity.Value => _value;

        Enum IQuantity.Unit => Unit;

        /// <inheritdoc />
        public {_unitEnumName} Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<{_unitEnumName}> QuantityInfo => Info;

        /// <inheritdoc cref=""IQuantity.QuantityInfo""/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref=""QuantityType"" /> of this quantity.
        /// </summary>
        public QuantityType Type => {_quantity.Name}<T>.QuantityType;

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => {_quantity.Name}<T>.BaseDimensions;

        #endregion
" );
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
        ///     Get <see cref=""{_quantity.Name}{{T}}"" /> in {unit.PluralName}.
        /// </summary>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public T {unit.PluralName} => As({_unitEnumName}.{unit.SingularName});
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
        /// <param name=""provider"">Format to use for localization. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        public static string GetAbbreviation({_unitEnumName} unit, IFormatProvider? provider)
        {{
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }}

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
        ///     Get <see cref=""{_quantity.Name}{{T}}"" /> from {unit.PluralName}.
        /// </summary>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public static {_quantity.Name}<T> From{unit.PluralName}(T {valueParamName})
        {{
            return new {_quantity.Name}<T>({valueParamName}, {_unitEnumName}.{unit.SingularName});
        }}");
            }

            Writer.WL();
            Writer.WL($@"
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref=""{_unitEnumName}"" /> to <see cref=""{_quantity.Name}{{T}}"" />.
        /// </summary>
        /// <param name=""value"">Value to convert from.</param>
        /// <param name=""fromUnit"">Unit to convert from.</param>
        /// <returns><see cref=""{_quantity.Name}{{T}}"" /> unit value.</returns>
        public static {_quantity.Name}<T> From(T value, {_unitEnumName} fromUnit)
        {{
            return new {_quantity.Name}<T>(value, fromUnit);
        }}

        #endregion
" );
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
        ///     Length.Parse(""5.5 m"", new CultureInfo(""en-US""));
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
        public static {_quantity.Name}<T> Parse(string str)
        {{
            return Parse(str, null);
        }}

        /// <summary>
        ///     Parse a string with one or two quantities of the format ""&lt;quantity&gt; &lt;unit&gt;"".
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <example>
        ///     Length.Parse(""5.5 m"", new CultureInfo(""en-US""));
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
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        public static {_quantity.Name}<T> Parse(string str, IFormatProvider? provider)
        {{
            return QuantityParser.Default.Parse<{_quantity.Name}<T>, {_unitEnumName}>(
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
        ///     Length.Parse(""5.5 m"", new CultureInfo(""en-US""));
        /// </example>
        public static bool TryParse(string? str, out {_quantity.Name}<T> result)
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
        ///     Length.Parse(""5.5 m"", new CultureInfo(""en-US""));
        /// </example>
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        public static bool TryParse(string? str, IFormatProvider? provider, out {_quantity.Name}<T> result)
        {{
            return QuantityParser.Default.TryParse<{_quantity.Name}<T>, {_unitEnumName}>(
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
        ///     Length.ParseUnit(""m"", new CultureInfo(""en-US""));
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
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        /// <example>
        ///     Length.ParseUnit(""m"", new CultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""UnitsNetException"">Error parsing string.</exception>
        public static {_unitEnumName} ParseUnit(string str, IFormatProvider? provider)
        {{
            return UnitParser.Default.Parse<{_unitEnumName}>(str, provider);
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
        ///     Length.TryParseUnit(""m"", new CultureInfo(""en-US""));
        /// </example>
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        public static bool TryParseUnit(string str, IFormatProvider? provider, out {_unitEnumName} unit)
        {{
            return UnitParser.Default.TryParse<{_unitEnumName}>(str, provider, out unit);
        }}

        #endregion
");
        }

        private void GenerateArithmeticOperators()
        {
            if (!_quantity.GenerateArithmetic)
                return;

            // Logarithmic units required different arithmetic
            if (_quantity.Logarithmic)
            {
                GenerateLogarithmicArithmeticOperators();
                return;
            }

            Writer.WL($@"
        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static {_quantity.Name}<T> operator -({_quantity.Name}<T> right)
        {{
            return new {_quantity.Name}<T>(CompiledLambdas.Negate(right.Value), right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from adding two <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator +({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            var value = CompiledLambdas.Add(left.Value, right.GetValueAs(left.Unit));
            return new {_quantity.Name}<T>(value, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from subtracting two <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator -({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            var value = CompiledLambdas.Subtract(left.Value, right.GetValueAs(left.Unit));
            return new {_quantity.Name}<T>(value, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from multiplying value and <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator *(T left, {_quantity.Name}<T> right)
        {{
            var value = CompiledLambdas.Multiply(left, right.Value);
            return new {_quantity.Name}<T>(value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from multiplying value and <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator *({_quantity.Name}<T> left, T right)
        {{
            var value = CompiledLambdas.Multiply(left.Value, right);
            return new {_quantity.Name}<T>(value, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from dividing <see cref=""{_quantity.Name}{{T}}""/> by value.</summary>
        public static {_quantity.Name}<T> operator /({_quantity.Name}<T> left, T right)
        {{
            var value = CompiledLambdas.Divide(left.Value, right);
            return new {_quantity.Name}<T>(value, left.Unit);
        }}

        /// <summary>Get ratio value from dividing <see cref=""{_quantity.Name}{{T}}""/> by <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static T operator /({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return CompiledLambdas.Divide(left.{_baseUnit.PluralName}, right.{_baseUnit.PluralName});
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
        public static {_quantity.Name}<T> operator -({_quantity.Name}<T> right)
        {{
            return new {_quantity.Name}<T>(-right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from logarithmic addition of two <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator +({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            // Logarithmic addition
            // Formula: {x}*log10(10^(x/{x}) + 10^(y/{x}))
            return new {_quantity.Name}<T>({x}*Math.Log10(Math.Pow(10, left.Value/{x}) + Math.Pow(10, right.GetValueAs(left.Unit)/{x})), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from logarithmic subtraction of two <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator -({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            // Logarithmic subtraction
            // Formula: {x}*log10(10^(x/{x}) - 10^(y/{x}))
            return new {_quantity.Name}<T>({x}*Math.Log10(Math.Pow(10, left.Value/{x}) - Math.Pow(10, right.GetValueAs(left.Unit)/{x})), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator *({_valueType} left, {_quantity.Name}<T> right)
        {{
            // Logarithmic multiplication = addition
            return new {_quantity.Name}<T>(left + right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static {_quantity.Name}<T> operator *({_quantity.Name}<T> left, double right)
        {{
            // Logarithmic multiplication = addition
            return new {_quantity.Name}<T>(left.Value + ({_valueType})right, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}{{T}}""/> from logarithmic division of <see cref=""{_quantity.Name}{{T}}""/> by value.</summary>
        public static {_quantity.Name}<T> operator /({_quantity.Name}<T> left, double right)
        {{
            // Logarithmic division = subtraction
            return new {_quantity.Name}<T>(left.Value - ({_valueType})right, left.Unit);
        }}

        /// <summary>Get ratio value from logarithmic division of <see cref=""{_quantity.Name}{{T}}""/> by <see cref=""{_quantity.Name}{{T}}""/>.</summary>
        public static double operator /({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            // Logarithmic division = subtraction
            return Convert.ToDouble(left.Value - right.GetValueAs(left.Unit));
        }}

        #endregion
");
        }

        private void GenerateEqualityAndComparison()
        {
            Writer.WL($@"
        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return CompiledLambdas.LessThanOrEqual(left.Value, right.GetValueAs(left.Unit));
        }}

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return CompiledLambdas.GreaterThanOrEqual(left.Value, right.GetValueAs(left.Unit));
        }}

        /// <summary>Returns true if less than.</summary>
        public static bool operator <({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return CompiledLambdas.LessThan(left.Value, right.GetValueAs(left.Unit));
        }}

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return CompiledLambdas.GreaterThan(left.Value, right.GetValueAs(left.Unit));
        }}

        /// <summary>Returns true if exactly equal.</summary>
        /// <remarks>Consider using <see cref=""Equals({_quantity.Name}{{T}}, double, ComparisonType)""/> for safely comparing floating point values.</remarks>
        public static bool operator ==({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return left.Equals(right);
        }}

        /// <summary>Returns true if not exactly equal.</summary>
        /// <remarks>Consider using <see cref=""Equals({_quantity.Name}{{T}}, double, ComparisonType)""/> for safely comparing floating point values.</remarks>
        public static bool operator !=({_quantity.Name}<T> left, {_quantity.Name}<T> right)
        {{
            return !(left == right);
        }}

        /// <inheritdoc />
        public int CompareTo(object obj)
        {{
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is {_quantity.Name}<T> obj{_quantity.Name})) throw new ArgumentException(""Expected type {_quantity.Name}."", nameof(obj));

            return CompareTo(obj{_quantity.Name});
        }}

        /// <inheritdoc />
        public int CompareTo({_quantity.Name}<T> other)
        {{
            return System.Collections.Generic.Comparer<T>.Default.Compare(Value, other.GetValueAs(this.Unit));
        }}

        /// <inheritdoc />
        /// <remarks>Consider using <see cref=""Equals({_quantity.Name}{{T}}, double, ComparisonType)""/> for safely comparing floating point values.</remarks>
        public override bool Equals(object obj)
        {{
            if(obj is null || !(obj is {_quantity.Name}<T> obj{_quantity.Name}))
                return false;

            return Equals(obj{_quantity.Name});
        }}

        /// <inheritdoc />
        /// <remarks>Consider using <see cref=""Equals({_quantity.Name}{{T}}, double, ComparisonType)""/> for safely comparing floating point values.</remarks>
        public bool Equals({_quantity.Name}<T> other)
        {{
            return Value.Equals(other.GetValueAs(this.Unit));
        }}

        /// <summary>
        ///     <para>
        ///     Compare equality to another <see cref=""{_quantity.Name}{{T}}"" /> within the given absolute or relative tolerance.
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
        ///     of floating point operations and using System.Double internally.
        ///     </para>
        /// </summary>
        /// <param name=""other"">The other quantity to compare to.</param>
        /// <param name=""tolerance"">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name=""comparisonType"">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        public bool Equals({_quantity.Name}<T> other, double tolerance, ComparisonType comparisonType)
        {{
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException(""tolerance"", ""Tolerance must be greater than or equal to 0."");

            var otherValueInThisUnits = other.As(this.Unit);
            return UnitsNet.Comparison.Equals(Value, otherValueInThisUnits, tolerance, comparisonType);
        }}

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current <see cref=""{_quantity.Name}{{T}}"" />.</returns>
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
        public T As({_unitEnumName} unit)
        {{
            if(Unit == unit)
                return Value;

            var converted = GetValueAs(unit);
            return converted;
        }}

        /// <inheritdoc cref=""IQuantity.As(UnitSystem)""/>
        public T As(UnitSystem unitSystem)
        {{
            if(unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if(firstUnitInfo == null)
                throw new ArgumentException(""No units were found for the given UnitSystem."", nameof(unitSystem));

            return As(firstUnitInfo.Value);
        }}

        /// <inheritdoc />
        double IQuantity.As(Enum unit)
        {{
            if(!(unit is {_unitEnumName} unitAs{_unitEnumName}))
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            var asValue = As(unitAs{_unitEnumName});
            return Convert.ToDouble(asValue);
        }}

        double IQuantity.As(UnitSystem unitSystem) => Convert.ToDouble(As(unitSystem));

        double IQuantity<{_unitEnumName}>.As({_unitEnumName} unit) => Convert.ToDouble(As(unit));

        /// <summary>
        ///     Converts this <see cref=""{_quantity.Name}{{T}}"" /> to another <see cref=""{_quantity.Name}{{T}}"" /> with the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <returns>A <see cref=""{_quantity.Name}{{T}}"" /> with the specified unit.</returns>
        public {_quantity.Name}<T> ToUnit({_unitEnumName} unit)
        {{
            var convertedValue = GetValueAs(unit);
            return new {_quantity.Name}<T>(convertedValue, unit);
        }}

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {{
            if(!(unit is {_unitEnumName} unitAs{_unitEnumName}))
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return ToUnit(unitAs{_unitEnumName});
        }}

        /// <inheritdoc cref=""IQuantity.ToUnit(UnitSystem)""/>
        public {_quantity.Name}<T> ToUnit(UnitSystem unitSystem)
        {{
            if(unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if(firstUnitInfo == null)
                throw new ArgumentException(""No units were found for the given UnitSystem."", nameof(unitSystem));

            return ToUnit(firstUnitInfo.Value);
        }}

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<{_unitEnumName}> IQuantity<{_unitEnumName}>.ToUnit({_unitEnumName} unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantityT<{_unitEnumName}, T> IQuantityT<{_unitEnumName}, T>.ToUnit({_unitEnumName} unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<{_unitEnumName}> IQuantity<{_unitEnumName}>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantityT<{_unitEnumName}, T> IQuantityT<{_unitEnumName}, T>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private T GetValueInBaseUnit()
        {{
            switch(Unit)
            {{" );
            foreach (var unit in _quantity.Units)
            {
                var func = unit.FromUnitToBaseFunc.Replace("x", "Value");
                Writer.WL($@"
                case {_unitEnumName}.{unit.SingularName}: return {func};");
            }

            Writer.WL($@"
                default:
                    throw new NotImplementedException($""Can not convert {{Unit}} to base units."");
            }}
        }}

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        internal {_quantity.Name}<T> ToBaseUnit()
        {{
            var baseUnitValue = GetValueInBaseUnit();
            return new {_quantity.Name}<T>(baseUnitValue, BaseUnit);
        }}

        private T GetValueAs({_unitEnumName} unit)
        {{
            if(Unit == unit)
                return Value;

            var baseUnitValue = GetValueInBaseUnit();

            switch(unit)
            {{");
            foreach (var unit in _quantity.Units)
            {
                var func = unit.FromBaseToUnitFunc.Replace("x", "baseUnitValue");
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
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        public string ToString(IFormatProvider? provider)
        {{
            return ToString(""g"", provider);
        }}

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name=""significantDigitsAfterRadix"">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        [Obsolete(@""This method is deprecated and will be removed at a future release. Please use ToString(""""s2"""") or ToString(""""s2"""", provider) where 2 is an example of the number passed to significantDigitsAfterRadix."")]
        public string ToString(IFormatProvider? provider, int significantDigitsAfterRadix)
        {{
            var value = Convert.ToDouble(Value);
            var format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(provider, format);
        }}

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name=""format"">String format to use. Default:  ""{{0:0.##}} {{1}} for value and unit abbreviation respectively.""</param>
        /// <param name=""args"">Arguments for string format. Value and unit are implicitly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        [Obsolete(""This method is deprecated and will be removed at a future release. Please use string.Format()."")]
        public string ToString(IFormatProvider? provider, [NotNull] string format, [NotNull] params object[] args)
        {{
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

            provider = provider ?? CultureInfo.CurrentUICulture;

            var value = Convert.ToDouble(Value);
            var formatArgs = UnitFormatter.GetFormatArgs(Unit, value, provider, args);
            return string.Format(provider, format, formatArgs);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TUnitType}}(IQuantity{{TUnitType}}, string, IFormatProvider)""/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using <see cref=""CultureInfo.CurrentUICulture"" />.
        /// </summary>
        /// <param name=""format"">The format string.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string format)
        {{
            return ToString(format, CultureInfo.CurrentUICulture);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TUnitType}}(IQuantity{{TUnitType}}, string, IFormatProvider)""/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using the specified format provider, or <see cref=""CultureInfo.CurrentUICulture"" /> if null.
        /// </summary>
        /// <param name=""format"">The format string.</param>
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string format, IFormatProvider? provider)
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

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {{
            throw new InvalidCastException($""Converting {{typeof({_quantity.Name}<T>)}} to bool is not supported."");
        }}

        byte IConvertible.ToByte(IFormatProvider provider)
        {{
            return Convert.ToByte(Value);
        }}

        char IConvertible.ToChar(IFormatProvider provider)
        {{
            throw new InvalidCastException($""Converting {{typeof({_quantity.Name}<T>)}} to char is not supported."");
        }}

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {{
            throw new InvalidCastException($""Converting {{typeof({_quantity.Name}<T>)}} to DateTime is not supported."");
        }}

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {{
            return Convert.ToDecimal(Value);
        }}

        double IConvertible.ToDouble(IFormatProvider provider)
        {{
            return Convert.ToDouble(Value);
        }}

        short IConvertible.ToInt16(IFormatProvider provider)
        {{
            return Convert.ToInt16(Value);
        }}

        int IConvertible.ToInt32(IFormatProvider provider)
        {{
            return Convert.ToInt32(Value);
        }}

        long IConvertible.ToInt64(IFormatProvider provider)
        {{
            return Convert.ToInt64(Value);
        }}

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {{
            return Convert.ToSByte(Value);
        }}

        float IConvertible.ToSingle(IFormatProvider provider)
        {{
            return Convert.ToSingle(Value);
        }}

        string IConvertible.ToString(IFormatProvider provider)
        {{
            return ToString(""g"", provider);
        }}

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {{
            if(conversionType == typeof({_quantity.Name}<T>))
                return this;
            else if(conversionType == typeof({_unitEnumName}))
                return Unit;
            else if(conversionType == typeof(QuantityType))
                return {_quantity.Name}<T>.QuantityType;
            else if(conversionType == typeof(QuantityInfo))
                return {_quantity.Name}<T>.Info;
            else if(conversionType == typeof(BaseDimensions))
                return {_quantity.Name}<T>.BaseDimensions;
            else
                throw new InvalidCastException($""Converting {{typeof({_quantity.Name}<T>)}} to {{conversionType}} is not supported."");
        }}

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {{
            return Convert.ToUInt16(Value);
        }}

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {{
            return Convert.ToUInt32(Value);
        }}

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {{
            return Convert.ToUInt64(Value);
        }}

        #endregion" );
        }

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        internal static string GetObsoleteAttributeOrNull(Quantity quantity) => GetObsoleteAttributeOrNull(quantity.ObsoleteText);

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        internal static string GetObsoleteAttributeOrNull(Unit unit) => GetObsoleteAttributeOrNull(unit.ObsoleteText);

        /// <summary>
        /// Returns the Obsolete attribute if ObsoleteText has been defined on the JSON input - otherwise returns empty string
        /// It is up to the consumer to wrap any padding/new lines in order to keep to correct indentation formats
        /// </summary>
        private static string GetObsoleteAttributeOrNull(string obsoleteText) => string.IsNullOrWhiteSpace(obsoleteText)
            ? null
            : $"[System.Obsolete(\"{obsoleteText}\")]";
    }
}
