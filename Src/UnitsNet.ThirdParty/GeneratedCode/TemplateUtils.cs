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
        //public static Dictionary<TUnit, IUnitAttribute<TUnit>> GetUnitToAttributeDictionary<TUnit>(Type enumType)
        //{
        //    return Enum.GetValues(enumType)
        //        .Cast<TUnit>()
        //        .Select(
        //            u =>
        //                new
        //                {
        //                    unit = u,
        //                    attr = (u as Enum).GetAttribute<ThirdPartyUnitAttribute>() as IUnitAttribute<TUnit>
        //                })
        //        .Where(item => item.attr != null)
        //        .ToDictionary(u => u.unit, u => u.attr);
        //}
        //public Dictionary<Unit, TUnitAttribute> GetUnitToAttributeDictionary<TUnit, TUnitAttribute>()
        //where TUnitAttribute : ThirdPartyUnitAttribute
        //{
        //    return Enum.GetValues(typeof(TUnit))
        //        .Cast<Unit>()
        //        .Select(u => new { unit = u, attr = u.GetAttribute<TUnitAttribute>() })
        //        .Where(item => item.attr != null)
        //        .ToDictionary(u => u.unit, u => u.attr);
        //}

        public static Dictionary<TUnit, IUnitAttribute<TUnit>> GetUnitToAttributeDictionary<TBaseUnitAttribute, TUnit>() //Type unitAttribute) 
            where TBaseUnitAttribute : Attribute
        {
            return Enum.GetValues(typeof(TUnit))
                .Cast<TUnit>()
                .Select(u => new { unit = u, attr = (u as Enum).GetAttribute<TBaseUnitAttribute>() as IUnitAttribute<TUnit>})
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

        //public static List<IUnitAttribute<TUnit>> GetUnitAttributes<TBaseUnitAttribute, TUnit>() where TBaseUnitAttribute : Attribute
        //{

        //    List<IUnitAttribute<TUnit>> attributes = GetUnitAttributeTypes<TBaseUnitAttribute, TUnit>().ToList();
        //    return attributes;
        //}  
        
        public static List<Type> GetUnitAttributeTypes<TBaseUnitAttribute, TUnit>() where TBaseUnitAttribute : Attribute
        {
            return FindDerivedTypes(typeof (TBaseUnitAttribute).Assembly, typeof (TBaseUnitAttribute)).ToList();
        }



        #region Private

        ///// <summary>
        /////     <see cref="IUnitAttribute{TUnit}.BaseUnit" /> and <see cref="IUnitAttribute{TUnit}.XmlDocSummary" /> are often
        /////     needed
        /////     when generating classes. To obtain we need to construct an instance of the attribute, as these are not static/const
        /////     for the reason of forcing derived implementations to implement them with abstract modifier in
        /////     <see cref="IUnitAttribute{TUnit}" />
        /////     base class.
        ///// </summary>
        //private static IUnitAttribute<TUnit> GetUnitAttributeFromUnitClassName<TUnit>(string unitClassName)
        //{
        //    // Derived UnitAttributes are typically named LengthAttribute, MassAttribute etc.
        //    const string attributeNamespace = "UnitsNet.ThirdParty.Attributes";
        //    string unitAttributeFullName = String.Format("{0}.{1}Attribute", attributeNamespace, unitClassName);
        //    Type unitAttributeType = typeof(TUnit).Assembly.GetType(unitAttributeFullName);
        //    if (unitAttributeType == null)
        //        return null;

        //    // Example ctor: public AngleAttribute(double ratio, string pluralName = null)
        //    //var attr = (IUnitAttribute<TUnit>) Activator.CreateInstance(unitAttributeType, new object[] {0.0, null});

        //    ConstructorInfo simplestCtor =
        //        unitAttributeType.GetConstructors().OrderBy(ctor => ctor.GetParameters().Length).First();
        //    object[] parameters = simplestCtor.GetParameters().Select(p => GetDefault(p.ParameterType)).ToArray();
        //    if (parameters.Length == 0)
        //        throw new Exception("Ctor with no params found for type: " + unitAttributeType);

        //    var attr = (IUnitAttribute<TUnit>)simplestCtor.Invoke(parameters);
        //    return attr;
        //}

        //private static object GetDefault(Type type)
        //{
        //    if (type.IsValueType)
        //    {
        //        return Activator.CreateInstance(type);
        //    }
        //    return null;
        //}

        //private static Dictionary<TUnit, IUnitAttribute<TUnit>> GetUnitToAttributeDictionary<TUnit>()
        //{
        //    return GetUnitToAttributeDictionary<TUnit>(typeof(TUnit));
        //}

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

        //public static List<string> GetUnitClassNamesFromUnitAttributeImplementations<TBaseUnitAttribute>() where TBaseUnitAttribute : Attribute
        //{
        //    // "LengthAttribute" => "Length"
        //    return GetUnitAttributeTypes<TBaseUnitAttribute>().Select(attr => attr.GetType().Name.Replace("Attribute", String.Empty)).ToList();
        //}

              private static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t != baseType &&
                                                  baseType.IsAssignableFrom(t));
        }

        #endregion
    }
}