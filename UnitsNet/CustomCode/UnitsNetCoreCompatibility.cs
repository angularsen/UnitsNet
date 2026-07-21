// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Core;
using UnitsNet.Units;

namespace UnitsNet;

public readonly partial struct Length : UnitsNet.Core.IQuantity<LengthUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Length");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Mass : UnitsNet.Core.IQuantity<MassUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Mass");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Duration : UnitsNet.Core.IQuantity<DurationUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Duration");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Area : UnitsNet.Core.IQuantity<AreaUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Area");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Speed : UnitsNet.Core.IQuantity<SpeedUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Speed");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Acceleration : UnitsNet.Core.IQuantity<AccelerationUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Acceleration");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Force : UnitsNet.Core.IQuantity<ForceUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Force");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Pressure : UnitsNet.Core.IQuantity<PressureUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Pressure");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Energy : UnitsNet.Core.IQuantity<EnergyUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Energy");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Power : UnitsNet.Core.IQuantity<PowerUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Power");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Temperature : UnitsNet.Core.IQuantity<TemperatureUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Temperature");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Level : UnitsNet.Core.IQuantity<LevelUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Level");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}

public readonly partial struct Information : UnitsNet.Core.IQuantity<InformationUnit, double>
{
    QuantityId UnitsNet.Core.IQuantity<double>.QuantityId => new("UnitsNet.Information");
    double UnitsNet.Core.IQuantity<double>.BaseValue => As(BaseUnit);
    string UnitsNet.Core.IQuantity<double>.UnitName => Unit.ToString();
}
