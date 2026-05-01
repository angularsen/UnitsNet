# Experimental: Generic Math and INumber

Generic math was introduced in .NET 7.
https://learn.microsoft.com/en-us/dotnet/standard/generics/math

We wanted to see what works and what doesn't for Units.NET, so we added some experimental support for the generic math interfaces in
[Generic math for UnitsNet in .NET 7 - Pull Request #1164](https://github.com/angularsen/UnitsNet/pull/1164).

Today, all quantities use `double`.
With generics, the consumer would be able to choose the numeric type, including new types like `float`.

## What can you do

Sum and Average, for now.

```cs
[Fact]
public void CanCalcSum()
{
    Length[] values = { Length.FromCentimeters(100), Length.FromCentimeters(200) };

    Assert.Equal(Length.FromCentimeters(300), values.Sum());
}

[Fact]
public void CanCalcAverage_ForQuantitiesWithDoubleValueType()
{
    Length[] values = { Length.FromCentimeters(100), Length.FromCentimeters(200) };

    Assert.Equal(Length.FromCentimeters(150), values.Average());
}
```

It seems there are no implementations shipped with .NET yet, so we provide these two extension methods as a proof of concept.
We can add more if there is a need for it.

https://github.com/angularsen/UnitsNet/blob/master/UnitsNet/GenericMath/GenericMathExtensions.cs

```cs
public static T Sum<T>(this IEnumerable<T> source)
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
{
    // Put accumulator on right hand side of the addition operator to construct quantities with the same unit as the values.
    // The addition operator implementation picks the unit from the left hand side, and the additive identity (e.g. Length.Zero) is always the base unit.
    return source.Aggregate(T.AdditiveIdentity, (acc, item) => item + acc);
}

public static T Average<T>(this IEnumerable<T> source)
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>, IDivisionOperators<T, double, T>
{
    // Put accumulator on right hand side of the addition operator to construct quantities with the same unit as the values.
    // The addition operator implementation picks the unit from the left hand side, and the additive identity (e.g. Length.Zero) is always the base unit.
    (T value, int count) result = source.Aggregate(
        (value: T.AdditiveIdentity, count: 0),
        (acc, item) => (value: item + acc.value, count: acc.count + 1));

    return result.value / result.count;
}
```

## Some quirks so far

### INumber.Min/Max not well defined

[INumber](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.inumber-1)

UnitsNet does not provide Min/Max values for quantities, since you quickly run into overflow exceptions when converting to other units.
Also the Min/Max could change when introducing bigger/smaller units.

### IAdditiveIdentity (Zero) not intuitive for quantities like Temperature

Temperature has its own quirks with arithmetic in general.

0 Celsius != 0 Fahrenheit != 0 Kelvin.

So for example 20 degrees C + 5 degrees C is ambiguous.
It could mean 25 degrees C, or it could mean 293.15 K + 278.15 K.

This made it hard to implement [IAdditiveIdentity](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.iadditiveidentity-2) in a way that is intuitive, which is essential to arithmetic like `Average()`.

We previously introduced `TemperatureDelta` to make arithmetic more clear, but this is not compatible with generic math.

### Could not implement generic Average()

[I was not able](https://github.com/angularsen/UnitsNet/pull/1164#issuecomment-1366726144) to create a truly generic `Average()` for both `double` and `decimal`, the compiler would complain about ambiguity, so I wound up with `DecimalGenericMathExtensions.Average<T>`. It doesn't mean it can't be done, but I could not figure it out.

### Quantities are not numbers, they are numbers + units

We can't implement `INumber<>`, but we can implement some individual generic math interfaces like `IAdditionOperators`, `IMultiplyOperators`, `IAdditiveIdentity`.

Units can trip up things like `Average()` using `IAdditiveIdentity` as the starting value, which typically maps to `Length.Zero`. Since addition picks the left hand side unit, the addition argument order must be so that the accumulated value is on the right hand side, to avoid getting the base unit instead of the first item's unit.

## Decisions and challenges

1. Can we avoid having to specify the numeric type `Length<double>` everywhere?
    1. We could have a default `Length` and a generic `Length<T>`, where the default was like today with `double` for all or most quantities. Due to `struct` not supporting inheritance, we would have to create twice as many quantities as today.
    1. If changed from `struct` to `class`, we could create derived types in different namespaces, like `UnitsNet.Double.Length` and `UnitsNet.Decimal.Length` deriving from `Length<T>`.
