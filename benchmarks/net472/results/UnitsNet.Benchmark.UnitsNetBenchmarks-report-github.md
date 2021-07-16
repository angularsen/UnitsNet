``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2029 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-LCCQSX : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.33 ns |     0.154 ns |     0.129 ns |     15.31 ns |      - |      - |     - |         - |
|         Constructor_SI |    587.11 ns |     6.368 ns |     5.957 ns |    587.56 ns | 0.0294 |      - |     - |     201 B |
|             FromMethod |     35.19 ns |     0.399 ns |     0.374 ns |     35.15 ns |      - |      - |     - |         - |
|             ToProperty |     10.35 ns |     0.083 ns |     0.074 ns |     10.34 ns |      - |      - |     - |         - |
|                     As |     10.30 ns |     0.128 ns |     0.120 ns |     10.26 ns |      - |      - |     - |         - |
|                  As_SI |    582.42 ns |     6.302 ns |     5.895 ns |    582.15 ns | 0.0293 |      - |     - |     201 B |
|                 ToUnit |     23.34 ns |     0.163 ns |     0.153 ns |     23.34 ns |      - |      - |     - |         - |
|              ToUnit_SI |    605.22 ns |     4.409 ns |     4.124 ns |    604.58 ns | 0.0289 |      - |     - |     201 B |
|           ToStringTest |  2,127.57 ns |    32.179 ns |    30.100 ns |  2,135.12 ns | 0.1879 |      - |     - |    1244 B |
|                  Parse | 61,991.53 ns |   826.953 ns |   773.532 ns | 61,699.15 ns | 8.3443 | 0.3576 |     - |   54377 B |
|          TryParseValid | 63,402.60 ns | 1,201.300 ns | 1,123.697 ns | 63,615.91 ns | 8.3428 | 0.2528 |     - |   54352 B |
|        TryParseInvalid | 67,062.36 ns |   871.850 ns |   815.529 ns | 67,090.88 ns | 8.2746 | 0.2713 |     - |   53895 B |
|           QuantityFrom |  1,948.48 ns |    34.299 ns |    80.846 ns |  1,900.00 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     23.35 ns |     0.264 ns |     0.247 ns |     23.31 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    590.95 ns |     8.906 ns |     8.331 ns |    592.76 ns | 0.0293 |      - |     - |     201 B |
|       IQuantity_ToUnit |     35.31 ns |     0.753 ns |     0.668 ns |     35.22 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,152.35 ns |    21.361 ns |    19.981 ns |  2,154.03 ns | 0.1858 |      - |     - |    1244 B |
