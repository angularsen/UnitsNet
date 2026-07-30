// Licensed under MIT No Attribution, see LICENSE file at the root.

extern alias Generated;
extern alias Legacy;

using Xunit;

namespace UnitsNet.Modular.Compatibility.Tests;

public sealed class UnitsNetCoreIntegrationTests
{
    [Fact]
    public void LegacyQuantities_ImplementSharedCoreContract()
    {
        Type contract = typeof(UnitsNet.Core.IQuantity<double>);
        Type[] legacyTypes =
        {
            typeof(Legacy::UnitsNet.Length),
            typeof(Legacy::UnitsNet.Mass),
            typeof(Legacy::UnitsNet.Duration),
            typeof(Legacy::UnitsNet.Area),
            typeof(Legacy::UnitsNet.Speed),
            typeof(Legacy::UnitsNet.Acceleration),
            typeof(Legacy::UnitsNet.Force),
            typeof(Legacy::UnitsNet.Pressure),
            typeof(Legacy::UnitsNet.Energy),
            typeof(Legacy::UnitsNet.Power),
            typeof(Legacy::UnitsNet.Temperature),
            typeof(Legacy::UnitsNet.TemperatureDelta),
            typeof(Legacy::UnitsNet.Level),
            typeof(Legacy::UnitsNet.Information),
        };

        Assert.All(legacyTypes, type => Assert.True(contract.IsAssignableFrom(type), type.FullName));
    }

    [Fact]
    public void LegacyLength_ImplementsSelfTypedCoreContract()
    {
        AssertSelfTypedContract<Legacy::UnitsNet.Length, Legacy::UnitsNet.Units.LengthUnit>(
            Legacy::UnitsNet.Units.LengthUnit.Meter,
            Legacy::UnitsNet.Units.LengthUnit.Kilometer);
    }

    [Fact]
    public void LegacyQuantities_ImplementCapabilityContracts()
    {
        AssertLinearCapabilities<Legacy::UnitsNet.Length, Legacy::UnitsNet.Units.LengthUnit>();
        AssertAffineCapabilities<
            Legacy::UnitsNet.Temperature,
            Legacy::UnitsNet.Units.TemperatureUnit,
            Legacy::UnitsNet.TemperatureDelta>();
        AssertLinearCapabilities<
            Legacy::UnitsNet.TemperatureDelta,
            Legacy::UnitsNet.Units.TemperatureDeltaUnit>();
        AssertLogarithmicCapabilities<Legacy::UnitsNet.Level, Legacy::UnitsNet.Units.LevelUnit>();
    }

    [Fact]
    public void QuantityMath_WorksAcrossBothImplementations()
    {
        Legacy::UnitsNet.Length legacy = UnitsNet.Core.QuantityMath.Average(new[]
        {
            Legacy::UnitsNet.Length.FromMeters(1),
            Legacy::UnitsNet.Length.FromCentimeters(300),
        });
        Generated::UnitsNet.Length generated = UnitsNet.Core.QuantityMath.Average(new[]
        {
            Generated::UnitsNet.Length.FromMeters(1),
            Generated::UnitsNet.Length.FromCentimeters(300),
        });

        Assert.Equal(legacy.Meters, generated.Meters, 10);
        Assert.Equal(2, generated.Meters, 10);
    }

    private static void AssertSelfTypedContract<TQuantity, TUnit>(TUnit baseUnit, TUnit largerUnit)
        where TQuantity : UnitsNet.Core.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum
    {
        Assert.Equal(new UnitsNet.Core.QuantityId("UnitsNet.Length"), TQuantity.QuantityId);
        Assert.Equal(baseUnit, TQuantity.BaseUnit);

        TQuantity quantity = TQuantity.From(2, baseUnit);
        UnitsNet.Core.IQuantity<TUnit, double> stored = quantity;
        Assert.Equal(2d, stored.Value);
        Assert.Equal(baseUnit, stored.Unit);
        Assert.Equal(2d, quantity.As(baseUnit));
        Assert.Equal(1000d, TQuantity.Convert(1, largerUnit, baseUnit), 10);
    }

    private static void AssertLinearCapabilities<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.ILinearQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        Assert.Equal(TQuantity.Zero, UnitsNet.Core.QuantityMath.Sum(Array.Empty<TQuantity>()));
    }

    private static void AssertAffineCapabilities<TQuantity, TUnit, TOffset>()
        where TQuantity : UnitsNet.Core.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Core.ILinearQuantity<TOffset>
    {
        TQuantity zero = TQuantity.From(0, TQuantity.BaseUnit);
        Assert.Equal(TQuantity.BaseUnit, zero.Unit);
        Assert.Equal(zero, zero + TOffset.Zero);
    }

    private static void AssertLogarithmicCapabilities<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        Assert.Equal(TQuantity.BaseUnit, TQuantity.Zero.Unit);
        Assert.True(TQuantity.LogarithmicScalingFactor > 0);
    }
}
