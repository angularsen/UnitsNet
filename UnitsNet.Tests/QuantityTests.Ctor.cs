using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    [UsedImplicitly]
    public partial class QuantityTests
    {
        /// <summary>
        /// Tests constructors of quantity types.
        /// </summary>
        public class Ctor
        {
            [Fact]
            [SuppressMessage("ReSharper", "ObjectCreationAsStatement", Justification = "Only testing the ctor itself, not the resulting value.")]
            public void DefaultCtorOfRepresentativeTypes_DoesNotThrow()
            {
                // double types
                new Length();

                // decimal types
                new Information();

                // logarithmic types
                new Level();
            }

            [Fact]
            public void DefaultCtorOfRepresentativeTypes_SetsValueToZeroAndUnitToBaseUnit()
            {
                // double types
                Assert.Equal(0, new Mass().Value);
                Assert.Equal(MassUnit.Kilogram, new Mass().Unit);

                // decimal types
                Assert.Equal(0, new Information().Value);
                Assert.Equal(InformationUnit.Bit, new Information().Unit);

                // logarithmic types
                Assert.Equal(0, new Level().Value);
                Assert.Equal(LevelUnit.Decibel, new Level().Unit);
            }

            /// <summary>
            ///     This test is a bit misplaced, but was added because when working on #389 unit+value there were two
            ///     ways to implement this; either assume BaseUnit of unit is not specified or throw if quantity did not have unit explicitly set.
            ///     Struct types do not allow custom default ctor implementations, so that exception would then be thrown when trying to convert.
            /// </summary>
            [Fact]
            public void DefaultCtorOfRepresentativeTypes_DoesNotThrowWhenConvertingToOtherUnits()
            {
                // double types
                Assert.Equal(0, new Mass().Hectograms);

                // decimal types
                Assert.Equal(0, new Information().Kibibits);

                // logarithmic types
                Assert.Equal(0, new Level().Nepers);
            }

            [Fact]
            public void CtorWithOnlyValueOfRepresentativeTypes_SetsValueToGivenValueAndUnitToBaseUnit()
            {
#pragma warning disable 618
                // double types
                Assert.Equal(5, new Mass(5L, MassUnit.Kilogram).Value);
                Assert.Equal(5, new Mass(5d, MassUnit.Kilogram).Value);
                Assert.Equal(MassUnit.Kilogram, new Mass(5L, MassUnit.Kilogram).Unit);
                Assert.Equal(MassUnit.Kilogram, new Mass(5d, MassUnit.Kilogram).Unit);

                // decimal types
                Assert.Equal(5, new Information(5L, InformationUnit.Bit).Value);
                Assert.Equal(5, new Information(5m, InformationUnit.Bit).Value);
                Assert.Equal(InformationUnit.Bit, new Information(5L, InformationUnit.Bit).Unit);
                Assert.Equal(InformationUnit.Bit, new Information(5m, InformationUnit.Bit).Unit);

                // logarithmic types
                Assert.Equal(5, new Level(5L, LevelUnit.Decibel).Value);
                Assert.Equal(5, new Level(5d, LevelUnit.Decibel).Value);
                Assert.Equal(LevelUnit.Decibel, new Level(5L, LevelUnit.Decibel).Unit);
                Assert.Equal(LevelUnit.Decibel, new Level(5d, LevelUnit.Decibel).Unit);
#pragma warning restore 618
            }

            [Fact]
            public void CtorWithValueAndUnitOfRepresentativeTypes_SetsValueAndUnit()
            {
                // double types
                var mass = new Mass(5L, MassUnit.Centigram);
                Assert.Equal(5, mass.Value);
                Assert.Equal(MassUnit.Centigram, mass.Unit);

                // decimal types
                var information = new Information(5, InformationUnit.Kibibit);
                Assert.Equal(5, information.Value);
                Assert.Equal(InformationUnit.Kibibit, information.Unit);

                // logarithmic types
                var level = new Level(5, LevelUnit.Neper);
                Assert.Equal(5, level.Value);
                Assert.Equal(LevelUnit.Neper, level.Unit);
            }

            [Fact]
            public void Constructor_UnitSystemGivenNull_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new Length(1.0, null));
            }
        }
    }
}
