# Adding Operator Overloads

There is a large number of operator overloads, to facilitate strongly typed computations such as `Speed speed = Length.FromMeters(100) / TimeSpan.FromSeconds(9)`.

1. Put operator overload in `Length.extra.cs` if the **first parameter** is `Length`
2. Add a short xmldoc summary as per the example below. You can add more descriptions if it is useful.
3. Add a unit test case and place it in the equivalent file `LengthTests.cs`.

The reason is to have a consistent place to find the operator overloads and the compiler complains if the containing type/file does not match any of the parameters of the operator overload method.

## Example

[UnitsNet/CustomCode/Quantities/Length.extra.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet/CustomCode/Quantities/Length.extra.cs)
```cs
/// <summary>Get <see cref="Volume"/> from <see cref="Length"/> times <see cref="Area"/>.</summary>
public static Volume operator *(Length length, Area area)
{
    return Volume.FromCubicMeters(area.SquareMeters * length.Meters);
}
```

[UnitsNet.Tests/CustomCode/LengthTests.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.Tests/CustomCode/LengthTests.cs)
```cs
[Fact]
public void LengthTimesAreaEqualsVolume()
{
    Volume volume = Length.FromMeters(3) * Area.FromSquareMeters(9);
    Assert.Equal(volume, Volume.FromCubicMeters(27));
}
```
