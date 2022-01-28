window.BENCHMARK_DATA = {
  "lastUpdate": 1643398826086,
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
          "id": "38e1415d8404c3d652568699906718e082568c2b",
          "message": "UnitsNet: 4.94.0",
          "timestamp": "2021-06-13T01:17:49+02:00",
          "tree_id": "4020015118dd7a840bfe802e245c9bc826055aa6",
          "url": "https://github.com/angularsen/UnitsNet/commit/38e1415d8404c3d652568699906718e082568c2b"
        },
        "date": 1623540481176,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.385317532747754,
            "unit": "ns",
            "range": "± 0.3371055310910674"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 654.0058725709624,
            "unit": "ns",
            "range": "± 8.623942440114124"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.708967016929996,
            "unit": "ns",
            "range": "± 0.5332934727936174"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.913628303100593,
            "unit": "ns",
            "range": "± 0.15133250809095808"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.767118987385208,
            "unit": "ns",
            "range": "± 0.10525165672829045"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 638.7930124070926,
            "unit": "ns",
            "range": "± 12.730085875540942"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.88597439290221,
            "unit": "ns",
            "range": "± 0.25153799563836016"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 671.9110505996139,
            "unit": "ns",
            "range": "± 14.73474564767554"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2754.177590783834,
            "unit": "ns",
            "range": "± 55.18461496297175"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 76803.96152098168,
            "unit": "ns",
            "range": "± 1630.4092759605776"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 76756.01316385662,
            "unit": "ns",
            "range": "± 1434.3993964976796"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 82521.91845348004,
            "unit": "ns",
            "range": "± 1680.2543797428757"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1945.0549450549452,
            "unit": "ns",
            "range": "± 176.54948079708186"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.992203168632265,
            "unit": "ns",
            "range": "± 0.37349576978449633"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 642.4467899332307,
            "unit": "ns",
            "range": "± 9.807587505873535"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 35.66318866733776,
            "unit": "ns",
            "range": "± 0.9355028125621344"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2641.4217503231253,
            "unit": "ns",
            "range": "± 38.48989843514887"
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
          "id": "34bd90c7cebc8aa4f4199b2445c05c6358fdf7c2",
          "message": "UnitsNet: 4.95.0",
          "timestamp": "2021-06-17T11:07:10+02:00",
          "tree_id": "d912f5cb02ea934078da5e6ea0049e66c2f004b8",
          "url": "https://github.com/angularsen/UnitsNet/commit/34bd90c7cebc8aa4f4199b2445c05c6358fdf7c2"
        },
        "date": 1623921648088,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.373856050880997,
            "unit": "ns",
            "range": "± 0.5114959304729505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 505.5810238885315,
            "unit": "ns",
            "range": "± 18.537066313924363"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.535582252193812,
            "unit": "ns",
            "range": "± 1.0062247744820494"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.21900293130889,
            "unit": "ns",
            "range": "± 0.4342923021824893"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.793157541667318,
            "unit": "ns",
            "range": "± 0.3126361905106147"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 497.88370657425463,
            "unit": "ns",
            "range": "± 17.50430666425911"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.88224445879466,
            "unit": "ns",
            "range": "± 0.712245234318371"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 503.313179126049,
            "unit": "ns",
            "range": "± 22.74706460110408"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1999.5247903342079,
            "unit": "ns",
            "range": "± 94.15192472316714"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 60491.281567959784,
            "unit": "ns",
            "range": "± 2358.266029246314"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60123.314652666755,
            "unit": "ns",
            "range": "± 2579.894927190847"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 63953.452022516,
            "unit": "ns",
            "range": "± 2962.7157387119664"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1608.421052631579,
            "unit": "ns",
            "range": "± 123.48068838136385"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.78876819318717,
            "unit": "ns",
            "range": "± 1.049723801274016"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 493.61148110837206,
            "unit": "ns",
            "range": "± 19.58557846051696"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 28.45090811067131,
            "unit": "ns",
            "range": "± 1.5808524014210388"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2012.8787567786728,
            "unit": "ns",
            "range": "± 89.76972034785078"
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
          "id": "2582139041e7eb82b95f5e363affcaff7d2abd3f",
          "message": "UnitsNet: 4.97.0",
          "timestamp": "2021-06-29T23:19:22+02:00",
          "tree_id": "bc66711be2e9540b9acf3bdf6cc9b7aa344237e6",
          "url": "https://github.com/angularsen/UnitsNet/commit/2582139041e7eb82b95f5e363affcaff7d2abd3f"
        },
        "date": 1625002257350,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.627536160870015,
            "unit": "ns",
            "range": "± 0.19490278027153132"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 505.9382375384301,
            "unit": "ns",
            "range": "± 15.618449192221739"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.370940468040605,
            "unit": "ns",
            "range": "± 0.6524941439127682"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.242863983852683,
            "unit": "ns",
            "range": "± 0.2367754319183784"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.601772440955491,
            "unit": "ns",
            "range": "± 0.2437685145539215"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 489.86821953273653,
            "unit": "ns",
            "range": "± 13.091031481408294"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.161319172946165,
            "unit": "ns",
            "range": "± 0.34663465152061396"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 502.4638275085787,
            "unit": "ns",
            "range": "± 8.511643372515747"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2163.2448698834155,
            "unit": "ns",
            "range": "± 74.40212034867398"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 58569.94728892719,
            "unit": "ns",
            "range": "± 1608.6958661289377"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 59550.571912813844,
            "unit": "ns",
            "range": "± 870.7816239428597"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 63988.70373654211,
            "unit": "ns",
            "range": "± 1690.0690432575557"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1438.4615384615386,
            "unit": "ns",
            "range": "± 79.95725353688927"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.387657989025815,
            "unit": "ns",
            "range": "± 0.4808963427285048"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 492.4595288328024,
            "unit": "ns",
            "range": "± 16.633923590662025"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.484173371546046,
            "unit": "ns",
            "range": "± 0.6679499544116064"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2214.8786061452793,
            "unit": "ns",
            "range": "± 65.94724501702362"
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
          "id": "d36819b1e689f0ac73a8f6e8d457481a9d98dbe4",
          "message": "UnitsNet: 4.97.1",
          "timestamp": "2021-07-05T18:04:35+02:00",
          "tree_id": "262bcc2d69f8d20357dc30ce152c1b42bb72eabb",
          "url": "https://github.com/angularsen/UnitsNet/commit/d36819b1e689f0ac73a8f6e8d457481a9d98dbe4"
        },
        "date": 1625501842605,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.535962814549043,
            "unit": "ns",
            "range": "± 0.866664690056532"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 613.1058551479045,
            "unit": "ns",
            "range": "± 11.79678287951259"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.837868683693145,
            "unit": "ns",
            "range": "± 0.6301979163170705"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.956324021073458,
            "unit": "ns",
            "range": "± 0.1980488332440747"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.966200738080456,
            "unit": "ns",
            "range": "± 0.30161818734573087"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 594.642310574779,
            "unit": "ns",
            "range": "± 24.72043475773044"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.354031751257892,
            "unit": "ns",
            "range": "± 0.9076825711560904"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 551.6569182346169,
            "unit": "ns",
            "range": "± 20.59096815101871"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1948.8518379262644,
            "unit": "ns",
            "range": "± 59.39619328650706"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 72451.70076743898,
            "unit": "ns",
            "range": "± 2212.437360122175"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 71788.49227552116,
            "unit": "ns",
            "range": "± 2415.69243509034"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 74909.79343387147,
            "unit": "ns",
            "range": "± 2157.851798997298"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2156.5656565656564,
            "unit": "ns",
            "range": "± 173.88808045055546"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.62136071153403,
            "unit": "ns",
            "range": "± 0.624310380946797"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 547.4986321928425,
            "unit": "ns",
            "range": "± 24.769904057246674"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.360502026839775,
            "unit": "ns",
            "range": "± 1.0899565741163657"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2060.571824079648,
            "unit": "ns",
            "range": "± 62.77587045509729"
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
          "id": "0202c0785db605ecb6f27a53bf574060f6c73461",
          "message": "JsonNet: 4.4.0",
          "timestamp": "2021-07-16T11:45:01+02:00",
          "tree_id": "3af160975622947fe4a0b2ead992f25b5bb014df",
          "url": "https://github.com/angularsen/UnitsNet/commit/0202c0785db605ecb6f27a53bf574060f6c73461"
        },
        "date": 1626429220683,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.022618480628738,
            "unit": "ns",
            "range": "± 0.07770537951890949"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 602.937060180166,
            "unit": "ns",
            "range": "± 10.839866568937541"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.514734362911838,
            "unit": "ns",
            "range": "± 0.5463459017589289"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.298013269506942,
            "unit": "ns",
            "range": "± 0.36020969134854847"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.231537025310455,
            "unit": "ns",
            "range": "± 0.31191846768202497"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 614.000439035444,
            "unit": "ns",
            "range": "± 9.995879411998493"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.656671008427818,
            "unit": "ns",
            "range": "± 0.20745085090865475"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 628.6404457654305,
            "unit": "ns",
            "range": "± 5.932471940955689"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2436.173467435699,
            "unit": "ns",
            "range": "± 53.24275921756254"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 69464.29193001741,
            "unit": "ns",
            "range": "± 1768.8439316660047"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 70667.15268471367,
            "unit": "ns",
            "range": "± 915.4109544179736"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 73754.43365987991,
            "unit": "ns",
            "range": "± 1427.818667021734"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1843.5897435897436,
            "unit": "ns",
            "range": "± 94.78580581684673"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.388009281663166,
            "unit": "ns",
            "range": "± 0.40760000853504313"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 589.1752128132862,
            "unit": "ns",
            "range": "± 11.67976354273818"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.29860053270827,
            "unit": "ns",
            "range": "± 0.6827162661253027"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2285.9373664157606,
            "unit": "ns",
            "range": "± 30.895622805086507"
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
          "id": "e263703d96fffce76cf5e665b2faece8684749a2",
          "message": "UnitsNet: 4.99.0",
          "timestamp": "2021-07-20T20:19:53+02:00",
          "tree_id": "da9711566d60004e73759d23781bac5c30fd2b5b",
          "url": "https://github.com/angularsen/UnitsNet/commit/e263703d96fffce76cf5e665b2faece8684749a2"
        },
        "date": 1626805724187,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.438276436970323,
            "unit": "ns",
            "range": "± 0.3264072769042017"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 511.22106559435866,
            "unit": "ns",
            "range": "± 14.943344110497286"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.753998490219534,
            "unit": "ns",
            "range": "± 0.6330549159677413"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 7.910759827344111,
            "unit": "ns",
            "range": "± 0.19774786200342775"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 7.813697952704627,
            "unit": "ns",
            "range": "± 0.2931153656262615"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 540.9167447592495,
            "unit": "ns",
            "range": "± 13.298966596053345"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.674704795781302,
            "unit": "ns",
            "range": "± 0.046730951171417685"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 554.6752552064402,
            "unit": "ns",
            "range": "± 1.3518706503602234"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2026.2221084690586,
            "unit": "ns",
            "range": "± 15.088957484978115"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 63233.36418408826,
            "unit": "ns",
            "range": "± 781.4318312348902"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 64374.902213072564,
            "unit": "ns",
            "range": "± 662.6596740864065"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 69073.63149635373,
            "unit": "ns",
            "range": "± 565.2627075659416"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1606.25,
            "unit": "ns",
            "range": "± 114.07522910227637"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.477762734941802,
            "unit": "ns",
            "range": "± 0.34169672678969715"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 524.6791317854885,
            "unit": "ns",
            "range": "± 1.5896446553913532"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 28.814647449797636,
            "unit": "ns",
            "range": "± 0.7039101609615347"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2056.813317317806,
            "unit": "ns",
            "range": "± 8.317588968119344"
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
          "id": "d35c7edea067a9fd3f94952d8e1305dee05df1c4",
          "message": "UnitsNet: 4.100.0",
          "timestamp": "2021-08-06T00:39:36+02:00",
          "tree_id": "e6a8c8630a1981bcafcc21db4f69ac4290507cf5",
          "url": "https://github.com/angularsen/UnitsNet/commit/d35c7edea067a9fd3f94952d8e1305dee05df1c4"
        },
        "date": 1628203690293,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.977273104900261,
            "unit": "ns",
            "range": "± 0.041151019067286174"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 533.3279941011483,
            "unit": "ns",
            "range": "± 0.9836852709285251"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.463700577502454,
            "unit": "ns",
            "range": "± 0.08966149546177817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.201807123551227,
            "unit": "ns",
            "range": "± 0.023874642556902255"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.200704754196218,
            "unit": "ns",
            "range": "± 0.02291358310806383"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 518.3102017495688,
            "unit": "ns",
            "range": "± 6.4806952346762525"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.673412450004893,
            "unit": "ns",
            "range": "± 0.04189624679562846"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 548.0603244398507,
            "unit": "ns",
            "range": "± 5.067771013570531"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2079.9241046461048,
            "unit": "ns",
            "range": "± 10.69643494896139"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 62349.92948191524,
            "unit": "ns",
            "range": "± 272.20059540390673"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 62153.17296340023,
            "unit": "ns",
            "range": "± 1497.2352549219418"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 69171.92581229954,
            "unit": "ns",
            "range": "± 318.8502771102068"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1357.142857142857,
            "unit": "ns",
            "range": "± 109.68931594164513"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.587115428981654,
            "unit": "ns",
            "range": "± 0.9024011912551152"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 527.3913034485041,
            "unit": "ns",
            "range": "± 1.1884518496871495"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.00851269059903,
            "unit": "ns",
            "range": "± 1.050098840090204"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2059.7262064708234,
            "unit": "ns",
            "range": "± 8.116947085921637"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "tristan.milnthorp@ansys.com",
            "name": "Tristan Milnthorp",
            "username": "tmilnthorp"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "8e603bf21a96e968efe30046bc7e3a62c68bcbb3",
          "message": "Only reference System.ValueTuple in net40 (#960)",
          "timestamp": "2021-08-11T21:53:02+02:00",
          "tree_id": "bc1328bc7d11d4bbd992c55677e3cdabfa3cd16b",
          "url": "https://github.com/angularsen/UnitsNet/commit/8e603bf21a96e968efe30046bc7e3a62c68bcbb3"
        },
        "date": 1628712268869,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.797942436600446,
            "unit": "ns",
            "range": "± 0.25124589239542616"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 557.5991675124451,
            "unit": "ns",
            "range": "± 19.278143080984773"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.686485624035615,
            "unit": "ns",
            "range": "± 0.9407872981299723"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.61644939398683,
            "unit": "ns",
            "range": "± 0.2954127284976617"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.468771264647184,
            "unit": "ns",
            "range": "± 0.30549825276642134"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 585.2851243284891,
            "unit": "ns",
            "range": "± 25.717786827586686"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.524754255497292,
            "unit": "ns",
            "range": "± 0.7223404171546941"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 608.1825692845407,
            "unit": "ns",
            "range": "± 10.685318219905636"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2021.7975928342794,
            "unit": "ns",
            "range": "± 63.83244358673514"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 67169.84156220047,
            "unit": "ns",
            "range": "± 1995.253926783082"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 71027.69034062813,
            "unit": "ns",
            "range": "± 2362.3421822496457"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 73821.20386192754,
            "unit": "ns",
            "range": "± 2377.194719209783"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1923.6559139784947,
            "unit": "ns",
            "range": "± 120.14289450697552"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.744917941824873,
            "unit": "ns",
            "range": "± 0.8070328744890101"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 541.1311850857744,
            "unit": "ns",
            "range": "± 13.828745999659912"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.135340219326068,
            "unit": "ns",
            "range": "± 1.026816560943867"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2038.4488018841535,
            "unit": "ns",
            "range": "± 92.62795335729311"
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
          "id": "f8b54550ec941357a75bc5d906542d255350156d",
          "message": "UnitsNet: 4.102.0",
          "timestamp": "2021-09-03T17:12:38+02:00",
          "tree_id": "78beb8d8cb6d6470322558367b67a2dc492278eb",
          "url": "https://github.com/angularsen/UnitsNet/commit/f8b54550ec941357a75bc5d906542d255350156d"
        },
        "date": 1630682545627,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.93339998010298,
            "unit": "ns",
            "range": "± 0.029990093523784858"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 512.1999501089799,
            "unit": "ns",
            "range": "± 3.19549123655208"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.462548758522864,
            "unit": "ns",
            "range": "± 0.04694395970737172"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.63902828284545,
            "unit": "ns",
            "range": "± 0.02083122478207852"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.320108348315525,
            "unit": "ns",
            "range": "± 0.019176880288750336"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 497.5508056854331,
            "unit": "ns",
            "range": "± 2.3535483085774906"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.70342305139338,
            "unit": "ns",
            "range": "± 0.04181518687319803"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 509.14343201291183,
            "unit": "ns",
            "range": "± 2.3697616049605505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2073.177911385638,
            "unit": "ns",
            "range": "± 15.502743822840568"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 59380.129303506255,
            "unit": "ns",
            "range": "± 178.23617279981988"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60449.951004016075,
            "unit": "ns",
            "range": "± 139.4392330781868"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 64970.03436426117,
            "unit": "ns",
            "range": "± 163.5172611064022"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1608.695652173913,
            "unit": "ns",
            "range": "± 102.33770202429771"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.475057800677693,
            "unit": "ns",
            "range": "± 0.061017585577420874"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 503.8879013682776,
            "unit": "ns",
            "range": "± 2.183084717456215"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.431592790082096,
            "unit": "ns",
            "range": "± 0.2804849179518928"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1998.5961023075004,
            "unit": "ns",
            "range": "± 11.575378797350284"
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
          "id": "888061fa75c75106e82ba268d0a16c4bbf61d366",
          "message": "Revert unintentional change to fix compile error",
          "timestamp": "2021-09-30T22:53:33+02:00",
          "tree_id": "fa4ae4810f31759b18cd6852fc39ea8c38f0430a",
          "url": "https://github.com/angularsen/UnitsNet/commit/888061fa75c75106e82ba268d0a16c4bbf61d366"
        },
        "date": 1633035789097,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.929148346403736,
            "unit": "ns",
            "range": "± 0.2100971240279719"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 578.9945718910105,
            "unit": "ns",
            "range": "± 10.259632154984347"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.667533820647034,
            "unit": "ns",
            "range": "± 0.5069233227238242"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.889294815507974,
            "unit": "ns",
            "range": "± 0.18315830614599385"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.997940088988253,
            "unit": "ns",
            "range": "± 0.18692385655883817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 569.9166279213936,
            "unit": "ns",
            "range": "± 10.388681976725648"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.196896950986837,
            "unit": "ns",
            "range": "± 0.3571300815742217"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 583.9364396687553,
            "unit": "ns",
            "range": "± 7.256781128502529"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2160.8262484670754,
            "unit": "ns",
            "range": "± 25.586943948700036"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 76525.09189797449,
            "unit": "ns",
            "range": "± 1958.9079724514627"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 78002.43269182199,
            "unit": "ns",
            "range": "± 1346.7424142956195"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 78659.0512582986,
            "unit": "ns",
            "range": "± 1611.78531775237"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2268.8888888888887,
            "unit": "ns",
            "range": "± 148.88683919807008"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.424064085504817,
            "unit": "ns",
            "range": "± 0.3693544690335162"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 574.3614584498489,
            "unit": "ns",
            "range": "± 16.826881743438133"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.310717513418943,
            "unit": "ns",
            "range": "± 0.6844598575472064"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2194.018850558643,
            "unit": "ns",
            "range": "± 39.657380183908245"
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
          "id": "6be7065e62b3a48ee75be8f7d14edf3fe6287910",
          "message": "UnitsNet: 4.103.0",
          "timestamp": "2021-11-12T09:05:57+01:00",
          "tree_id": "2d7786f04db8e557609b8e51947bf838afa0699b",
          "url": "https://github.com/angularsen/UnitsNet/commit/6be7065e62b3a48ee75be8f7d14edf3fe6287910"
        },
        "date": 1636704858234,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.958736845546492,
            "unit": "ns",
            "range": "± 0.03186038407649416"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 506.4766257788612,
            "unit": "ns",
            "range": "± 1.6513575627139012"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.830477662110443,
            "unit": "ns",
            "range": "± 0.05520871388280338"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.350032020375346,
            "unit": "ns",
            "range": "± 0.031014523160594207"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.349984901323381,
            "unit": "ns",
            "range": "± 0.024710495034586465"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 506.31428010900817,
            "unit": "ns",
            "range": "± 2.720737392740643"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.661871344552107,
            "unit": "ns",
            "range": "± 0.04003307822474866"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 517.2023261913051,
            "unit": "ns",
            "range": "± 1.9956625899258575"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2118.1299924652526,
            "unit": "ns",
            "range": "± 11.113402709232888"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 59985.22342995168,
            "unit": "ns",
            "range": "± 182.6797766154083"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60580.07939844005,
            "unit": "ns",
            "range": "± 171.04191864197395"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 65803.85932641353,
            "unit": "ns",
            "range": "± 198.58131056438938"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1930.357142857143,
            "unit": "ns",
            "range": "± 82.9449825478922"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.058793094071994,
            "unit": "ns",
            "range": "± 0.13193958622322144"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 507.3042092974236,
            "unit": "ns",
            "range": "± 2.464289970566423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.571339787323147,
            "unit": "ns",
            "range": "± 0.08896826149254379"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2085.1491872313145,
            "unit": "ns",
            "range": "± 9.29666283908663"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "efortin76@gmail.com",
            "name": "Étienne Fortin",
            "username": "ebfortin"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "24e8e28bb5db3365875d1ec3815538d614028dcb",
          "message": "Add Duration.JulianYear (#978)\n\nCo-authored-by: Andreas Gullberg Larsen <andreas.larsen84@gmail.com>",
          "timestamp": "2021-11-12T09:05:20+01:00",
          "tree_id": "c2698667dd0247627ad664de729a67fd3f0eb6de",
          "url": "https://github.com/angularsen/UnitsNet/commit/24e8e28bb5db3365875d1ec3815538d614028dcb"
        },
        "date": 1636704911403,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.947711469186816,
            "unit": "ns",
            "range": "± 0.030468144425542954"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 511.86445152064397,
            "unit": "ns",
            "range": "± 3.3206732174346483"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.80038421732294,
            "unit": "ns",
            "range": "± 0.05748645252661969"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.331595962197861,
            "unit": "ns",
            "range": "± 0.02298473543808153"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.343768351998346,
            "unit": "ns",
            "range": "± 0.024656217534940048"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 505.7741008571355,
            "unit": "ns",
            "range": "± 1.2032015756024677"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.65228117722008,
            "unit": "ns",
            "range": "± 0.03993006738514489"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 513.4169295220662,
            "unit": "ns",
            "range": "± 3.6834183094685984"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2089.6573935886854,
            "unit": "ns",
            "range": "± 21.117905021098142"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 63580.60052007152,
            "unit": "ns",
            "range": "± 631.6175729490216"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60040.41737168642,
            "unit": "ns",
            "range": "± 235.94491860680006"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 65556.27163083377,
            "unit": "ns",
            "range": "± 289.49052643194295"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2027.7777777777778,
            "unit": "ns",
            "range": "± 99.60799535506253"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.097662323535562,
            "unit": "ns",
            "range": "± 0.052452962242461584"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 500.7081923523225,
            "unit": "ns",
            "range": "± 1.6287870195934988"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.571588972452826,
            "unit": "ns",
            "range": "± 0.059517428272556266"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2063.8823026908462,
            "unit": "ns",
            "range": "± 5.622321650610421"
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
          "id": "ca757677c49699a1f9a8358df8889efdc2d190c3",
          "message": "UnitsNet: 4.104.0",
          "timestamp": "2021-11-15T11:20:41+01:00",
          "tree_id": "86881d619917fa1293f5316e32ec14d534f39644",
          "url": "https://github.com/angularsen/UnitsNet/commit/ca757677c49699a1f9a8358df8889efdc2d190c3"
        },
        "date": 1636972369744,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.280092568252458,
            "unit": "ns",
            "range": "± 0.07959110404055814"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 565.2351504839196,
            "unit": "ns",
            "range": "± 3.821132084761884"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.162876099339794,
            "unit": "ns",
            "range": "± 0.27626661042197187"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.049388538075235,
            "unit": "ns",
            "range": "± 0.22483747950437213"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.8742294197791,
            "unit": "ns",
            "range": "± 0.1934841995907367"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 566.8507900577066,
            "unit": "ns",
            "range": "± 3.4792977847955475"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.817868736340248,
            "unit": "ns",
            "range": "± 0.21146827394933754"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 588.3217977843238,
            "unit": "ns",
            "range": "± 8.700657664739147"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2239.469664925907,
            "unit": "ns",
            "range": "± 67.93056679500481"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 75106.09850192898,
            "unit": "ns",
            "range": "± 493.029568293679"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 77732.66432112586,
            "unit": "ns",
            "range": "± 456.1788059120449"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 81112.60648616735,
            "unit": "ns",
            "range": "± 1483.887986609897"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2331,
            "unit": "ns",
            "range": "± 165.56911340322904"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.302071279921634,
            "unit": "ns",
            "range": "± 0.25904532488543525"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 567.8702450053121,
            "unit": "ns",
            "range": "± 4.471891792461472"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.202508171334127,
            "unit": "ns",
            "range": "± 0.3529739621927565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2140.1415375227903,
            "unit": "ns",
            "range": "± 14.24724533010879"
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
          "id": "041c0f452a6f3fd067b7927b33d6c7a9d28a0dfd",
          "message": "UnitsNet: 4.105.0",
          "timestamp": "2021-11-22T18:08:28+01:00",
          "tree_id": "a8735f5745c20e48fad922651370c0f1912feb7c",
          "url": "https://github.com/angularsen/UnitsNet/commit/041c0f452a6f3fd067b7927b33d6c7a9d28a0dfd"
        },
        "date": 1637601547489,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.454645515010949,
            "unit": "ns",
            "range": "± 0.2167690827354157"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 649.6646839238814,
            "unit": "ns",
            "range": "± 15.202487886554605"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.907827318207175,
            "unit": "ns",
            "range": "± 0.6338665000996468"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.321530180859918,
            "unit": "ns",
            "range": "± 0.2481094556607589"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.361234566425576,
            "unit": "ns",
            "range": "± 0.16907386820937925"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 664.6603768343479,
            "unit": "ns",
            "range": "± 13.96121321399269"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.61213431660631,
            "unit": "ns",
            "range": "± 0.23887890149826102"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 638.5904808484349,
            "unit": "ns",
            "range": "± 11.98267303965235"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2632.4839949925813,
            "unit": "ns",
            "range": "± 31.022081812748862"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 75680.28030955361,
            "unit": "ns",
            "range": "± 2085.178953679734"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 74845.0280931086,
            "unit": "ns",
            "range": "± 2069.0647591558095"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 82503.06314149559,
            "unit": "ns",
            "range": "± 1977.5304847419502"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2316.4835164835163,
            "unit": "ns",
            "range": "± 160.04425517388503"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.559113180199553,
            "unit": "ns",
            "range": "± 0.6037722305730799"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 623.0546559631526,
            "unit": "ns",
            "range": "± 11.515310652921116"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.822509657968546,
            "unit": "ns",
            "range": "± 0.6955051933621974"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2632.947559319534,
            "unit": "ns",
            "range": "± 46.178145066910965"
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
          "id": "463f970fa801d3603013922ce50ee6e718fbdc9f",
          "message": "UnitsNet: 4.106.0",
          "timestamp": "2021-11-23T23:20:56+01:00",
          "tree_id": "a332c1fae10a93c71a7f3cd313989f7fc1571b50",
          "url": "https://github.com/angularsen/UnitsNet/commit/463f970fa801d3603013922ce50ee6e718fbdc9f"
        },
        "date": 1637706570484,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.646652485987971,
            "unit": "ns",
            "range": "± 0.19295147603364124"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 596.1322267858054,
            "unit": "ns",
            "range": "± 7.078463979229893"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.523002850664717,
            "unit": "ns",
            "range": "± 0.6093950952742317"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.933576602243772,
            "unit": "ns",
            "range": "± 0.08367330252355079"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.91072894373636,
            "unit": "ns",
            "range": "± 0.15040688549296433"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 602.4744342708793,
            "unit": "ns",
            "range": "± 4.13099011771442"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.40215494776914,
            "unit": "ns",
            "range": "± 0.2672857103393517"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 615.9924121034967,
            "unit": "ns",
            "range": "± 7.272691678043968"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2367.0530198497513,
            "unit": "ns",
            "range": "± 57.99745993552409"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 88266.52602966379,
            "unit": "ns",
            "range": "± 1603.6179789070545"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 87428.89348976307,
            "unit": "ns",
            "range": "± 1266.5329113921746"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 92722.97385009738,
            "unit": "ns",
            "range": "± 1786.4864910099925"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2387.6288659793813,
            "unit": "ns",
            "range": "± 183.29037297343856"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.013898656019176,
            "unit": "ns",
            "range": "± 0.3336713456346125"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 688.5801526856775,
            "unit": "ns",
            "range": "± 8.987150367087986"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.603396062492262,
            "unit": "ns",
            "range": "± 0.7070571999889405"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2562.927875379139,
            "unit": "ns",
            "range": "± 42.97722245541449"
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
          "id": "cbbaf4782a0af1d1726f63a215d480de6f0cd87a",
          "message": "UnitsNet: 4.107.0",
          "timestamp": "2021-11-23T23:22:58+01:00",
          "tree_id": "7524e92f9a30dc6a876b29ec061262d5d4bb6615",
          "url": "https://github.com/angularsen/UnitsNet/commit/cbbaf4782a0af1d1726f63a215d480de6f0cd87a"
        },
        "date": 1637706787136,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.988800316094682,
            "unit": "ns",
            "range": "± 0.19580910084804284"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 552.7066020483167,
            "unit": "ns",
            "range": "± 10.245215596856749"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.17037355602051,
            "unit": "ns",
            "range": "± 0.7096135639068923"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.945957835792953,
            "unit": "ns",
            "range": "± 0.2900263103247489"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.489101585625054,
            "unit": "ns",
            "range": "± 0.1722502878393799"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 560.5831099001446,
            "unit": "ns",
            "range": "± 22.721256132470405"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.781577728002073,
            "unit": "ns",
            "range": "± 0.2948577873843568"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 555.2489621683195,
            "unit": "ns",
            "range": "± 7.423214891721937"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2104.2531453365978,
            "unit": "ns",
            "range": "± 72.05089642385832"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 70705.14675627486,
            "unit": "ns",
            "range": "± 1312.4361816818518"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 75365.04270927544,
            "unit": "ns",
            "range": "± 1324.2752990714564"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 80761.97286650723,
            "unit": "ns",
            "range": "± 1897.1464448896825"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2307.6923076923076,
            "unit": "ns",
            "range": "± 160.71421788087025"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.938925034984184,
            "unit": "ns",
            "range": "± 0.6298574349758121"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 575.816361185489,
            "unit": "ns",
            "range": "± 6.039915899704639"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.76925094561018,
            "unit": "ns",
            "range": "± 0.9141662329973637"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2040.2054832765648,
            "unit": "ns",
            "range": "± 34.804677257129185"
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
          "id": "604244bbcc2e08866fb8c8d7a898039f16bd87eb",
          "message": "UnitsNet: 4.108.0",
          "timestamp": "2021-11-25T23:00:50+01:00",
          "tree_id": "a4b00c29e1f6afdf28dfe6f773d06de4bd97b869",
          "url": "https://github.com/angularsen/UnitsNet/commit/604244bbcc2e08866fb8c8d7a898039f16bd87eb"
        },
        "date": 1637878289730,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.02653329694975,
            "unit": "ns",
            "range": "± 0.24083174202660165"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 611.0375968970532,
            "unit": "ns",
            "range": "± 6.713726506251548"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.92960263811519,
            "unit": "ns",
            "range": "± 0.4158546039686207"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.907151827839664,
            "unit": "ns",
            "range": "± 0.12211222103793619"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.007144511858579,
            "unit": "ns",
            "range": "± 0.21495311870345216"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 611.6586382927227,
            "unit": "ns",
            "range": "± 12.045787700476836"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.723290601459755,
            "unit": "ns",
            "range": "± 0.15728055952529632"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 626.6821138629492,
            "unit": "ns",
            "range": "± 11.802203084346136"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2850.608986150564,
            "unit": "ns",
            "range": "± 55.76530975099931"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 72302.08431822788,
            "unit": "ns",
            "range": "± 1426.425861761233"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 71061.04342761802,
            "unit": "ns",
            "range": "± 1513.6695088271795"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 79769.19290895166,
            "unit": "ns",
            "range": "± 1394.984482242437"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2294.68085106383,
            "unit": "ns",
            "range": "± 176.80985551071387"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.482865340655675,
            "unit": "ns",
            "range": "± 0.6871848192043817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 613.5778123226863,
            "unit": "ns",
            "range": "± 14.764858229883544"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.74262209838307,
            "unit": "ns",
            "range": "± 1.171593621485308"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2476.0566169578565,
            "unit": "ns",
            "range": "± 48.181710070386046"
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
          "id": "9799a1b3aa9c5cfc6ede322350ce2cbfcaee1a74",
          "message": "UnitsNet: 4.109.0",
          "timestamp": "2021-12-01T23:20:56+01:00",
          "tree_id": "92361a8ae9f407e57ce54d24b421f7ba44b026ba",
          "url": "https://github.com/angularsen/UnitsNet/commit/9799a1b3aa9c5cfc6ede322350ce2cbfcaee1a74"
        },
        "date": 1638398049156,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.877565651837394,
            "unit": "ns",
            "range": "± 0.41544773963629356"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 600.0096853724541,
            "unit": "ns",
            "range": "± 20.058189887170077"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 32.94665517150974,
            "unit": "ns",
            "range": "± 0.6075617157120399"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.310754615330097,
            "unit": "ns",
            "range": "± 0.2288888989036618"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.292773790214005,
            "unit": "ns",
            "range": "± 0.29880820377469736"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 583.5149590399432,
            "unit": "ns",
            "range": "± 21.914160338357384"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.394835066919796,
            "unit": "ns",
            "range": "± 0.598234319130936"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 606.5887728679043,
            "unit": "ns",
            "range": "± 9.01196320792636"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2166.6146530210394,
            "unit": "ns",
            "range": "± 77.43943799199698"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 75556.79530828726,
            "unit": "ns",
            "range": "± 2458.658223639985"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 75679.95466870023,
            "unit": "ns",
            "range": "± 2444.1440864377573"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 81410.80379383717,
            "unit": "ns",
            "range": "± 2939.3185507515113"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2491.4893617021276,
            "unit": "ns",
            "range": "± 161.08474659176898"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.044804581905726,
            "unit": "ns",
            "range": "± 0.4796074531713329"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 586.0307507804054,
            "unit": "ns",
            "range": "± 23.831001856335657"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.52413447275342,
            "unit": "ns",
            "range": "± 1.2256928032986172"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2188.980580468883,
            "unit": "ns",
            "range": "± 51.39527590971288"
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
          "id": "6f865f3bd9418f3b681a1f9f91d31b35eb2ae696",
          "message": "UnitsNet: 4.110.0",
          "timestamp": "2021-12-07T15:48:12+01:00",
          "tree_id": "f21b4e1d2aae896af7ec6785c6e90c19040e1808",
          "url": "https://github.com/angularsen/UnitsNet/commit/6f865f3bd9418f3b681a1f9f91d31b35eb2ae696"
        },
        "date": 1638889724820,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.327456640598363,
            "unit": "ns",
            "range": "± 0.38923282063184866"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 603.8099420087543,
            "unit": "ns",
            "range": "± 17.731514499544527"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.182956671064208,
            "unit": "ns",
            "range": "± 0.41410342549248874"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.606896471770558,
            "unit": "ns",
            "range": "± 0.2630398764018154"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.524953365626384,
            "unit": "ns",
            "range": "± 0.2846483329524717"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 591.8839001395398,
            "unit": "ns",
            "range": "± 10.203126634754256"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.798500099695413,
            "unit": "ns",
            "range": "± 0.3458375143842133"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 600.8998819077041,
            "unit": "ns",
            "range": "± 13.760280919522007"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2362.483324591711,
            "unit": "ns",
            "range": "± 65.36400864713112"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 68835.44795513609,
            "unit": "ns",
            "range": "± 1036.0722408437498"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 70740.65449337629,
            "unit": "ns",
            "range": "± 1546.6310275620842"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 75144.46760709425,
            "unit": "ns",
            "range": "± 924.0997503234813"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2204.6511627906975,
            "unit": "ns",
            "range": "± 145.44615073400152"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.35924453451822,
            "unit": "ns",
            "range": "± 0.36982591256934805"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 591.754620854124,
            "unit": "ns",
            "range": "± 12.18134140501687"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.190007431969413,
            "unit": "ns",
            "range": "± 0.8830570150508742"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2314.1364564674595,
            "unit": "ns",
            "range": "± 44.56582287876421"
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
          "id": "19c0fa957faebc4ca39bdd25d2a43df3bde81b0c",
          "message": "UnitsNet: 4.111.0",
          "timestamp": "2021-12-30T14:33:18+01:00",
          "tree_id": "4290f00b7eedd3c0844ddbb85ccbffef2ad375c5",
          "url": "https://github.com/angularsen/UnitsNet/commit/19c0fa957faebc4ca39bdd25d2a43df3bde81b0c"
        },
        "date": 1640872011023,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.089826026327076,
            "unit": "ns",
            "range": "± 0.5864342018826586"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 541.670513647087,
            "unit": "ns",
            "range": "± 21.044803345106263"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 27.608668164915766,
            "unit": "ns",
            "range": "± 1.1644331526140237"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.325671242303242,
            "unit": "ns",
            "range": "± 0.44239134310609135"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.584687900119462,
            "unit": "ns",
            "range": "± 0.37284001258979166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 523.2421361150599,
            "unit": "ns",
            "range": "± 24.0884618633707"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.16360307073994,
            "unit": "ns",
            "range": "± 0.8510241372792458"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 554.700956230894,
            "unit": "ns",
            "range": "± 26.52464728863372"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2127.6375897879275,
            "unit": "ns",
            "range": "± 108.20770044034887"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 73075.20879263393,
            "unit": "ns",
            "range": "± 1709.8373773921232"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 75327.1953765097,
            "unit": "ns",
            "range": "± 3135.699428810506"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 77591.49135276,
            "unit": "ns",
            "range": "± 2192.7567362526866"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2281.7204301075267,
            "unit": "ns",
            "range": "± 148.1378885855865"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.82289573209418,
            "unit": "ns",
            "range": "± 0.9000046243629362"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 555.4412573559661,
            "unit": "ns",
            "range": "± 9.3091422365932"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 27.60350036585608,
            "unit": "ns",
            "range": "± 1.99733113369314"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1993.1262594428558,
            "unit": "ns",
            "range": "± 100.65883705923241"
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
          "id": "9517e77f4db722e4a81eaab9234faf701d50098c",
          "message": "UnitsNet: 4.112.0",
          "timestamp": "2021-12-31T11:56:28+01:00",
          "tree_id": "a481bd27a6fb898efd934017a12d54af6b65b0e7",
          "url": "https://github.com/angularsen/UnitsNet/commit/9517e77f4db722e4a81eaab9234faf701d50098c"
        },
        "date": 1640948797732,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.881710335723678,
            "unit": "ns",
            "range": "± 0.46628155496121043"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 579.3467946340257,
            "unit": "ns",
            "range": "± 20.284898737960575"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.295413011685866,
            "unit": "ns",
            "range": "± 1.1068964832333148"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.04538219690573,
            "unit": "ns",
            "range": "± 0.4111017249477247"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.715816710793955,
            "unit": "ns",
            "range": "± 0.2098947806715237"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 557.7904017704267,
            "unit": "ns",
            "range": "± 20.320043750117783"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.164190399815045,
            "unit": "ns",
            "range": "± 0.47414067824871436"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 552.6257480111386,
            "unit": "ns",
            "range": "± 16.682369549307854"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2123.379419120154,
            "unit": "ns",
            "range": "± 35.074419478278124"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 62451.79556064891,
            "unit": "ns",
            "range": "± 1020.298492857556"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 62181.744820974534,
            "unit": "ns",
            "range": "± 1092.2685007946568"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 69473.08383322885,
            "unit": "ns",
            "range": "± 2640.2809384372003"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1964.8936170212767,
            "unit": "ns",
            "range": "± 177.62316448304264"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.30109841903544,
            "unit": "ns",
            "range": "± 0.40909489368406954"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 560.1766157323374,
            "unit": "ns",
            "range": "± 10.158359758630944"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 27.339483730675777,
            "unit": "ns",
            "range": "± 0.9872047465347468"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2132.593294510797,
            "unit": "ns",
            "range": "± 46.055890403525176"
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
          "id": "cece3f33b4178cfc741b12e3ffe6c90f02bc7ff3",
          "message": "UnitsNet: 4.113.0",
          "timestamp": "2022-01-16T14:20:46+01:00",
          "tree_id": "c07f982f2294501c2269b20aafe0079601c3ac3b",
          "url": "https://github.com/angularsen/UnitsNet/commit/cece3f33b4178cfc741b12e3ffe6c90f02bc7ff3"
        },
        "date": 1642339824831,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.222654081826189,
            "unit": "ns",
            "range": "± 0.14354521023324207"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 636.9971983071495,
            "unit": "ns",
            "range": "± 6.843236556802764"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.678817966852193,
            "unit": "ns",
            "range": "± 0.40606765917248955"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.27237824644429,
            "unit": "ns",
            "range": "± 0.21384629002248726"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.30628232097467,
            "unit": "ns",
            "range": "± 0.30575799161447154"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 635.7157062024164,
            "unit": "ns",
            "range": "± 14.000354638179305"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.685350777675914,
            "unit": "ns",
            "range": "± 0.38307022965709114"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 642.399100394461,
            "unit": "ns",
            "range": "± 10.055193700542292"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2670.8988441084957,
            "unit": "ns",
            "range": "± 42.748870091157244"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 74654.77645324139,
            "unit": "ns",
            "range": "± 1939.1984133405117"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 76175.27125837297,
            "unit": "ns",
            "range": "± 1417.2067632945502"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 83773.83920427399,
            "unit": "ns",
            "range": "± 2093.721696065523"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2139.622641509434,
            "unit": "ns",
            "range": "± 86.24567467751966"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 25.64653576800187,
            "unit": "ns",
            "range": "± 0.9275619433875694"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 629.4895968897478,
            "unit": "ns",
            "range": "± 9.468629533718492"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.775429866698225,
            "unit": "ns",
            "range": "± 0.607978662227361"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2688.094778529614,
            "unit": "ns",
            "range": "± 46.73762668216417"
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
          "id": "2c3cb93cffd453a296a64ed0eadc5d02e35a4836",
          "message": "UnitsNet: 4.114.0",
          "timestamp": "2022-01-18T00:16:43+01:00",
          "tree_id": "74ebf3209c87a855e5ee6265cf0c14fb85eeeec0",
          "url": "https://github.com/angularsen/UnitsNet/commit/2c3cb93cffd453a296a64ed0eadc5d02e35a4836"
        },
        "date": 1642462244006,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.920041862295616,
            "unit": "ns",
            "range": "± 0.030305375238660802"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 514.0731158635922,
            "unit": "ns",
            "range": "± 1.8362757253862028"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 25.443752817980478,
            "unit": "ns",
            "range": "± 0.057626125881273915"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.330257848268527,
            "unit": "ns",
            "range": "± 0.02783286054426097"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.331348191618419,
            "unit": "ns",
            "range": "± 0.009283706779861647"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 505.3952522634765,
            "unit": "ns",
            "range": "± 2.059637038036093"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.639986060939712,
            "unit": "ns",
            "range": "± 0.03976933059552346"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 522.95110701107,
            "unit": "ns",
            "range": "± 2.8126612368806403"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2291.3601789298477,
            "unit": "ns",
            "range": "± 9.995264092964359"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 59656.6548146122,
            "unit": "ns",
            "range": "± 232.840348116827"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60385.683924576544,
            "unit": "ns",
            "range": "± 315.0856135683394"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 65620.38334204564,
            "unit": "ns",
            "range": "± 262.3332308345185"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1810.5263157894738,
            "unit": "ns",
            "range": "± 108.64120550764585"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.68622461519016,
            "unit": "ns",
            "range": "± 0.10925421938222739"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 504.89193007707416,
            "unit": "ns",
            "range": "± 1.291491715552265"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.367358774754397,
            "unit": "ns",
            "range": "± 0.11543703874797716"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2318.157143316738,
            "unit": "ns",
            "range": "± 10.495605883535907"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "tristan.milnthorp@ansys.com",
            "name": "Tristan Milnthorp",
            "username": "tmilnthorp"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "f3d3b8c1777cc8a22abd4176fb91d1ef13e5e954",
          "message": "Deprecate more usage of QuantityType (#1019)",
          "timestamp": "2022-01-26T21:14:06+01:00",
          "tree_id": "688a91d28cc1634b1488f9b34a293c4bf496bbb2",
          "url": "https://github.com/angularsen/UnitsNet/commit/f3d3b8c1777cc8a22abd4176fb91d1ef13e5e954"
        },
        "date": 1643229717760,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.94364082144067,
            "unit": "ns",
            "range": "± 0.6665354281005219"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 547.4366525848247,
            "unit": "ns",
            "range": "± 32.3084246181042"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.165623918377584,
            "unit": "ns",
            "range": "± 1.2743559318747055"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.2288248624407,
            "unit": "ns",
            "range": "± 0.4615516191662159"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 7.918047266743416,
            "unit": "ns",
            "range": "± 0.36288666049300317"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 565.9114037800742,
            "unit": "ns",
            "range": "± 25.826981980900822"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.26193860906444,
            "unit": "ns",
            "range": "± 0.6861772756299348"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 590.3466820737892,
            "unit": "ns",
            "range": "± 25.924143905786394"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2385.883110848261,
            "unit": "ns",
            "range": "± 130.5232018497266"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 80940.85770138813,
            "unit": "ns",
            "range": "± 4306.318038296218"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 77569.94232005141,
            "unit": "ns",
            "range": "± 4818.026115115988"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 79910.51576614968,
            "unit": "ns",
            "range": "± 4782.906037765102"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2298.9473684210525,
            "unit": "ns",
            "range": "± 177.14925600344924"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.80322946510957,
            "unit": "ns",
            "range": "± 1.500407487902352"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 585.2201467424389,
            "unit": "ns",
            "range": "± 14.664258993216059"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.459126201006566,
            "unit": "ns",
            "range": "± 0.629657751158666"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2223.5023370018725,
            "unit": "ns",
            "range": "± 125.01450278444551"
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
          "id": "1d26388f6713da6a179178f1f0a0fa15a72802c4",
          "message": "UnitsNet: 4.115.0",
          "timestamp": "2022-01-26T22:24:53+01:00",
          "tree_id": "826cfb1f15ac583ee2fbec88316b7d912d5e2369",
          "url": "https://github.com/angularsen/UnitsNet/commit/1d26388f6713da6a179178f1f0a0fa15a72802c4"
        },
        "date": 1643233375538,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.555350811618963,
            "unit": "ns",
            "range": "± 0.24590366838348765"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 554.929211676229,
            "unit": "ns",
            "range": "± 23.685665756435352"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.791419906192935,
            "unit": "ns",
            "range": "± 1.2436896495901846"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.206695386253452,
            "unit": "ns",
            "range": "± 0.1385594901020418"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.389110921749815,
            "unit": "ns",
            "range": "± 0.35471365402775673"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 548.7159271148587,
            "unit": "ns",
            "range": "± 23.921695497419382"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.994795122737656,
            "unit": "ns",
            "range": "± 0.5372907722137815"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 631.0954056074382,
            "unit": "ns",
            "range": "± 24.750542801667965"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2291.829611839029,
            "unit": "ns",
            "range": "± 39.12518420931592"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 80492.75358809187,
            "unit": "ns",
            "range": "± 1958.9779472294742"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 80448.33438685209,
            "unit": "ns",
            "range": "± 2364.8551994328486"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 88038.90450037488,
            "unit": "ns",
            "range": "± 2489.7078141966613"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2479.381443298969,
            "unit": "ns",
            "range": "± 166.4194902509773"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.18939077385927,
            "unit": "ns",
            "range": "± 0.35267994060105423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 599.4179377747156,
            "unit": "ns",
            "range": "± 6.961354464687698"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.668631398195476,
            "unit": "ns",
            "range": "± 0.5625540009914197"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2243.0671821444234,
            "unit": "ns",
            "range": "± 39.24392097214812"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "tristan.milnthorp@ansys.com",
            "name": "Tristan Milnthorp",
            "username": "tmilnthorp"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "fa983e226f47f4377bb2cf57371c65ec77743c16",
          "message": "Move default unit converter registration to quantity types (#1018)\n\nRef #1016 \r\n\r\nInstead of a huge single method in UnitConverter, it is split up into a static method per quanitity type.",
          "timestamp": "2022-01-26T22:24:33+01:00",
          "tree_id": "2d6e58fdb244eb59e91e62e2dda3bffe386857d7",
          "url": "https://github.com/angularsen/UnitsNet/commit/fa983e226f47f4377bb2cf57371c65ec77743c16"
        },
        "date": 1643233507612,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.49293008346443,
            "unit": "ns",
            "range": "± 0.6410181974701404"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 522.5213958442691,
            "unit": "ns",
            "range": "± 21.83726185636027"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.250090927455567,
            "unit": "ns",
            "range": "± 1.2945678312854205"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.043776355352009,
            "unit": "ns",
            "range": "± 0.4982273962942083"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 7.836394411460724,
            "unit": "ns",
            "range": "± 0.5218689877385666"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 525.5659451066357,
            "unit": "ns",
            "range": "± 22.225511475663893"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.795513327505187,
            "unit": "ns",
            "range": "± 0.8365222161867606"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 544.571289244917,
            "unit": "ns",
            "range": "± 24.728158522225286"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2147.242497467628,
            "unit": "ns",
            "range": "± 99.5284159842608"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 65851.83064657768,
            "unit": "ns",
            "range": "± 3138.327705963699"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 65991.48931468507,
            "unit": "ns",
            "range": "± 3109.9840432385663"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 70648.0999533599,
            "unit": "ns",
            "range": "± 3550.2650178897675"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2263.529411764706,
            "unit": "ns",
            "range": "± 352.15224616888753"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.573853333489524,
            "unit": "ns",
            "range": "± 1.024645187552499"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 504.6740209220108,
            "unit": "ns",
            "range": "± 22.766577857532873"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.08635283574935,
            "unit": "ns",
            "range": "± 1.653856406561703"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2135.94210003024,
            "unit": "ns",
            "range": "± 101.31256227440262"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "tristan.milnthorp@ansys.com",
            "name": "Tristan Milnthorp",
            "username": "tmilnthorp"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "f33c63d837f8cb8792e9c3ea51b310a984db9f20",
          "message": "Remove duplicate QuantityInfo constructor setters (#1020)",
          "timestamp": "2022-01-28T13:06:48+01:00",
          "tree_id": "07e0c8a95208e1fd2a729f345000c65d9d8add2f",
          "url": "https://github.com/angularsen/UnitsNet/commit/f33c63d837f8cb8792e9c3ea51b310a984db9f20"
        },
        "date": 1643372293029,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.896370628824808,
            "unit": "ns",
            "range": "± 0.15777195557666682"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 502.2091315453383,
            "unit": "ns",
            "range": "± 14.717657285304309"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.752947955980943,
            "unit": "ns",
            "range": "± 0.6622845573697355"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.366899576464542,
            "unit": "ns",
            "range": "± 0.3349499689861185"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.46862073032016,
            "unit": "ns",
            "range": "± 0.2654600328901279"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 487.43246648430176,
            "unit": "ns",
            "range": "± 14.526155923386963"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.76287468605272,
            "unit": "ns",
            "range": "± 0.4819933899570126"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 506.3570551287546,
            "unit": "ns",
            "range": "± 14.883312280493465"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1939.5627871334934,
            "unit": "ns",
            "range": "± 60.36795632884902"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 59363.93834761627,
            "unit": "ns",
            "range": "± 1197.5427143362963"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 58483.971669296094,
            "unit": "ns",
            "range": "± 1769.216449475467"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 63079.191601350176,
            "unit": "ns",
            "range": "± 1523.029760925494"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2040.7407407407406,
            "unit": "ns",
            "range": "± 85.8223670509816"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.533430666952157,
            "unit": "ns",
            "range": "± 0.6587994765498051"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 484.44698757573167,
            "unit": "ns",
            "range": "± 13.635941167760228"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.967633639055403,
            "unit": "ns",
            "range": "± 0.887876908488334"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1909.1868644725362,
            "unit": "ns",
            "range": "± 52.76750897182155"
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
          "id": "e341c81e3c758b674d7310f2c4b4f85c88c77a5e",
          "message": "UnitsNet: 4.116.0",
          "timestamp": "2022-01-28T20:25:51+01:00",
          "tree_id": "8a314b036542bb52be4e62f35c29e7d0c102c4fc",
          "url": "https://github.com/angularsen/UnitsNet/commit/e341c81e3c758b674d7310f2c4b4f85c88c77a5e"
        },
        "date": 1643398824881,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.683423722171701,
            "unit": "ns",
            "range": "± 0.294628868048763"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 662.95355482051,
            "unit": "ns",
            "range": "± 13.598736522725414"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.53873893205566,
            "unit": "ns",
            "range": "± 0.4034917870893946"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.94906321178836,
            "unit": "ns",
            "range": "± 0.22740646133969988"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.981953257733903,
            "unit": "ns",
            "range": "± 0.3694240572546368"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 688.3371468256553,
            "unit": "ns",
            "range": "± 17.23176322016595"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.012920069270148,
            "unit": "ns",
            "range": "± 0.38190370946440494"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 658.5169967841999,
            "unit": "ns",
            "range": "± 9.273505941484775"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2605.9156185409474,
            "unit": "ns",
            "range": "± 49.042063845974404"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 77325.48704069441,
            "unit": "ns",
            "range": "± 2239.8972634902984"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 78333.77678253813,
            "unit": "ns",
            "range": "± 2429.447445100901"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 84855.34032925774,
            "unit": "ns",
            "range": "± 1740.1696868597987"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2691.780821917808,
            "unit": "ns",
            "range": "± 133.07623614715308"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.726702135830823,
            "unit": "ns",
            "range": "± 0.5811742873432862"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 644.294389419918,
            "unit": "ns",
            "range": "± 8.8460166778799"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 35.296309937212804,
            "unit": "ns",
            "range": "± 0.6171507982647606"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2654.517314708867,
            "unit": "ns",
            "range": "± 30.73583092650037"
          }
        ]
      }
    ]
  }
}