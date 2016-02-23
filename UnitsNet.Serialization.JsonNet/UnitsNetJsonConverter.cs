// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
using System.Globalization;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    ///     A JSON.net <see cref="JsonConverter" /> for converting to/from JSON and Units.NET
    ///     units like <see cref="Length" /> and <see cref="Mass" />.
    /// </summary>
    /// <remarks>
    ///     Relies on reflection and the type names and namespaces as of 3.x.x of Units.NET.
    ///     Assumptions by reflection code in the converter:
    ///     * Unit classes are of type UnitsNet.Length etc.
    ///     * Unit enums are of type UnitsNet.Units.LengthUnit etc.
    ///     * Unit class has a BaseUnit property returning the base unit, such as LengthUnit.Meter
    /// </remarks>
    public class UnitsNetJsonConverter : JsonConverter
    {
        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        ///     The object value.
        /// </returns>
        /// <exception cref="UnitsNetException">Unable to parse value and unit from JSON.</exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var vu = serializer.Deserialize<ValueUnit>(reader);
            // A null System.Nullable value was deserialized so just return null.
            if (vu == null)
                return null;

            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            string unitEnumTypeName = vu.Unit.Split('.')[0];
            string unitEnumValue = vu.Unit.Split('.')[1];

            // "MassUnit" => "Mass"
            string unitTypeName = unitEnumTypeName.Substring(0, unitEnumTypeName.Length - "Unit".Length);

            // "UnitsNet.Units.MassUnit,UnitsNet"
            string unitEnumTypeAssemblyQualifiedName = "UnitsNet.Units." + unitEnumTypeName + ",UnitsNet";

            // "UnitsNet.Mass,UnitsNet"
            string unitTypeAssemblyQualifiedName = "UnitsNet." + unitTypeName + ",UnitsNet";

            // -- see http://stackoverflow.com/a/6465096/1256096 for details
            Type reflectedUnitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);
            if (reflectedUnitEnumType == null)
            {
                var ex = new UnitsNetException("Unable to find enum type.");
                ex.Data["type"] = unitEnumTypeAssemblyQualifiedName;
                throw ex;
            }

            Type reflectedUnitType = Type.GetType(unitTypeAssemblyQualifiedName);
            if (reflectedUnitType == null)
            {
                var ex = new UnitsNetException("Unable to find unit type.");
                ex.Data["type"] = unitTypeAssemblyQualifiedName;
                throw ex;
            }

            object unit = Enum.Parse(reflectedUnitEnumType, unitEnumValue);

            // Mass.From() method, assume no overloads exist
            MethodInfo fromMethod = (from m in reflectedUnitType.GetMethods()
                                     where m.Name.Equals("From", StringComparison.InvariantCulture) &&
                                     !m.ReturnType.IsGenericType  // we want the non nullable type
                                     select m).Single();

            // Ex: Mass.From(55, MassUnit.Gram)
            // TODO: there is a possible loss of precision if base value requires higher precision than double can represent.
            // Example: Serializing Information.FromExabytes(100) then deserializing to Information 
            // will likely return a very different result. Not sure how we can handle this?
            return fromMethod.Invoke(null, BindingFlags.Static, null, new[] {vu.Value, unit},
                CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="UnitsNetException">Can't serialize 'null' value.</exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type unitType = value.GetType();

            FieldInfo[] fields =
                unitType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (fields.Length == 0)
            {
                var ex = new UnitsNetException("No private fields found in type.");
                ex.Data["type"] = unitType;
                throw ex;
            }
            if (fields.Length > 1)
            {
                var ex = new UnitsNetException("Expected exactly 1 private field, but found multiple.");
                ex.Data["type"] = unitType;
                throw ex;
            }

            // Unit base type can be double, long or decimal,
            // so make sure we serialize the real type to avoid
            // loss of precision
            FieldInfo baseValueField = fields.First();
            object baseValue = baseValueField.GetValue(value);

            // Mass => "MassUnit.Kilogram"
            PropertyInfo baseUnitPropInfo = unitType.GetProperty("BaseUnit");

            // Read static BaseUnit property value
            var baseUnitEnumValue = (Enum) baseUnitPropInfo.GetValue(null, null);
            Type baseUnitType = baseUnitEnumValue.GetType();
            string baseUnit = $"{baseUnitType.Name}.{baseUnitEnumValue}";

            serializer.Serialize(writer, new ValueUnit
            {
                // This might throw OverflowException for very large values?
                // TODO Should we serialize long, decimal and long differently?
                Value = Convert.ToDouble(baseValue),
                Unit = baseUnit
            });
        }

        /// <summary>
        ///     A structure used to serialize/deserialize Units.NET unit instances.
        /// </summary>
        /// <remarks>
        ///     TODO Units may use decimal, long or double as base value type and might result
        ///     in a loss of precision when serializing/deserializing to decimal.
        ///     Decimal is the highest precision type available in .NET, but has a smaller
        ///     range than double.
        /// </remarks>
        private class ValueUnit
        {
            public string Unit { get; [UsedImplicitly] set; }
            public double Value { get; [UsedImplicitly] set; }
        }

        #region Can Convert

        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            if (IsNullable(objectType))
            {
                return CanConvertNullable(objectType);
            }

            return objectType.Namespace != null && objectType.Namespace.Equals("UnitsNet");
        }

        /// <summary>
        ///     Determines whether the specified object type is actually a <see cref="System.Nullable" /> type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if the object type is nullable; otherwise <c>false</c>.</returns>
        protected bool IsNullable(Type objectType)
        {
            return Nullable.GetUnderlyingType(objectType) != null;
        }

        /// <summary>
        ///     Determines whether this instance can convert the specified nullable object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if the object type is a nullable container for a UnitsNet type; otherwise <c>false</c>.</returns>
        protected virtual bool CanConvertNullable(Type objectType)
        {
            // Need to look at the FullName in order to determine if the nullable type contains a UnitsNet type.
            // For example: FullName = 'System.Nullable`1[[UnitsNet.Frequency, UnitsNet, Version=3.19.0.0, Culture=neutral, PublicKeyToken=null]]'
            return objectType.FullName != null && objectType.FullName.Contains("UnitsNet.");
        }

        #endregion
    }
}