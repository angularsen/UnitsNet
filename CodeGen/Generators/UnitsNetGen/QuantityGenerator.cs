// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using CodeGen.Helpers;
using CodeGen.Helpers.ExpressionAnalyzer;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using CodeGen.JsonTypes;
using Fractions;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class QuantityGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;

        private readonly bool _isDimensionless;
        private readonly string _unitEnumName;
        private readonly Unit _baseUnit;

        public QuantityGenerator(Quantity quantity)
        {
            _quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));

            _baseUnit = quantity.Units.FirstOrDefault(u => u.SingularName == _quantity.BaseUnit) ??
                        throw new ArgumentException($"No unit found with SingularName equal to BaseUnit [{_quantity.BaseUnit}]. This unit must be defined.",
                            nameof(quantity));

            _unitEnumName = $"{quantity.Name}Unit";

            BaseDimensions baseDimensions = quantity.BaseDimensions;
            _isDimensionless = baseDimensions is { L: 0, M: 0, T: 0, I: 0, Θ: 0, N: 0, J: 0 };
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System.Globalization;
using System.Resources;
using System.Runtime.Serialization;
using UnitsNet.Debug;

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
    [DebuggerDisplay(QuantityDebugProxy.DisplayFormat)]
    [DebuggerTypeProxy(typeof(QuantityDebugProxy))]
    public readonly partial struct {_quantity.Name} :");
            GenerateInterfaceExtensions();

            Writer.WL($@"
    {{
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        [DataMember(Name = ""Value"", Order = 1, EmitDefaultValue = false)]
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        [DataMember(Name = ""Unit"", Order = 2, EmitDefaultValue = false)]
        private readonly {_unitEnumName}? _unit;
");
            GenerateQuantityInfo();
            GenerateStaticConstructor();
            GenerateInstanceConstructors();
            GenerateStaticProperties();
            GenerateProperties();
            GenerateConversionProperties();
            GenerateStaticMethods();
            GenerateStaticFactoryMethods();
            GenerateStaticParseMethods();
            GenerateArithmeticOperators();
            GenerateRelationalOperators();
            GenerateEqualityAndComparison();
            GenerateToString();

            Writer.WL($@"
    }}
}}");
            return Writer.ToString();
        }

        private void GenerateInterfaceExtensions()
        {
            // generate the base interface (either IVectorQuantity, IAffineQuantity or ILogarithmicQuantity)
            if (_quantity.Logarithmic)
            {
                Writer.WL(@$"
        ILogarithmicQuantity<{_quantity.Name}, {_unitEnumName}>,");
            }
            else if (!string.IsNullOrEmpty(_quantity.AffineOffsetType))
            {
                Writer.WL(@$"
        IAffineQuantity<{_quantity.Name}, {_unitEnumName}, {_quantity.AffineOffsetType}>,");
            }
            else // the default quantity type implements the IVectorQuantity interface
            {
                Writer.WL(@$"
        IArithmeticQuantity<{_quantity.Name}, {_unitEnumName}>,");
            }

            Writer.WL(@"
#if NET7_0_OR_GREATER");
            if (!_quantity.IsAffine)
            {
                Writer.WL($@"
        IDivisionOperators<{_quantity.Name}, {_quantity.Name}, double>,");
            }

            if (_quantity.Relations.Any(r => r.Operator is "*" or "/"))
            {
                foreach (QuantityRelation relation in _quantity.Relations)
                {
                    if (relation.LeftQuantity != _quantity) continue;
                    switch (relation.Operator)
                    {
                        case "*":
                            Writer.W(@"
        IMultiplyOperators");
                            break;
                        case "/":
                            Writer.W(@"
        IDivisionOperators");
                            break;
                        default:
                            continue;
                    }

                    Writer.WL($"<{relation.LeftQuantity.Name}, {relation.RightQuantity.Name}, {relation.ResultQuantity.Name}>,");
                }
            }

            Writer.WL(@$"
        IComparisonOperators<{_quantity.Name}, {_quantity.Name}, bool>,
        IParsable<{_quantity.Name}>,
#endif
        IComparable,
        IComparable<{_quantity.Name}>,
        IEquatable<{_quantity.Name}>,
        IFormattable");
        }

        private void GenerateQuantityInfo()
        {
            var quantityInfoClassName = $"{_quantity.Name}Info";
            BaseDimensions baseDimensions = _quantity.BaseDimensions;
            var createDimensionsExpression = _isDimensionless
                ? "BaseDimensions.Dimensionless"
                : $"new BaseDimensions({baseDimensions.L}, {baseDimensions.M}, {baseDimensions.T}, {baseDimensions.I}, {baseDimensions.Θ}, {baseDimensions.N}, {baseDimensions.J})";

            Writer.WL($@"
        /// <summary>
        ///     Provides detailed information about the <see cref=""{_quantity.Name}""/> quantity, including its name, base unit, unit mappings, base dimensions, and conversion functions.
        /// </summary>
        public sealed class {quantityInfoClassName}: QuantityInfo<{_quantity.Name}, {_unitEnumName}>
        {{");
            Writer.WL($@"
            /// <inheritdoc />
            public {quantityInfoClassName}(string name, {_unitEnumName} baseUnit, IEnumerable<IUnitDefinition<{_unitEnumName}>> unitMappings, {_quantity.Name} zero, BaseDimensions baseDimensions,
                QuantityFromDelegate<{_quantity.Name}, {_unitEnumName}> fromDelegate, ResourceManager? unitAbbreviations)
                : base(name, baseUnit, unitMappings, zero, baseDimensions, fromDelegate, unitAbbreviations)
            {{
            }}

            /// <inheritdoc />
            public {quantityInfoClassName}(string name, {_unitEnumName} baseUnit, IEnumerable<IUnitDefinition<{_unitEnumName}>> unitMappings, {_quantity.Name} zero, BaseDimensions baseDimensions)
                : this(name, baseUnit, unitMappings, zero, baseDimensions, {_quantity.Name}.From, new ResourceManager(""UnitsNet.GeneratedCode.Resources.{_quantity.Name}"", typeof({_quantity.Name}).Assembly))
            {{
            }}

            /// <summary>
            ///     Creates a new instance of the <see cref=""{quantityInfoClassName}""/> class with the default settings for the {_quantity.Name} quantity.
            /// </summary>
            /// <returns>A new instance of the <see cref=""{quantityInfoClassName}""/> class with the default settings.</returns>
            public static {quantityInfoClassName} CreateDefault()
            {{
                return new {quantityInfoClassName}(nameof({_quantity.Name}), DefaultBaseUnit, GetDefaultMappings(), new {_quantity.Name}(0, DefaultBaseUnit), DefaultBaseDimensions);
            }}

            /// <summary>
            ///     Creates a new instance of the <see cref=""{quantityInfoClassName}""/> class with the default settings for the {_quantity.Name} quantity and a callback for customizing the default unit mappings.
            /// </summary>
            /// <param name=""customizeUnits"">
            ///     A callback function for customizing the default unit mappings.
            /// </param>
            /// <returns>
            ///     A new instance of the <see cref=""{quantityInfoClassName}""/> class with the default settings.
            /// </returns>
            public static {quantityInfoClassName} CreateDefault(Func<IEnumerable<UnitDefinition<{_unitEnumName}>>, IEnumerable<IUnitDefinition<{_unitEnumName}>>> customizeUnits)
            {{
                return new {quantityInfoClassName}(nameof({_quantity.Name}), DefaultBaseUnit, customizeUnits(GetDefaultMappings()), new {_quantity.Name}(0, DefaultBaseUnit), DefaultBaseDimensions);
            }}

            /// <summary>
            ///     The <see cref=""BaseDimensions"" /> for <see cref=""{_quantity.Name}""/> is {_quantity.BaseDimensions}.
            /// </summary>
            public static BaseDimensions DefaultBaseDimensions {{ get; }} = {createDimensionsExpression};

            /// <summary>
            ///     The default base unit of {_quantity.Name} is {_baseUnit.SingularName}. All conversions, as defined in the <see cref=""GetDefaultMappings""/>, go via this value.
            /// </summary>
            public static {_unitEnumName} DefaultBaseUnit {{ get; }} = {_unitEnumName}.{_baseUnit.SingularName};

            /// <summary>
            ///     Retrieves the default mappings for <see cref=""{_unitEnumName}""/>.
            /// </summary>
            /// <returns>An <see cref=""IEnumerable{{T}}""/> of <see cref=""UnitDefinition{{{_unitEnumName}}}""/> representing the default unit mappings for {_quantity.Name}.</returns>
            public static IEnumerable<UnitDefinition<{_unitEnumName}>> GetDefaultMappings()
            {{");

            foreach (Unit unit in _quantity.Units)
            {
                BaseUnits? baseUnits = unit.BaseUnits;
                string baseUnitsFormat;
                if (baseUnits == null)
                {
                    baseUnitsFormat = "BaseUnits.Undefined";
                }
                else
                {
                    baseUnitsFormat = $"new BaseUnits({string.Join(", ",
                        new[]
                        {
                            baseUnits.L != null ? $"length: LengthUnit.{baseUnits.L}" : null,
                            baseUnits.M != null ? $"mass: MassUnit.{baseUnits.M}" : null,
                            baseUnits.T != null ? $"time: DurationUnit.{baseUnits.T}" : null,
                            baseUnits.I != null ? $"current: ElectricCurrentUnit.{baseUnits.I}" : null,
                            baseUnits.Θ != null ? $"temperature: TemperatureUnit.{baseUnits.Θ}" : null,
                            baseUnits.N != null ? $"amount: AmountOfSubstanceUnit.{baseUnits.N}" : null,
                            baseUnits.J != null ? $"luminousIntensity: LuminousIntensityUnit.{baseUnits.J}" : null
                        }.Where(str => str != null))})";
                }

                // the UnitInfo constructor has 3 overloads:
                // - one for the base unit without conversion expressions
                // - one for units with only FromBaseToUnit conversion expression (with the FromUnitToBase expression assumed to be the inverse)
                // - one for units with both FromBaseToUnit and FromUnitToBase conversion expressions (required when the conversion is not a simple inverse, e.g. affine conversions)
                if (unit.SingularName == _quantity.BaseUnit)
                {
                    Writer.WL($@"
                yield return new ({_unitEnumName}.{unit.SingularName}, ""{unit.SingularName}"", ""{unit.PluralName}"", {baseUnitsFormat});");
                }
                else
                {
                    CompositeExpression expressionFromBaseToUnit = ExpressionEvaluator.Evaluate(unit.FromBaseToUnitFunc, "{x}");
                    // Check if FromUnitToBase is simply the inverse of FromBaseToUnit
                    if (expressionFromBaseToUnit.Terms.Count == 1 && expressionFromBaseToUnit.Degree == Fraction.One)
                    {
                        Writer.WL($@"
                yield return new ({_unitEnumName}.{unit.SingularName}, ""{unit.SingularName}"", ""{unit.PluralName}"", {baseUnitsFormat},
                     {expressionFromBaseToUnit.GetConversionExpressionFormat()}
                );");
                    }
                    else
                    {
                        Writer.WL($@"
                yield return new ({_unitEnumName}.{unit.SingularName}, ""{unit.SingularName}"", ""{unit.PluralName}"", {baseUnitsFormat},
                     {expressionFromBaseToUnit.GetConversionExpressionFormat()},
                     {unit.GetUnitToBaseConversionExpressionFormat()}
                );");
                    }
                }
            }

            Writer.WL($@"
            }}
        }}
");
        }

        private void GenerateStaticConstructor()
        {
            Writer.WL($@"
        static {_quantity.Name}()
        {{");
            Writer.WL($@"
            Info = UnitsNetSetup.CreateQuantityInfo({_quantity.Name}Info.CreateDefault);
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
        public {_quantity.Name}(double value, {_unitEnumName} unit)
        {{");
            Writer.WL(@"
            _value = value;");
            Writer.WL($@"
            _unit = unit;
        }}
");
            if (!_isDimensionless)
            {
                Writer.WL($@"
        /// <summary>
        /// Creates an instance of the quantity with the given numeric value in units compatible with the given <see cref=""UnitSystem""/>.
        /// If multiple compatible units were found, the first match is used.
        /// </summary>
        /// <param name=""value"">The numeric value to construct this quantity with.</param>
        /// <param name=""unitSystem"">The unit system to create the quantity with.</param>
        /// <exception cref=""ArgumentNullException"">The given <see cref=""UnitSystem""/> is null.</exception>
        /// <exception cref=""ArgumentException"">No unit was found for the given <see cref=""UnitSystem""/>.</exception>
        public {_quantity.Name}(double value, UnitSystem unitSystem)
        {{
            _value = value;
            _unit = Info.GetDefaultUnit(unitSystem);
        }}
");
            }
        }

        private void GenerateStaticProperties()
        {
            Writer.WL($@"
        #region Static Properties

        /// <summary>
        ///     The <see cref=""UnitConverter"" /> containing the default generated conversion functions for <see cref=""{_quantity.Name}"" /> instances.
        /// </summary>
        [Obsolete(""Replaced by UnitConverter.Default"")]
        public static UnitConverter DefaultConversionFunctions => UnitConverter.Default;

        /// <inheritdoc cref=""IQuantity.QuantityInfo""/>
        public static QuantityInfo<{_quantity.Name}, {_unitEnumName}> Info {{ get; }}

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions => Info.BaseDimensions;

        /// <summary>
        ///     The base unit of {_quantity.Name}, which is {_quantity.BaseUnit}. All conversions go via this value.
        /// </summary>
        public static {_unitEnumName} BaseUnit => Info.BaseUnitInfo.Value;

        /// <summary>
        ///     All units of measurement for the {_quantity.Name} quantity.
        /// </summary>
        public static IReadOnlyCollection<{_unitEnumName}> Units => Info.Units;

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit {_quantity.BaseUnit}.
        /// </summary>
        public static {_quantity.Name} Zero => Info.Zero;
");

            if (_quantity.Logarithmic)
            {
                Writer.WL($@"
        /// <inheritdoc />
        public static double LogarithmicScalingFactor {{get;}} = {10 * _quantity.LogarithmicScalingFactor};
");
            }

            Writer.WL(@"
        #endregion
");
        }

        private void GenerateProperties()
        {
            Writer.WL($@"
        #region Properties

        /// <inheritdoc />
        public double Value => _value;

        /// <inheritdoc />
        public {_unitEnumName} Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<{_quantity.Name}, {_unitEnumName}> QuantityInfo => Info;

        #region Explicit implementations

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        UnitKey IQuantity.UnitKey => UnitKey.ForUnit(Unit);

#if NETSTANDARD2_0
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IQuantityInstanceInfo<{_quantity.Name}> IQuantityOfType<{_quantity.Name}>.QuantityInfo => Info;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QuantityInfo<{_unitEnumName}> IQuantity<{_unitEnumName}>.QuantityInfo => Info;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QuantityInfo IQuantity.QuantityInfo => Info;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Enum IQuantity.Unit => Unit;
#endif
");
            if (_quantity.Logarithmic)
            {
                Writer.WL($@"
#if NETSTANDARD2_0
        double ILogarithmicQuantity<{_quantity.Name}>.LogarithmicScalingFactor => LogarithmicScalingFactor;
#endif
");
            }

            Writer.WL(@"
        #endregion

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
        ///     Gets a <see cref=""double""/> value of this quantity converted into <see cref=""{_unitEnumName}.{unit.SingularName}""/>
        /// </summary>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public double {unit.PluralName} => this.As({_unitEnumName}.{unit.SingularName});
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

                Writer.WL($@"
        /// <summary>
        ///     Creates a <see cref=""{_quantity.Name}""/> from <see cref=""{_unitEnumName}.{unit.SingularName}""/>.
        /// </summary>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        public static {_quantity.Name} From{unit.PluralName}(double value)
        {{
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
        public static {_quantity.Name} From(double value, {_unitEnumName} fromUnit)
        {{
            return new {_quantity.Name}(value, fromUnit);
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
            return QuantityParser.Default.Parse<{_quantity.Name}, {_unitEnumName}>(str, provider, From);
        }}

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format ""&lt;quantity&gt; &lt;unit&gt;"".
        /// </summary>
        /// <param name=""str"">String to parse. Typically in the form: {{number}} {{unit}}</param>
        /// <param name=""result"">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse(""5.5 m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        public static bool TryParse([NotNullWhen(true)]string? str, out {_quantity.Name} result)
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
        public static bool TryParse([NotNullWhen(true)]string? str, IFormatProvider? provider, out {_quantity.Name} result)
        {{
            return QuantityParser.Default.TryParse<{_quantity.Name}, {_unitEnumName}>(str, provider, From, out result);
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
        /// <param name=""provider"">Format to use when parsing the unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        /// <example>
        ///     Length.ParseUnit(""m"", CultureInfo.GetCultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""UnitsNetException"">Error parsing string.</exception>
        public static {_unitEnumName} ParseUnit(string str, IFormatProvider? provider)
        {{
            return UnitParser.Default.Parse(str, Info.UnitInfos, provider).Value;
        }}

        /// <inheritdoc cref=""TryParseUnit(string,IFormatProvider?,out UnitsNet.Units.{_unitEnumName})""/>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, out {_unitEnumName} unit)
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
        /// <param name=""provider"">Format to use when parsing the unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, IFormatProvider? provider, out {_unitEnumName} unit)
        {{
            return UnitParser.Default.TryParse(str, Info, provider, out unit);
        }}

        #endregion
");
        }

        private void GenerateArithmeticOperators()
        {
            if (_quantity.IsAffine)
            {
                // the generation of arithmetic operators with affine quantities, such as Temperature + TemperatureDelta, is currently not supported
                // TODO see about handling this case using the UnitRelations
                return;
            }

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
            return new {_quantity.Name}(left.Value + right.As(left.Unit), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from subtracting two <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator -({_quantity.Name} left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}(left.Value - right.As(left.Unit), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from multiplying value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *(double left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}(left * right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from multiplying value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_quantity.Name} left, double right)
        {{
            return new {_quantity.Name}(left.Value * right, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from dividing <see cref=""{_quantity.Name}""/> by value.</summary>
        public static {_quantity.Name} operator /({_quantity.Name} left, double right)
        {{
            return new {_quantity.Name}(left.Value / right, left.Unit);
        }}

        /// <summary>Get ratio value from dividing <see cref=""{_quantity.Name}""/> by <see cref=""{_quantity.Name}""/>.</summary>
        public static double operator /({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.{_baseUnit.PluralName} / right.{_baseUnit.PluralName};
        }}

        #endregion
");
        }

        private void GenerateLogarithmicArithmeticOperators()
        {
            // Most logarithmic operators need a simple scaling factor of 10. However, certain units such as voltage ratio need to use 20 instead.
            Writer.WL($@"
        #region Logarithmic Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static {_quantity.Name} operator -({_quantity.Name} quantity)
        {{
            return new {_quantity.Name}(-quantity.Value, quantity.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic addition of two <see cref=""{_quantity.Name}""/>.</summary>
        /// <remarks>This operation involves a conversion of the values to linear space, which is not guaranteed to produce an exact value.
        /// <para>The final result is rounded to 15 significant digits.</para>
        /// </remarks>
        public static {_quantity.Name} operator +({_quantity.Name} left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}((double)QuantityValueExtensions.AddWithLogScaling((QuantityValue)left.Value, (QuantityValue)right.As(left.Unit), (QuantityValue)LogarithmicScalingFactor), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic subtraction of two <see cref=""{_quantity.Name}""/>.</summary>
        /// <remarks>This operation involves a conversion of the values to linear space, which is not guaranteed to produce an exact value.
        /// <para>The final result is rounded to 15 significant digits.</para>
        /// </remarks>
        public static {_quantity.Name} operator -({_quantity.Name} left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}((double)QuantityValueExtensions.SubtractWithLogScaling((QuantityValue)left.Value, (QuantityValue)right.As(left.Unit), (QuantityValue)LogarithmicScalingFactor), left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *(double left, {_quantity.Name} right)
        {{
            return new {_quantity.Name}(left + right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_quantity.Name} left, double right)
        {{
            return new {_quantity.Name}(left.Value + right, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic division of <see cref=""{_quantity.Name}""/> by value.</summary>
        public static {_quantity.Name} operator /({_quantity.Name} left, double right)
        {{
            return new {_quantity.Name}(left.Value - right, left.Unit);
        }}

        /// <summary>Get ratio value from logarithmic division of <see cref=""{_quantity.Name}""/> by <see cref=""{_quantity.Name}""/>.</summary>
        public static double operator /({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value - right.As(left.Unit);
        }}

        #endregion
" );
        }

        /// <summary>
        ///     Generates relational operators for quantities based on their defined relations.
        /// </summary>
        /// <param name="inverseWithFixedUnit">
        ///     Specifies whether inverse relational operators should be generated as implicit conversions or simply using the unit specified in the UnitRelations.
        ///     If <c>true</c>, the method generates inverse operators that convert to a fixed unit, as specified in the UnitRelations.
        ///     If <c>false</c>, the method generates inverse operators as implicit conversions that utilize the UnitConverter for conversion.
        /// </param>
        private void GenerateRelationalOperators(bool inverseWithFixedUnit = false)
        {
            if (_quantity.Relations.Length == 0) return;

            Writer.WL($@"
        #region Relational Operators
");

            foreach (QuantityRelation relation in _quantity.Relations)
            {
                if (relation.Operator == "inverse")
                {
                    if (inverseWithFixedUnit)
                    {
                        // this was the original behavior where the inverse always used the fixed unit from the relation
                        Writer.WL($@"
        /// <summary>Calculates the inverse of this quantity.</summary>
        /// <returns>The corresponding inverse quantity, <see cref=""{relation.RightQuantity.Name}""/>.</returns>
        public {relation.RightQuantity.Name} Inverse()
        {{
            return {relation.RightQuantity.Name}.From{relation.RightUnit.PluralName}(QuantityValue.Inverse({relation.LeftUnit.PluralName}));
        }}
");
                    }
                    else
                    {
                        // this is the proposed improvement where the inverse is considered a type of implicit conversion
                        Writer.WL($@"
        /// <summary>Calculates the inverse of this quantity.</summary>
        /// <returns>The corresponding inverse quantity, <see cref=""{relation.RightQuantity.Name}""/>.</returns>
        public {relation.RightQuantity.Name} Inverse()
        {{
            return UnitConverter.Default.ConvertTo(Value, Unit, {relation.RightQuantity.Name}.Info);
        }}
");
                    }
                }
                else
                {
                    const string valueType = "double";
                    var leftParameterType = relation.LeftQuantity.Name;
                    var leftConversionProperty = relation.LeftUnit.PluralName;
                    var rightParameterType = relation.RightQuantity.Name;
                    var rightConversionProperty = relation.RightUnit.PluralName;

                    string leftParameterName, rightParameterName;
                    if (leftParameterType == rightParameterType)
                    {
                        leftParameterName = "left";
                        rightParameterName = "right";
                    }
                    else
                    {
                        leftParameterName = leftParameterType is valueType ? "value": leftParameterType.ToCamelCase();
                        rightParameterName = rightParameterType is valueType ? "value": rightParameterType.ToCamelCase();
                    }

                    var leftPart = leftParameterType is valueType ? leftParameterName : $"{leftParameterName}.{leftConversionProperty}";
                    var rightPart = rightParameterName is valueType ? rightParameterName : $"{rightParameterName}.{rightConversionProperty}";
                    var expression = $"{leftPart} {relation.Operator} {rightPart}";

                    var resultType = relation.ResultQuantity.Name;
                    if (resultType is not valueType)
                    {
                        expression = $"{resultType}.From{relation.ResultUnit.PluralName}({expression})";
                    }

                    Writer.WL($@"
        /// <summary>Get <see cref=""{resultType}""/> from <see cref=""{leftParameterType}""/> {relation.Operator} <see cref=""{rightParameterType}""/>.</summary>
        public static {resultType} operator {relation.Operator}({leftParameterType} {leftParameterName}, {rightParameterType} {rightParameterName})
        {{
            return {expression};
        }}
");
                }
            }

            Writer.WL($@"

        #endregion
");
        }

        private void GenerateEqualityAndComparison()
        {
            Writer.WL($@"
        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value <= right.As(left.Unit);
        }}

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value >= right.As(left.Unit);
        }}

        /// <summary>Returns true if less than.</summary>
        public static bool operator <({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value < right.As(left.Unit);
        }}

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Value > right.As(left.Unit);
        }}

        /// <summary>
        ///     Determines whether two <see cref=""{_quantity.Name}""/> instances are equal.
        /// </summary>
        /// <remarks>
        ///     Equality is evaluated in a unit-aware manner. The right-hand operand is converted to the unit of the left-hand
        ///     operand and then the underlying numeric values are compared.
        ///     This means two quantities with numerically equal values but different units will be considered equal.
        ///     The operator delegates to <see cref=""Equals({_quantity.Name})""/>, which implements this conversion-and-compare logic.
        /// </remarks>
        public static bool operator ==({_quantity.Name} left, {_quantity.Name} right)
        {{
            return left.Equals(right);
        }}

        /// <summary>
        ///     Determines whether two <see cref=""{_quantity.Name}""/> instances are not equal.
        /// </summary>
        /// <remarks>
        ///     This operator is the logical negation of <see cref=""operator ==({_quantity.Name},{_quantity.Name})""/>.
        ///     See that operator (and <see cref=""Equals({_quantity.Name})""/>) for details on how equality is evaluated
        ///     (i.e., by converting one operand to the other's unit and comparing their numeric values).
        /// </remarks>
        public static bool operator !=({_quantity.Name} left, {_quantity.Name} right)
        {{
            return !(left == right);
        }}

        /// <inheritdoc />
        /// <summary>
        ///     Determines whether the specified object is equal to the current <see cref=""{_quantity.Name}""/> instance.
        /// </summary>
        /// <remarks>
        ///     Returns <c>false</c> if <paramref name=""obj""/> is <c>null</c> or not a <see cref=""{_quantity.Name}""/>.
        ///     When <paramref name=""obj""/> is a <see cref=""{_quantity.Name}""/>, this method delegates to
        ///     <see cref=""Equals({_quantity.Name})""/>, which performs a unit-aware comparison by converting the other
        ///     instance to this instance's unit before comparing numeric values.
        /// </remarks>
        public override bool Equals(object? obj)
        {{
            if (obj is not {_quantity.Name} otherQuantity)
                return false;

            return Equals(otherQuantity);
        }}

        /// <inheritdoc />
        /// <summary>
        ///     Determines whether the current instance is equal to another <see cref=""{_quantity.Name}""/> instance.
        /// </summary>
        /// <remarks>
        ///     Comparison is performed by converting <paramref name=""other""/> to this instance's unit and then comparing the underlying numeric values.
        ///     This makes two quantities equal even when their units differ, provided the converted numeric values are equal.
        /// </remarks>
        public bool Equals({_quantity.Name} other)
        {{
            return _value.Equals(other.As(this.Unit));
        }}

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current {_quantity.Name}.</returns>
        public override int GetHashCode()
        {{
            return Comparison.GetHashCode(typeof({_quantity.Name}), this.As(BaseUnit));
        }}

        /// <inheritdoc  cref=""CompareTo({_quantity.Name})"" />
        /// <param name=""obj"">An object to compare with this instance.</param>
        /// <exception cref=""T:System.ArgumentException"">
        ///    <paramref name=""obj"" /> is not the same type as this instance.
        /// </exception>
        public int CompareTo(object? obj)
        {{
            if (obj is not {_quantity.Name} otherQuantity)
                throw obj is null ? new ArgumentNullException(nameof(obj)) : ExceptionHelper.CreateArgumentException<{_quantity.Name}>(obj, nameof(obj));

            return CompareTo(otherQuantity);
        }}

        /// <summary>
        ///     Compares the current <see cref=""{_quantity.Name}""/> with another <see cref=""{_quantity.Name}""/> and returns an integer that indicates
        ///     whether the current instance precedes, follows, or occurs in the same position in the sort order as the other quantity, when converted to the same unit.
        /// </summary>
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
            return _value.CompareTo(other.As(this.Unit));
        }}

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
            return ToString(null, null);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TQuantity}}(TQuantity, string, IFormatProvider)""/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using the specified format provider, or <see cref=""CultureInfo.CurrentCulture"" /> if null.
        /// </summary>
        public string ToString(string? format, IFormatProvider? provider)
        {{
            return QuantityFormatter.Default.Format(this, format, provider);
        }}

        #endregion
" );
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
