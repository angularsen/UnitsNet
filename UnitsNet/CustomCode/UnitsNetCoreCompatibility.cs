// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET8_0_OR_GREATER

using UnitsNet.Core;
using UnitsNet.Units;

namespace UnitsNet;

public readonly partial struct Length : UnitsNet.Core.ILinearQuantity<Length, LengthUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Length");

    /// <inheritdoc />
    public static double Convert(double value, LengthUnit fromUnit, LengthUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Length System.Numerics.IAdditiveIdentity<Length, Length>.AdditiveIdentity => Zero;
}

public readonly partial struct Mass : UnitsNet.Core.ILinearQuantity<Mass, MassUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Mass");

    /// <inheritdoc />
    public static double Convert(double value, MassUnit fromUnit, MassUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Mass System.Numerics.IAdditiveIdentity<Mass, Mass>.AdditiveIdentity => Zero;
}

public readonly partial struct Duration : UnitsNet.Core.ILinearQuantity<Duration, DurationUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Duration");

    /// <inheritdoc />
    public static double Convert(double value, DurationUnit fromUnit, DurationUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Duration System.Numerics.IAdditiveIdentity<Duration, Duration>.AdditiveIdentity => Zero;
}

public readonly partial struct Area : UnitsNet.Core.ILinearQuantity<Area, AreaUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Area");

    /// <inheritdoc />
    public static double Convert(double value, AreaUnit fromUnit, AreaUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Area System.Numerics.IAdditiveIdentity<Area, Area>.AdditiveIdentity => Zero;
}

public readonly partial struct Speed : UnitsNet.Core.ILinearQuantity<Speed, SpeedUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Speed");

    /// <inheritdoc />
    public static double Convert(double value, SpeedUnit fromUnit, SpeedUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Speed System.Numerics.IAdditiveIdentity<Speed, Speed>.AdditiveIdentity => Zero;
}

public readonly partial struct Acceleration : UnitsNet.Core.ILinearQuantity<Acceleration, AccelerationUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Acceleration");

    /// <inheritdoc />
    public static double Convert(double value, AccelerationUnit fromUnit, AccelerationUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Acceleration System.Numerics.IAdditiveIdentity<Acceleration, Acceleration>.AdditiveIdentity => Zero;
}

public readonly partial struct Force : UnitsNet.Core.ILinearQuantity<Force, ForceUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Force");

    /// <inheritdoc />
    public static double Convert(double value, ForceUnit fromUnit, ForceUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Force System.Numerics.IAdditiveIdentity<Force, Force>.AdditiveIdentity => Zero;
}

public readonly partial struct Pressure : UnitsNet.Core.ILinearQuantity<Pressure, PressureUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Pressure");

    /// <inheritdoc />
    public static double Convert(double value, PressureUnit fromUnit, PressureUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Pressure System.Numerics.IAdditiveIdentity<Pressure, Pressure>.AdditiveIdentity => Zero;
}

public readonly partial struct Energy : UnitsNet.Core.ILinearQuantity<Energy, EnergyUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Energy");

    /// <inheritdoc />
    public static double Convert(double value, EnergyUnit fromUnit, EnergyUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Energy System.Numerics.IAdditiveIdentity<Energy, Energy>.AdditiveIdentity => Zero;
}

public readonly partial struct Power : UnitsNet.Core.ILinearQuantity<Power, PowerUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Power");

    /// <inheritdoc />
    public static double Convert(double value, PowerUnit fromUnit, PowerUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Power System.Numerics.IAdditiveIdentity<Power, Power>.AdditiveIdentity => Zero;
}

public readonly partial struct Temperature : UnitsNet.Core.IAffineQuantity<Temperature, TemperatureUnit, TemperatureDelta>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Temperature");

    /// <inheritdoc />
    public static double Convert(double value, TemperatureUnit fromUnit, TemperatureUnit toUnit) =>
        From(value, fromUnit).As(toUnit);
}

public readonly partial struct TemperatureDelta : UnitsNet.Core.ILinearQuantity<TemperatureDelta, TemperatureDeltaUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.TemperatureDelta");

    /// <inheritdoc />
    public static double Convert(double value, TemperatureDeltaUnit fromUnit, TemperatureDeltaUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static TemperatureDelta System.Numerics.IAdditiveIdentity<TemperatureDelta, TemperatureDelta>.AdditiveIdentity => Zero;
}

public readonly partial struct Level : UnitsNet.Core.ILogarithmicQuantity<Level, LevelUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Level");

    /// <inheritdoc />
    public static double Convert(double value, LevelUnit fromUnit, LevelUnit toUnit) =>
        From(value, fromUnit).As(toUnit);
}

public readonly partial struct Information : UnitsNet.Core.ILinearQuantity<Information, InformationUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Information");

    /// <inheritdoc />
    public static double Convert(double value, InformationUnit fromUnit, InformationUnit toUnit) =>
        From(value, fromUnit).As(toUnit);

    static Information System.Numerics.IAdditiveIdentity<Information, Information>.AdditiveIdentity => Zero;
}

#endif
