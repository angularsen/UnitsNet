using System;

namespace UnitsNet.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class I18nAttribute : Attribute
    {
        private readonly Cultures _culture;
        private readonly string[] _abbreviations;

        public I18nAttribute(Cultures culture, params string[] abbreviations)
        {
            _culture = culture;
            _abbreviations = abbreviations;
        }

        public Cultures Culture
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