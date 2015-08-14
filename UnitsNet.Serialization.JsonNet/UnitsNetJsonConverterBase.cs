// Copyright Initial Force AS.  All rights reserved.
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
using System.Linq.Expressions;
using Newtonsoft.Json;
using System.Reflection;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    /// Base class for converting units to/from JSON using Json.Net
    /// </summary>
    /// <typeparam name="TUnit">The type of unit to convert. For example, <see cref="UnitsNet.Mass"/>.</typeparam>
    public class UnitsNetJsonConverterBase<TUnit> : JsonConverter 
        where TUnit : struct, IComparable, IComparable<TUnit>
    {
        private Func<TUnit, double> _valueWriter;
        private Enum _baseUnit;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TUnit);
        }

        /// <summary>
        /// Initializes the expressions used to store the value to write to JSON and the base unit.
        /// </summary>
        /// <param name="expressionToStore">The expression to store the unit value to JSON.</param>
        /// <param name="expressionToRestore">The expression to restore the unit value from JSON.</param>
        protected void Init(Expression<Func<TUnit, double>> expressionToStore, Enum baseUnit)
        {
            _valueWriter = expressionToStore.Compile();
            _baseUnit = baseUnit;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // TODO: Refactor this method
            double? value = null;
            string unitEnumTypeAndValue = null;

            while (reader.Read())
            {
                if (value != null && unitEnumTypeAndValue != null)
                    break;

                switch (reader.TokenType)
                {
                    case JsonToken.Float:
                    case JsonToken.Integer:
                        value = Convert.ToDouble(reader.Value);
                        break;
                    case JsonToken.String:
                        unitEnumTypeAndValue = reader.Value.ToString();
                        break;
                }
            }
            if (value == null || unitEnumTypeAndValue == null)
                return null;

            string unitEnumType = unitEnumTypeAndValue.Split('.')[0];
            string unitEnumValue = unitEnumTypeAndValue.Split('.')[1];

            // Ex: UnitsNet.Units.MassUnit,UnitsNet -- see http://stackoverflow.com/a/6465096/1256096 for details
            Type reflectedUnitEnumType = Type.GetType("UnitsNet.Units." + unitEnumType + ",UnitsNet");
            object unit = Enum.Parse(reflectedUnitEnumType, unitEnumValue);

            MethodInfo fromMethod = typeof(TUnit).GetMethod("From");

            // Ex: Mass.From(55, MassUnit.Gram)
            return fromMethod.Invoke(null, BindingFlags.Static, null, new[] { value.Value, unit }, null);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var unit = (TUnit)value;

            writer.WriteStartObject();

            writer.WritePropertyName("Value");
            writer.WriteValue(_valueWriter(unit));
            writer.WritePropertyName("Unit");
            writer.WriteValue(GetBaseUnitEnum());

            writer.WriteEndObject();
        }

        /// <summary>
        /// Gets the full base unit enum name. For example: 'MassUnit.Kilogram'
        /// </summary>
        protected virtual string GetBaseUnitEnum()
        {
            return _baseUnit.GetType().Name + "." + _baseUnit;
        }
    }
}