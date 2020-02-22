using UnitsNet;
using static System.Console;

namespace Try
{
    class Program
    {
        ///<param name="region">Takes in the --region option from the code fence options in markdown</param>
        ///<param name="session">Takes in the --session option from the code fence options in markdown</param>
        ///<param name="package">Takes in the --package option from the code fence options in markdown</param>
        ///<param name="project">Takes in the --project option from the code fence options in markdown</param>
        ///<param name="args">Takes in any additional arguments passed in the code fence options in markdown</param>
        ///<see>To learn more see <a href="https://aka.ms/learntdn">our documentation</a></see>
        static int Main(
            string region = null,
            string session = null,
            string package = null,
            string project = null,
            string[] args = null)
        {
            return region switch
            {
                "hello-world"       => HelloWorld(),
                "tostring"          => ToStrings(),
                _                   => MissingTag(region),
            };
        }

        private static int ToStrings()
        {
            #region tostring
            WriteLine("Length.FromMeters(10): {0}", Length.FromMeters(10));
            WriteLine("Hello World!");
            #endregion
            return 0;
        }

        private static int HelloWorld()
        {
            #region hello-world
            WriteLine("Hello World!");
            #endregion
            return 0;
        }

        private static int MissingTag(string tag, bool region = true)
        {
            WriteLine($"No code snippet configured for {(region ? "region" : "session")}: {tag}");
            return 1;
        }
    }
}
