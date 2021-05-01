``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-NYOTTA : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.339 ns |     0.2066 ns |     0.1932 ns |      - |     - |     - |         - |
|         Constructor_SI |    377.266 ns |     6.2353 ns |     5.8325 ns | 0.0068 |     - |     - |     192 B |
|             FromMethod |     30.773 ns |     0.1965 ns |     0.1641 ns |      - |     - |     - |         - |
|             ToProperty |      9.605 ns |     0.1047 ns |     0.0979 ns |      - |     - |     - |         - |
|                     As |      9.689 ns |     0.2393 ns |     0.2238 ns |      - |     - |     - |         - |
|                  As_SI |    409.885 ns |     6.8476 ns |     6.4052 ns | 0.0073 |     - |     - |     192 B |
|                 ToUnit |     19.749 ns |     0.3254 ns |     0.3043 ns |      - |     - |     - |         - |
|              ToUnit_SI |    386.188 ns |     5.5953 ns |     4.9601 ns | 0.0069 |     - |     - |     192 B |
|           ToStringTest |  1,624.069 ns |    24.6341 ns |    23.0428 ns | 0.0350 |     - |     - |     944 B |
|                  Parse | 55,940.538 ns |   912.8246 ns |   853.8567 ns | 1.2194 |     - |     - |   33344 B |
|          TryParseValid | 57,506.724 ns | 1,127.7484 ns | 1,580.9457 ns | 1.2421 |     - |     - |   33320 B |
|        TryParseInvalid | 59,684.317 ns | 1,124.7408 ns | 1,104.6458 ns | 1.1875 |     - |     - |   32928 B |
|           QuantityFrom |  3,631.579 ns |    72.3020 ns |   207.4481 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     22.297 ns |     0.2926 ns |     0.2594 ns | 0.0009 |     - |     - |      24 B |
|        IQuantity_As_SI |    394.638 ns |     4.0634 ns |     3.8009 ns | 0.0071 |     - |     - |     192 B |
|       IQuantity_ToUnit |     36.843 ns |     0.6774 ns |     0.5657 ns | 0.0021 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,587.227 ns |    15.3290 ns |    13.5888 ns | 0.0349 |     - |     - |     944 B |
