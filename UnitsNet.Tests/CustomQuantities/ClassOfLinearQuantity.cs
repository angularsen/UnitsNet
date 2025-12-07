// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics;
using UnitsNet.Debug;

namespace UnitsNet.Tests.CustomQuantities;

/// <summary>
///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
/// </summary>
public enum ClassOfLinearQuantityUnit
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
public class ClassOfLinearQuantity(QuantityValue value, ClassOfLinearQuantityUnit unit) : IArithmeticQuantity<ClassOfLinearQuantity, ClassOfLinearQuantityUnit>
{
    public static readonly QuantityInfo<ClassOfLinearQuantity, ClassOfLinearQuantityUnit> Info = new(
        ClassOfLinearQuantityUnit.Some,
        new UnitDefinition<ClassOfLinearQuantityUnit>[]
        {
            new(ClassOfLinearQuantityUnit.Some, "Some", BaseUnits.Undefined),
            new(ClassOfLinearQuantityUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne), QuantityValue.FromTerms(1, 10)),
            new(ClassOfLinearQuantityUnit.AShitTon, "ShitTons", BaseUnits.Undefined, QuantityValue.FromTerms(1, 100))
        },
        new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
        From);

    public ClassOfLinearQuantityUnit Unit { get; } = unit;

    public QuantityValue Value { get; } = value;

    public static ClassOfLinearQuantity From(QuantityValue value, ClassOfLinearQuantityUnit unit)
    {
        return new ClassOfLinearQuantity(value, unit);
    }

    public static ClassOfLinearQuantity Zero { get; } = new(0, ClassOfLinearQuantityUnit.Some);

    public static ClassOfLinearQuantity operator +(ClassOfLinearQuantity left, ClassOfLinearQuantity right)
    {
        return new ClassOfLinearQuantity(left.Value + right.As(left.Unit), left.Unit);
    }

    public static ClassOfLinearQuantity operator -(ClassOfLinearQuantity left, ClassOfLinearQuantity right)
    {
        return new ClassOfLinearQuantity(left.Value - right.As(left.Unit), left.Unit);
    }

    public static ClassOfLinearQuantity operator *(ClassOfLinearQuantity left, QuantityValue right)
    {
        return new ClassOfLinearQuantity(left.Value * right, left.Unit);
    }

    public static ClassOfLinearQuantity operator /(ClassOfLinearQuantity left, QuantityValue right)
    {
        return new ClassOfLinearQuantity(left.Value / right, left.Unit);
    }

    public static ClassOfLinearQuantity operator -(ClassOfLinearQuantity value)
    {
        return new ClassOfLinearQuantity(-value.Value, value.Unit);
    }

    #region IQuantity

    QuantityInfo<ClassOfLinearQuantity, ClassOfLinearQuantityUnit> IQuantity<ClassOfLinearQuantity, ClassOfLinearQuantityUnit>.QuantityInfo
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

    IQuantityInstanceInfo<ClassOfLinearQuantity> IQuantityOfType<ClassOfLinearQuantity>.QuantityInfo
    {
        get => Info;
    }

    Enum IQuantity.Unit
    {
        get => Unit;
    }

    QuantityInfo<ClassOfLinearQuantityUnit> IQuantity<ClassOfLinearQuantityUnit>.QuantityInfo
    {
        get => Info;
    }
#endif

    #endregion
}
