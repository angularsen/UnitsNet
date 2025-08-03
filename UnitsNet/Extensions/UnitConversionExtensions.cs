// ReSharper disable once CheckNamespace
namespace UnitsNet.Units;

/// <summary>
///     Provides extension methods for converting quantities in the UnitsNet library to another unit.
/// </summary>
public static class UnitConversionExtensions
{
    /// <inheritdoc cref="UnitConverter.ConvertValue{TQuantity,TUnit}" />
    public static QuantityValue As<TQuantity, TUnit>(this TQuantity quantity, TUnit unit)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return UnitConverter.Default.ConvertValue(quantity, unit);
    }

    /// <summary>
    ///     Gets the value in the unit determined by the given <see cref="UnitSystem" />. If multiple units were found for the
    ///     given <see cref="UnitSystem" />,
    ///     the first match will be used.
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> to convert the quantity value to.</param>
    /// <returns>The converted value.</returns>
    public static QuantityValue As<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantity
    {
        return quantity.GetValue(quantity.QuantityInfo.GetDefaultUnit(unitSystem).UnitKey);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    public static TQuantity ToUnit<TQuantity, TUnit>(this TQuantity quantity, TUnit unit)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return UnitConverter.Default.ConvertToUnit(quantity, unit);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    public static TQuantity ToUnit<TQuantity, TUnit>(this TQuantity quantity, TUnit unit, UnitConverter unitConverter)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return unitConverter.ConvertToUnit(quantity, unit);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    public static TQuantity ToUnit<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantityOfType<TQuantity>
    {
#if NET
        QuantityInfo quantityInfo = quantity.QuantityInfo;
#else
        QuantityInfo quantityInfo = ((IQuantity)quantity).QuantityInfo;
#endif
        return UnitConverter.Default.ConvertToUnit(quantity, quantityInfo.GetDefaultUnit(unitSystem).UnitKey);
    }
}
