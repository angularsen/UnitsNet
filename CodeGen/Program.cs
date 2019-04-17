using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Serilog;
using Serilog.Events;

namespace CodeGen
{
    class Program
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="verbose">Verbose output? Defaults to false.</param>
        /// <param name="repositoryRoot">The repository root directory, defaults to searching parent directories for UnitsNet.sln.</param>
        static int Main(bool verbose = false, DirectoryInfo repositoryRoot = null)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Console(restrictedToMinimumLevel: verbose ? LogEventLevel.Verbose : LogEventLevel.Information)
                .CreateLogger();

            try
            {
                if (repositoryRoot == null)
                {
                    var executableParentDir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    Log.Verbose($"Executable dir: {executableParentDir}");

                    if (!TryFindRepositoryRoot(executableParentDir, out repositoryRoot))
                    {
                        throw new Exception($"Unable to find repository root in directory hierarchy: {executableParentDir}");
                    }
                }

                var sw = Stopwatch.StartNew();
                Log.Information($"Units.NET code generator {Assembly.GetExecutingAssembly().GetName().Version}", ConsoleColor.Green);
                if (verbose)
                {
                    Log.Debug($"verbose: {true}", ConsoleColor.Blue);
                }

                Generator.Generate(repositoryRoot);
                Log.Information($"Completed in {sw.ElapsedMilliseconds} ms!", ConsoleColor.Green);
                return 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "Unexpected error.");
                return 1;
            }
        }

        private static bool TryFindRepositoryRoot(DirectoryInfo searchFromDir, out DirectoryInfo repoRootDir)
        {
            for (var dir = searchFromDir; dir != null; dir = dir.Parent)
            {
                if (dir.GetFiles("UnitsNet.sln").Any())
                {
                    repoRootDir = dir;
                    Log.Verbose($"Found repo root: {dir}");
                    return true;
                }

                Log.Verbose($"Not repo root: {dir}");
            }

            Log.Verbose($"Giving up finding repo root.");
            repoRootDir = null;
            return false;
        }
    }
}
