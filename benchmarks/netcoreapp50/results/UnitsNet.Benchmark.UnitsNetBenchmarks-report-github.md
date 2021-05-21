``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-JNXRND : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     10.763 ns |     0.2318 ns |     0.2055 ns |      - |     - |     - |         - |
|         Constructor_SI |    357.011 ns |     6.9501 ns |     7.1372 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     27.487 ns |     0.5924 ns |     0.7052 ns |      - |     - |     - |         - |
|             ToProperty |      9.647 ns |     0.2380 ns |     0.2444 ns |      - |     - |     - |         - |
|                     As |     10.451 ns |     0.2526 ns |     0.3781 ns |      - |     - |     - |         - |
|                  As_SI |    352.645 ns |     6.8576 ns |     7.0422 ns | 0.0099 |     - |     - |     192 B |
|                 ToUnit |     18.383 ns |     0.4053 ns |     0.4667 ns |      - |     - |     - |         - |
|              ToUnit_SI |    362.727 ns |     5.1353 ns |     4.2882 ns | 0.0101 |     - |     - |     192 B |
|           ToStringTest |  1,397.464 ns |    25.8384 ns |    29.7555 ns | 0.0479 |     - |     - |     944 B |
|                  Parse | 48,715.932 ns |   958.7754 ns | 1,344.0693 ns | 1.7484 |     - |     - |   33344 B |
|          TryParseValid | 48,514.317 ns |   876.2628 ns |   731.7191 ns | 1.7635 |     - |     - |   33320 B |
|        TryParseInvalid | 52,370.138 ns | 1,031.5594 ns | 1,266.8476 ns | 1.6589 |     - |     - |   32928 B |
|           QuantityFrom |  3,025.253 ns |   104.7365 ns |   307.1739 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     23.033 ns |     0.5043 ns |     0.8965 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    369.116 ns |     7.3847 ns |    10.5910 ns | 0.0102 |     - |     - |     192 B |
|       IQuantity_ToUnit |     32.982 ns |     0.7283 ns |     1.0210 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,500.382 ns |    29.4444 ns |    32.7274 ns | 0.0505 |     - |     - |     944 B |
