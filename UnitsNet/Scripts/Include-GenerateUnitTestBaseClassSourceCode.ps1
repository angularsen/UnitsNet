﻿using module ".\Types.psm1"
function GenerateUnitTestBaseClassSourceCode([Quantity]$quantity)
{
    $quantityName = $quantity.Name
    $units = $quantity.Units
    $valueType = $quantity.BaseType
    [Unit]$baseUnit = $units | where { $_.SingularName -eq $quantity.BaseUnit } | Select-Object -First 1
    $baseUnitSingularName = $baseUnit.SingularName
    $baseUnitPluralName = $baseUnit.PluralName
    $baseUnitVariableName = $baseUnitSingularName.ToLowerInvariant()
    $unitEnumName = "$quantityName" + "Unit"

@"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of $quantityName.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class $($quantityName)TestsBase
    {
"@;    foreach ($unit in $units) {@"
        protected abstract double $($unit.PluralName)InOne$($baseUnit.SingularName) { get; }
"@; }@"

// ReSharper disable VirtualMemberNeverOverriden.Global
"@;    foreach ($unit in $units) {@"
        protected virtual double $($unit.PluralName)Tolerance { get { return 1e-5; } }
"@; }@"
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new $quantityName(($valueType)0.0, $unitEnumName.Undefined));
        }

"@; if ($quantity.BaseType -eq "double") {@"
        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new $quantityName(double.PositiveInfinity, $unitEnumName.$($baseUnit.SingularName)));
            Assert.Throws<ArgumentException>(() => new $quantityName(double.NegativeInfinity, $unitEnumName.$($baseUnit.SingularName)));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new $quantityName(double.NaN, $unitEnumName.$($baseUnit.SingularName)));
        }
"@; }@"

        [Fact]
        public void $($baseUnit.SingularName)To$($quantityName)Units()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
"@; foreach ($unit in $units) {@"
            AssertEx.EqualTolerance($($unit.PluralName)InOne$($baseUnit.SingularName), $baseUnitVariableName.$($unit.PluralName), $($unit.PluralName)Tolerance);
"@; }@"
        }

        [Fact]
        public void FromValueAndUnit()
        {
"@; foreach ($unit in $units) {@"
            AssertEx.EqualTolerance(1, $quantityName.From(1, $unitEnumName.$($unit.SingularName)).$($unit.PluralName), $($unit.PluralName)Tolerance);
"@; }@"
        }

"@; if ($quantity.BaseType -eq "double") {@"
        [Fact]
        public void From$($baseUnit.PluralName)_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => $quantityName.From$($baseUnit.PluralName)(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => $quantityName.From$($baseUnit.PluralName)(double.NegativeInfinity));
        }

        [Fact]
        public void From$($baseUnit.PluralName)_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => $quantityName.From$($baseUnit.PluralName)(double.NaN));
        }
