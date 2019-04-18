// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;
using System.Text;

namespace CodeGen.Helpers
{
    internal class MyTextWriter
    {
        private readonly StringBuilder _sb = new StringBuilder();
        private string _currentIndentationString;
        private int _indentLevel;

        public MyTextWriter(string indentString = "    ", int initialIndentLevel = 0)
        {
            IndentString = indentString;
            IndentLevel = initialIndentLevel;
        }

        public string IndentString { get; }

        public int IndentLevel
        {
            get => _indentLevel;
            set
            {
                _indentLevel = value;
                _currentIndentationString = GetIndent(_indentLevel);
            }
        }

        private string GetIndent(int indentLevel)
        {
            return string.Join(string.Empty, Enumerable.Repeat(IndentString, indentLevel));
        }

        /// <summary>
        ///     Write line with current indent. Trims preceding newline if any, to simplify code formatting when calling this method.
        /// </summary>
        /// <param name="indentLevel">The indent level to prepend the text with.</param>
        /// <param name="text">The text to write</param>
        public void WL(int indentLevel, string text = "")
        {
            _sb.Append(GetIndent(indentLevel));
            _sb.AppendLine(text.TrimStart('\r', '\n'));
        }

        /// <summary>
        ///     Write line with current indent. Trims preceding newline if any, to simplify code formatting when calling this method.
        /// </summary>
        /// <param name="text">The text to write</param>
        public void WL(string text = "")
        {
            _sb.Append(_currentIndentationString);
            _sb.AppendLine(text.TrimStart('\r', '\n'));
        }

        /// <summary>
        ///     Write with current indent, but no newline. Trims preceding newline if any, to simplify code formatting when calling this method.
        /// </summary>
        /// <param name="text">The text to write</param>
        public void W(string text = "")
        {
            _sb.Append(_currentIndentationString);
            _sb.Append(text.TrimStart('\r', '\n'));
        }

        /// <summary>
        ///     Append text without indentation and without newline.
        /// </summary>
        /// <param name="text">The text to write</param>
        public void Append(string text = "")
        {
            _sb.Append(text);
        }

        /// <summary>
        ///     Returns the text written so far.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _sb.ToString();
        }

        /// <summary>
        /// Write line with current ident only if <paramref name="text"/> actually contains text and not just whitespace.
        /// </summary>
        /// <param name="indentLevel">The level of indentation to prepend to the text.</param>
        /// <param name="text">The text to write.</param>
        public void WLIfText(int indentLevel, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            WL(indentLevel, text);
        }

        /// <summary>
        /// Write line with current ident only if <paramref name="condition"/> is <c>true</c>.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="text">The text to write.</param>
        public void WLCondition(bool condition, string text)
        {
            if (condition)
                WL(text);
        }
    }
}
