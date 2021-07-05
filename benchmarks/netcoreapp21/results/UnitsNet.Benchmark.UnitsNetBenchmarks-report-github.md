``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-CFMPDI : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.536 ns |     0.2939 ns |     0.8667 ns |     12.608 ns |      - |      - |     - |         - |
|         Constructor_SI |    613.106 ns |    11.4875 ns |    11.7968 ns |    615.106 ns | 0.0260 |      - |     - |     192 B |
|             FromMethod |     30.838 ns |     0.6417 ns |     0.6302 ns |     30.890 ns |      - |      - |     - |         - |
|             ToProperty |      8.956 ns |     0.2117 ns |     0.1980 ns |      9.026 ns |      - |      - |     - |         - |
|                     As |      8.966 ns |     0.2204 ns |     0.3016 ns |      8.904 ns |      - |      - |     - |         - |
|                  As_SI |    594.642 ns |    11.7195 ns |    24.7204 ns |    595.842 ns | 0.0261 |      - |     - |     192 B |
|                 ToUnit |     20.354 ns |     0.4545 ns |     0.9077 ns |     20.370 ns |      - |      - |     - |         - |
|              ToUnit_SI |    551.657 ns |    10.9629 ns |    20.5910 ns |    550.058 ns | 0.0259 |      - |     - |     192 B |
|           ToStringTest |  1,948.852 ns |    38.1508 ns |    59.3962 ns |  1,941.862 ns | 0.1357 |      - |     - |     952 B |
|                  Parse | 72,451.701 ns | 1,448.7782 ns | 2,212.4374 ns | 72,239.282 ns | 6.6676 | 0.1419 |     - |   44816 B |
|          TryParseValid | 71,788.492 ns | 1,422.6057 ns | 2,415.6924 ns | 71,462.836 ns | 6.5425 | 0.1422 |     - |   44792 B |
|        TryParseInvalid | 74,909.793 ns | 1,472.1455 ns | 2,157.8518 ns | 74,940.156 ns | 6.4381 | 0.1497 |     - |   44392 B |
|           QuantityFrom |  2,156.566 ns |    59.2903 ns |   173.8881 ns |  2,100.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     18.621 ns |     0.4088 ns |     0.6243 ns |     18.575 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    547.499 ns |    10.9739 ns |    24.7699 ns |    547.069 ns | 0.0264 |      - |     - |     192 B |
|       IQuantity_ToUnit |     29.361 ns |     0.6634 ns |     1.0900 ns |     29.098 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,060.572 ns |    41.1077 ns |    62.7759 ns |  2,047.663 ns | 0.1379 |      - |     - |     952 B |
