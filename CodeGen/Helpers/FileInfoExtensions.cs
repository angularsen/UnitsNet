using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeGen.Helpers
{
    internal static class FileInfoExtensions
    {
        private static readonly string[] RegexHints = { ".*", "^", "\\s", "\\d" };

        public static void EditFile(
            this FileInfo sourceFile,
            Dictionary<string, string> replacements)
        {
            var tempFilename = $"{sourceFile.FullName}.edited";
            using (StreamReader input = sourceFile.OpenText())
            using (var output = new StreamWriter(tempFilename))
            {
                while (input.ReadLine() is { } line)
                {
                    // Replacing longer matches first is a safeguard heuristic.
                    // It ensures we don't accidentally replace "List<int>"
                    // before "IList<int>", which would break "IList<int>" replacement.
                    foreach (var (key, value) in replacements.OrderByDescending(r => r.Key.Length))
                    {
                        if (line.Contains(key))
                        {
                            line = line.Replace(key, value);
                        }
                        try
                        {
                            if (RegexHints.Any(regexHint => key.Contains(regexHint)))
                            {
                                line = Regex.Replace(line, key, value);
                            }
                        }
                        catch (RegexParseException) { }
                    }

                    // Make sure all line endings on Windows are CRLF.
                    // This is important for opening .nfproj flies in Visual Studio,
                    // and maybe for some other files too.
                    line = line.Replace("\r", "").Replace("\n", Environment.NewLine);

                    output.WriteLine(line);
                }
            }

            sourceFile.Delete();
            new FileInfo(tempFilename).MoveTo(sourceFile.FullName);
        }
    }
}
