// See https://aka.ms/new-console-template for more information

using ConsoleNet6;
using static System.Console;
using static ConsoleNet6.LengthUnit;

void Foo<TQuantity>(TQuantity left, TQuantity right)
    where TQuantity : IQuantity<TQuantity>
{
    WriteLine($"Foo({left}, {right})\n---\n");
    WriteLine(left.CompareTo(right).ToString().PadRight(20)             + "<==  left.CompareTo(right)");
    WriteLine((left + right).ToString()!.PadRight(20)                   + "<==  left + right");
    WriteLine(TQuantity.Parse("25 m", null).ToString()!.PadRight(20)    + "<==  TQuantity.Parse(\"25 m\", null)");
}

TQuantity Sum<TQuantity>(IEnumerable<TQuantity> items)
    where TQuantity : IQuantity<TQuantity>
{
    return items.Aggregate(TQuantity.Zero, (acc, item) => acc + item);    
}

var oneMeter = new Length(1, Meter);
var tenCentimeters = new Length(10, Centimeter);

Foo(oneMeter, tenCentimeters);

Length[] lengths = new[] { 1, 2, 3, 4 }.Select(val => new Length(val, Meter)).ToArray();
WriteLine(Sum(lengths).ToString()!.PadRight(20)                          + "<==  Sum [1,2,3,4] array of meters");
