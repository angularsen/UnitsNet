window.BENCHMARK_DATA = {
  "lastUpdate": 1619833940284,
  "repoUrl": "https://github.com/angularsen/UnitsNet",
  "entries": {
    "UnitsNet Benchmarks (netcoreapp21)": [
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
        "date": 1619819522462,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.732948654232318,
            "unit": "ns",
            "range": "± 0.1731267208410751"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 591.671800413742,
            "unit": "ns",
            "range": "± 8.421631820046251"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.38045274530271,
            "unit": "ns",
            "range": "± 0.44627561691966605"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.051029474454221,
            "unit": "ns",
            "range": "± 0.1125710070051503"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.143728570127776,
            "unit": "ns",
            "range": "± 0.1424346048603952"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 599.6195759524404,
            "unit": "ns",
            "range": "± 8.44781983173399"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.619927538039235,
            "unit": "ns",
            "range": "± 0.3536452752705522"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 606.2085447967438,
            "unit": "ns",
            "range": "± 8.13068878967091"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2593.1096736002446,
            "unit": "ns",
            "range": "± 66.63204886502756"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 88210.72408055977,
            "unit": "ns",
            "range": "± 3324.4468961708876"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 81969.27663866244,
            "unit": "ns",
            "range": "± 2465.612318477688"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 85788.11239193083,
            "unit": "ns",
            "range": "± 1592.6229932250267"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2485.057471264368,
            "unit": "ns",
            "range": "± 135.99652494892032"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.979227065905132,
            "unit": "ns",
            "range": "± 0.37007435496620955"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 593.4233336346855,
            "unit": "ns",
            "range": "± 8.299706717065762"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.59163237139186,
            "unit": "ns",
            "range": "± 0.5955212655786474"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2394.9585634995483,
            "unit": "ns",
            "range": "± 51.02015797660711"
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
        "date": 1619832819171,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.938560128518029,
            "unit": "ns",
            "range": "± 0.26326158361548774"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 558.5166404799317,
            "unit": "ns",
            "range": "± 11.490154170515376"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.87478917796872,
            "unit": "ns",
            "range": "± 0.4988755966710511"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.594504917837686,
            "unit": "ns",
            "range": "± 0.15630200827488283"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.516618731005702,
            "unit": "ns",
            "range": "± 0.11028590990465023"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 551.8690836683801,
            "unit": "ns",
            "range": "± 6.915538194273752"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.76975754655684,
            "unit": "ns",
            "range": "± 0.400249682459203"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 582.3212745970878,
            "unit": "ns",
            "range": "± 3.8578537433703883"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2122.6344256724765,
            "unit": "ns",
            "range": "± 35.39194865953502"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 70155.61569812703,
            "unit": "ns",
            "range": "± 1264.4135879183823"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 69258.5552474907,
            "unit": "ns",
            "range": "± 881.4801428599538"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 75529.04676566942,
            "unit": "ns",
            "range": "± 867.6156824248516"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1861.8556701030927,
            "unit": "ns",
            "range": "± 187.3295330477552"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.869255080201995,
            "unit": "ns",
            "range": "± 0.28331954689486"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 562.6289501233166,
            "unit": "ns",
            "range": "± 8.648402656994243"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.259297812587715,
            "unit": "ns",
            "range": "± 0.7032018956969064"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2144.6824131768344,
            "unit": "ns",
            "range": "± 26.584022249137394"
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
        "date": 1619833939873,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.217974104165487,
            "unit": "ns",
            "range": "± 0.15351019664432813"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 649.0020997449618,
            "unit": "ns",
            "range": "± 7.603224095311176"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.957150491453,
            "unit": "ns",
            "range": "± 0.4356767122631558"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.61867668046432,
            "unit": "ns",
            "range": "± 0.1268826132310476"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.549800393588152,
            "unit": "ns",
            "range": "± 0.12448843392015596"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 648.7837619195153,
            "unit": "ns",
            "range": "± 6.604381174222387"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.4525478710262,
            "unit": "ns",
            "range": "± 0.15425117458142604"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 632.0901022254633,
            "unit": "ns",
            "range": "± 7.43588421718765"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2514.4983693960676,
            "unit": "ns",
            "range": "± 41.87440188316363"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 72305.62535345582,
            "unit": "ns",
            "range": "± 662.5570002999431"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 72910.42207946704,
            "unit": "ns",
            "range": "± 839.0972367011367"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 79902.98987301075,
            "unit": "ns",
            "range": "± 1451.9379491991483"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2012.5,
            "unit": "ns",
            "range": "± 89.97354108424373"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.227747072401158,
            "unit": "ns",
            "range": "± 0.42129821802986606"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 623.6314972590976,
            "unit": "ns",
            "range": "± 4.795118247280936"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.771958329945086,
            "unit": "ns",
            "range": "± 0.2992482033277683"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2438.7258202297476,
            "unit": "ns",
            "range": "± 18.332493254010725"
          }
        ]
      }
    ]
  }
}