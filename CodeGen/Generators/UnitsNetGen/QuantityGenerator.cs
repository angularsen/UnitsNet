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
#if NET
using System.Numerics;
#endif

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
        {(_quantity.GenerateArithmetic ? "IArithmeticQuantity" : "IQuantity")}<{_quantity.Name}, {_unitEnumName}>,");

            if (_quantity.Relations.Any(r => r.Operator is "*" or "/"))
            {
                Writer.WL(@$"
#if NET7_0_OR_GREATER");
                foreach (QuantityRelation relation in _quantity.Relations)
                {
                    if (relation.LeftQuantity == _quantity)
                    {
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
#endif");
            }

            Writer.WL(@$"
#if NET7_0_OR_GREATER
        IComparisonOperators<{_quantity.Name}, {_quantity.Name}, bool>,
        IParsable<{_quantity.Name}>,
#endif
        IComparable,
        IComparable<{_quantity.Name}>,
        IEquatable<{_quantity.Name}>,
        IFormattable");

            Writer.WL($@"
    {{
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        [DataMember(Name = ""Value"", Order = 1)]
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        [DataMember(Name = ""Unit"", Order = 2)]
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
            GenerateConversionMethods();
            GenerateToString();

            Writer.WL($@"
    }}
}}");
            return Writer.ToString();
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
        private static class {quantityInfoClassName}
        {{");
            Writer.WL($@"
            /// <summary>
            ///     Creates a new instance of the <see cref=""{quantityInfoClassName}""/> class with the default settings for the {_quantity.Name} quantity and a callback for customizing the default unit mappings.
            /// </summary>
            /// <param name=""unitAbbreviations"">
            ///     When provided, the resource manager used for localizing the quantity's unit abbreviations. Defaults to the built-in abbreviations.
            /// </param>
            /// <param name=""customizeUnits"">
            ///     Optionally add, replace or remove unit definitions from the default set of units.
            /// </param>
            /// <returns>
            ///     A new instance of the <see cref=""{quantityInfoClassName}""/> class with the default settings.
            /// </returns>
            private static QuantityInfo<{_quantity.Name}, {_unitEnumName}> Create(
                ResourceManager? unitAbbreviations = null,
                Func<IEnumerable<IUnitDefinition<{_unitEnumName}>>, IEnumerable<IUnitDefinition<{_unitEnumName}>>>? customizeUnits = null)
            {{
                IEnumerable<IUnitDefinition<{_unitEnumName}>> unitMappings = {_quantity.Name}Info.GetDefaultMappings();
                if (customizeUnits != null)
                    unitMappings = customizeUnits(unitMappings);

                return new QuantityInfo<{_quantity.Name}, {_unitEnumName}>(
                    name: nameof({_quantity.Name}),
                    baseUnit: DefaultBaseUnit,
                    unitMappings: unitMappings,
                    zero: new {_quantity.Name}(0, DefaultBaseUnit),
                    baseDimensions: DefaultBaseDimensions,
                    fromDelegate: From,
                    registerUnitConversions: RegisterDefaultConversions,
                    unitAbbreviations ?? DefaultUnitAbbreviations);
            }}

            /// <summary>
            ///     The <see cref=""BaseDimensions"" /> for <see cref=""{_quantity.Name}""/> is {_quantity.BaseDimensions}.
            /// </summary>
            private static BaseDimensions DefaultBaseDimensions {{ get; }} = {createDimensionsExpression};

            /// <summary>
            ///     The default base unit of {_quantity.Name} is {_baseUnit.SingularName}. All conversions, as defined in the <see cref=""GetDefaultMappings""/>, go via this value.
            /// </summary>
            private static {_unitEnumName} DefaultBaseUnit {{ get; }} = {_unitEnumName}.{_baseUnit.SingularName};

            /// <summary>
            ///     The default resource manager for unit abbreviations of the {_quantity.Name} quantity.
            /// </summary>
            private static ResourceManager DefaultUnitAbbreviations {{ get; }} = new(""UnitsNet.GeneratedCode.Resources.{_quantity.Name}"", typeof({_quantity.Name}).Assembly);

            /// <summary>
            ///     Retrieves the default mappings for <see cref=""{_unitEnumName}""/>.
            /// </summary>
            /// <returns>An <see cref=""IEnumerable{{T}}""/> of <see cref=""UnitDefinition{{{_unitEnumName}}}""/> representing the default unit mappings for {_quantity.Name}.</returns>
            private static IEnumerable<UnitDefinition<{_unitEnumName}>> GetDefaultMappings()
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

                Writer.WL($@"
                yield return new ({_unitEnumName}.{unit.SingularName}, ""{unit.SingularName}"", ""{unit.PluralName}"", {baseUnitsFormat});");
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
            Info = {_quantity.Name}Info.Create();
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
        public static UnitConverter DefaultConversionFunctions {{ get; }}

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
        public double Value => _value;

        /// <inheritdoc />
        public {_unitEnumName} Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<{_quantity.Name}, {_unitEnumName}> QuantityInfo => Info;

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => {_quantity.Name}.BaseDimensions;

        #region Explicit implementations

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Enum IQuantity.Unit => Unit;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        UnitKey IQuantity.UnitKey => UnitKey.ForUnit(Unit);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QuantityInfo IQuantity.QuantityInfo => Info;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QuantityInfo<{_unitEnumName}> IQuantity<{_unitEnumName}>.QuantityInfo => Info;

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
        public double {unit.PluralName} => As({_unitEnumName}.{unit.SingularName});
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
            return UnitParser.Default.Parse(str, Info.UnitInfos, provider).Value;
        }}

        /// <inheritdoc cref=""TryParseUnit(string,IFormatProvider,out UnitsNet.Units.{_unitEnumName})""/>
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
        /// <param name=""provider"">Format to use when parsing number and unit. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, IFormatProvider? provider, out {_unitEnumName} unit)
        {{
            return UnitParser.Default.TryParse(str, Info, provider, out unit);
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
        public static {_quantity.Name} operator *(double left, {_quantity.Name} right)
        {{
            // Logarithmic multiplication = addition
            return new {_quantity.Name}(left + right.Value, right.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic multiplication of value and <see cref=""{_quantity.Name}""/>.</summary>
        public static {_quantity.Name} operator *({_quantity.Name} left, double right)
        {{
            // Logarithmic multiplication = addition
            return new {_quantity.Name}(left.Value + right, left.Unit);
        }}

        /// <summary>Get <see cref=""{_quantity.Name}""/> from logarithmic division of <see cref=""{_quantity.Name}""/> by value.</summary>
        public static {_quantity.Name} operator /({_quantity.Name} left, double right)
        {{
            // Logarithmic division = subtraction
            return new {_quantity.Name}(left.Value - right, left.Unit);
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

        /// <summary>
        ///     Generates operators that express relations between quantities as applied by <see cref="QuantityRelationsParser" />.
        /// </summary>
        private void GenerateRelationalOperators()
        {
            if (!_quantity.Relations.Any()) return;

            Writer.WL($@"
        #region Relational Operators
");

            foreach (QuantityRelation relation in _quantity.Relations)
            {
                if (relation.Operator == "inverse")
                {
                    Writer.WL($@"
        /// <summary>Calculates the inverse of this quantity.</summary>
        /// <returns>The corresponding inverse quantity, <see cref=""{relation.RightQuantity.Name}""/>.</returns>
        public {relation.RightQuantity.Name} Inverse()
        {{
            return {relation.RightQuantity.Name}.From{relation.RightUnit.PluralName}(1 / {relation.LeftUnit.PluralName});
        }}
");
                }
                else
                {
                    var leftParameter = relation.LeftQuantity.Name.ToCamelCase();
                    var leftConversionProperty = relation.LeftUnit.PluralName;
                    var rightParameter = relation.RightQuantity.Name.ToCamelCase();
                    var rightConversionProperty = relation.RightUnit.PluralName;

                    if (leftParameter == rightParameter)
                    {
                        leftParameter = "left";
                        rightParameter = "right";
                    }

                    var leftPart = $"{leftParameter}.{leftConversionProperty}";
                    var rightPart = $"{rightParameter}.{rightConversionProperty}";

                    if (leftParameter is "double")
                    {
                        leftParameter = leftPart = "value";
                    }

                    if (rightParameter is "double")
                    {
                        rightParameter = rightPart = "value";
                    }

                    var expression = $"{leftPart} {relation.Operator} {rightPart}";

                    if (relation.ResultQuantity.Name is not "double")
                    {
                        expression = $"{relation.ResultQuantity.Name}.From{relation.ResultUnit.PluralName}({expression})";
                    }

                    Writer.WL($@"
        /// <summary>Get <see cref=""{relation.ResultQuantity.Name}""/> from <see cref=""{relation.LeftQuantity.Name}""/> {relation.Operator} <see cref=""{relation.RightQuantity.Name}""/>.</summary>
        public static {relation.ResultQuantity.Name} operator {relation.Operator}({relation.LeftQuantity.Name} {leftParameter}, {relation.RightQuantity.Name} {rightParameter})
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
        ///     of floating-point operations and using double internally.
        ///     </para>
        /// </summary>
        /// <param name=""other"">The other quantity to compare to.</param>
        /// <param name=""tolerance"">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name=""comparisonType"">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        [Obsolete(""Use Equals({_quantity.Name} other, {_quantity.Name} tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units."")]
        public bool Equals({_quantity.Name} other, double tolerance, ComparisonType comparisonType)
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
        public double As({_unitEnumName} unit)
        {{
            if (Unit == unit)
                return Value;

            return ToUnit(unit).Value;
        }}
");

            Writer.WL( $@"

        /// <inheritdoc cref=""IQuantity.As(UnitSystem)""/>
        public double As(UnitSystem unitSystem)
        {{
            return As(Info.GetDefaultUnit(unitSystem));
        }}
");

            Writer.WL($@"
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
");
            Writer.WL($@"
        /// <inheritdoc cref=""IQuantity.ToUnit(UnitSystem)""/>
        public {_quantity.Name} ToUnit(UnitSystem unitSystem)
        {{
            return ToUnit(Info.GetDefaultUnit(unitSystem));
        }}
");

            Writer.WL($@"
        #region Explicit implementations

        double IQuantity.As(Enum unit)
        {{
            if (unit is not {_unitEnumName} typedUnit)
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return As(typedUnit);
        }}

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {{
            if (!(unit is {_unitEnumName} typedUnit))
                throw new ArgumentException($""The given unit is of type {{unit.GetType()}}. Only {{typeof({_unitEnumName})}} is supported."", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }}

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<{_unitEnumName}> IQuantity<{_unitEnumName}>.ToUnit({_unitEnumName} unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<{_unitEnumName}> IQuantity<{_unitEnumName}>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        #endregion

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

        /// <summary>
        ///     Gets the default string representation of value and unit using the given format provider.
        /// </summary>
        /// <returns>String representation.</returns>
        /// <param name=""provider"">Format to use for localization and number formatting. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        public string ToString(IFormatProvider? provider)
        {{
            return ToString(null, provider);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TQuantity}}(TQuantity, string?, IFormatProvider?)""/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using <see cref=""CultureInfo.CurrentCulture"" />.
        /// </summary>
        /// <param name=""format"">The format string.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string? format)
        {{
            return ToString(format, null);
        }}

        /// <inheritdoc cref=""QuantityFormatter.Format{{TQuantity}}(TQuantity, string?, IFormatProvider?)""/>
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
