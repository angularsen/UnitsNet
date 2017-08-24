using System;
using System.Collections.Generic;


namespace UnitsNet.OperatorOverloads
{
    public class Localization
    {
        public string Culture { get; set; }
        public List<string> Abbreviations { get; set; }
    }

    public class Unit
    {
        public string SingularName { get; set; }
        public string PluralName { get; set; }
        public string FromUnitToBaseFunc { get; set; }
        public string FromBaseToUnitFunc { get; set; }
        public List<Localization> Localization { get; set; }
    }

    public class Quantity
    {
        public string Name { get; set; }
        public string BaseUnit { get; set; }
        public string XmlDoc { get; set; }
        public List<Unit> Units { get; set; }

        /// <summary>
        /// m kg s A K mol cd
        /// </summary>
        public int[] SiArray { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
