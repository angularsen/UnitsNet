# Serialization

- [(Recommended) Map to your own custom DTO types](#recommended-map-to-your-own-custom-dto-types)
- [UnitsNet.Serialization.JsonNet with Json.NET (Newtonsoft)](#unitsnetserializationjsonnet-with-jsonnet-newtonsoft)
- [DataContractSerializer for XML](#datacontractserializer-for-xml)
- [DataContractJsonSerializer for JSON (not recommended)](#datacontractjsonserializer-for-json-not-recommended)
- [UnitsNet.Serialization.SystemTextJson](#unitsnetserializationsystemtextjson)
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

### Choosing a `QuantityValue` format

`AbbreviatedUnitsConverter` uses `DecimalPrecision` when writing and `ExactNumber` when reading by default. Configure the
value representation explicitly when exact round-tripping or compatibility with an existing `double`-based payload is
required:

```c#
var valueFormats = new QuantityValueFormatOptions(
    QuantityValueSerializationFormat.RoundTrip,
    QuantityValueDeserializationFormat.RoundTrip);

jsonSerializerSettings.Converters.Add(new AbbreviatedUnitsConverter(valueFormats));
```

Available serialization formats are decimal precision (up to 29 significant digits), double precision, exact
round-tripping and a custom converter. `ExactNumber` reads every digit of a JSON number directly into its numeric
`QuantityValue`; it does not retain the original spelling of the token. Deserialization can alternatively recover
conventional rounded `double` values, read the round-trip representation or use a custom converter.

## DataContractSerializer for XML

All quantities and the `IQuantity` interface have `[DataContract]` annotations and can be serialized by the built-in XML [DataContractSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer).

Because `QuantityValue` is fraction-backed, configure the supplied surrogate provider to avoid exposing the internal
`BigInteger` representation of its numerator and denominator:

```c#
using System.Runtime.Serialization;
using UnitsNet.Serialization;

var serializer = new DataContractSerializer(typeof(Power));
serializer.SetSerializationSurrogateProvider(QuantityValueSurrogateSerializationProvider.Instance);
```

The compact representation stores the exact numerator and denominator:

```xml
<Power xmlns="http://schemas.datacontract.org/2004/07/UnitsNet"
       xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
    <Value>
        <N>12</N>
        <D>10</D>
    </Value>
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
        <a:Value>
            <a:N>12</a:N>
            <a:D>10</a:D>
        </a:Value>
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

## UnitsNet.Serialization.SystemTextJson

Install the `UnitsNet.Serialization.SystemTextJson` package and register converters for the value, unit and quantity
representations you want. For concrete quantity types, this example writes readable decimal values and unit
abbreviations:

```c#
using System.Text.Json;
using UnitsNet.Serialization.SystemTextJson;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Serialization.SystemTextJson.Value;

var options = new JsonSerializerOptions();
options.Converters.Add(new QuantityValueDecimalNotationConverter());
options.Converters.Add(new AbbreviatedUnitConverter());
options.Converters.Add(new JsonQuantityConverter());

string json = JsonSerializer.Serialize(Mass.FromGrams(4.2), options);
Mass mass = JsonSerializer.Deserialize<Mass>(json, options);
// {"Value":4.2,"Unit":"g"}
```

To serialize properties declared as `IQuantity`, use an interface converter. The payload includes the quantity type so it
can be reconstructed:

```c#
var options = new JsonSerializerOptions();
options.Converters.Add(new QuantityValueDecimalNotationConverter());
options.Converters.Add(new AbbreviatedInterfaceQuantityWithAvailableValueConverter());

string json = JsonSerializer.Serialize<IQuantity>(Length.FromMeters(10), options);
IQuantity quantity = JsonSerializer.Deserialize<IQuantity>(json, options);
// {"Value":10,"Unit":"m","Type":"Length"}
```

For exact round-tripping, use `QuantityValueMixedNotationConverter`. It emits finite values as decimal numbers and
non-terminating values such as one third as fractional strings. Other converters provide fractional-object, decimal and
`double` representations.

## Protobuf and other `[DataContract]` compatible serializers

TODO Test and document here.

## Backwards compatibility

We strive to maintain backwards compatibility of round-trip serialization within a major version.
However, the quantities and units themselves are inherently not stable:

- The base unit of quantities has changed several times in the history, e.g. Kilogram -> Gram.
- The unit enum value is not stable due to code generator sorting units alphabetically.

This is why the full unit name is serialized in Json.NET, so we can avoid ambiguity and be robust to any internal changes of the quantities and units.
