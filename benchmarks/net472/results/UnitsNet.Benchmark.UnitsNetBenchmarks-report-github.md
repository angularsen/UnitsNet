``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-AKFHNG : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.659 ns |   0.0415 ns |   0.0388 ns |      - |      - |     - |         - |
|         Constructor_SI |    486.491 ns |   4.4271 ns |   4.1411 ns | 0.0292 |      - |     - |     201 B |
|             FromMethod |     29.839 ns |   0.0980 ns |   0.0917 ns |      - |      - |     - |         - |
|             ToProperty |      8.669 ns |   0.0442 ns |   0.0413 ns |      - |      - |     - |         - |
|                     As |      8.689 ns |   0.0426 ns |   0.0399 ns |      - |      - |     - |         - |
|                  As_SI |    485.052 ns |   3.4362 ns |   3.2143 ns | 0.0293 |      - |     - |     201 B |
|                 ToUnit |     19.385 ns |   0.0551 ns |   0.0489 ns |      - |      - |     - |         - |
|              ToUnit_SI |    496.506 ns |   3.2687 ns |   3.0576 ns | 0.0296 |      - |     - |     201 B |
|           ToStringTest |  1,745.282 ns |   6.6487 ns |   5.1909 ns | 0.1895 |      - |     - |    1244 B |
|                  Parse | 51,588.305 ns | 208.0010 ns | 184.3875 ns | 8.3965 | 0.3072 |     - |   54377 B |
|          TryParseValid | 52,079.594 ns | 262.7070 ns | 245.7363 ns | 8.4016 | 0.3074 |     - |   54352 B |
|        TryParseInvalid | 56,249.725 ns | 247.4439 ns | 231.4592 ns | 8.2525 | 0.3346 |     - |   53895 B |
|           QuantityFrom |  1,617.949 ns |  31.7408 ns |  55.5915 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     18.532 ns |   0.1013 ns |   0.0948 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    482.056 ns |   2.0430 ns |   1.9111 ns | 0.0292 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.505 ns |   0.2400 ns |   0.2245 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,803.192 ns |   8.9910 ns |   8.4102 ns | 0.1874 |      - |     - |    1244 B |
