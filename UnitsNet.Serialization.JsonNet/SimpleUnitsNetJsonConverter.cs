using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using UnitsNet.InternalHelpers;

namespace UnitsNet.Serialization.JsonNet
{
    public class SimpleUnitsNetJsonConverter : JsonConverter
    {

        private readonly object[] _targetUnit = null;

        public SimpleUnitsNetJsonConverter() { }

        public SimpleUnitsNetJsonConverter(object TargetUnits)
        {
            _targetUnit = new object[] { TargetUnits };
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
            return notNullableFromMethod.Invoke(null, new[] { reader.Value });
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
