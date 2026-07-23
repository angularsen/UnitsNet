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

    static Length System.Numerics.IAdditiveIdentity<Length, Length>.AdditiveIdentity => Zero;
}

public readonly partial struct Mass : UnitsNet.Core.ILinearQuantity<Mass, MassUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Mass");

    static Mass System.Numerics.IAdditiveIdentity<Mass, Mass>.AdditiveIdentity => Zero;
}

public readonly partial struct Duration : UnitsNet.Core.ILinearQuantity<Duration, DurationUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Duration");

    static Duration System.Numerics.IAdditiveIdentity<Duration, Duration>.AdditiveIdentity => Zero;
}

public readonly partial struct Area : UnitsNet.Core.ILinearQuantity<Area, AreaUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Area");

    static Area System.Numerics.IAdditiveIdentity<Area, Area>.AdditiveIdentity => Zero;
}

public readonly partial struct Speed : UnitsNet.Core.ILinearQuantity<Speed, SpeedUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Speed");

    static Speed System.Numerics.IAdditiveIdentity<Speed, Speed>.AdditiveIdentity => Zero;
}

public readonly partial struct Acceleration : UnitsNet.Core.ILinearQuantity<Acceleration, AccelerationUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Acceleration");

    static Acceleration System.Numerics.IAdditiveIdentity<Acceleration, Acceleration>.AdditiveIdentity => Zero;
}

public readonly partial struct Force : UnitsNet.Core.ILinearQuantity<Force, ForceUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Force");

    static Force System.Numerics.IAdditiveIdentity<Force, Force>.AdditiveIdentity => Zero;
}

public readonly partial struct Pressure : UnitsNet.Core.ILinearQuantity<Pressure, PressureUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Pressure");

    static Pressure System.Numerics.IAdditiveIdentity<Pressure, Pressure>.AdditiveIdentity => Zero;
}

public readonly partial struct Energy : UnitsNet.Core.ILinearQuantity<Energy, EnergyUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Energy");

    static Energy System.Numerics.IAdditiveIdentity<Energy, Energy>.AdditiveIdentity => Zero;
}

public readonly partial struct Power : UnitsNet.Core.ILinearQuantity<Power, PowerUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Power");

    static Power System.Numerics.IAdditiveIdentity<Power, Power>.AdditiveIdentity => Zero;
}

public readonly partial struct Temperature : UnitsNet.Core.IAffineQuantity<Temperature, TemperatureUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Temperature");
}

public readonly partial struct Level : UnitsNet.Core.ILogarithmicQuantity<Level, LevelUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Level");
}

public readonly partial struct Information : UnitsNet.Core.ILinearQuantity<Information, InformationUnit>
{
    /// <inheritdoc />
    public static QuantityId QuantityId { get; } = new("UnitsNet.Information");

    static Information System.Numerics.IAdditiveIdentity<Information, Information>.AdditiveIdentity => Zero;
}

#endif
