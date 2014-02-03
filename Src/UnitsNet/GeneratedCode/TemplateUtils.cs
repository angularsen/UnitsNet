// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnitsNet.Attributes;
using UnitsNet.Extensions;

namespace UnitsNet.GeneratedCode
{
    public static class TemplateUtils
    {
        public static IEnumerable<UnitClassInfo> GetUnitClasses(Assembly assemblyContainingUnitEnums)
        {
            Dictionary<Type, UnitEnumValueInfo[]> dict =
                GetUnitEnumValueInfoPerUnitType(assemblyContainingUnitEnums);

            var unitsInfo = new List<UnitClassInfo>();
            foreach (KeyValuePair<Type, UnitEnumValueInfo[]> pair in dict)
            {
                Type unitEnumType = pair.Key;
                List<UnitEnumValueInfo> enumValues = pair.Value.Where(val => val.UnitAttribute != null).ToList();

                // Ignore enums that do not specify any unit attributes, such as OtherUnit.
                if (!enumValues.Any())
                    continue;

                UnitEnumValueInfo baseUnit =
                    enumValues.FirstOrDefault(val => val.Value.ToString() == val.UnitAttribute.BaseUnitName);

                if (baseUnit == null)
                    throw new InvalidOperationException(
                        "At least one unit attribute is defined for the values of this enum, but none of them matched the base unit. Did you forget to specify a base unit in the unit attribute?");

                string baseUnitName = baseUnit.Value.ToString();
                string baseUnitPluralName = baseUnit.UnitAttribute.PluralName ?? baseUnitName + "s";

                IOrderedEnumerable<UnitInfo> orderedClassUnits =
                    enumValues.Select(
                        val =>
                            new UnitInfo(val.Value.ToString(), val.UnitAttribute.PluralName,
                                val.UnitAttribute.LinearFunction))
                        .OrderBy(val => val.SingularName);

                // LengthUnit enum type => Length unit class
                string unitClassName = unitEnumType.Name.Replace("Unit", string.Empty);

                unitsInfo.Add(new UnitClassInfo(unitClassName, baseUnit.UnitAttribute.XmlDocSummary, unitEnumType.Name,
                    baseUnitName,
                    baseUnitPluralName, orderedClassUnits.ToList()));
            }

            return unitsInfo;
        }


        public static Dictionary<TUnit, IUnitAttribute<TUnit>> GetUnitToAttributeDictionary<TBaseUnitAttribute, TUnit>()
            where TBaseUnitAttribute : Attribute
            where TUnit : /*Enum constraint hack*/ struct, IConvertible
        {
            return Enum.GetValues(typeof (TUnit))
                .Cast<TUnit>()
                .Select(
                    u => new {unit = u, attr = (u as Enum).GetAttribute<TBaseUnitAttribute>() as IUnitAttribute<TUnit>})
                .Where(item => item.attr != null)
                .ToDictionary(u => u.unit, u => u.attr);
        }

        /// <summary>
        /// Returns a dictionary of enum type to unit 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Dictionary<Type, UnitEnumValueInfo[]> GetUnitEnumValueInfoPerUnitType(Assembly assembly)
        {
            // Do not match on namespace, it might break too easily on refactoring.
            IEnumerable<Type> unitEnumTypes = assembly.GetTypes().Where(t => t.IsEnum && t.Name.EndsWith("Unit"));
            return unitEnumTypes.Select(
                enumType =>
                    new
                    {
                        EnumType = enumType,
                        EnumValues =
                            Enum.GetValues(enumType)
                                .Cast<Enum>()
                                .Select(enumValue => new UnitEnumValueInfo(enumValue.GetAttribute<IUnitAttribute>(), enumValue.GetType(), enumValue))
                    })
                .Where(item => item.EnumValues.Any())
                .ToDictionary(item => item.EnumType, item => item.EnumValues.ToArray());
        }

        /// <summary>
        /// Get dictionary of unit values to unit attributes, where unit attributes inherit <paramref name="unitAttributeIsOfType"/>.
        /// </summary>
        /// <typeparam name="TBaseUnitAttribute"></typeparam>
        /// <typeparam name="TUnit"></typeparam>
        /// <param name="unitAttributeIsOfType"></param>
        /// <returns></returns>
        public static Dictionary<TUnit, IUnitAttribute<TUnit>> GetUnitToAttributeDictionary<TBaseUnitAttribute, TUnit>(Type unitAttributeIsOfType)
            where TBaseUnitAttribute : Attribute
            where TUnit : /*Enum constraint hack*/ struct, IConvertible
        {

            return Enum.GetValues(typeof (TUnit))
                .Cast<TUnit>()
                .Select(
                    u => new {unit = u, attr = (u as Enum).GetAttribute<TBaseUnitAttribute>(unitAttributeIsOfType) as IUnitAttribute<TUnit>})
                .Where(item => item.attr != null)
                .ToDictionary(u => u.unit, u => u.attr);
        }

