// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetWrcGen
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
using UnitsNet.Units;
using UnitsNet.InternalHelpers;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{");
            Writer.WLIfText(1, GetObsoleteAttributeOrNull(_quantity));
            Writer.WL($@"
    /// <summary>
    ///     {_quantity.XmlDoc}
    /// </summary>");

            Writer.WLCondition(_quantity.XmlDocRemarks.HasText(), $@"
    /// <remarks>
    ///     {_quantity.XmlDocRemarks}
    /// </remarks>");

            Writer.WL($@"
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class {_quantity.Name} : IQuantity
    {{
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly {_quantity.BaseType} _value;

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
            GenerateEqualityAndComparison();
            GenerateConversionMethods();
            GenerateToString();

            Writer.WL($@"
        private static IFormatProvider GetFormatProviderFromCultureName([CanBeNull] string cultureName)
        {{
            return cultureName != null ? new CultureInfo(cultureName) : (IFormatProvider)null;
        }}
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
            BaseDimensions = BaseDimensions.Dimensionless;"
                : $@"
            BaseDimensions = new BaseDimensions({baseDimensions.L}, {baseDimensions.M}, {baseDimensions.T}, {baseDimensions.I}, {baseDimensions.Θ}, {baseDimensions.N}, {baseDimensions.J});");

            Writer.WL($@"
            Info = new QuantityInfo(QuantityType.{_quantity.Name}, Units.Cast<Enum>().ToArray(), BaseUnit, Zero, BaseDimensions);
        }}
");
        }

        private void GenerateInstanceConstructors()
        {
            Writer.WL($@"
        /// <summary>
        ///     Creates the quantity with a value of 0 in the base unit {_baseUnit.SingularName}.
        /// </summary>
        /// <remarks>
        ///     Windows Runtime Component requires a default constructor.
        /// </remarks>
        public {_quantity.Name}()
        {{
            _value = 0;
            _unit = BaseUnit;
        }}

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name=""value"">The numeric value to construct this quantity with.</param>
        /// <param name=""unit"">The unit representation to construct this quantity with.</param>
        /// <remarks>Value parameter cannot be named 'value' due to constraint when targeting Windows Runtime Component.</remarks>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>
        private {_quantity.Name}({_quantity.BaseType} value, {_unitEnumName} unit)
        {{
            if(unit == {_unitEnumName}.Undefined)
              throw new ArgumentException(""The quantity can not be created with an undefined unit."", nameof(unit));
");

            Writer.WL(_quantity.BaseType == "double"
                ? @"
            _value = Guard.EnsureValidNumber(value, nameof(value));"
                : @"
            _value = value;");
            Writer.WL($@"
            _unit = unit;
        }}
");
        }

        private void GenerateStaticProperties()
        {
            Writer.WL($@"
        #region Static Properties

        /// <summary>
        ///     Information about the quantity type, such as unit values and names.
        /// </summary>
        internal static QuantityInfo Info {{ get; }}

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions {{ get; }}

        /// <summary>
        ///     The base unit of {_quantity.Name}, which is {_quantity.BaseUnit}. All conversions go via this value.
        /// </summary>
        public static {_unitEnumName} BaseUnit {{ get; }} = {_unitEnumName}.{_quantity.BaseUnit};

        /// <summary>
        /// Represents the largest possible value of {_quantity.Name}
        /// </summary>
        public static {_quantity.Name} MaxValue {{ get; }} = new {_quantity.Name}({_valueType}.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of {_quantity.Name}
        /// </summary>
        public static {_quantity.Name} MinValue {{ get; }} = new {_quantity.Name}({_valueType}.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref=""QuantityType"" /> of this quantity.
        /// </summary>
        public static QuantityType QuantityType {{ get; }} = QuantityType.{_quantity.Name};

        /// <summary>
        ///     All units of measurement for the {_quantity.Name} quantity.
        /// </summary>
        public static {_unitEnumName}[] Units {{ get; }} = Enum.GetValues(typeof({_unitEnumName})).Cast<{_unitEnumName}>().Except(new {_unitEnumName}[]{{ {_unitEnumName}.Undefined }}).ToArray();

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit {_quantity.BaseUnit}.
        /// </summary>
        public static {_quantity.Name} Zero {{ get; }} = new {_quantity.Name}(0, BaseUnit);

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
        public double Value => Convert.ToDouble(_value);
");

            Writer.WL($@"
        /// <inheritdoc cref=""IQuantity.Unit""/>
        object IQuantity.Unit => Unit;

        /// <summary>
        ///     The unit this quantity was constructed with -or- <see cref=""BaseUnit"" /> if default ctor was used.
        /// </summary>
        public {_unitEnumName} Unit => _unit.GetValueOrDefault(BaseUnit);

        internal QuantityInfo QuantityInfo => Info;

        /// <summary>
        ///     The <see cref=""QuantityType"" /> of this quantity.
        /// </summary>
        public QuantityType Type => {_quantity.Name}.QuantityType;

        /// <summary>
        ///     The <see cref=""BaseDimensions"" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => {_quantity.Name}.BaseDimensions;

        #endregion
");
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
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use when parsing number and unit. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public static string GetAbbreviation({_quantity.Name}Unit unit, [CanBeNull] string cultureName)
        {{
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
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
        ///     Get {_quantity.Name} from {unit.PluralName}.
        /// </summary>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        [Windows.Foundation.Metadata.DefaultOverload]
        public static {_quantity.Name} From{unit.PluralName}(double {valueParamName})
        {{
            {_valueType} value = ({_valueType}) {valueParamName};
            return new {_quantity.Name}(value, {_unitEnumName}.{unit.SingularName});
        }}");
            }

            Writer.WL();
            Writer.WL($@"
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref=""{_unitEnumName}"" /> to <see cref=""{_quantity.Name}"" />.
        /// </summary>
        /// <param name=""value"">Value to convert from.</param>
        /// <param name=""fromUnit"">Unit to convert from.</param>
        /// <returns>{_quantity.Name} unit value.</returns>
        // Fix name conflict with parameter ""value""
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName(""returnValue"")]
        public static {_quantity.Name} From(double value, {_unitEnumName} fromUnit)
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
        public static {_quantity.Name} Parse(string str)
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
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use when parsing number and unit. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public static {_quantity.Name} Parse(string str, [CanBeNull] string cultureName)
        {{
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.Parse<{_quantity.Name}, {_unitEnumName}>(
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
        public static bool TryParse([CanBeNull] string str, out {_quantity.Name} result)
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
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use when parsing number and unit. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public static bool TryParse([CanBeNull] string str, [CanBeNull] string cultureName, out {_quantity.Name} result)
        {{
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.TryParse<{_quantity.Name}, {_unitEnumName}>(
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
        /// <example>
        ///     Length.ParseUnit(""m"", new CultureInfo(""en-US""));
        /// </example>
        /// <exception cref=""ArgumentNullException"">The value of 'str' cannot be null. </exception>
        /// <exception cref=""UnitsNetException"">Error parsing string.</exception>
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use when parsing number and unit. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public static {_unitEnumName} ParseUnit(string str, [CanBeNull] string cultureName)
        {{
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.Parse<{_unitEnumName}>(str, provider);
        }}

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
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use when parsing number and unit. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public static bool TryParseUnit(string str, [CanBeNull] string cultureName, out {_unitEnumName} unit)
        {{
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.TryParse<{_unitEnumName}>(str, provider, out unit);
        }}

        #endregion
");
        }

        private void GenerateEqualityAndComparison()
        {
            Writer.WL($@"
        #region Equality / IComparable

        public int CompareTo(object obj)
        {{
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is {_quantity.Name} obj{_quantity.Name})) throw new ArgumentException(""Expected type {_quantity.Name}."", nameof(obj));

            return CompareTo(obj{_quantity.Name});
        }}

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal int CompareTo({_quantity.Name} other)
        {{
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }}

        [Windows.Foundation.Metadata.DefaultOverload]
        public override bool Equals(object obj)
        {{
            if(obj is null || !(obj is {_quantity.Name} obj{_quantity.Name}))
                return false;

            return Equals(obj{_quantity.Name});
        }}

        public bool Equals({_quantity.Name} other)
        {{
            return _value.Equals(other.AsBaseNumericType(this.Unit));
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
        ///     of floating point operations and using System.Double internally.
        ///     </para>
        /// </summary>
        /// <param name=""other"">The other quantity to compare to.</param>
        /// <param name=""tolerance"">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name=""comparisonType"">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        public bool Equals({_quantity.Name} other, double tolerance, ComparisonType comparisonType)
        {{
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException(""tolerance"", ""Tolerance must be greater than or equal to 0."");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }}

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current {_quantity.Name}.</returns>
        public override int GetHashCode()
        {{
            return new {{ QuantityType, Value, Unit }}.GetHashCode();
        }}

        #endregion
");
        }

        private void GenerateConversionMethods()
        {
            Writer.WL($@"
        #region Conversion Methods

        double IQuantity.As(object unit) => As(({_quantity.Name}Unit)unit);

        /// <summary>
        ///     Convert to the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As({_unitEnumName} unit)
        {{
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }}

        /// <summary>
        ///     Converts this {_quantity.Name} to another {_quantity.Name} with the unit representation <paramref name=""unit"" />.
        /// </summary>
        /// <returns>A {_quantity.Name} with the specified unit.</returns>
        public {_quantity.Name} ToUnit({_unitEnumName} unit)
        {{
            var convertedValue = AsBaseNumericType(unit);
            return new {_quantity.Name}(convertedValue, unit);
        }}

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private {_valueType} AsBaseUnit()
        {{
            switch(Unit)
            {{");
            foreach (var unit in _quantity.Units)
            {
                var func = unit.FromUnitToBaseFunc.Replace("x", "_value");
                Writer.WL($@"
                case {_unitEnumName}.{unit.SingularName}: return {func};");
            }

            Writer.WL($@"
                default:
                    throw new NotImplementedException($""Can not convert {{Unit}} to base units."");
            }}
        }}

        private {_valueType} AsBaseNumericType({_unitEnumName} unit)
        {{
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

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
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {{
            return ToString(null);
        }}

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <returns>String representation.</returns>
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use for localization and number formatting. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public string ToString([CanBeNull] string cultureName)
        {{
            var provider = cultureName;
            return ToString(provider, 2);
        }}

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name=""significantDigitsAfterRadix"">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use for localization and number formatting. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public string ToString(string cultureName, int significantDigitsAfterRadix)
        {{
            var provider = cultureName;
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
        /// <param name=""cultureName"">Name of culture (ex: ""en-US"") to use for localization and number formatting. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        public string ToString([CanBeNull] string cultureName, [NotNull] string format, [NotNull] params object[] args)
        {{
            var provider = GetFormatProviderFromCultureName(cultureName);
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

            provider = provider ?? GlobalConfiguration.DefaultCulture;

            var value = Convert.ToDouble(Value);
            var formatArgs = UnitFormatter.GetFormatArgs(Unit, value, provider, args);
            return string.Format(provider, format, formatArgs);
        }}

        #endregion
");
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
            : $"[System.Obsolete({obsoleteText})]";
    }
}
