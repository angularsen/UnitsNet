window.BENCHMARK_DATA = {
  "lastUpdate": 1622239498497,
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
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "7c7cfcfc9e955244a8417d52fbdebbb19570f850",
          "message": "UnitsNet: 4.90.0",
          "timestamp": "2021-05-07T23:23:03+02:00",
          "tree_id": "89daec8f877fa5ad23a94d168fdda1cc669e3e3c",
          "url": "https://github.com/angularsen/UnitsNet/commit/7c7cfcfc9e955244a8417d52fbdebbb19570f850"
        },
        "date": 1620423142203,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.517176864381188,
            "unit": "ns",
            "range": "± 0.18789082332348844"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 655.819992857341,
            "unit": "ns",
            "range": "± 9.28716482941452"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.40822298259375,
            "unit": "ns",
            "range": "± 0.2832632969033569"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.225305693224536,
            "unit": "ns",
            "range": "± 0.12874104014830184"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.198341319039466,
            "unit": "ns",
            "range": "± 0.12931601170498197"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 629.284352475011,
            "unit": "ns",
            "range": "± 11.675842302456962"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.91611036620474,
            "unit": "ns",
            "range": "± 0.27882905754420534"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 659.4567442753341,
            "unit": "ns",
            "range": "± 14.946081119796112"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2611.0769116989554,
            "unit": "ns",
            "range": "± 31.84141214535119"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 74784.81107392762,
            "unit": "ns",
            "range": "± 1967.395349218772"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 73889.3102925572,
            "unit": "ns",
            "range": "± 1271.5454952302546"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 79668.50515463918,
            "unit": "ns",
            "range": "± 1115.593546984625"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1871.276595744681,
            "unit": "ns",
            "range": "± 154.2392642265473"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.426948265432582,
            "unit": "ns",
            "range": "± 0.5263684103179245"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 640.5482227776041,
            "unit": "ns",
            "range": "± 8.14842902385684"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.51404909808205,
            "unit": "ns",
            "range": "± 0.47694140844253335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2594.398430354652,
            "unit": "ns",
            "range": "± 35.01139957778996"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "9bc3f8d7606f2f9f3b04da4b7a55f639456ef73d",
          "message": "UnitsNet: 4.91.0",
          "timestamp": "2021-05-17T13:58:40+02:00",
          "tree_id": "4ac74e829091aacf70960da873093b36f28f95f6",
          "url": "https://github.com/angularsen/UnitsNet/commit/9bc3f8d7606f2f9f3b04da4b7a55f639456ef73d"
        },
        "date": 1621253328656,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.838618592095548,
            "unit": "ns",
            "range": "± 0.19097958946428167"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 669.664222443107,
            "unit": "ns",
            "range": "± 14.64694810613694"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.956165212844997,
            "unit": "ns",
            "range": "± 0.39681062660454636"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 11.02387528108373,
            "unit": "ns",
            "range": "± 0.1987535356723113"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 11.264569846830799,
            "unit": "ns",
            "range": "± 0.49445829897128973"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 647.8179859424051,
            "unit": "ns",
            "range": "± 21.217186146011407"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.462788136793232,
            "unit": "ns",
            "range": "± 0.2776329585489361"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 675.5951855193971,
            "unit": "ns",
            "range": "± 18.838375851036048"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2541.258965147083,
            "unit": "ns",
            "range": "± 72.99515843735554"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 78037.59756699264,
            "unit": "ns",
            "range": "± 1715.020769615875"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 78040.09532666822,
            "unit": "ns",
            "range": "± 1575.2527486718327"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 83338.08583690987,
            "unit": "ns",
            "range": "± 1693.189118563269"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1813.978494623656,
            "unit": "ns",
            "range": "± 226.78825493391423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 25.049772367634265,
            "unit": "ns",
            "range": "± 0.4635134528416716"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 642.9975859718669,
            "unit": "ns",
            "range": "± 13.36670091235779"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 35.651202653668825,
            "unit": "ns",
            "range": "± 0.5324525949333653"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2561.296467996193,
            "unit": "ns",
            "range": "± 80.28205272242158"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "08752bc5d9b3b519a301572155d8683be9550188",
          "message": "UnitsNet: 4.92.0",
          "timestamp": "2021-05-21T11:35:59+02:00",
          "tree_id": "486a17363fc0e3ccf1fae277ae71fe9c5a312067",
          "url": "https://github.com/angularsen/UnitsNet/commit/08752bc5d9b3b519a301572155d8683be9550188"
        },
        "date": 1621590459004,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.927205334260533,
            "unit": "ns",
            "range": "± 0.02213141067543832"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 531.736716584875,
            "unit": "ns",
            "range": "± 3.9443309423513817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.824730401626116,
            "unit": "ns",
            "range": "± 0.045224690312892654"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.735902803008404,
            "unit": "ns",
            "range": "± 0.02424024447807335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.738126841321082,
            "unit": "ns",
            "range": "± 0.020659162060540144"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 509.04708321035434,
            "unit": "ns",
            "range": "± 1.794603699488407"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.642163630074233,
            "unit": "ns",
            "range": "± 0.031363196739595166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 520.9120235831207,
            "unit": "ns",
            "range": "± 2.0435812750109523"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2171.6073619987033,
            "unit": "ns",
            "range": "± 11.920561135020337"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 59176.37382587418,
            "unit": "ns",
            "range": "± 118.27082214418797"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 59050.48565009544,
            "unit": "ns",
            "range": "± 112.41489026395146"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 64784.809572825536,
            "unit": "ns",
            "range": "± 165.72938832797965"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1720.6349206349207,
            "unit": "ns",
            "range": "± 78.61447408126726"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.144811432788995,
            "unit": "ns",
            "range": "± 0.0769589211799713"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 501.1882286989545,
            "unit": "ns",
            "range": "± 2.1018525476401657"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.322689575529918,
            "unit": "ns",
            "range": "± 0.10009671823399638"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1953.5538057742783,
            "unit": "ns",
            "range": "± 11.272715791157594"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "3941f35a258d7c670d8c56f64c77af7be305be27",
          "message": "UnitsNet: 4.92.1",
          "timestamp": "2021-05-21T22:47:40+02:00",
          "tree_id": "6cebb087590ad5d68218b8696c216ac8f8c0bd33",
          "url": "https://github.com/angularsen/UnitsNet/commit/3941f35a258d7c670d8c56f64c77af7be305be27"
        },
        "date": 1621630658181,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.157055167143424,
            "unit": "ns",
            "range": "± 0.12399562724111987"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 661.3451204402696,
            "unit": "ns",
            "range": "± 8.098709186829298"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.52432387060103,
            "unit": "ns",
            "range": "± 0.6391941291230011"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.621084211878069,
            "unit": "ns",
            "range": "± 0.19585380719202486"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.528828940410628,
            "unit": "ns",
            "range": "± 0.07526994662455869"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 632.6191973886522,
            "unit": "ns",
            "range": "± 11.814872425829252"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.665967448244526,
            "unit": "ns",
            "range": "± 0.36675322602185145"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 624.2194128496774,
            "unit": "ns",
            "range": "± 9.487266956071295"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2454.888036932317,
            "unit": "ns",
            "range": "± 32.274075950292755"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 71926.57808895984,
            "unit": "ns",
            "range": "± 1627.8427398600284"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 70878.77897092213,
            "unit": "ns",
            "range": "± 890.8137160887802"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 80455.41947693563,
            "unit": "ns",
            "range": "± 1781.5020809913262"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2056.179775280899,
            "unit": "ns",
            "range": "± 138.95311192479753"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.60021513768812,
            "unit": "ns",
            "range": "± 0.4378420197611483"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 634.8128647029133,
            "unit": "ns",
            "range": "± 7.669648890455269"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 34.05443684573263,
            "unit": "ns",
            "range": "± 0.9692501201427409"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2523.4985441918025,
            "unit": "ns",
            "range": "± 22.948277807273637"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "59d980c098795945fd5a11ea4bd695934ecc9bd4",
          "message": "UnitsNet: 4.93.0",
          "timestamp": "2021-05-28T23:53:04+02:00",
          "tree_id": "bff33bbf617580f8bacaa25fff56a132320a766e",
          "url": "https://github.com/angularsen/UnitsNet/commit/59d980c098795945fd5a11ea4bd695934ecc9bd4"
        },
        "date": 1622239497423,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.930917029299287,
            "unit": "ns",
            "range": "± 0.07244162661447619"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 524.4909559507137,
            "unit": "ns",
            "range": "± 17.186692472727305"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.388408875540602,
            "unit": "ns",
            "range": "± 0.21447374082241397"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.561141253263512,
            "unit": "ns",
            "range": "± 0.3849366399169337"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.755754264816382,
            "unit": "ns",
            "range": "± 0.019843281684418047"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 509.69370112865147,
            "unit": "ns",
            "range": "± 18.869158184275147"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.652410048244885,
            "unit": "ns",
            "range": "± 0.12888215823414115"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 514.7102285727834,
            "unit": "ns",
            "range": "± 18.98341669276959"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2041.7858927795987,
            "unit": "ns",
            "range": "± 83.35662342212001"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 60146.86735664464,
            "unit": "ns",
            "range": "± 1335.0254673480447"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60355.83593687414,
            "unit": "ns",
            "range": "± 1078.0375736215087"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 64423.253156456645,
            "unit": "ns",
            "range": "± 2625.651698506734"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1307.7777777777778,
            "unit": "ns",
            "range": "± 121.06992851452367"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.802397760798065,
            "unit": "ns",
            "range": "± 1.0603362616767005"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 514.5555553718629,
            "unit": "ns",
            "range": "± 19.386631792015926"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.958333201456895,
            "unit": "ns",
            "range": "± 0.10060191526934213"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2047.6108601105504,
            "unit": "ns",
            "range": "± 55.37200255681669"
          }
        ]
      }
    ]
  }
}