        public static Dictionary<TUnit, I18nAttribute[]> GetUnitToI18nAttributesDictionaryForUnitType<TUnit>()
            where TUnit : /*Enum constraint hack*/ struct, IConvertible
        {
            return Enum.GetValues(typeof (TUnit))
                .Cast<TUnit>()
                .Select(
                    u => new {unit = u, attrs = (u as Enum).GetAttributes<I18nAttribute>()})
                .Where(item => item.attrs != null)
                .ToDictionary(u => u.unit, u => u.attrs);
        }

        public static Dictionary<int, I18nAttribute[]> GetUnitToI18nAttributesDictionaryForUnitType(Type unitType)
        {
            return Enum.GetValues(unitType)
                .Cast<object>()
                .Select(
                    u => new {unit = Convert.ToInt32(u), attrs = (u as Enum).GetAttributes<I18nAttribute>()})
                .Where(item => item.attrs != null)
                .ToDictionary(u => u.unit, u => u.attrs);
        }

        public static I18nAttribute[] GetI18nAttributesForUnit<TUnit>(TUnit u)
            where TUnit : /*Enum constraint hack*/ struct, IConvertible
        {
            return (u as Enum).GetAttributes<I18nAttribute>();
        }

        public static string GetUnitPluralName<TUnit>(Dictionary<TUnit, IUnitAttribute<TUnit>> unitToAttribute,
            TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IConvertible
        {
            // Use attribute value if it has a valid value, otherwise append 's' to the enum value name to get plural form (works for 90%).
            IUnitAttribute<TUnit> att;
            if (!unitToAttribute.TryGetValue(unit, out att))
            {
                return String.Format("NO_UNIT_ATTRIBUTE_SET_FOR_ENUM_VALUE__{0}", unit);
            }

            // Default to plural with "s" postfix if no PluralName is explicitly set.
            string baseUnitPluralName = (att != null && !string.IsNullOrEmpty(att.PluralName))
                ? att.PluralName
                : unit + "s";
            return baseUnitPluralName;
        }

        public static List<Type> GetUnitAttributeTypes<TBaseUnitAttribute>() where TBaseUnitAttribute : Attribute
        {
            return FindDerivedTypes(typeof (TBaseUnitAttribute).Assembly, typeof (TBaseUnitAttribute)).ToList();
        }

        /// <summary>
        ///     Returns a list of <see cref="TUnit" /> values for a unit class by the class name.
        ///     This is resolved by looking at the <see cref="IUnitAttribute{TUnit}" /> attributes the enum values are tagged with.
        ///     For example, a
        ///     <param name="unitClassName" />
        ///     of "Length" will match all <see cref="TUnit" /> values tagged with
        ///     <see cref="LengthAttribute" />.
        /// </summary>
        public static List<TUnit> GetUnitsOfUnitClass<TUnit>(string unitClassName, IEnumerable<Type> unitAttributeTypes,
            Dictionary<TUnit, IUnitAttribute<TUnit>> unitToAttribute)
            where TUnit : /*Enum constraint hack*/ struct, IConvertible
        {
            Type unitClassAttributeType = unitAttributeTypes.First(type => type.Name.StartsWith(unitClassName));
            List<TUnit> unitsOfUnitClass =
                unitToAttribute
                    .Where(pair => pair.Value.GetType() == unitClassAttributeType)
                    .Select(pair => pair.Key)
                    .ToList();

            return unitsOfUnitClass;
        }


        #region Private

        private static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t != baseType &&
                                                  baseType.IsAssignableFrom(t));
        }

        #endregion 
    }

    public class UnitEnumValueInfo
    {
        public readonly IUnitAttribute UnitAttribute;
        public readonly Type UnitEnumType;
        public readonly Enum Value;

        public UnitEnumValueInfo(IUnitAttribute unitAttribute, Type unitEnumType, Enum value)
        {
            UnitAttribute = unitAttribute;
            UnitEnumType = unitEnumType;
            Value = value;
        }
    }

    public class UnitInfo
    {
        public readonly string SingularName;
        public readonly string PluralName;
        public readonly LinearFunction LinearFunction;

        public UnitInfo(string singularName, string pluralName, LinearFunction linearFunction)
        {
            SingularName = singularName;
            PluralName = pluralName ?? singularName + "s";
            LinearFunction = linearFunction;
        } 
    }

    public class UnitClassInfo
    {
        public readonly string UnitClassName;
        public readonly string UnitClassXmlDoc; 
        public readonly string UnitEnumTypeName; 
        public readonly string BaseUnitName;
        public readonly string BaseUnitPluralName;
        public readonly ICollection<UnitInfo> OrderedUnits;

        public UnitClassInfo(string unitClassName, string unitClassXmlDoc, string unitEnumTypeName, string baseUnitName, string baseUnitPluralName, ICollection<UnitInfo> orderedUnits)
        {
            UnitClassName = unitClassName;
            UnitClassXmlDoc = unitClassXmlDoc;
            UnitEnumTypeName = unitEnumTypeName;
            BaseUnitName = baseUnitName;
            BaseUnitPluralName = baseUnitPluralName;
            OrderedUnits = orderedUnits;
        }
    }

}