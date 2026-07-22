// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET8_0_OR_GREATER

using UnitsNet.Core;
using UnitsNet.Units;

namespace UnitsNet;

public readonly partial struct Length : IQuantity<Length, LengthUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Length");
}

public readonly partial struct Mass : IQuantity<Mass, MassUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Mass");
}

public readonly partial struct Duration : IQuantity<Duration, DurationUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Duration");
}

public readonly partial struct Area : IQuantity<Area, AreaUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Area");
}

public readonly partial struct Speed : IQuantity<Speed, SpeedUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Speed");
}

public readonly partial struct Acceleration : IQuantity<Acceleration, AccelerationUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Acceleration");
}

public readonly partial struct Force : IQuantity<Force, ForceUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Force");
}

public readonly partial struct Pressure : IQuantity<Pressure, PressureUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Pressure");
}

public readonly partial struct Energy : IQuantity<Energy, EnergyUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Energy");
}

public readonly partial struct Power : IQuantity<Power, PowerUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Power");
}

public readonly partial struct Temperature : IQuantity<Temperature, TemperatureUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Temperature");
}

public readonly partial struct Level : IQuantity<Level, LevelUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Level");
}

public readonly partial struct Information : IQuantity<Information, InformationUnit, double>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Information");
}

#endif
