``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-ZNLZHM : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |      Error |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|------:|------:|----------:|
|            Constructor |     11.49 ns |   0.085 ns |   0.080 ns |      - |     - |     - |         - |
|         Constructor_SI |    386.20 ns |   4.067 ns |   3.396 ns | 0.0102 |     - |     - |     192 B |
|             FromMethod |     29.33 ns |   0.190 ns |   0.168 ns |      - |     - |     - |         - |
|             ToProperty |    181.08 ns |   1.553 ns |   1.377 ns | 0.0059 |     - |     - |     112 B |
|                     As |    203.65 ns |   2.184 ns |   2.043 ns | 0.0057 |     - |     - |     112 B |
|                  As_SI |    380.45 ns |   2.516 ns |   2.354 ns | 0.0099 |     - |     - |     192 B |
|                 ToUnit |    168.22 ns |   1.385 ns |   1.081 ns | 0.0060 |     - |     - |     112 B |
|              ToUnit_SI |    384.14 ns |   3.352 ns |   2.799 ns | 0.0100 |     - |     - |     192 B |
|           ToStringTest |  1,626.59 ns |  13.052 ns |  11.570 ns | 0.0487 |     - |     - |     944 B |
|                  Parse | 53,846.15 ns | 680.150 ns | 636.213 ns | 1.7003 |     - |     - |   33344 B |
|          TryParseValid | 53,080.38 ns | 788.623 ns | 737.679 ns | 1.6931 |     - |     - |   33320 B |
|        TryParseInvalid | 57,509.67 ns | 613.304 ns | 573.685 ns | 1.7102 |     - |     - |   32928 B |
|           QuantityFrom |     86.05 ns |   0.849 ns |   0.795 ns | 0.0029 |     - |     - |      56 B |
|           IQuantity_As |    200.91 ns |   3.445 ns |   3.223 ns | 0.0071 |     - |     - |     136 B |
|        IQuantity_As_SI |    380.25 ns |   2.622 ns |   2.189 ns | 0.0097 |     - |     - |     192 B |
|       IQuantity_ToUnit |    201.73 ns |   1.259 ns |   1.051 ns | 0.0088 |     - |     - |     168 B |
| IQuantity_ToStringTest |  1,532.42 ns |  26.154 ns |  24.465 ns | 0.0488 |     - |     - |     944 B |
