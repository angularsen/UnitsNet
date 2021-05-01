window.BENCHMARK_DATA = {
  "lastUpdate": 1619833960971,
  "repoUrl": "https://github.com/angularsen/UnitsNet",
  "entries": {
    "UnitsNet Benchmarks (net472)": [
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
        "date": 1619819544145,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 16.104053877815726,
            "unit": "ns",
            "range": "± 0.4665971830243125"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 639.2482603092783,
            "unit": "ns",
            "range": "± 15.53192928307264"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 38.75285224139871,
            "unit": "ns",
            "range": "± 0.6444642015269129"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.494940581903196,
            "unit": "ns",
            "range": "± 0.22727719952946074"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.296642594761172,
            "unit": "ns",
            "range": "± 0.2599475749673262"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 639.9775848965467,
            "unit": "ns",
            "range": "± 21.24305822229252"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 24.635977453299496,
            "unit": "ns",
            "range": "± 0.4621274827749784"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 647.1772397597704,
            "unit": "ns",
            "range": "± 12.290126555894139"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2363.825843666931,
            "unit": "ns",
            "range": "± 68.06082520458534"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 74037.06123214452,
            "unit": "ns",
            "range": "± 1824.3333340746565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 73595.05242947867,
            "unit": "ns",
            "range": "± 1726.3649651339215"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 77885.88588002707,
            "unit": "ns",
            "range": "± 1971.8459078098117"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2814.4329896907216,
            "unit": "ns",
            "range": "± 191.4798132972341"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.321361856780346,
            "unit": "ns",
            "range": "± 0.6022867724253932"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 641.7277766407423,
            "unit": "ns",
            "range": "± 10.89961360456673"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 38.44490495213574,
            "unit": "ns",
            "range": "± 1.047720754859349"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2415.4515213861387,
            "unit": "ns",
            "range": "± 48.92455015899322"
          }
        ]
      },
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
          "id": "3bca803d0beb9c6e5da35b250d25c3aa09ddc807",
          "message": "Update continious-benchmarking.yml\n\nworkflow should only run on the main repository",
          "timestamp": "2021-05-01T04:23:34+03:00",
          "tree_id": "ffa3044720f9f19dd674ab3048f42b98ae2cc121",
          "url": "https://github.com/angularsen/UnitsNet/commit/3bca803d0beb9c6e5da35b250d25c3aa09ddc807"
        },
        "date": 1619832844690,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.053468574888194,
            "unit": "ns",
            "range": "± 0.1371659692432721"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 612.2115277120159,
            "unit": "ns",
            "range": "± 7.314884291422373"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 37.51916676161037,
            "unit": "ns",
            "range": "± 0.3290172004694769"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.138118078210884,
            "unit": "ns",
            "range": "± 0.10490172470139317"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.195209816888939,
            "unit": "ns",
            "range": "± 0.11962416161661983"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 602.8006194679043,
            "unit": "ns",
            "range": "± 7.078217774092053"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.026098693685025,
            "unit": "ns",
            "range": "± 0.16588520297028858"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 620.972902209284,
            "unit": "ns",
            "range": "± 12.086205728525595"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2555.227765653113,
            "unit": "ns",
            "range": "± 64.95265535062335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 73624.31473151532,
            "unit": "ns",
            "range": "± 1369.6129667106836"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 73961.98079461978,
            "unit": "ns",
            "range": "± 717.1881564600592"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 77686.18374868375,
            "unit": "ns",
            "range": "± 513.9345666370139"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2450.6849315068494,
            "unit": "ns",
            "range": "± 109.44720654172457"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.80424508547659,
            "unit": "ns",
            "range": "± 0.5274553215105569"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 599.1048332442443,
            "unit": "ns",
            "range": "± 7.661196829983116"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 39.30622334385681,
            "unit": "ns",
            "range": "± 1.1591911913576736"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2486.52560531666,
            "unit": "ns",
            "range": "± 51.73828001448342"
          }
        ]
      },
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
          "id": "3bca803d0beb9c6e5da35b250d25c3aa09ddc807",
          "message": "Update continious-benchmarking.yml\n\nworkflow should only run on the main repository",
          "timestamp": "2021-05-01T04:23:34+03:00",
          "tree_id": "ffa3044720f9f19dd674ab3048f42b98ae2cc121",
          "url": "https://github.com/angularsen/UnitsNet/commit/3bca803d0beb9c6e5da35b250d25c3aa09ddc807"
        },
        "date": 1619833960266,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.330246655803112,
            "unit": "ns",
            "range": "± 0.22080513486910258"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 550.9459350467793,
            "unit": "ns",
            "range": "± 5.309906568407245"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 38.91712979045187,
            "unit": "ns",
            "range": "± 0.43220810836209844"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.15313597392531,
            "unit": "ns",
            "range": "± 0.1678060339312448"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.16206048076485,
            "unit": "ns",
            "range": "± 0.2557934679849112"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 555.09000449547,
            "unit": "ns",
            "range": "± 12.37266118265786"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 24.020095736017968,
            "unit": "ns",
            "range": "± 0.5059905626321808"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 594.9274253103501,
            "unit": "ns",
            "range": "± 16.454603784476845"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1960.6610545575127,
            "unit": "ns",
            "range": "± 29.17749568577539"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 62882.15762435785,
            "unit": "ns",
            "range": "± 1162.1875610731747"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 62467.91530069328,
            "unit": "ns",
            "range": "± 1443.8117227159764"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 66127.42290389881,
            "unit": "ns",
            "range": "± 1160.06532138677"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2444.0860215053763,
            "unit": "ns",
            "range": "± 172.86735653283904"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.0710499414648,
            "unit": "ns",
            "range": "± 0.23706719793813316"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 558.5104695275887,
            "unit": "ns",
            "range": "± 12.175024928903985"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.8869987126048,
            "unit": "ns",
            "range": "± 0.49476053120656566"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1996.6758499171644,
            "unit": "ns",
            "range": "± 31.14525268657382"
          }
        ]
      }
    ]
  }
}