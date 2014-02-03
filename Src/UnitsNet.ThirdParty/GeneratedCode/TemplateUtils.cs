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
using UnitsNet.ThirdParty.Attributes;
using UnitsNet.ThirdParty.Extensions;

namespace UnitsNet.ThirdParty.GeneratedCode
{
    public static class TemplateUtils
    {
        public static Dictionary<TUnit, IUnitAttribute<TUnit>> GetUnitToAttributeDictionary<TBaseUnitAttribute, TUnit>()
            where TBaseUnitAttribute : Attribute
        {
            return Enum.GetValues(typeof (TUnit))
                .Cast<TUnit>()
                .Select(
                    u => new {unit = u, attr = (u as Enum).GetAttribute<TBaseUnitAttribute>() as IUnitAttribute<TUnit>})
                .Where(item => item.attr != null)
                .ToDictionary(u => u.unit, u => u.attr);
        }

        public static string GetUnitPluralName<TUnit>(Dictionary<TUnit, IUnitAttribute<TUnit>> unitToAttribute,
            TUnit unit)
        {
            // Use attribute value if it has a valid value, otherwise append 's' to the enum value name to get plural form (works for 90%).
            IUnitAttribute<TUnit> att;
            if (!unitToAttribute.TryGetValue(unit, out att))
            {
                return String.Format("NO_UNIT_ATTRIBUTE_SET_FOR_ENUM_VALUE__{0}", unit);
            }

            // Default to plural with "s" postfix if no PluralName is explicitly set.
            string baseUnitPluralName = (att != null && !string.IsNullOrWhiteSpace(att.PluralName))
                ? att.PluralName
                : unit + "s";
            return baseUnitPluralName;
        }

        public static List<Type> GetUnitAttributeTypes<TBaseUnitAttribute, TUnit>() where TBaseUnitAttribute : Attribute
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
}