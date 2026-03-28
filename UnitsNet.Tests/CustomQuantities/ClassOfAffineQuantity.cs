// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics;
using UnitsNet.Debug;

namespace UnitsNet.Tests.CustomQuantities;

/// <summary>
///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
/// </summary>
public enum ClassOfAffineQuantityUnit
{
    Some,
    ATon,
    AShitTon
}

/// <inheritdoc cref="IQuantity" />
/// <summary>
///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
/// </summary>
[DebuggerDisplay(QuantityDebugProxy.DisplayFormat)]
[DebuggerTypeProxy(typeof(QuantityDebugProxy))]
public class ClassOfAffineQuantity(double value, ClassOfAffineQuantityUnit unit) : IAffineQuantity<ClassOfAffineQuantity, ClassOfAffineQuantityUnit, ClassOfLinearQuantity>
{
    public static readonly QuantityInfo<ClassOfAffineQuantity, ClassOfAffineQuantityUnit> Info = new(
        ClassOfAffineQuantityUnit.Some,
        new UnitDefinition<ClassOfAffineQuantityUnit>[]
        {
            new(ClassOfAffineQuantityUnit.Some, "Some", BaseUnits.Undefined),
            new(ClassOfAffineQuantityUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne), QuantityValue.FromTerms(1, 10)),
            new(ClassOfAffineQuantityUnit.AShitTon, "ShitTons", BaseUnits.Undefined, QuantityValue.FromTerms(1, 100))
        },
        new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
        From);

    public ClassOfAffineQuantityUnit Unit { get; } = unit;

    public double Value { get; } = value;

    public static ClassOfAffineQuantity From(double value, ClassOfAffineQuantityUnit unit)
    {
        return new ClassOfAffineQuantity(value, unit);
    }

    public static ClassOfAffineQuantity Zero { get; } = new(0, ClassOfAffineQuantityUnit.Some);
    
    public static ClassOfAffineQuantity operator +(ClassOfAffineQuantity left, ClassOfLinearQuantity right)
    {
        return new ClassOfAffineQuantity(left.As(ClassOfAffineQuantityUnit.Some) + right.As(ClassOfLinearQuantityUnit.Some), ClassOfAffineQuantityUnit.Some);
    }

    public static ClassOfLinearQuantity operator -(ClassOfAffineQuantity left, ClassOfAffineQuantity right)
    {
        return new ClassOfLinearQuantity(left.As(ClassOfAffineQuantityUnit.Some) - right.As(ClassOfAffineQuantityUnit.Some), ClassOfLinearQuantityUnit.Some);
    }

    #region IQuantity

    QuantityInfo<ClassOfAffineQuantity, ClassOfAffineQuantityUnit> IQuantity<ClassOfAffineQuantity, ClassOfAffineQuantityUnit>.QuantityInfo
    {
        get => Info;
    }

    public override string ToString()
    {
        return ToString("G", null);
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return QuantityFormatter.Default.Format(this, format, formatProvider);
    }

    UnitKey IQuantity.UnitKey
    {
        get => UnitKey.ForUnit(Unit);
    }
    
#if !NET
    QuantityInfo IQuantity.QuantityInfo
    {
        get => Info;
    }

    IQuantityInstanceInfo<ClassOfAffineQuantity> IQuantityOfType<ClassOfAffineQuantity>.QuantityInfo
    {
        get => Info;
    }

    Enum IQuantity.Unit
    {
        get => Unit;
    }

    QuantityInfo<ClassOfAffineQuantityUnit> IQuantity<ClassOfAffineQuantityUnit>.QuantityInfo
    {
        get => Info;
    }
#endif

    #endregion

}
