``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-DKTSHI : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.85 ns |     0.274 ns |     0.256 ns |      - |     - |     - |         - |
|         Constructor_SI |    406.47 ns |     7.954 ns |    11.407 ns | 0.0096 |     - |     - |     192 B |
|             FromMethod |     31.27 ns |     0.636 ns |     0.595 ns |      - |     - |     - |         - |
|             ToProperty |     10.89 ns |     0.252 ns |     0.248 ns |      - |     - |     - |         - |
|                     As |     11.51 ns |     0.258 ns |     0.241 ns |      - |     - |     - |         - |
|                  As_SI |    406.41 ns |     8.149 ns |     9.058 ns | 0.0096 |     - |     - |     192 B |
|                 ToUnit |     20.51 ns |     0.456 ns |     0.488 ns |      - |     - |     - |         - |
|              ToUnit_SI |    413.87 ns |     5.677 ns |     5.310 ns | 0.0100 |     - |     - |     192 B |
|           ToStringTest |  1,667.38 ns |    32.360 ns |    43.200 ns | 0.0501 |     - |     - |     944 B |
|                  Parse | 55,306.80 ns | 1,099.206 ns | 1,896.077 ns | 1.7637 |     - |     - |   33344 B |
|          TryParseValid | 56,574.03 ns | 1,113.062 ns | 1,665.978 ns | 1.7633 |     - |     - |   33320 B |
|        TryParseInvalid | 58,072.23 ns |   996.871 ns | 1,364.528 ns | 1.6453 |     - |     - |   32928 B |
|           QuantityFrom |  4,075.00 ns |    81.327 ns |   144.559 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     24.90 ns |     0.546 ns |     1.025 ns | 0.0012 |     - |     - |      24 B |
|        IQuantity_As_SI |    405.76 ns |     7.756 ns |     8.621 ns | 0.0102 |     - |     - |     192 B |
|       IQuantity_ToUnit |     38.46 ns |     0.873 ns |     1.917 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,665.32 ns |    33.125 ns |    44.221 ns | 0.0493 |     - |     - |     944 B |
