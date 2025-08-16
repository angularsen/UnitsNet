using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// ReSharper disable ConvertToAutoPropertyWhenPossible

namespace UnitsNet;

/// <summary>
///     Represents a unique key for a unit type and its corresponding value.
/// </summary>
/// <remarks>
///     This key is particularly useful when using an enum-based unit in a hash-based collection,
///     as it avoids the boxing that would normally occur when casting the enum to <see cref="Enum" />.
/// </remarks>
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public readonly record struct UnitKey
{
    // apparently, on netstandard, the use of auto-properties is significantly slower
    private readonly Type _unitEnumType;
    private readonly int _unitEnumValue;

    /// <summary>
    ///     Represents a unique key for a unit type and its corresponding value.
    /// </summary>
    /// <remarks>
    ///     This key is particularly useful when using an enum-based unit in a hash-based collection,
    ///     as it avoids the boxing that would normally occur when casting the enum to <see cref="Enum" />.
    /// </remarks>
    internal UnitKey(Type UnitEnumType, int UnitEnumValue)
    {
        _unitEnumType = UnitEnumType;
        _unitEnumValue = UnitEnumValue;
    }

    /// <summary>
    ///     Gets the type of the unit represented by this <see cref="UnitKey" />.
    /// </summary>
    /// <remarks>
    ///     This property holds the <see cref="Type" /> of the unit enumeration associated with this key.
    ///     It is particularly useful for identifying the unit type in scenarios where multiple unit types are used.
    /// </remarks>
    public Type UnitEnumType
    {
        get => _unitEnumType;
    }

    /// <summary>
    ///     Gets the integer value associated with the unit type.
    /// </summary>
    /// <remarks>
    ///     This property represents the unique value of the unit within its type, typically corresponding to the underlying
    ///     integer value of an enumeration.
    /// </remarks>
    public int UnitEnumValue
    {
        get => _unitEnumValue;
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="UnitKey" /> struct for the specified unit.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit, which must be a struct and an enumeration.</typeparam>
    /// <param name="unit">The unit value to create the <see cref="UnitKey" /> for.</param>
    /// <returns>A new instance of the <see cref="UnitKey" /> struct representing the specified unit.</returns>
    public static UnitKey ForUnit<TUnit>(TUnit unit)
        where TUnit : struct, Enum
    {
        return new UnitKey(typeof(TUnit), Unsafe.As<TUnit, int>(ref unit));
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="UnitKey" /> struct for a specified unit type and value.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit, which must be an enumeration.</typeparam>
    /// <param name="unitValue">The integer value representing the unit.</param>
    /// <returns>A new <see cref="UnitKey" /> instance representing the specified unit type and value.</returns>
    public static UnitKey Create<TUnit>(int unitValue)
        where TUnit : struct, Enum
    {
        return new UnitKey(typeof(TUnit), unitValue);
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="UnitKey" /> struct for the specified unit type and value.
    /// </summary>
    /// <param name="unitType">The type of the unit, which must be an enumeration.</param>
    /// <param name="unitValue">The integer value representing the unit.</param>
    /// <returns>A new instance of the <see cref="UnitKey" /> struct.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="unitType" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="unitType" /> is not an enumeration type.
    /// </exception>
    /// <remarks>
    ///     This method is useful for creating a <see cref="UnitKey" /> when the unit type and value are known.
    /// </remarks>
    public static UnitKey Create(Type unitType, int unitValue)
    {
        if (unitType is null)
        {
            throw new ArgumentNullException(nameof(unitType));
        }

        if (!unitType.IsEnum)
        {
            throw new ArgumentException($"Unit type must be an enumeration, but was {unitType.FullName}.", nameof(unitType));
        }

        return new UnitKey(unitType, unitValue);
    }

    /// <summary>
    ///     Implicitly converts an enumeration value to a <see cref="UnitKey" />.
    /// </summary>
    /// <param name="unit">The enumeration value to convert.</param>
    /// <returns>A new instance of the <see cref="UnitKey" /> struct representing the specified enumeration value.</returns>
    /// <remarks>
    ///     This implicit conversion allows for seamless usage of enumeration values where <see cref="UnitKey" /> instances are
    ///     expected.
    ///     <para>
    ///         For better performance, prefer using the <see cref="ForUnit{TUnit}(TUnit)" /> method, which avoids the boxing
    ///         involved with the cast to <see cref="Enum" />.
    ///     </para>
    /// </remarks>
    public static implicit operator UnitKey(Enum unit)
    {
        // using Unsafe.Unbox<int>(unit) isn't any faster
        return new UnitKey(unit.GetType(), (int)(object)unit);
    }

    /// <summary>
    ///     Explicitly converts a <see cref="UnitKey" /> to its corresponding enumeration value.
    /// </summary>
    /// <param name="unitKey">The <see cref="UnitKey" /> instance to convert.</param>
    /// <returns>The enumeration value represented by the <see cref="UnitKey" />.</returns>
    /// <remarks>
    ///     This explicit conversion is useful when you need to retrieve the original enumeration value from a
    ///     <see cref="UnitKey" />.
    /// </remarks>
    public static explicit operator Enum(UnitKey unitKey)
    {
        return (Enum)Enum.ToObject(unitKey._unitEnumType, unitKey._unitEnumValue);
    }

    /// <summary>
    ///     Converts the current <see cref="UnitKey" /> to its corresponding enumeration value of type
    ///     <typeparamref name="TUnit" />.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit, which must be a struct and an enumeration.</typeparam>
    /// <returns>The enumeration value of type <typeparamref name="TUnit" /> represented by the current <see cref="UnitKey" />.</returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the type of <typeparamref name="TUnit" /> does not match the type of the current <see cref="UnitKey" />
    ///     .
    /// </exception>
    /// <remarks>
    ///     This method is useful for retrieving the original enumeration value from a <see cref="UnitKey" />.
    /// </remarks>
    public TUnit ToUnit<TUnit>() where TUnit : struct, Enum
    {
        if (typeof(TUnit) != _unitEnumType)
        {
            throw new InvalidOperationException($"Cannot convert UnitKey of type {_unitEnumType} to {typeof(TUnit)}.");
        }

        var unitValue = _unitEnumValue;
        return Unsafe.As<int, TUnit>(ref unitValue);
    }

    private string GetDebuggerDisplay()
    {
        try
        {
            var unitName = Enum.GetName(_unitEnumType, _unitEnumValue);
            return string.IsNullOrEmpty(unitName) ? $"{nameof(UnitEnumType)}: {_unitEnumType}, {nameof(UnitEnumValue)} = {_unitEnumValue}" : $"{_unitEnumType.Name}.{unitName}";
        }
        catch
        {
            return $"{nameof(UnitEnumType)}: {_unitEnumType}, {nameof(UnitEnumValue)} = {_unitEnumValue}";
        }
    }

    /// <summary>
    ///     Deconstructs the <see cref="UnitKey" /> into its component parts.
    /// </summary>
    /// <param name="unitType">The type of the unit.</param>
    /// <param name="unitValue">The value of the unit.</param>
    /// <remarks>
    ///     This method allows for the use of deconstruction syntax to extract the unit type and value
    ///     from a <see cref="UnitKey" /> instance.
    /// </remarks>
    public void Deconstruct(out Type unitType, out int unitValue)
    {
        unitType = _unitEnumType;
        unitValue = _unitEnumValue;
    }

    #region Equality members

    /// <inheritdoc />
    public bool Equals(UnitKey other)
    {
        // implementing the Equality members on net48 is 5x faster than the default
        return _unitEnumType == other._unitEnumType && _unitEnumValue == other._unitEnumValue;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        // implementing the Equality members on net48 is 5x faster than the default
        if (_unitEnumType == null)
        {
            return _unitEnumValue;
        }

        unchecked
        {
            return (_unitEnumType.GetHashCode() * 397) ^ _unitEnumValue;
        }
    }

    #endregion
}
