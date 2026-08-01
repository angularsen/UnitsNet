// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.IO;
using System.Text;

namespace CodeGen.Helpers
{
    internal static class CodeGenFile
    {
        internal static readonly Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        public static string ReadAllText(string path)
        {
            return File.ReadAllText(path, Utf8NoBom);
        }

        public static void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents, Utf8NoBom);
        }

        public static StreamReader OpenText(string path)
        {
            return new StreamReader(path, Utf8NoBom, detectEncodingFromByteOrderMarks: true);
        }

        public static StreamWriter CreateText(string path)
        {
            return new StreamWriter(path, append: false, Utf8NoBom);
        }
    }
}
