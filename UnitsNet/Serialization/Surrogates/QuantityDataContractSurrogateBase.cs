// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETFRAMEWORK
using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace UnitsNet.Serialization.Surrogates
{
    /// <summary>
    ///     Can be used as a base class for an alternative (surrogate) representation of a given quantity type(s).
    /// </summary>
    public abstract class QuantityDataContractSurrogateBase : IDataContractSurrogate
    {
        /// <inheritdoc />
        public abstract Type GetDataContractType(Type type);

        /// <inheritdoc />
        public abstract object GetObjectToSerialize(object obj, Type targetType);

        /// <inheritdoc />
        public abstract object GetDeserializedObject(object obj, Type targetType);

        object IDataContractSurrogate.GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        object IDataContractSurrogate.GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        void IDataContractSurrogate.GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        Type IDataContractSurrogate.GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        CodeTypeDeclaration IDataContractSurrogate.ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Can be used to convert back from the surrogate (string representation of the form "{EnumType}.{EnumValue}" format: e.g.
        ///     "MassUnit.Kilogram") of a given unit, to it's actual unit Enum type (e.g. MassUnit)
        /// </summary>
        /// <param name="unit">The string representation of the unit (must match one of the existing enum types: e.g. 'MassUnit.Kilogram') </param>
        /// <returns>The corresponding enum type</returns>
        /// <exception cref="UnitsNetException">In case no matching quantity type is found</exception>
        /// <exception cref="ArgumentException">In case no matching unit value is found</exception>
        protected static Enum GetUnit(string unit)
        {
            var unitParts = unit.Split('.');

            if (unitParts.Length != 2)
            {
                var ex = new UnitsNetException($"\"{unit}\" is not a valid unit.");
                ex.Data["type"] = unit;
                throw ex;
            }

            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            var unitEnumTypeName = unitParts[0];
            var unitEnumValue = unitParts[1];

            // "UnitsNet.Units.MassUnit,UnitsNet"
            var unitEnumTypeAssemblyQualifiedName = "UnitsNet.Units." + unitEnumTypeName + ",UnitsNet";

            // -- see http://stackoverflow.com/a/6465096/1256096 for details
            var unitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);
            if (unitEnumType == null)
            {
                var ex = new UnitsNetException("Unable to find enum type.");
                ex.Data["type"] = unitEnumTypeAssemblyQualifiedName;
                throw ex;
            }

            var unitValue = (Enum) Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram
            return unitValue;
        }

        /// <summary>
        /// Constructs a quantity with a unit of the form "{EnumType}.{EnumValue}"
        /// <seealso cref="GetUnit"/>
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">The string representation of the unit (must match one of the existing enum types: e.g. 'MassUnit.Kilogram') </param>
        /// <returns>The corresponding enum type</returns>
        /// <exception cref="UnitsNetException">In case no matching quantity type is found</exception>
        /// <exception cref="ArgumentException">In case no matching unit value is found</exception>
        protected static IQuantity FromQuantityValue(QuantityValue value, string unit)
        {
            return Quantity.From(value, GetUnit(unit));
        }
    }
}
#endif
