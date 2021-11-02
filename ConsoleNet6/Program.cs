// See https://aka.ms/new-console-template for more information

using ConsoleNet6;
using static System.Console;
using static ConsoleNet6.LengthUnit;

void Foo<TQuantity>(TQuantity left, TQuantity right)
    where TQuantity : IQuantity<TQuantity>
{
    WriteLine("Foo\n---");
    WriteLine("left: " + left);
    WriteLine("right: " + right);
    WriteLine("left.CompareTo(right): "             + left.CompareTo(right));
    WriteLine("left + right: "                      + (left + right));
    WriteLine("TQuantity.Parse(\"25 m\", null): " + TQuantity.Parse("25 m", null));
}

TQuantity Sum<TQuantity>(IEnumerable<TQuantity> items)
    where TQuantity : IQuantity<TQuantity>
{
    return items.Aggregate(TQuantity.Zero, (acc, item) => acc + item);    
}

var oneMeter = new Length(1, Meter);
var tenCentimeters = new Length(10, Centimeter);

WriteLine("oneMeter + tenCentimeters: " + (oneMeter + tenCentimeters));

Foo(new Length(1, Meter), new Length(10, Centimeter));

Length[] lengths = new[] { 1, 2, 3, 4 }.Select(val => new Length(val, Meter)).ToArray();
WriteLine("Sum [1,2,3,4] array of meters: " + Sum(lengths));
