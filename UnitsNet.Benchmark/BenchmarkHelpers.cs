// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet.Benchmark;

public static class BenchmarkHelpers
{
    public static string[] GetRandomAbbreviations<TQuantity>(this Random random, UnitAbbreviationsCache abbreviations, int nbAbbreviations)
    {
        return random.GetItems(abbreviations.GetAllUnitAbbreviationsForQuantity(typeof(TQuantity)).ToArray(), nbAbbreviations);
    }
    
    public static (TQuantity Quantity, TUnit Unit)[] GetRandomConversions<TQuantity, TUnit>(this Random random, double value, TUnit[] options,
        int nbConversions)
        where TQuantity : IQuantity<TUnit>
        where TUnit : Enum
    {
        var quantities = GetRandomQuantities<TQuantity, TUnit>(random, value, options, nbConversions);
        TUnit[] units = random.GetItems(options, nbConversions);
        return quantities.Zip(units, (quantity, unit) => (quantity, unit)).ToArray();
    }

    public static IEnumerable<TQuantity> GetRandomQuantities<TQuantity, TUnit>(this Random random, double value, TUnit[] units, int nbQuantities)
        where TQuantity : IQuantity<TUnit> where TUnit : Enum
    {
        IEnumerable<TQuantity> quantities = random.GetItems(units, nbQuantities).Select(unit => (TQuantity)Quantity.From(value, unit));
        return quantities;
    }

#if !NET
    /// <summary>Creates an array populated with items chosen at random from the provided set of choices.</summary>
    /// <param name="random">The random number generator used to select items.</param>
    /// <param name="choices">The items to use to populate the array.</param>
    /// <param name="length">The length of array to return.</param>
    /// <typeparam name="T">The type of array.</typeparam>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="choices" /> is empty.</exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="choices" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="length" /> is not zero or a positive number.</exception>
    /// <returns>An array populated with random items.</returns>
    public static T[] GetItems<T>(this Random random, T[] choices, int length)
    {
        return GetItems<T>(random, new ReadOnlySpan<T>(choices), length);
    }
    
    /// <summary>
    /// Generates an array of specified length with items chosen at random from the provided set of choices.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    /// <param name="random">The random number generator used to select items.</param>
    /// <param name="choices">The set of items to choose from.</param>
    /// <param name="length">The length of the resulting array.</param>
    /// <returns>An array of randomly selected items.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="choices"/> is empty.</exception>
    public static T[] GetItems<T>(this Random random, ReadOnlySpan<T> choices, int length)
    {
        T[] array = new T[length];
        GetItems<T>(random, choices, array.AsSpan<T>());
        return array;
    }

    /// <summary>Fills the elements of a specified span with items chosen at random from the provided set of choices.</summary>
    /// <param name="random">The random number generator used to select items.</param>
    /// <param name="choices">The items to use to populate the span.</param>
    /// <param name="destination">The span to be filled with items.</param>
    /// <typeparam name="T">The type of span.</typeparam>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="choices" /> is empty.</exception>
    public static void GetItems<T>(this Random random, ReadOnlySpan<T> choices, Span<T> destination)
    {
        for (int index = 0; index < destination.Length; ++index)
            destination[index] = choices[random.Next(choices.Length)];
    }
    #endif
}
