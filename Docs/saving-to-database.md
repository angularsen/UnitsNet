# Saving to Database

There is currently no out-of-the-box solution for storing UnitsNet quantities and units in an SQL database, or any other database.

The main reason is that UnitsNet does occasionally need to do breaking changes on the unit definitions:
- Rename or remove a quantity or a unit
- Change the unit abbreviations for a unit

It is not trivial to ensure backwards compatibility for these changes, for different types of databases and ORM frameworks.
Handling it properly may involve storing the version of UnitsNet with the data, and having migration steps between versions.

## Simple approaches

### 1. Single column for the value

Store the `Value` of the quantity, converted to _some_ base unit (e.g. storing all values as `MassUnit.Gram` or `VolumeUnit.Milliliter`). This is probably the only option that can support direct database queries (anything else would require some form of a `CASE` switching query on the set of applicable units). This option assumes that the UI is responsible for actually selecting an appropriate display unit for the quantity.

### 2. Two columns for value and unit

Map the `{Value, Unit}` pair to two columns. This assumes that the user is expecting to see the quantity in the same unit as it was entered. The slight problem here is when dealing with the non-default abbreviations — if the UI supports the input of the quantity using _all_ of the unit abbreviations, then you wouldn't be able to restore the _exact quantity string_ (e.g. expecting "ts." instead of "tsp" for the `MetricTeaspoon`). This is of course not a huge issue, but something to keep in mind when mapping _custom abbreviations_.

### 3. Single string column

The code for parsing a quantity from string is still very slow, so option 2 is likely better for performance.

## Recommended approach

Serialize `double Value` and `string UnitName` similar to how we do [JSON serialization](serialization.md), but use your own custom serialization format to avoid any breaking changes in names of UnitsNet:

```cs
IQuantity myQuantity = ...;

var myDbEntity = new MyDbEntity {
    Value = myQuantity.Value,
    UnitName = myQuantity switch {
        LengthUnit.Meter => "Length:Meter",
        LengthUnit.Centimeter => "Length:Centimeter",
        MassUnit.Kilogram => "Mass:Kilogram",
        // ... and any other units we want to support serializing
        _ => throw new NotImplementedException("Unit not supported for serialization to SQL: " + myQuantity.Unit);
    }
};
```

You would then have to parse it back out with a simple `string.Split` and similar switch conditions.
It's a boring one time job, but then you are in full control of any future changes to the library and will get compile errors if anything is renamed or removed.

From discussion: https://github.com/angularsen/UnitsNet/discussions/1513#discussioncomment-12243230
