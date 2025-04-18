using UnitsNet;
using UnitsNet.Units;

namespace UnitsNetSetup.Configuration;

internal static class ConfigureWithCustomConversions
{
    public static void Configure()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(
            builder => builder
                // configure custom conversion coefficients while preserving the default QuantityInfo for the Pressure (which has the "Pascal" as the DefaultBaseUnit)
                .ConfigureQuantity(() => Pressure.PressureInfo.CreateDefault(ConfigureCustomPressureUnitConversions))
                // configure a "completely new" configuration for the TemperatureDelta
                .ConfigureQuantity<TemperatureDelta, TemperatureDeltaUnit>(CreateCustomTemperatureConfiguration)
        );
    }

    private static IEnumerable<IUnitDefinition<PressureUnit>> ConfigureCustomPressureUnitConversions(IEnumerable<UnitDefinition<PressureUnit>> unitDefinitions)
    {
        // we customize a subset of the existing unit definitions (preserving the rest)
        return unitDefinitions.Select(definition => definition.Value switch
        {
            // since these conversions don't involve a constant term we can only specify the conversionFromBase (with the inverse conversion assumed to be the inverse: e.g. 1/999)
            PressureUnit.InchOfWaterColumn => new UnitDefinition<PressureUnit>(definition.Value, definition.Name, definition.BaseUnits, conversionFromBase: 999),
            PressureUnit.MeterOfWaterColumn => definition.WithConversionFromBase(1234.5m),
            PressureUnit.MillimeterOfWaterColumn => definition.WithConversionFromBase(1.2345),
            PressureUnit.MillimeterOfMercury => new UnitDefinition<PressureUnit>(definition.Value, definition.Name, definition.BaseUnits, QuantityValue.FromTerms(1, 3)),
            PressureUnit.Decapascal => new UnitDefinition<PressureUnit>(definition.Value, definition.Name, definition.PluralName, definition.BaseUnits,
                definition.ConversionFromBase.Coefficient * 1.2m,
                definition.ConversionToBase.Coefficient / 1.2m
                ),
            // all preceding conversions result in something of the form:
            PressureUnit.InchOfMercury => new UnitDefinition<PressureUnit>(PressureUnit.InchOfMercury, definition.Name, definition.PluralName, definition.BaseUnits,
                // f(x) = 1/3 * x
                QuantityValue.FromTerms(1, 3),
                // f(x) = 3 * g(x)^1 + 0  // with g(x) => x in this case
                new ConversionExpression(
                    3,
                    null, // a delegate of the form QuantityValue -> QuantityValue (when null, g(x) = x)
                    1,
                    0)),
            // we keep all other unit conversions as they are
            _ => definition
        });
    }

    private static QuantityInfo<TemperatureDelta, TemperatureDeltaUnit> CreateCustomTemperatureConfiguration()
    {
        // the default BaseUnit for the TemperatureDelta is the Kelvin, but for the purposes of this demo, we can change it to DegreeCelsius
        // note that changing the base unit would normally require us to modify all the conversion coefficients, which isn't a trivial task (a generic extension method could be added in the future) 
        return new QuantityInfo<TemperatureDelta, TemperatureDeltaUnit>(
            "MyTemperature",
            TemperatureDeltaUnit.DegreeCelsius,
            // since the conversion coefficient for the new base is the same of the last we don't have to modify anything here
            TemperatureDelta.TemperatureDeltaInfo.GetDefaultMappings(),
            // these correspond to the SI dimensions for the quantity: no reason to modify them
            TemperatureDelta.TemperatureDeltaInfo.DefaultBaseDimensions,
            // we could provide a custom delegate here ((QuantityValue, TemperatureDeltaUnit) => TemperatureDelta), but this is not particularly useful for the default quantities
            TemperatureDelta.From // while required on netstandard2.0, this parameter is optional in net7+
        );
    }

    public static void OutputPressure()
    {
        var pressure = Pressure.FromPascals(100);
        Console.WriteLine(pressure); // outputs: "100 Pa"
        Console.WriteLine(pressure.As(PressureUnit.Kilopascal)); // outputs: "0.1"
        Console.WriteLine(pressure.As(PressureUnit.InchOfWaterColumn)); // outputs: "9990"
        Console.WriteLine(pressure.As(PressureUnit.MeterOfWaterColumn)); // outputs: "123450"
        Console.WriteLine(pressure.As(PressureUnit.MillimeterOfWaterColumn)); // outputs: "123.45"
        Console.WriteLine(pressure.As(PressureUnit.Decapascal)); // outputs: "12"
        Pressure pressureInInchesOfWaterColumn = pressure.ToUnit(PressureUnit.InchOfMercury);
        Console.WriteLine(pressureInInchesOfWaterColumn); // outputs: "33.33333333333333 inHg"
        Console.WriteLine(pressureInInchesOfWaterColumn.Value * 3 == 100); // outputs: "True"
        Pressure conversionBackToPascals = pressureInInchesOfWaterColumn
            .ToUnit(PressureUnit.Atmosphere)
            .ToUnit(PressureUnit.MeterOfWaterColumn)
            .ToUnit(PressureUnit.MillimeterOfWaterColumn)
            .ToUnit(PressureUnit.Decapascal)
            .ToUnit(PressureUnit.Pascal);
        Console.WriteLine(conversionBackToPascals); // outputs: "100 Pa"
        Console.WriteLine(conversionBackToPascals == pressure); // outputs: "True"
        Console.WriteLine(conversionBackToPascals == pressureInInchesOfWaterColumn); // outputs: "True"
    }

    public static void OutputTemperatureDelta()
    {
        TemperatureDelta temperatureDelta = default;
        Console.WriteLine(temperatureDelta.Unit); // outputs: "DegreeCelsius"
        Console.WriteLine(temperatureDelta.QuantityInfo.Name); // outputs: "MyTemperature"
    }
}
