using System;
using System.Collections.Generic;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityComparisonTests
    {
        [Fact]
        public void CompareTo_WithSameQuantityInAnotherUnit_ReturnsZero()
        {
            var firstMass = Mass.FromGrams(0.001);
            var secondMass = firstMass.ToUnit(MassUnit.Microgram);

            Assert.Equal(0, firstMass.CompareTo(secondMass));
            Assert.Equal(0, secondMass.CompareTo(firstMass));
        }

        [Fact]
        public void CompareTo_WithVeryCloseQuantity_ReturnsNonZero()
        {
            var firstMass = Mass.FromGrams(0);
            var secondMass = Mass.FromGrams(double.Epsilon);

            Assert.Equal(-1, firstMass.CompareTo(secondMass));
            Assert.Equal(1, secondMass.CompareTo(firstMass));
        }

        [Fact]
        public void Equals_WithSameQuantityInAnotherUnit_IsNotReflexive()
        {
            var firstMass = Mass.FromGrams(0.001);
            var secondMass = firstMass.ToUnit(MassUnit.Microgram);

            Assert.NotEqual(firstMass, secondMass);
            Assert.Equal(secondMass, firstMass);
        }

        [Fact]
        public void Equals_WithVeryCloseQuantityInSameUnit_ReturnsFalse()
        {
            var firstMass = Mass.FromGrams(0);
            var secondMass = Mass.FromGrams(double.Epsilon);

            Assert.NotEqual(firstMass, secondMass);
            Assert.NotEqual(secondMass, firstMass);
        }

        [Fact]
        public void GetHashCode_WithSameQuantityInAnotherUnit_ReturnsSameValue()
        {
            var firstMass = Mass.FromGrams(0.001);
            var secondMass = firstMass.ToUnit(MassUnit.Microgram);

            Assert.Equal(firstMass.GetHashCode(), secondMass.GetHashCode());
        }

        [Fact]
        public void GetHashCode_WithVeryCloseQuantities_ReturnsSameValue()
        {
            var firstMass = Mass.FromGrams(0);
            var secondMass = Mass.FromGrams(double.Epsilon);

            Assert.Equal(firstMass.GetHashCode(), secondMass.GetHashCode());
        }

        [Fact]
        public void Contains_CollectionWithMixedUnits_DependsOnTheOrderOfInsertion()
        {
            var firstMass = Mass.FromGrams(0.001);
            var secondMass = firstMass.ToUnit(MassUnit.Microgram);

            var collectionWithFirst = new HashSet<Mass> {firstMass};
            var collectionWithSecond = new HashSet<Mass> {secondMass};

            Assert.Contains(firstMass, collectionWithFirst);
            Assert.DoesNotContain(secondMass, collectionWithFirst);

            Assert.Contains(firstMass, collectionWithSecond);
            Assert.Contains(secondMass, collectionWithSecond);
        }

        [Fact]
        public void Contains_CollectionWithVeryCloseQuantities_ReturnsTrueIfValuesAreStrictlyEqual()
        {
            var firstMass = Mass.FromGrams(0);
            var secondMass = Mass.FromGrams(double.Epsilon);

            var collection = new HashSet<Mass> {firstMass};

            // equal hash codes do not imply object equality
            Assert.Equal(firstMass.GetHashCode(), secondMass.GetHashCode());
            Assert.NotEqual(firstMass, secondMass);

            // Contains first checks HashCode, followed by Equals check
            Assert.Contains(firstMass, collection);
            Assert.DoesNotContain(secondMass, collection);
        }

        [Fact]
        public void Sort_CollectionWithMixedUnits_SortedByNaturalOrder()
        {
            var firstMass = Mass.FromGrams(0);
            var secondMass = Mass.FromGrams(double.Epsilon);
            var thirdMass = Mass.FromGrams(0.001);
            var fourthMass = thirdMass.ToUnit(MassUnit.Microgram);

            var collection = new[] {thirdMass, firstMass, fourthMass, secondMass};
            Array.Sort(collection);

            Assert.Equal(firstMass, collection[0]);
            Assert.Equal(secondMass, collection[1]);
            Assert.Equal(thirdMass, collection[2]);
            Assert.Equal(fourthMass, collection[3]);
        }
    }
}
