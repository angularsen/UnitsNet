window.BENCHMARK_DATA = {
  "lastUpdate": 1619819497174,
  "repoUrl": "https://github.com/angularsen/UnitsNet",
  "entries": {
    "UnitsNet Benchmarks (netcoreapp50)": [
      {
        "commit": {
          "author": {
            "email": "lipchev@gmail.com",
            "name": "lipchev",
            "username": "lipchev"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "0f39bec5fb0843821cfe0835a93260ba816da6c2",
          "message": "Merge pull request #923 from lipchev/benchmark-workflows\n\nAdding benchmark workflows",
          "timestamp": "2021-05-01T00:41:21+03:00",
          "tree_id": "629160691b70e08113bd3e3f2feb12f119eee6f4",
          "url": "https://github.com/angularsen/UnitsNet/commit/0f39bec5fb0843821cfe0835a93260ba816da6c2"
        },
        "date": 1619819496219,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.885047153752135,
            "unit": "ns",
            "range": "± 0.1279005844703242"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 304.2678550705392,
            "unit": "ns",
            "range": "± 5.739269560621526"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 26.615457671535115,
            "unit": "ns",
            "range": "± 0.5291188278799794"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.083759633573635,
            "unit": "ns",
            "range": "± 0.28470191530837824"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.122832398258808,
            "unit": "ns",
            "range": "± 0.21884402458261967"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 317.23194326596405,
            "unit": "ns",
            "range": "± 8.269648655251215"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.40352550669787,
            "unit": "ns",
            "range": "± 0.3089460710460945"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 319.0624164763596,
            "unit": "ns",
            "range": "± 5.796288965207915"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1268.8808274687522,
            "unit": "ns",
            "range": "± 27.641243459940373"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 47973.86506893408,
            "unit": "ns",
            "range": "± 1372.2166447749137"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 46413.37747159346,
            "unit": "ns",
            "range": "± 1385.2277205478667"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 49298.78860201056,
            "unit": "ns",
            "range": "± 1207.8375818796487"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3021.7391304347825,
            "unit": "ns",
            "range": "± 144.3744775568763"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.396978477026224,
            "unit": "ns",
            "range": "± 0.6765852917614826"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 314.01685304991435,
            "unit": "ns",
            "range": "± 4.562115015057172"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.816514621951274,
            "unit": "ns",
            "range": "± 0.8739300796931313"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1319.6720618241718,
            "unit": "ns",
            "range": "± 34.212040173306804"
          }
        ]
      }
    ]
  }
}