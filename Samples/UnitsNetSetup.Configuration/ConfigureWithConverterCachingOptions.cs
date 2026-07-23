using UnitsNet;
using UnitsNet.Units;

namespace UnitsNetSetup.Configuration;

internal static class ConfigureWithConverterCachingOptions
{
    /// <summary>
    ///     Demonstrates the default caching options for the UnitsNet configuration.
    /// </summary>
    /// <remarks>
    ///     This method sets up the configuration using the same caching options as the ones which are used by default:
    ///     The configuration uses an empty dynamic cache (backed by a ConcurrentDictionary), with the option to reduce any conversion expression prior to
    ///     caching.
    ///     <para>
    ///         This configuration has a small overhead when it first encounters a particular combination of units, as well
    ///         as some overhead due to locking.
    ///     </para>
    /// </remarks>
    public static void ConfigureDefault()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithConverterOptions(new QuantityConverterBuildOptions(freeze: false, defaultCachingMode: ConversionCachingMode.None, reduceConstants: true)));
    }

    /// <summary>
    ///     Demonstrates the use of a fully-cached immutable (a.k.a. "frozen") caching configuration.
    /// </summary>
    /// <remarks>
    ///     This method sets up the configuration using an immutable cache (backed by a FrozenDictionary) and loads up the unit
    ///     conversions for all quantities (~40K).
    ///     <para>
    ///         While offering the best performance for all subsequent operations, this configuration comes with increase
    ///         startup time and memory footprint:
    ///     </para>
    ///     <para>On a modern machine this takes up around ~30 ms, and uses ~12 MB of RAM.</para>
    /// </remarks>
    public static void ConfigureAsFrozen()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithConverterOptions(new QuantityConverterBuildOptions(freeze: true, defaultCachingMode: ConversionCachingMode.All, reduceConstants: true)));
    }

    /// <summary>
    ///     Demonstrates the use of a no-caching configuration.
    /// </summary>
    /// <remarks>
    ///     This method sets up a configuration which doesn't support caching.
    ///     <para>While having the smallest memory footprint, this configuration is about 2x slower than the alternatives.</para>
    /// </remarks>
    public static void ConfigureWithoutCaching()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithConverterOptions(new QuantityConverterBuildOptions(freeze: true, defaultCachingMode: ConversionCachingMode.None)));
    }

    /// <summary>
    ///     Demonstrates the use of an immutable (a.k.a. "frozen") caching configuration which caches only a specific selection of quantities.
    /// </summary>
    /// <remarks>
    ///     This method sets up the configuration using an immutable cache (backed by a FrozenDictionary) and loads up the unit
    ///     conversions for the Mass, Volume and Density.
    ///     <para>
    ///         The startup time and memory footprint for such a configuration should be fairly very small, while offering the best performance for the selected quantities,
    ///         while still being able to use the remaining quantities, without caching any of their conversions.
    ///     </para>
    /// </remarks>
    public static void ConfigureAsFrozenWithCustomCachingOptions()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithConverterOptions(new QuantityConverterBuildOptions(freeze: true, defaultCachingMode: ConversionCachingMode.None)
                .WithCustomCachingOptions<Mass>(new ConversionCacheOptions(cachingMode: ConversionCachingMode.All, reduceConstants: true))
                .WithCustomCachingOptions<Volume>(new ConversionCacheOptions(cachingMode: ConversionCachingMode.All, reduceConstants: true))
                .WithCustomCachingOptions<Density>(new ConversionCacheOptions(cachingMode: ConversionCachingMode.All, reduceConstants: true))));
    }

    /// <summary>
    ///     Demonstrates the use of a fully-cached immutable (a.k.a. "frozen") caching configuration with a specific set of
    ///     quantities.
    /// </summary>
    /// <remarks>
    ///     This method sets up a configuration containing only "Mass", "Volume" and "Density" and loads up all their unit
    ///     conversions into an immutable cache.
    ///     <para>
    ///         This configuration offers the best performance, by skipping the loading of all but the specified quantities,
    ///         however attempting to use any other quantity is going to result in a <see cref="QuantityNotFoundException" />.
    ///     </para>
    /// </remarks>
    public static void ConfigureWithSpecificQuantitiesAsFrozen()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithQuantities([Mass.Info, Volume.Info, Density.Info])
            .WithConverterOptions(new QuantityConverterBuildOptions(freeze: true, defaultCachingMode: ConversionCachingMode.All, reduceConstants: true)));
    }

    /// <summary>
    ///     Demonstrates the use of a fully-cached immutable (a.k.a. "frozen") caching configuration with a specific set of
    ///     quantities and a subset of their units.
    /// </summary>
    /// <remarks>
    ///     This method sets up a configuration containing only "Mass", "Volume" and "Density", each configured with a minimum
    ///     set of units, loaded into an immutable cache.
    ///     <para>
    ///         This configuration offers the absolute best performance (startup, operations and memory), by skipping the
    ///         loading of all but the specified quantities,
    ///         configured to contain the minimum set of required units, however attempting to use any other unit or quantity
    ///         is going to result in a <see cref="UnitNotFoundException" /> or <see cref="QuantityNotFoundException" />.
    ///     </para>
    ///     <para>
    ///         Note that instead of selecting a particular set of units, you can use the
    ///         <see cref="QuantityInfoBuilderExtensions.ExcludeUnits{TUnitDefinition,TUnit}" />
    ///         to remove units that you know to be inapplicable for the given application (e.g.
    ///         <see cref="MassUnit.EarthMass" /> and <see cref="MassUnit.SolarMass" />)
    ///     </para>
    /// </remarks>
    public static void ConfigureWithSpecificQuantitiesAndUnitsAsFrozen()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithQuantities(() => [
                Mass.MassInfo.CreateDefault(units => units.SelectUnits(MassUnit.Kilogram, MassUnit.Gram)),
                Volume.VolumeInfo.CreateDefault(units => units.SelectUnits(VolumeUnit.CubicMeter, VolumeUnit.Milliliter)),
                Density.DensityInfo.CreateDefault(units => units.SelectUnits(DensityUnit.KilogramPerCubicMeter, DensityUnit.GramPerMilliliter))
            ])
            .WithConverterOptions(new QuantityConverterBuildOptions(freeze: true, defaultCachingMode: ConversionCachingMode.All, reduceConstants: true)));
    }
    
    public static void OutputDensity()
    {
        var mass = Mass.FromGrams(5);
        var volume = Volume.FromMilliliters(2);
        Density density = mass / volume;
        Console.WriteLine($"Density: {density}"); // outputs "2500 kg/m3"
        Console.WriteLine($"Density: {density.ToUnit(DensityUnit.GramPerMilliliter)}");  // outputs "2.5 g/ml"
    }
}
