using System;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitTestBaseClassGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;
        private readonly Unit _baseUnit;
        private readonly string _unitEnumName;

        public UnitTestBaseClassGenerator(Quantity quantity)
        {
            _quantity = quantity;
            _baseUnit = quantity.Units.FirstOrDefault(u => u.SingularName == _quantity.BaseUnit) ??
                        throw new ArgumentException($"No unit found with SingularName equal to BaseUnit [{_quantity.BaseUnit}]. This unit must be defined.",
                            nameof(quantity));
            _unitEnumName = $"{quantity.Name}Unit";
        }

        public override string Generate()
        {
            var baseUnitVariableName = _baseUnit.SingularName.ToLowerInvariant();

            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{{
    /// <summary>
    /// Test of {_quantity.Name}.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class {_quantity.Name}TestsBase
    {{");
            foreach (var unit in _quantity.Units) Writer.WL($@"
        protected abstract double {unit.PluralName}InOne{_baseUnit.SingularName} {{ get; }}");

            Writer.WL("");
            Writer.WL($@"
// ReSharper disable VirtualMemberNeverOverriden.Global");
            foreach (var unit in _quantity.Units) Writer.WL($@"
        protected virtual double {unit.PluralName}Tolerance {{ get {{ return 1e-5; }} }}"); Writer.WL($@"
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {{
            Assert.Throws<ArgumentException>(() => new {_quantity.Name}(({_quantity.BaseType})0.0, {_unitEnumName}.Undefined));
        }}
");
            if (_quantity.BaseType == "double") Writer.WL($@"
        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {{
            Assert.Throws<ArgumentException>(() => new {_quantity.Name}(double.PositiveInfinity, {_unitEnumName}.{_baseUnit.SingularName}));
            Assert.Throws<ArgumentException>(() => new {_quantity.Name}(double.NegativeInfinity, {_unitEnumName}.{_baseUnit.SingularName}));
        }}

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {{
            Assert.Throws<ArgumentException>(() => new {_quantity.Name}(double.NaN, {_unitEnumName}.{_baseUnit.SingularName}));
        }}
"); Writer.WL($@"

        [Fact]
        public void {_baseUnit.SingularName}To{_quantity.Name}Units()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");

            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance({unit.PluralName}InOne{_baseUnit.SingularName}, {baseUnitVariableName}.{unit.PluralName}, {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}

        [Fact]
        public void FromValueAndUnit()
        {{");
            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance(1, {_quantity.Name}.From(1, {_unitEnumName}.{unit.SingularName}).{unit.PluralName}, {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}
");
            if (_quantity.BaseType == "double") Writer.WL($@"
        [Fact]
        public void From{_baseUnit.PluralName}_WithInfinityValue_ThrowsArgumentException()
        {{
            Assert.Throws<ArgumentException>(() => {_quantity.Name}.From{_baseUnit.PluralName}(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => {_quantity.Name}.From{_baseUnit.PluralName}(double.NegativeInfinity));
        }}

        [Fact]
        public void From{_baseUnit.PluralName}_WithNanValue_ThrowsArgumentException()
        {{
            Assert.Throws<ArgumentException>(() => {_quantity.Name}.From{_baseUnit.PluralName}(double.NaN));
        }}
"); Writer.WL($@"

        [Fact]
        public void As()
        {{
            var {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");
            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance({unit.PluralName}InOne{_baseUnit.SingularName}, {baseUnitVariableName}.As({_unitEnumName}.{unit.SingularName}), {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}

        [Fact]
        public void ToUnit()
        {{
            var {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");
            foreach (var unit in _quantity.Units)
            {
                var asQuantityVariableName = $"{unit.SingularName.ToLowerInvariant()}Quantity";

                Writer.WL("");
                Writer.WL($@"
            var {asQuantityVariableName} = {baseUnitVariableName}.ToUnit({_unitEnumName}.{unit.SingularName});
            AssertEx.EqualTolerance({unit.PluralName}InOne{_baseUnit.SingularName}, (double){asQuantityVariableName}.Value, {unit.PluralName}Tolerance);
            Assert.Equal({_unitEnumName}.{unit.SingularName}, {asQuantityVariableName}.Unit);");
            }
            Writer.WL($@"
        }}

        [Fact]
        public void ConversionRoundTrip()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");
            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance(1, {_quantity.Name}.From{unit.PluralName}({baseUnitVariableName}.{unit.PluralName}).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}
");
            if (_quantity.Logarithmic)
            {
                var unit = _quantity.Units.Last();
                Writer.WL($@"
        [Fact]
        public void LogarithmicArithmeticOperators()
        {{
            {_quantity.Name} v = {_quantity.Name}.From{_baseUnit.PluralName}(40);
            AssertEx.EqualTolerance(-40, -v.{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertEx.EqualTolerance(50, (10*v).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertEx.EqualTolerance(35, (v/5).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertEx.EqualTolerance(35, v/{_quantity.Name}.From{_baseUnit.PluralName}(5), {unit.PluralName}Tolerance);
        }}

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();
");
            }
            else if (_quantity.GenerateArithmetic)
            {
                Writer.WL($@"
        [Fact]
        public void ArithmeticOperators()
        {{
            {_quantity.Name} v = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            AssertEx.EqualTolerance(-1, -v.{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, ({_quantity.Name}.From{_baseUnit.PluralName}(3)-v).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, (v + v).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(10, (v*10).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(10, (10*v).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, ({_quantity.Name}.From{_baseUnit.PluralName}(10)/5).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, {_quantity.Name}.From{_baseUnit.PluralName}(10)/{_quantity.Name}.From{_baseUnit.PluralName}(5), {_baseUnit.PluralName}Tolerance);
        }}
");
            }
            else
            {
                Writer.WL("");
            }

            Writer.WL($@"
        [Fact]
        public void ComparisonOperators()
        {{
            {_quantity.Name} one{_baseUnit.SingularName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            {_quantity.Name} two{_baseUnit.PluralName} = {_quantity.Name}.From{_baseUnit.PluralName}(2);

            Assert.True(one{_baseUnit.SingularName} < two{_baseUnit.PluralName});
            Assert.True(one{_baseUnit.SingularName} <= two{_baseUnit.PluralName});
            Assert.True(two{_baseUnit.PluralName} > one{_baseUnit.SingularName});
            Assert.True(two{_baseUnit.PluralName} >= one{_baseUnit.SingularName});

            Assert.False(one{_baseUnit.SingularName} > two{_baseUnit.PluralName});
            Assert.False(one{_baseUnit.SingularName} >= two{_baseUnit.PluralName});
            Assert.False(two{_baseUnit.PluralName} < one{_baseUnit.SingularName});
            Assert.False(two{_baseUnit.PluralName} <= one{_baseUnit.SingularName});
        }}

        [Fact]
        public void CompareToIsImplemented()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.Equal(0, {baseUnitVariableName}.CompareTo({baseUnitVariableName}));
            Assert.True({baseUnitVariableName}.CompareTo({_quantity.Name}.Zero) > 0);
            Assert.True({_quantity.Name}.Zero.CompareTo({baseUnitVariableName}) < 0);
        }}

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.Throws<ArgumentException>(() => {baseUnitVariableName}.CompareTo(new object()));
        }}

        [Fact]
        public void CompareToThrowsOnNull()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.Throws<ArgumentNullException>(() => {baseUnitVariableName}.CompareTo(null));
        }}

        [Fact]
        public void EqualityOperators()
        {{
            var a = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            var b = {_quantity.Name}.From{_baseUnit.PluralName}(2);

 // ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
        }}

        [Fact]
        public void EqualsIsImplemented()
        {{
            var a = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            var b = {_quantity.Name}.From{_baseUnit.PluralName}(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }}

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {{
            var v = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.True(v.Equals({_quantity.Name}.From{_baseUnit.PluralName}(1), {_baseUnit.PluralName}Tolerance, ComparisonType.Relative));
            Assert.False(v.Equals({_quantity.Name}.Zero, {_baseUnit.PluralName}Tolerance, ComparisonType.Relative));
        }}

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.False({baseUnitVariableName}.Equals(new object()));
        }}

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.False({baseUnitVariableName}.Equals(null));
        }}

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {{
            Assert.DoesNotContain({_unitEnumName}.Undefined, {_quantity.Name}.Units);
        }}

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {{
            var units = Enum.GetValues(typeof({_unitEnumName})).Cast<{_unitEnumName}>();
            foreach(var unit in units)
            {{
                if(unit == {_unitEnumName}.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }}
        }}

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {{
            Assert.False({_quantity.Name}.BaseDimensions is null);
        }}
    }}
}}");
            return Writer.ToString();
        }
    }
}
