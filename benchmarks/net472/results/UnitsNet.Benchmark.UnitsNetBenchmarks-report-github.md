``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-KPSPNZ : .NET Framework 4.8 (4.8.4360.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.54 ns |     0.318 ns |     0.326 ns |     14.48 ns |      - |      - |     - |         - |
|         Constructor_SI |    588.51 ns |    10.184 ns |     9.028 ns |    587.02 ns | 0.0285 |      - |     - |     201 B |
|             FromMethod |     35.71 ns |     0.437 ns |     0.409 ns |     35.70 ns |      - |      - |     - |         - |
|             ToProperty |     10.51 ns |     0.141 ns |     0.132 ns |     10.47 ns |      - |      - |     - |         - |
|                     As |     10.32 ns |     0.251 ns |     0.258 ns |     10.30 ns |      - |      - |     - |         - |
|                  As_SI |    575.85 ns |    11.410 ns |    16.364 ns |    570.86 ns | 0.0286 |      - |     - |     201 B |
|                 ToUnit |     23.26 ns |     0.111 ns |     0.098 ns |     23.24 ns |      - |      - |     - |         - |
|              ToUnit_SI |    619.78 ns |     9.062 ns |     7.567 ns |    621.18 ns | 0.0289 |      - |     - |     201 B |
|           ToStringTest |  2,303.64 ns |    45.445 ns |    70.752 ns |  2,310.18 ns | 0.1865 |      - |     - |    1244 B |
|                  Parse | 66,070.23 ns | 1,114.977 ns | 1,042.950 ns | 65,769.95 ns | 8.3300 | 0.2644 |     - |   54377 B |
|          TryParseValid | 60,476.07 ns | 1,168.534 ns | 1,477.821 ns | 60,252.22 ns | 8.3092 | 0.2408 |     - |   54353 B |
|        TryParseInvalid | 69,915.79 ns | 1,384.888 ns | 2,497.239 ns | 69,483.54 ns | 8.2926 | 0.2719 |     - |   53895 B |
|           QuantityFrom |  2,001.04 ns |    94.818 ns |   273.571 ns |  1,900.00 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     22.21 ns |     0.429 ns |     0.642 ns |     22.18 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    589.44 ns |    11.187 ns |    12.884 ns |    589.22 ns | 0.0284 |      - |     - |     201 B |
|       IQuantity_ToUnit |     32.38 ns |     0.748 ns |     1.349 ns |     32.41 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,152.64 ns |    22.404 ns |    19.860 ns |  2,149.09 ns | 0.1857 |      - |     - |    1244 B |
