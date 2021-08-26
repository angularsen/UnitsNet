// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Globalization;

namespace UnitsNet.Serialization
{
    /// <summary>
    /// Common converter functionality that can be used from both Json.Net and System.Text.Json converters
    /// </summary>
    public class QuantityConverter<TQuantity>
    {
        private readonly ConcurrentDictionary<string, (Type Quantity, Type Unit)> _registeredTypes = new ();

        /// <summary>
        /// Register custom types so that the converter can instantiate these quantities.
        /// Instead of calling <see cref="Quantity.From"/>, the <see cref="Activator"/> will be used to instantiate the object.
        /// It is therefore assumed that the constructor of <paramref name="quantity"/> is specified with <c>new T(double value, typeof(<paramref name="unit"/>) unit)</c>.
        /// Registering the same <paramref name="unit"/> multiple times, it will overwrite the one registered.
        /// </summary>
        public void RegisterCustomType(Type quantity, Type unit)
        {
            if (!typeof(TQuantity).IsAssignableFrom(quantity))
            {
                throw new ArgumentException($"The type {quantity} is not a {typeof(TQuantity)}");
            }

            if (!typeof(Enum).IsAssignableFrom(unit))
            {
                throw new ArgumentException($"The type {unit} is not a {nameof(Enum)}");
            }

            _registeredTypes[unit.Name] = (quantity, unit);
        }

        /// <summary>
        /// Signature of function that creates an <see cref="IValueUnit"/>.
        /// </summary>
        public delegate IValueUnit CreateValueUnitFunc(string unit, double value);

        /// <summary>
        /// Signature of function that creates an <see cref="IExtendedValueUnit"/>.
        /// </summary>
        public delegate IExtendedValueUnit CreateExtendedValueUnitFunc(string unit, double value, string valueString, string valueType);

        /// <remarks>
        /// Copied from UnitsNet.Serialization.JsonNet UnitsNetBaseJsonConverter to be used with System.Text.Json
        /// </remarks>
        public IValueUnit ConvertIQuantity(IQuantity quantity, CreateValueUnitFunc createValueUnit, CreateExtendedValueUnitFunc createExtendedValueUnit)
        {
            quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));

            if (quantity is IDecimalQuantity d)
            {
                return createExtendedValueUnit(
                    unit: $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}",
                    value: quantity.Value,
                    valueString: d.Value.ToString(CultureInfo.InvariantCulture),
                    valueType: "decimal");
            }

            return createValueUnit(value: quantity.Value, unit: $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}");
        }

        /// <summary>
        /// Convert a <see cref="IValueUnit"/> to an <see cref="IQuantity"/>
        /// </summary>
        /// <param name="valueUnit">The value unit to convert</param>
        /// <exception cref="UnitsNetException">Thrown when an invalid Unit has been provided</exception>
        /// <returns>An IQuantity</returns>
        public IQuantity ConvertValueUnit(IValueUnit valueUnit)
        {
            if (string.IsNullOrWhiteSpace(valueUnit?.Unit))
            {
                return null;
            }

            var unit = GetUnit(valueUnit.Unit);
            var registeredQuantity = GetRegisteredType(valueUnit.Unit).Quantity;

            if (registeredQuantity is not null)
            {
                return (IQuantity)Activator.CreateInstance(registeredQuantity, valueUnit.Value, unit);
            }

            return valueUnit switch
            {
                IExtendedValueUnit {ValueType: "decimal"} extendedValueUnit => Quantity.From(decimal.Parse(extendedValueUnit.ValueString, CultureInfo.InvariantCulture), unit),
                _ => Quantity.From(valueUnit.Value, unit)
            };
        }


        private (Type Quantity, Type Unit) GetRegisteredType(string unit)
        {
            (var unitEnumTypeName, var _) = SplitUnitString(unit);
            if (_registeredTypes.TryGetValue(unitEnumTypeName, out var registeredType))
            {
                return registeredType;
            }

            return (null, null);
        }

        private Enum GetUnit(string unit)
        {
            (var unitEnumTypeName, var unitEnumValue) = SplitUnitString(unit);

            // First try to find the name in the list of registered types.
            Type unitEnumType = GetRegisteredType(unit).Unit;

            if (unitEnumType is null)
            {
                // "UnitsNet.Units.MassUnit,UnitsNet"
                var unitEnumTypeAssemblyQualifiedName = "UnitsNet.Units." + unitEnumTypeName + ",UnitsNet";

                // -- see http://stackoverflow.com/a/6465096/1256096 for details
                unitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);

                if (unitEnumType is null)
                {
                    var ex = new UnitsNetException("Unable to find enum type.");
                    ex.Data["type"] = unitEnumTypeAssemblyQualifiedName;
                    throw ex;
                }
            }

            var unitValue = (Enum) Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram
            return unitValue;
        }

        private (string EnumName, string EnumValue) SplitUnitString(string unit)
        {
            var unitParts = unit.Split('.');

            if (unitParts.Length != 2)
            {
                var ex = new UnitsNetException($"\"{unit}\" is not a valid unit.");
                ex.Data["type"] = unit;
                throw ex;
            }

            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            return (unitParts[0], unitParts[1]);
        }
    }
}
