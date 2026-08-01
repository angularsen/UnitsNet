// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.IO;
using System.Text;

namespace CodeGen.Helpers
{
    /// <summary>
    ///     Provides file I/O helpers for CodeGen files with explicit UTF-8 encoding behavior.
    /// </summary>
    internal static class CodeGenFile
    {
        /// <summary>
        ///     UTF-8 encoding without byte order mark, used for generated and codegen-normalized files.
        /// </summary>
        internal static readonly Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        /// <summary>
        ///     Reads all text from a CodeGen input file as UTF-8.
        /// </summary>
        /// <remarks>
        ///     Existing byte order marks are still detected when present.
        /// </remarks>
        public static string ReadAllText(string path)
        {
            return File.ReadAllText(path, Utf8NoBom);
        }

        /// <summary>
        ///     Writes all text to a generated or codegen-normalized file as UTF-8 without byte order mark.
        /// </summary>
        public static void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents, Utf8NoBom);
        }

        /// <summary>
        ///     Opens a CodeGen input file for text reading as UTF-8.
        /// </summary>
        /// <remarks>
        ///     Existing byte order marks are still detected when present.
        /// </remarks>
        public static StreamReader OpenText(string path)
        {
            return new StreamReader(path, Utf8NoBom, detectEncodingFromByteOrderMarks: true);
        }

        /// <summary>
        ///     Creates or overwrites a generated or codegen-normalized text file as UTF-8 without byte order mark.
        /// </summary>
        public static StreamWriter CreateText(string path)
        {
            return new StreamWriter(path, append: false, Utf8NoBom);
        }
    }
}
