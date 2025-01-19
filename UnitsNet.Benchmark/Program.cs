using System;
using System.Diagnostics;
using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace UnitsNet.Benchmark;

internal class Program
{
    private static void Main(string[] args)
    {
        var switcher = new BenchmarkSwitcher(Assembly.GetExecutingAssembly());
        Console.Out.WriteLine("Starting benchmarks with args = {0}", string.Join(" ", args));
        if (Debugger.IsAttached)
        {
            Console.Out.WriteLine("Using an attached debugger: setting configuration to DebugInProcessConfig");
            switcher.Run(args, new DebugInProcessConfig());
        }
        else
        {
            switcher.Run(args);
        }
    }
}
