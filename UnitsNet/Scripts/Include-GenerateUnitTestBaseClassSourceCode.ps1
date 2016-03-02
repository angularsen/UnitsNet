function GenerateUnitTestBaseClassSourceCode($unitClass)
{
    $className = $unitClass.Name;
    $baseType = $unitClass.BaseType;
    $units = $unitClass.Units;
    $baseUnit = $units | where { $_.SingularName -eq $unitClass.BaseUnit }
    $baseUnitPluralName = $baseUnit.PluralName
    $baseUnitVariableName = $baseUnit.SingularName.ToLowerInvariant();
    $unitEnumName = "$($className)Unit";

@"
// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;
using UnitsNet.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of $className.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class $($className)TestsBase
    {
"@;    foreach ($unit in $units) {@"
        protected abstract double $($unit.PluralName)InOne$($baseUnit.SingularName) { get; }
"@; }@"

// ReSharper disable VirtualMemberNeverOverriden.Global
"@;    foreach ($unit in $units) {@"
        protected virtual double $($unit.PluralName)Tolerance { get { return 1e-5; } }
"@; }@"
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void $($baseUnit.SingularName)To$($className)Units()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
"@; foreach ($unit in $units) {@"
            Assert.AreEqual($($unit.PluralName)InOne$($baseUnit.SingularName), $baseUnitVariableName.$($unit.PluralName), $($unit.PluralName)Tolerance);
"@; }@"
        }

        [Test]
        public void FromValueAndUnit()
        {
"@; foreach ($unit in $units) {@"
            Assert.AreEqual(1, $className.From(1, $unitEnumName.$($unit.SingularName)).$($unit.PluralName), $($unit.PluralName)Tolerance);
"@; }@"
        }

        [Test]
        public void As()
        {
            var $baseUnitVariableName = $className.From$baseUnitPluralName(1);
"@; foreach ($unit in $units) {@"
            Assert.AreEqual($($unit.PluralName)InOne$($baseUnit.SingularName), $baseUnitVariableName.As($($className)Unit.$($unit.SingularName)), $($unit.PluralName)Tolerance);
"@; }@"
        }

        [Test]
        public void ConversionRoundTrip()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
"@; foreach ($unit in $units) {@"
            Assert.AreEqual(1, $className.From$($unit.PluralName)($baseUnitVariableName.$($unit.PluralName)).$baseUnitPluralName, $($unit.PluralName)Tolerance);
"@; }@"
        }

"@; if ($unitClass.Logarithmic -eq $true) {
        # Call another script function to generate logarithm-specific arithmetic operator test code.
        GenerateLogarithmicTestBaseClassSourceCode -className $className -baseUnitPluralName $baseUnitPluralName -unit $unit
    }
    else {@"
        [Test]
        public void ArithmeticOperators()
        {
            $className v = $className.From$baseUnitPluralName(1);
            Assert.AreEqual(-1, -v.$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            Assert.AreEqual(2, ($className.From$baseUnitPluralName(3)-v).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            Assert.AreEqual(2, (v + v).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            Assert.AreEqual(10, (v*10).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            Assert.AreEqual(10, (10*v).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            Assert.AreEqual(2, ($className.From$baseUnitPluralName(10)/5).$baseUnitPluralName, $($baseUnit.PluralName)Tolerance);
            Assert.AreEqual(2, $className.From$baseUnitPluralName(10)/$className.From$baseUnitPluralName(5), $($baseUnit.PluralName)Tolerance);
        }
"@; }@"

        [Test]
        public void ComparisonOperators()
        {
            $className one$($baseUnit.SingularName) = $className.From$baseUnitPluralName(1);
            $className two$baseUnitPluralName = $className.From$baseUnitPluralName(2);

            Assert.True(one$($baseUnit.SingularName) < two$baseUnitPluralName);
            Assert.True(one$($baseUnit.SingularName) <= two$baseUnitPluralName);
            Assert.True(two$baseUnitPluralName > one$($baseUnit.SingularName));
            Assert.True(two$baseUnitPluralName >= one$($baseUnit.SingularName));

            Assert.False(one$($baseUnit.SingularName) > two$baseUnitPluralName);
            Assert.False(one$($baseUnit.SingularName) >= two$baseUnitPluralName);
            Assert.False(two$baseUnitPluralName < one$($baseUnit.SingularName));
            Assert.False(two$baseUnitPluralName <= one$($baseUnit.SingularName));
        }

        [Test]
        public void CompareToIsImplemented()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
            Assert.AreEqual(0, $baseUnitVariableName.CompareTo($baseUnitVariableName));
            Assert.Greater($baseUnitVariableName.CompareTo($className.Zero), 0);
            Assert.Less($className.Zero.CompareTo($baseUnitVariableName), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            $baseUnitVariableName.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            $baseUnitVariableName.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            $className a = $className.From$baseUnitPluralName(1);
            $className b = $className.From$baseUnitPluralName(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a);
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsIsImplemented()
        {
            $className v = $className.From$baseUnitPluralName(1);
            Assert.IsTrue(v.Equals($className.From$baseUnitPluralName(1)));
            Assert.IsFalse(v.Equals($className.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
            Assert.IsFalse($baseUnitVariableName.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            $className $baseUnitVariableName = $className.From$baseUnitPluralName(1);
            Assert.IsFalse($baseUnitVariableName.Equals(null));
        }
    }
}
"@;
}