"@; }@"

        [Fact]
        public void As()
        {
            var $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
"@; foreach ($unit in $units) {@"
            AssertEx.EqualTolerance($($unit.PluralName)InOne$($baseUnit.SingularName), $baseUnitVariableName.As($($quantityName)Unit.$($unit.SingularName)), $($unit.PluralName)Tolerance);
"@; }@"
        }

        [Fact]
        public void ToUnit()
        {
            var $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
"@; foreach ($unit in $units)
{
        $asQuantityVariableName = "$($unit.SingularName.ToLowerInvariant())Quantity";
@"

            var $asQuantityVariableName = $baseUnitVariableName.ToUnit($($quantityName)Unit.$($unit.SingularName));
            AssertEx.EqualTolerance($($unit.PluralName)InOne$($baseUnit.SingularName), (double)$asQuantityVariableName.Value, $($unit.PluralName)Tolerance);
            Assert.Equal($($quantityName)Unit.$($unit.SingularName), $asQuantityVariableName.Unit);
"@; }@"
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
"@; foreach ($unit in $units) {@"
            AssertEx.EqualTolerance(1, $quantityName.From$($unit.PluralName)($baseUnitVariableName.$($unit.PluralName)).$baseUnitPluralName, $($unit.PluralName)Tolerance);
"@; }@"
        }

"@; if ($quantity.Logarithmic -eq $true) {@"
        [Fact]
        public void LogarithmicArithmeticOperators()
        {
            $quantityName v = $quantityName.From$baseUnitPluralName(40);
            AssertEx.EqualTolerance(-40, -v.$baseUnitPluralName, $($unit.PluralName)Tolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            AssertEx.EqualTolerance(50, (10*v).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            AssertEx.EqualTolerance(35, (v/5).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            AssertEx.EqualTolerance(35, v/$quantityName.From$baseUnitPluralName(5), $($unit.PluralName)Tolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();

"@; }
    elseif ($quantity.GenerateArithmetic -eq $true) {@"
        [Fact]
        public void ArithmeticOperators()
        {
            $quantityName v = $quantityName.From$baseUnitPluralName(1);
            AssertEx.EqualTolerance(-1, -v.$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            AssertEx.EqualTolerance(2, ($quantityName.From$baseUnitPluralName(3)-v).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            AssertEx.EqualTolerance(2, (v + v).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            AssertEx.EqualTolerance(10, (v*10).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            AssertEx.EqualTolerance(10, (10*v).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            AssertEx.EqualTolerance(2, ($quantityName.From$baseUnitPluralName(10)/5).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            AssertEx.EqualTolerance(2, $quantityName.From$baseUnitPluralName(10)/$quantityName.From$baseUnitPluralName(5), $($baseUnit.PluralName)Tolerance);
        }
"@; }@"

        [Fact]
        public void ComparisonOperators()
        {
            $quantityName one$($baseUnit.SingularName) = $quantityName.From$baseUnitPluralName(1);
            $quantityName two$baseUnitPluralName = $quantityName.From$baseUnitPluralName(2);

            Assert.True(one$($baseUnit.SingularName) < two$baseUnitPluralName);
            Assert.True(one$($baseUnit.SingularName) <= two$baseUnitPluralName);
            Assert.True(two$baseUnitPluralName > one$($baseUnit.SingularName));
            Assert.True(two$baseUnitPluralName >= one$($baseUnit.SingularName));

            Assert.False(one$($baseUnit.SingularName) > two$baseUnitPluralName);
            Assert.False(one$($baseUnit.SingularName) >= two$baseUnitPluralName);
            Assert.False(two$baseUnitPluralName < one$($baseUnit.SingularName));
            Assert.False(two$baseUnitPluralName <= one$($baseUnit.SingularName));
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
            Assert.Equal(0, $baseUnitVariableName.CompareTo($baseUnitVariableName));
            Assert.True($baseUnitVariableName.CompareTo($quantityName.Zero) > 0);
            Assert.True($quantityName.Zero.CompareTo($baseUnitVariableName) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
            Assert.Throws<ArgumentException>(() => $baseUnitVariableName.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
            Assert.Throws<ArgumentNullException>(() => $baseUnitVariableName.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = $quantityName.From$baseUnitPluralName(1);
            var b = $quantityName.From$baseUnitPluralName(2);

 // ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            var a = $quantityName.From$baseUnitPluralName(1);
            var b = $quantityName.From$baseUnitPluralName(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = $quantityName.From$baseUnitPluralName(1);
            Assert.True(v.Equals($quantityName.From$baseUnitPluralName(1), $($baseUnitPluralName)Tolerance, ComparisonType.Relative));
            Assert.False(v.Equals($quantityName.Zero, $($baseUnitPluralName)Tolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
            Assert.False($baseUnitVariableName.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            $quantityName $baseUnitVariableName = $quantityName.From$baseUnitPluralName(1);
            Assert.False($baseUnitVariableName.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain($unitEnumName.Undefined, $quantityName.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof($unitEnumName)).Cast<$unitEnumName>();
            foreach(var unit in units)
            {
                if(unit == $unitEnumName.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False($quantityName.BaseDimensions is null);
        }
    }
}
"@;
}
