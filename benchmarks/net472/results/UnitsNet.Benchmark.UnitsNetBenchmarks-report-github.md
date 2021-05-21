``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-PDCUDG : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.903 ns |     0.3186 ns |     0.4362 ns |      - |      - |     - |         - |
|         Constructor_SI |    542.771 ns |    10.5048 ns |    13.6592 ns | 0.0294 |      - |     - |     201 B |
|             FromMethod |     33.377 ns |     0.7054 ns |     1.0982 ns |      - |      - |     - |         - |
|             ToProperty |      9.784 ns |     0.2440 ns |     0.3339 ns |      - |      - |     - |         - |
|                     As |     10.057 ns |     0.2428 ns |     0.4792 ns |      - |      - |     - |         - |
|                  As_SI |    562.291 ns |    10.8298 ns |    14.4575 ns | 0.0297 |      - |     - |     201 B |
|                 ToUnit |     21.508 ns |     0.4197 ns |     0.5603 ns |      - |      - |     - |         - |
|              ToUnit_SI |    521.838 ns |     8.7716 ns |     7.7758 ns | 0.0293 |      - |     - |     201 B |
|           ToStringTest |  1,926.257 ns |    37.6145 ns |    52.7303 ns | 0.1867 |      - |     - |    1244 B |
|                  Parse | 54,280.765 ns | 1,005.6181 ns | 1,307.5876 ns | 8.3971 | 0.3189 |     - |   54377 B |
|          TryParseValid | 57,946.521 ns | 1,150.9778 ns | 1,722.7293 ns | 8.3880 | 0.3226 |     - |   54352 B |
|        TryParseInvalid | 60,033.537 ns | 1,197.5641 ns | 1,331.0893 ns | 8.2811 | 0.2366 |     - |   53895 B |
|           QuantityFrom |  2,231.313 ns |    59.3872 ns |   174.1724 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     20.536 ns |     0.4379 ns |     0.5538 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    548.695 ns |     7.7808 ns |     6.8975 ns | 0.0289 |      - |     - |     201 B |
|       IQuantity_ToUnit |     32.895 ns |     0.7514 ns |     0.8352 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,028.621 ns |    39.9874 ns |    49.1081 ns | 0.1881 |      - |     - |    1244 B |
