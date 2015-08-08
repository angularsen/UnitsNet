using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace UnitsNet.Tests.Examples
{
    public class UnitsNetJsonConverter<T> : JsonConverter where T : struct
    {
        private Func<T, double> _valueWriter;
        private Func<double, T> _valueReader;

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(T?) || objectType == typeof(T));
        }

        protected void Init(Expression<Func<T, double>> expressionToStore, Expression<Func<double, T>> expressionToRestore)
        {
            _valueWriter = expressionToStore.Compile();
            _valueReader = expressionToRestore.Compile();
        }

        public override object ReadJson(JsonReader reader, Type objectType,
                                        object existingValue, JsonSerializer serializer)
        {
            object value = null;
            switch (reader.TokenType)
            {
                case JsonToken.Float:
                case JsonToken.Integer:
                    value = _valueReader(Convert.ToDouble(reader.Value));
                    break;
                case JsonToken.Null:
                case JsonToken.String:
                    value = null;
                    break;
            }
            return value;
        }

        public override void WriteJson(JsonWriter writer, object value,
                                       JsonSerializer serializer)
        {
            var unit = (T?)value;
            if (!unit.HasValue)
            {
                writer.WriteValue((double?)null);
            }
            else
            {
                writer.WriteValue(_valueWriter(unit.Value));
            }
        }
    }

}
