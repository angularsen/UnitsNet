using System.Diagnostics;

namespace UnitsNetSetup.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("UnitsNet Configuration Samples");
        var activeScenario = args[0];
        
        var startingTimestamp = Stopwatch.GetTimestamp();
        switch (activeScenario)
        {
            case "CachingOptions":
                StartWithCachingOptions(args.Length == 1 ? null : args[1]);
                break;
            case "CustomConversions":
                StartWithCustomConversions();
                break;
            case "CustomQuantities":
                StartWithCustomQuantities();
                break;
            default:
                Console.WriteLine("\nInvalid scenario specified.");
                break;
        }

        Console.WriteLine($"Finished in {Stopwatch.GetElapsedTime(startingTimestamp, Stopwatch.GetTimestamp())}");
    }

    private static void StartWithCachingOptions(string? configurationToUse)
    {
        Console.WriteLine($"Running Caching Options Scenario with configuration: {configurationToUse}");
        switch (configurationToUse)
        {
            case "AsFrozen":
                ConfigureWithConverterCachingOptions.ConfigureAsFrozen();
                break;
            case "WithoutCaching":
                ConfigureWithConverterCachingOptions.ConfigureWithoutCaching();
                break;
            case "AsFrozenWithCustomCachingOptions":
                ConfigureWithConverterCachingOptions.ConfigureAsFrozenWithCustomCachingOptions();
                break;
            case "WithSpecificQuantitiesAsFrozen":
                ConfigureWithConverterCachingOptions.ConfigureWithSpecificQuantitiesAsFrozen();
                break;
            case "WithSpecificQuantitiesAndUnitsAsFrozen":
                ConfigureWithConverterCachingOptions.ConfigureWithSpecificQuantitiesAndUnitsAsFrozen();
                break;
            default:
                ConfigureWithConverterCachingOptions.ConfigureDefault();
                break;
        }
        ConfigureWithConverterCachingOptions.OutputDensity();
    }


    private static void StartWithCustomConversions()
    {
        Console.WriteLine($"{DateTime.Now}: Running the Custom Conversions Scenario");
        ConfigureWithCustomConversions.Configure();
        ConfigureWithCustomConversions.OutputPressure();
        ConfigureWithCustomConversions.OutputTemperatureDelta();
    }

    private static void StartWithCustomQuantities()
    {
        Console.WriteLine("\nRunning the Custom Quantities Scenario");
        ConfigureWithCustomQuantities.Configure();
        ConfigureWithCustomQuantities.OutputHowMuch();
    }
}
