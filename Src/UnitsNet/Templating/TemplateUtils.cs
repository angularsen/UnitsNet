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

namespace UnitsNet.Templating
{
    public static class TemplateUtils
    {
        public static IEnumerable<UnitClassInfo> GetUnitClasses(params Assembly[] assembliesToSearchForUnits)
        { 
            if (assembliesToSearchForUnits == null || assembliesToSearchForUnits.Length == 0)
                throw new ArgumentException("Specify at least one assembly.", "assembliesToSearchForUnits");

            Dictionary<Type, UnitEnumValueInfo[]> dict =
                GetUnitEnumValueInfoPerUnitType(assembliesToSearchForUnits);

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

                unitsInfo.Add(new UnitClassInfo(unitClassName, baseUnit.UnitAttribute.XmlDocSummary,
                    baseUnitName,
                    baseUnitPluralName, orderedClassUnits.ToList(), unitEnumType));
            }

            return unitsInfo;
        }

        /// <summary>
        /// Returns a dictionary of enum type to unit 
        /// </summary>
        /// <param name="assemblies">Assemblies to search for unit enum types tagged with attributes of type <see cref="IUnitAttribute"/>.</param>
        /// <returns>Dictionary mapping enum type to an array of info structures describing the unit enum value, mapping function, base unit, unit plural name etc.</returns>
        private static Dictionary<Type, UnitEnumValueInfo[]> GetUnitEnumValueInfoPerUnitType(params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
                throw new ArgumentException("At least one assembly must be specified.", "assemblies");

            // Do not match on namespace, it might break too easily on refactoring.
            // TODO Only match enums tagged with an attribute of type IUnitAttribute
            IEnumerable<Type> unitEnumTypes = GetUnitEnumTypes(assemblies);

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

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<Type> GetUnitEnumTypes(params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
                throw new ArgumentException("Specify at least one assembly.", "assemblies");

            return assemblies
                .Distinct()
                .SelectMany(ass => ass.GetTypes().Where(t => t.IsEnum && t.Name.EndsWith("Unit")));
        }

        // ReSharper disable once InconsistentNaming
        public static Dictionary<int, I18nAttribute[]> GetI18nAttributesByUnitEnumValue(Type unitType)
        {
            return Enum.GetValues(unitType)
                .Cast<object>()
                .Select(
                    u => new {unit = Convert.ToInt32(u), attrs = (u as Enum).GetAttributes<I18nAttribute>()})
                .Where(item => item.attrs != null)
                .ToDictionary(u => u.unit, u => u.attrs);
        }

        #region Private

        #endregion 
    }
}