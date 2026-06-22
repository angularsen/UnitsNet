# Serialization

- [(Recommended) Map to your own custom DTO types](#recommended-map-to-your-own-custom-dto-types)
- [UnitsNet.Serialization.JsonNet with Json.NET (Newtonsoft)](#unitsnetserializationjsonnet-with-jsonnet-newtonsoft)
- [DataContractSerializer for XML](#datacontractserializer-for-xml)
- [DataContractJsonSerializer for JSON (not recommended)](#datacontractjsonserializer-for-json-not-recommended)
- [System.Text.Json (not yet implemented)](#systemtextjson-not-yet-implemented)
- [Protobuf and other `[DataContract]` compatible serializers](#protobuf-and-other-datacontract-compatible-serializers)
- [Backwards compatibility](#backwards-compatibility)

## (Recommended) Map to your own custom DTO types

The recommended approach is to create your own data transfer object types (DTO) and map to/from `IQuantity`.
This way you are in full control of the shape of your JSON, XML, etc. and also any breaking changes or deprecations to UnitsNet.

It could be solved like this, storing the value, quantity name and unit name:

```c#
// Your custom DTO type for quantities.
public record QuantityDto(double Value, string QuantityName, string UnitName);

// The original quantity.
IQuantity q = Length.FromCentimeters(5);

// Map to your custom DTO type.
QuantityDto dto = new(
    Value: (double)q.Value,
    QuantityName: q.QuantityInfo.Name,
    UnitName: q.Unit.ToString());

/* Serialize to JSON:
{
    "Value": 5,
    "QuantityName": "Length",
    "UnitName": "Centimeter"
}
*/
string json = System.Text.Json.JsonSerializer.Serialize(dto);

// Deserialize from JSON.
QuantityDto deserialized = System.Text.Json.JsonSerializer.Deserialize<QuantityDto>(json)!;

// Map back to IQuantity.
if (Quantity.TryFrom(deserialized.Value, deserialized.QuantityName, deserialized.UnitName, out IQuantity? deserializedQuantity))
{
    // Take your quantity and run with it.
}
```

Alternatively, you can choose to use our custom serializers to map to/from `IQuantity` to JSON, XML etc.
We strive to avoid breaking changes, but we can't guarantee it.

## UnitsNet.Serialization.JsonNet with Json.NET (Newtonsoft)

### Example

```c#
var jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
jsonSerializerSettings.Converters.Add(new UnitsNetIQuantityJsonConverter());

string json = JsonConvert.SerializeObject(new { Name = "Raiden", Weight = Mass.FromKilograms(90) }, jsonSerializerSettings);

object obj = JsonConvert.DeserializeObject(json);
```

JSON output:
```json
{
  "Name": "Raiden",
  "Weight": {
    "Unit": "MassUnit.Kilogram",
    "Value": 90.0
  }
}
```

### Serializing `IComparable`

If you need to support deserializing into properties/fields of type `IComparable` instead of type `IQuantity`, then you can add
```c#
jsonSerializerSettings.Converters.Add(new UnitsNetIComparableJsonConverter());
```

## DataContractSerializer for XML

All quantities and the `IQuantity` interface have `[DataContract]` annotations and can be serialized by the built-in XML [DataContractSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer).

```xml
<Power xmlns="http://schemas.datacontract.org/2004/07/UnitsNet"
       xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
    <Value>1.20</Value>
    <Unit>Milliwatt</Unit>
</Power>
```

Serializing `IQuantity` with additional type information:
```c#
[DataContract]
[KnownType(typeof(Mass))]
[KnownType(typeof(Information))]
public class Foo
{
    [DataMember]
    public IQuantity Quantity { get; set; }
}

// Serialized object
new Foo { Quantity = new Information(1.20m, InformationUnit.Exabyte) };
```
```xml
<Foo xmlns="http://schemas.datacontract.org/2004/07/UnitsNet.Tests.Serialization"
                     xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
    <Quantity i:type="a:Information" xmlns:a="http://schemas.datacontract.org/2004/07/UnitsNet">
        <a:Value>1.20</a:Value>
        <a:Unit>Exabyte</a:Unit>
    </Quantity>
</Foo>
```

## DataContractJsonSerializer for JSON (not recommended)

For JSON, we recommend [UnitsNet.Serialization.JsonNet](https://www.nuget.org/packages/UnitsNet.Serialization.JsonNet) with Json.NET (Newtonsoft) instead.

All quantities and the `IQuantity` interface have `[DataContract]` annotations and can be serialized by the built-in JSON [DataContractJsonSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.json.datacontractjsonserializer).

It is not recommended, because the enum value is serialized as integer and this value is not stable.

Schema:
```json
{
  "__type": "Information:#UnitsNet",
  "Value": 1.20,
  "Unit": 4
}
```

## System.Text.Json (not yet implemented)

See
- [WIP: Add serialization support for System.Text.Json #905](https://github.com/angularsen/UnitsNet/pull/905)
- [Add serialization support for System.Text.Json (Attempt #2) #966](https://github.com/angularsen/UnitsNet/pull/966)

## Protobuf and other `[DataContract]` compatible serializers

TODO Test and document here.

## Backwards compatibility

We strive to maintain backwards compatibility of round-trip serialization within a major version.
However, the quantities and units themselves are inherently not stable:

- The base unit of quantities has changed several times in the history, e.g. Kilogram -> Gram.
- The unit enum value is not stable due to code generator sorting units alphabetically.

This is why the full unit name is serialized in Json.NET, so we can avoid ambiguity and be robust to any internal changes of the quantities and units.
