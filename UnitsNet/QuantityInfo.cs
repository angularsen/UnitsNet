// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Information about the quantity, such as names, unit values and zero quantity.
    ///     This is useful to enumerate units and present names with quantities and units
    ///     chose dynamically at runtime, such as unit conversion apps or allowing the user to change the
    ///     unit representation.
    /// </summary>
    /// <remarks>
    ///     Typically you obtain this by looking it up via <see cref="IQuantity.QuantityInfo" />.
    /// </remarks>
    public class QuantityInfo
    {
        private static readonly string UnitEnumNamespace = typeof(LengthUnit).Namespace;

        private static readonly Dictionary<string, Type> UnitEnumTypes = typeof(Length)
            .Wrap()
            .Assembly
            .GetExportedTypes()
            .Where(t => t.Wrap().IsEnum && t.Namespace == UnitEnumNamespace && t.Name.EndsWith("Unit"))
            .ToDictionary(t => t.Name, t => t);

        /// <summary>
        ///     Constructs an instance.
        /// </summary>
        /// <param name="quantityType">The quantity enum value.</param>
        /// <param name="unitInfos">The information about the units for this quantity.</param>
        /// <param name="baseUnit">The base unit enum value.</param>
        /// <param name="zero">The zero quantity.</param>
        /// <param name="baseDimensions">The base dimensions of the quantity.</param>
        /// <exception cref="ArgumentException">Quantity type can not be undefined.</exception>
        /// <exception cref="ArgumentNullException">If units -or- baseUnit -or- zero -or- baseDimensions is null.</exception>
        [Obsolete("QuantityType will be removed in the future. Use the QuantityInfo(string, UnitInfo[], UnitInfo, IQuantity, BaseDimensions) constructor.")]
        public QuantityInfo(QuantityType quantityType, [NotNull] UnitInfo[] unitInfos, [NotNull] Enum baseUnit, [NotNull] IQuantity zero, [NotNull] BaseDimensions baseDimensions)
            : this(quantityType.ToString(), UnitEnumTypes[$"{quantityType}Unit"], unitInfos, baseUnit, zero, baseDimensions, quantityType)
        {
        }

        /// <summary>
        ///     Constructs an instance.
        /// </summary>
        /// <param name="name">Name of the quantity.</param>
        /// <param name="unitType">The unit enum type, such as <see cref="LengthUnit" />.</param>
        /// <param name="unitInfos">The information about the units for this quantity.</param>
        /// <param name="baseUnit">The base unit enum value.</param>
        /// <param name="zero">The zero quantity.</param>
        /// <param name="baseDimensions">The base dimensions of the quantity.</param>
        /// <param name="quantityType">The the quantity type. Defaults to Undefined.</param>
        /// <exception cref="ArgumentException">Quantity type can not be undefined.</exception>
        /// <exception cref="ArgumentNullException">If units -or- baseUnit -or- zero -or- baseDimensions is null.</exception>
        [Obsolete( "Use the QuantityInfo(string, UnitInfo[], UnitInfo, IQuantity, BaseDimensions) constructor." )]
        public QuantityInfo([NotNull] string name, Type unitType, [NotNull] UnitInfo[] unitInfos, [NotNull] Enum baseUnit, [NotNull] IQuantity zero, [NotNull] BaseDimensions baseDimensions,
           QuantityType quantityType = QuantityType.Undefined) :
            this(name, unitType, zero, baseDimensions, quantityType)
        {
            UnitInfo = new Collection<UnitInfo>(unitInfos ?? throw new ArgumentNullException(nameof(unitInfos)));
            BaseUnitInfo = unitInfos.First(unitInfo => unitInfo.Value.Equals(baseUnit));
        }

        /// <summary>
        ///     Constructs an instance.
        /// </summary>
        /// <param name="name">Name of the quantity.</param>
        /// <param name="unitType">The unit enum type, such as <see cref="LengthUnit" />.</param>
        /// <param name="zero">The zero quantity.</param>
        /// <param name="baseDimensions">The base dimensions of the quantity.</param>
        /// <param name="quantityType">The the quantity type. Defaults to Undefined.</param>
        /// <exception cref="ArgumentException">Quantity type can not be undefined.</exception>
        /// <exception cref="ArgumentNullException">If units -or- baseUnit -or- zero -or- baseDimensions is null.</exception>
        protected QuantityInfo([NotNull] string name, Type unitType, [NotNull] IQuantity zero, [NotNull] BaseDimensions baseDimensions,
           QuantityType quantityType = QuantityType.Undefined)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UnitType = unitType ?? throw new ArgumentNullException(nameof(unitType));
            Zero = zero ?? throw new ArgumentNullException(nameof(zero));
            BaseDimensions = baseDimensions ?? throw new ArgumentNullException(nameof(baseDimensions));

            ValueType = zero.GetType();
            UnitInfo = new Collection<UnitInfo>();

            BaseUnitInfo = null!;

            // Obsolete members
            QuantityType = quantityType;
            BaseUnit = null!;
        }

        /// <summary>
        ///     Quantity name, such as "Length" or "Mass".
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Quantity type, such as <see cref="UnitsNet.QuantityType.Length" /> or <see cref="UnitsNet.QuantityType.Mass" />.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use QuantityInfo instead.")]
        public QuantityType QuantityType { get; }

        /// <summary>
        ///     The units for this quantity.
        /// </summary>
        public UnitInfo[] UnitInfos
        {
            get => UnitInfo.ToArray();
        }

        /// <summary>
        ///     The units for this quantity.
        /// </summary>
        public ICollection<UnitInfo> UnitInfo { get; }

        /// <summary>
        ///     All unit names for the quantity, such as ["Centimeter", "Decimeter", "Meter", ...].
        /// </summary>
        [Obsolete("This property is deprecated and will be removed at a future release. Please use the UnitInfos property.")]
        public string[] UnitNames
        {
            get => UnitInfos.Select(unitInfo => unitInfo.Name).ToArray();
        }

        /// <summary>
        ///     All unit enum values for the quantity, such as [<see cref="LengthUnit.Centimeter" />,
        ///     <see cref="LengthUnit.Decimeter" />, <see cref="LengthUnit.Meter" />, ...].
        /// </summary>
        [Obsolete("This property is deprecated and will be removed at a future release. Please use the UnitInfos property.")]
        public Enum[] Units
        {
            get => UnitInfos.Select( unitInfo => unitInfo.Value ).ToArray();
        }

        /// <summary>
        ///     The base unit of this quantity.
        /// </summary>
        public UnitInfo BaseUnitInfo { get; protected set; }

        /// <summary>
        ///     The base unit for the quantity, such as <see cref="LengthUnit.Meter" />.
        /// </summary>
        [Obsolete("This property is deprecated and will be removed at a future release. Please use the BaseUnitInfo property.")]
        public Enum BaseUnit{ get; }

        /// <summary>
        ///     Zero value of quantity, such as <see cref="Length.Zero" />.
        /// </summary>
        public IQuantity Zero { get; }

        /// <summary>
        ///     Unit enum type, such as <see cref="LengthUnit"/> or <see cref="MassUnit"/>.
        /// </summary>
        public Type UnitType { get; }

        /// <summary>
        ///     Quantity value type, such as <see cref="Length"/> or <see cref="Mass"/>.
        /// </summary>
        public Type ValueType { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> for a quantity.
        /// </summary>
        public BaseDimensions BaseDimensions { get; }

        /// <summary>
        /// Gets the <see cref="UnitInfo"/> whose <see cref="BaseUnits"/> is a subset of <paramref name="baseUnits"/>.
        /// </summary>
        /// <example>Length.Info.GetUnitInfoFor(unitSystemWithFootAsLengthUnit) returns <see cref="UnitInfo" /> for <see cref="LengthUnit.Foot" />.</example>
        /// <param name="baseUnits">The <see cref="BaseUnits"/> to check against.</param>
        /// <returns>The <see cref="UnitInfo"/> that has <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseUnits"/> is null.</exception>
        /// <exception cref="InvalidOperationException">No unit was found that is a subset of <paramref name="baseUnits"/>.</exception>
        /// <exception cref="InvalidOperationException">More than one unit was found that is a subset of <paramref name="baseUnits"/>.</exception>
        public UnitInfo GetUnitInfoFor(BaseUnits baseUnits)
        {
            if(baseUnits is null)
                throw new ArgumentNullException(nameof(baseUnits));

            var matchingUnitInfos = GetUnitInfosFor(baseUnits)
                .Take(2)
                .ToArray();

            var firstUnitInfo = matchingUnitInfos.FirstOrDefault();
            if (firstUnitInfo == null)
                throw new InvalidOperationException($"No unit was found that is a subset of {nameof(baseUnits)}");

            if (matchingUnitInfos.Length > 1)
                throw new InvalidOperationException($"More than one unit was found that is a subset of {nameof(baseUnits)}");

            return firstUnitInfo;
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> of <see cref="UnitInfo"/> that have <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.
        /// </summary>
        /// <param name="baseUnits">The <see cref="BaseUnits"/> to check against.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="UnitInfo"/> that have <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseUnits"/> is null.</exception>
        public IEnumerable<UnitInfo> GetUnitInfosFor(BaseUnits baseUnits)
        {
            if(baseUnits is null)
                throw new ArgumentNullException(nameof(baseUnits));

            return UnitInfos.Where((unitInfo) => unitInfo.BaseUnits.IsSubsetOf(baseUnits));
        }
    }

    /// <inheritdoc cref="QuantityInfo" />
    /// <remarks>
    ///     This is a specialization of <see cref="QuantityInfo" />, for when the unit type is known.
    ///     Typically you obtain this by looking it up statically from <see cref="Length.Info" /> or
    ///     <see cref="Length.QuantityInfo" />, or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
    /// </remarks>
    /// <typeparam name="TUnit">The unit enum type, such as <see cref="LengthUnit" />. </typeparam>
    public class QuantityInfo<TUnit> : QuantityInfo
        where TUnit : Enum
    {
        /// <inheritdoc cref="QuantityInfo{TUnit}(string,UnitsNet.UnitInfo{TUnit}[],TUnit,UnitsNet.IQuantity{TUnit},UnitsNet.BaseDimensions,UnitsNet.QuantityType)" />
        [Obsolete("QuantityType will be removed in the future. Use QuantityInfo(QuantityType, string, UnitInfo{TUnit}[], TUnit, IQuantity{TUnit}, BaseDimensions) instead.")]
        public QuantityInfo(QuantityType quantityType, UnitInfo<TUnit>[] unitInfos, TUnit baseUnit, IQuantity<TUnit> zero, BaseDimensions baseDimensions)
            : this(quantityType.ToString(), unitInfos, baseUnit, zero, baseDimensions, quantityType)
        {
        }

        /// <inheritdoc />
        public QuantityInfo(string name, UnitInfo<TUnit>[] unitInfos, TUnit baseUnit, IQuantity<TUnit> zero, BaseDimensions baseDimensions,
            QuantityType quantityType = QuantityType.Undefined)
            : this(name, zero, baseDimensions, quantityType)
        {
            UnitInfo = new Collection<UnitInfo<TUnit>>(unitInfos ?? throw new ArgumentNullException(nameof(unitInfos)));
            BaseUnitInfo = unitInfos.First(unitInfo => unitInfo.Value.Equals(baseUnit));
        }

        /// <inheritdoc />
        protected QuantityInfo(string name, IQuantity<TUnit> zero, BaseDimensions baseDimensions,
            QuantityType quantityType = QuantityType.Undefined)
            : base(name, typeof(TUnit), zero, baseDimensions, quantityType)
        {
            Zero = zero ?? throw new ArgumentNullException(nameof(zero));
            UnitInfo = new Collection<UnitInfo<TUnit>>();
            BaseUnitInfo = null!;
            BaseUnit = default(TUnit)!;
        }

        /// <inheritdoc cref="QuantityInfo.UnitInfos" />
        public new UnitInfo<TUnit>[] UnitInfos
        {
            get => UnitInfo.ToArray();
        }

        /// <inheritdoc cref="QuantityInfo.UnitInfo" />
        public new ICollection<UnitInfo<TUnit>> UnitInfo { get; }

        /// <inheritdoc cref="QuantityInfo.Units" />
        [Obsolete("This property is deprecated and will be removed at a future release. Please use the UnitInfos property.")]
        public new TUnit[] Units
        {
            get => UnitInfos.Select(unitInfo => unitInfo.Value).ToArray();
        }

        /// <inheritdoc cref="QuantityInfo.BaseUnitInfo" />
        public new UnitInfo<TUnit> BaseUnitInfo { get; protected set; }

        /// <inheritdoc cref="QuantityInfo.BaseUnit" />
        [Obsolete("This property is deprecated and will be removed at a future release. Please use the BaseUnitInfo property.")]
        public new TUnit BaseUnit { get; }

        /// <inheritdoc cref="QuantityInfo.Zero" />
        public new IQuantity<TUnit> Zero { get; }

        /// <inheritdoc cref="QuantityInfo.GetUnitInfoFor" />
        public new UnitInfo<TUnit> GetUnitInfoFor(BaseUnits baseUnits)
        {
            return (UnitInfo<TUnit>)base.GetUnitInfoFor(baseUnits);
        }

        /// <inheritdoc cref="QuantityInfo.GetUnitInfosFor" />
        public new IEnumerable<UnitInfo<TUnit>> GetUnitInfosFor(BaseUnits baseUnits)
        {
            return base.GetUnitInfosFor(baseUnits).Cast<UnitInfo<TUnit>>();
        }
    }
}
