using System;
using System.Globalization;

namespace UnitsNet.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class I18nAttribute : Attribute
    {
        private readonly CultureInfo _culture;
        private readonly string[] _abbreviations;

        public I18nAttribute(string culture, params string[] abbreviations)
        {
            _culture = CultureInfo.GetCultureInfo(culture);
            _abbreviations = abbreviations;
        }

        public CultureInfo Culture
        {
            get { return _culture; }
        }

        public string[] Abbreviations
        {
            get { return _abbreviations; }
        }

        public string DefaultAbbreviation
        {
            get { return Abbreviations[0]; }
        }
    }
}