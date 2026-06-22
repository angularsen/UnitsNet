// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity.
    /// </summary>
    public interface IQuantity : IFormattable
    {
        /// <summary>
        ///     Information about the quantity type, such as unit values and names.
        /// </summary>
        /// <remarks>
        ///     Kept for back-compat with netstandard2.0. On .NET 5+, prefer the static <c>TSelf.Info</c>
        ///     property or the <c>GetQuantityInfo()</c> extension method on <see cref="QuantityExtensions"/>.
        /// </remarks>
#if NET
        [Obsolete("Kept for back-compat with netstandard2.0. On .NET 5+, use the static TSelf.Info property or the GetQuantityInfo() extension method.")]
#endif
        QuantityInfo QuantityInfo { get; }

        /// <summary>
        ///     The unit this quantity was constructed with -or- BaseUnit if default ctor was used.
        /// </summary>
        Enum Unit { get; }

        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="Unit" />.
        /// </summary>
        QuantityValue Value { get; }

        /// <summary>
        ///     Gets the unique key for the unit type and its corresponding value.
        /// </summary>
        /// <remarks>
        ///     This property is particularly useful when using an enum-based unit in a hash-based collection,
        ///     as it avoids the boxing that would normally occur when casting the enum to <see cref="Enum" />.
        /// </remarks>
        UnitKey UnitKey { get; }
    }

    /// <summary>
    ///     A stronger typed interface where the unit enum type is known, to avoid passing in the
    ///     wrong unit enum type and not having to cast from <see cref="Enum" />.
    /// </summary>
    /// <example>
    ///     IQuantity{LengthUnit} length;
    ///     QuantityValue centimeters = length.As(LengthUnit.Centimeter); // Type safety on enum type
    /// </example>
    /// <typeparam name="TUnitType">The unit type of the quantity.</typeparam>
    public interface IQuantity<TUnitType> : IQuantity
        where TUnitType : struct, Enum
    {
        /// <inheritdoc cref="IQuantity.Unit" />
        new TUnitType Unit { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
#if NET
        [Obsolete("Kept for back-compat with netstandard2.0. On .NET 5+, use the static TSelf.Info property or the GetQuantityInfo() extension method.")]
#endif
        new QuantityInfo<TUnitType> QuantityInfo { get; }

#if NET

        #region Implementation of IQuantity

#pragma warning disable CS0618 // Type or member is obsolete
        QuantityInfo IQuantity.QuantityInfo
        {
            get => QuantityInfo;
        }
#pragma warning restore CS0618

        Enum IQuantity.Unit
        {
            get => Unit;
        }

        #endregion

#endif
    }

    /// <inheritdoc cref="IQuantity" />
    /// <remarks>
    ///     This is a specialization of <see cref="IQuantity" /> that is used (internally) for constraining certain
    ///     methods, without having to include the unit type as additional generic parameter.
    /// </remarks>
    /// <typeparam name="TQuantity"></typeparam>
    public interface IQuantityOfType<out TQuantity> : IQuantity
        where TQuantity : IQuantity
    {
#if NET
        /// <summary>
        ///     The static <see cref="UnitsNet.QuantityInfo"/> for this quantity type.
        /// </summary>
        /// <remarks>
        ///     Implemented by every quantity as a public static <c>Info</c> property. Prefer this and the
        ///     <see cref="QuantityExtensions.GetQuantityInfo(IQuantity)"/> extension method over the
        ///     obsolete instance <see cref="IQuantity.QuantityInfo"/> property.
        /// </remarks>
        public static abstract QuantityInfo Info { get; }

        /// <summary>
        ///     Creates an instance of the quantity from a specified value and unit.
        /// </summary>
        /// <param name="value">The numerical value of the quantity.</param>
        /// <param name="unit">The unit of the quantity.</param>
        /// <returns>An instance of the quantity with the specified value and unit.</returns>
        public static abstract TQuantity Create(QuantityValue value, UnitKey unit);
#else
        /// <inheritdoc cref="IQuantity.QuantityInfo" />
        new IQuantityInstanceInfo<TQuantity> QuantityInfo { get; }
#endif
    }

    /// <summary>
    ///     An <see cref="IQuantity{TUnitType}"/> that supports generic equality comparison with tolerance.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
    public interface IQuantity<TSelf, TUnitType> : IQuantityOfType<TSelf>, IQuantity<TUnitType>
        where TSelf : IQuantity<TSelf, TUnitType>
        where TUnitType : struct, Enum
    {
        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
#if NET
        [Obsolete("Kept for back-compat with netstandard2.0. On .NET 5+, use the static TSelf.Info property or the GetQuantityInfo() extension method.")]
#endif
        new QuantityInfo<TSelf, TUnitType> QuantityInfo { get; }

#if NET
        /// <inheritdoc cref="IQuantityOfType{TQuantity}.Info"/>
        public new static abstract QuantityInfo<TSelf, TUnitType> Info { get; }

        /// <summary>
        ///     Creates an instance of the quantity from a specified value and unit.
        /// </summary>
        /// <param name="value">The numerical value of the quantity.</param>
        /// <param name="unit">The unit of the quantity.</param>
        /// <returns>An instance of the quantity with the specified value and unit.</returns>
        static abstract TSelf From(QuantityValue value, TUnitType unit);

        static TSelf IQuantityOfType<TSelf>.Create(QuantityValue value, UnitKey unit) => TSelf.From(value, unit.ToUnit<TUnitType>());

        static QuantityInfo IQuantityOfType<TSelf>.Info => TSelf.Info;

#pragma warning disable CS0618 // Type or member is obsolete
        QuantityInfo<TUnitType> IQuantity<TUnitType>.QuantityInfo
        {
            get => QuantityInfo;
        }
#pragma warning restore CS0618
        
#endif
    }
}
