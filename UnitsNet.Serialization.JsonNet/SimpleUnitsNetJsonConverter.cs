using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnitsNet.InternalHelpers;

namespace UnitsNet.Serialization.JsonNet
{
    public class SimpleUnitsNetJsonConverter : JsonConverter
    {

        private readonly object[] _targetUnit = null;
        private readonly string[] _priorityUnits = null;

        public SimpleUnitsNetJsonConverter()
        {
            _priorityUnits = new string[0];
        }

        public SimpleUnitsNetJsonConverter(object targetUnits, string[] priorityUnits = null)
        {
            _targetUnit = targetUnits == null ? null : new object[] { targetUnits };
            _priorityUnits = priorityUnits ?? new string[0];
        }

        public override bool CanConvert(Type objectType)
        {
#if (NETSTANDARD1_0)
            return objectType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IQuantity));

#else
            return objectType.IsAssignableFrom(typeof(IQuantity));
#endif
       }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            MethodInfo notNullableFromMethod = objectType.GetDeclaredMethods().Single(m => m.Name == "Parse" && m.GetParameters().Length == 1 && m.DeclaringType == objectType);
            object result = null;
            try
            {
                return notNullableFromMethod.Invoke(null, new[] { reader.Value });
            }
            catch(Exception ex)
            {
                if(ex.InnerException is AmbiguousUnitParseException)
                {
                    // If overrides provided try to recover
                    // First get the unit type
                    var unitType = objectType.GetPropety("Unit").PropertyType;
                    var regex = new Regex(QuantityParser.GetRegexString(unitType));

                    string value = (string)reader.Value;

                    MatchCollection matches = regex.Matches(value.Trim());
                    var validGroups = new List<GroupCollection>();
                    foreach(Match match in matches)
                    {
                        GroupCollection groups = match.Groups;

                        string valueString = groups["value"].Value;
                        string unitString = groups["unit"].Value;
                        if (groups["invalid"].Value != "")
                        {
                            var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                            newEx.Data["input"] = value;
                            newEx.Data["matched value"] = valueString;
                            newEx.Data["matched unit"] = unitString;
                            throw newEx;
                        }
                        if ((valueString == "") && (unitString == "")) continue;
                        else
                        {
                            validGroups.Add(groups);
                        }
                    }

                    if (validGroups.Count > 1)
                    {
                        // Not going to handle multiple values to add together at this time
                        throw new UnitsNetException($"Unable to handle multiple values and ambiguous units for value: {value}.", ex);
                    }

                    Dictionary<string, object> overridesDict = new Dictionary<string, object>();

                    foreach(var overrideValue in _priorityUnits)
                    {
                        object enumVal;
                        try
                        {
                            enumVal = Enum.Parse(unitType, overrideValue);
                        }
                        catch
                        {
                            continue;
                        }
                        overridesDict[UnitSystem.Default.GetDefaultAbbreviation(unitType, Convert.ToInt32(enumVal))] = enumVal;
                    }

                    if(overridesDict.Count > 0)
                    {
                        var unit = validGroups[0]["unit"].Value;

                        if (!overridesDict.Keys.Contains(unit))
                        {
                            throw new AmbiguousUnitParseException($"Ambigous units for value {reader.Value} and Unit type {unitType}. Provide priority units in serializer contructor to define the desired unit.", ex);
                        }
                        else
                        {
                            // Get the From Method
                            ConstructorInfo constructor;
#if (NETSTANDARD1_0)
                            constructor = objectType.GetTypeInfo().DeclaredConstructors.Single(c => c.GetParameters().Length == 2);
#else
                            constructor = objectType.GetConstructor(new[] {typeof(double), unitType});
#endif
                            double doubleVal = double.Parse(validGroups[0]["value"].Value);
                            return constructor.Invoke(new[] { doubleVal, overridesDict[unit] });
                        }
                    }
                    else
                    {
                        throw new AmbiguousUnitParseException($"Ambigous units for value {reader.Value} and Unit type {unitType}. Provide priority units in serializer contructor to define the desired unit.", ex);
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            int paramTarget = _targetUnit == null ? 0 : 1;
            var methods = value.GetType().GetDeclaredMethods().Select(s => s).ToList();
            var notNullableFromMethod = methods.Single(m => m.Name == "ToString" && m.DeclaringType == value.GetType() && m.GetParameters().Length == paramTarget);
            serializer.Serialize(writer, notNullableFromMethod.Invoke(value, _targetUnit));
        }
    }
}
