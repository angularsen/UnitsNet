// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitOfTests
    {
        // 1 furlong = 201.168 m
        private static readonly UnitOf<Length> Furlong = new("Furlong", "Furlongs", 201.168);

        [Fact]
        public void Constructor_SetsNames()
        {
            Assert.Equal("Furlong", Furlong.Name);
            Assert.Equal("Furlongs", Furlong.PluralName);
        }

        [Fact]
        public void Constructor_WithNullArguments_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitOf<Length>(null!, "Furlongs", 1));
            Assert.Throws<ArgumentNullException>(() => new UnitOf<Length>("Furlong", null!, 1));
            Assert.Throws<ArgumentNullException>(() => new UnitOf<Length>("Furlong", "Furlongs", (BaseUnits)null!, 1));
        }

        [Fact]
        public void BaseUnits_WhenNotGiven_IsUndefined()
        {
            Assert.Equal(BaseUnits.Undefined, Furlong.BaseUnits);
        }

        [Fact]
        public void Constructor_WithBaseUnits_KeepsThem()
        {
            var baseUnits = new BaseUnits(length: LengthUnit.Foot, time: DurationUnit.Day);
            var footPerDay = new UnitOf<Speed>("FootPerDay", "FeetPerDay", baseUnits, 0.3048 / 86400);

            Assert.Equal(baseUnits, footPerDay.BaseUnits);
            Assert.Equal(86400, Speed.FromFeetPerSecond(1).As(footPerDay), 9);
        }

        [Fact]
        public void ToString_ReturnsName()
        {
            Assert.Equal("Furlong", Furlong.ToString());
        }

        [Fact]
        public void As_ReturnsValueInThatUnit()
        {
            Assert.Equal(1, Length.FromFeet(660).As(Furlong), 12);
            Assert.Equal(8, Length.FromMiles(1).As(Furlong), 12);
        }

        [Fact]
        public void As_FromOtherUnitOfTheQuantity_ReturnsValueInThatUnit()
        {
            Assert.Equal(1, Length.FromKilometers(0.201168).As(Furlong), 12);
        }

        [Fact]
        public void As_NullUnit_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Length.FromMeters(1).As((UnitOf<Length>)null!));
        }

        [Fact]
        public void From_ReturnsQuantityInBaseUnit()
        {
            Length length = Length.Info.From(2, Furlong);

            Assert.Equal(LengthUnit.Meter, length.Unit);
            Assert.Equal(402.336, length.Value, 12);
        }

        [Fact]
        public void From_RoundTripsWithAs()
        {
            Assert.Equal(42, Length.Info.From(42, Furlong).As(Furlong), 12);
        }

        [Fact]
        public void From_InfoOfAnotherQuantity_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Mass.Info.From(1, Furlong));
        }

        [Fact]
        public void From_NullArguments_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Length.Info.From(1, (UnitOf<Length>)null!));
            Assert.Throws<ArgumentNullException>(() => ((QuantityInfo)null!).From(1, Furlong));
        }
    }
}
