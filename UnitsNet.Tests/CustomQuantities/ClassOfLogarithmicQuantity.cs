// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics;
using UnitsNet.Debug;

namespace UnitsNet.Tests.CustomQuantities;

/// <summary>
///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
/// </summary>
public enum ClassOfLogarithmicQuantityUnit
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
public class ClassOfLogarithmicQuantity(QuantityValue value, ClassOfLogarithmicQuantityUnit unit) : ILogarithmicQuantity<ClassOfLogarithmicQuantity, ClassOfLogarithmicQuantityUnit>
{
    public static readonly QuantityInfo<ClassOfLogarithmicQuantity, ClassOfLogarithmicQuantityUnit> Info = new(
        ClassOfLogarithmicQuantityUnit.Some,
        new UnitDefinition<ClassOfLogarithmicQuantityUnit>[]
        {
            new(ClassOfLogarithmicQuantityUnit.Some, "Some", BaseUnits.Undefined),
            new(ClassOfLogarithmicQuantityUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne), QuantityValue.FromTerms(1, 10)),
            new(ClassOfLogarithmicQuantityUnit.AShitTon, "ShitTons", BaseUnits.Undefined, QuantityValue.FromTerms(1, 100))
        },
        new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
        From);

    public ClassOfLogarithmicQuantityUnit Unit { get; } = unit;

    public QuantityValue Value { get; } = value;

    public static ClassOfLogarithmicQuantity From(QuantityValue value, ClassOfLogarithmicQuantityUnit unit)
    {
        return new ClassOfLogarithmicQuantity(value, unit);
    }

    public static QuantityValue LogarithmicScalingFactor { get => 10; }
    
    public static ClassOfLogarithmicQuantity Zero { get; } = new(0, ClassOfLogarithmicQuantityUnit.Some);

    public static ClassOfLogarithmicQuantity operator +(ClassOfLogarithmicQuantity left, ClassOfLogarithmicQuantity right)
    {
        // note: the AddWithLogScaling function isn't public
        return new ClassOfLogarithmicQuantity(QuantityValueExtensions.AddWithLogScaling(left.Value, right.As(left.Unit), LogarithmicScalingFactor), left.Unit);
    }

    public static ClassOfLogarithmicQuantity operator -(ClassOfLogarithmicQuantity left, ClassOfLogarithmicQuantity right)
    {
        // note: the SubtractWithLogScaling function isn't public
        return new ClassOfLogarithmicQuantity(QuantityValueExtensions.SubtractWithLogScaling(left.Value, right.As(left.Unit), LogarithmicScalingFactor), left.Unit);
    }

    public static ClassOfLogarithmicQuantity operator *(ClassOfLogarithmicQuantity left, QuantityValue right)
    {
        return new ClassOfLogarithmicQuantity(left.Value + right, left.Unit);
    }

    public static ClassOfLogarithmicQuantity operator /(ClassOfLogarithmicQuantity left, QuantityValue right)
    {
        return new ClassOfLogarithmicQuantity(left.Value - right, left.Unit);
    }

    public static ClassOfLogarithmicQuantity operator -(ClassOfLogarithmicQuantity value)
    {
        return new ClassOfLogarithmicQuantity(-value.Value, value.Unit);
    }

    #region IQuantity

    QuantityInfo<ClassOfLogarithmicQuantity, ClassOfLogarithmicQuantityUnit> IQuantity<ClassOfLogarithmicQuantity, ClassOfLogarithmicQuantityUnit>.QuantityInfo
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

    QuantityValue ILogarithmicQuantity<ClassOfLogarithmicQuantity>.LogarithmicScalingFactor
    {
        get => LogarithmicScalingFactor;
    }

    QuantityInfo IQuantity.QuantityInfo
    {
        get => Info;
    }

    IQuantityInstanceInfo<ClassOfLogarithmicQuantity> IQuantityOfType<ClassOfLogarithmicQuantity>.QuantityInfo
    {
        get => Info;
    }

    Enum IQuantity.Unit
    {
        get => Unit;
    }

    QuantityInfo<ClassOfLogarithmicQuantityUnit> IQuantity<ClassOfLogarithmicQuantityUnit>.QuantityInfo
    {
        get => Info;
    }
#endif

    #endregion
}
