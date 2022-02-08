``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-PQJLDU : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.74 ns |     0.186 ns |     0.174 ns |      - |     - |     - |         - |
|         Constructor_SI |    394.57 ns |     3.309 ns |     2.933 ns | 0.0097 |     - |     - |     192 B |
|             FromMethod |     29.85 ns |     0.353 ns |     0.330 ns |      - |     - |     - |         - |
|             ToProperty |    189.65 ns |     2.573 ns |     2.148 ns | 0.0058 |     - |     - |     112 B |
|                     As |    187.87 ns |     1.992 ns |     1.864 ns | 0.0057 |     - |     - |     112 B |
|                  As_SI |    392.83 ns |     4.449 ns |     3.944 ns | 0.0096 |     - |     - |     192 B |
|                 ToUnit |    194.53 ns |     1.956 ns |     1.734 ns | 0.0058 |     - |     - |     112 B |
|              ToUnit_SI |    402.21 ns |     7.083 ns |     6.625 ns | 0.0097 |     - |     - |     192 B |
|           ToStringTest |  1,631.40 ns |    16.926 ns |    15.832 ns | 0.0485 |     - |     - |     944 B |
|                  Parse | 54,759.23 ns |   674.995 ns |   563.651 ns | 1.7693 |     - |     - |   33345 B |
|          TryParseValid | 54,421.09 ns | 1,062.589 ns | 1,136.958 ns | 1.6726 |     - |     - |   33320 B |
|        TryParseInvalid | 58,415.69 ns |   894.656 ns |   836.861 ns | 1.7303 |     - |     - |   32929 B |
|           QuantityFrom |     87.23 ns |     0.792 ns |     0.741 ns | 0.0029 |     - |     - |      56 B |
|           IQuantity_As |    195.79 ns |     3.522 ns |     3.295 ns | 0.0073 |     - |     - |     136 B |
|        IQuantity_As_SI |    393.84 ns |     6.090 ns |     5.697 ns | 0.0096 |     - |     - |     192 B |
|       IQuantity_ToUnit |    199.18 ns |     4.092 ns |     4.548 ns | 0.0086 |     - |     - |     168 B |
| IQuantity_ToStringTest |  1,757.77 ns |    32.332 ns |    28.661 ns | 0.0486 |     - |     - |     944 B |
