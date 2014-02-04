using UnitsNet.Attributes;

namespace UnitsNet.Templating
{
    public class UnitInfo
    {
        public readonly string SingularName;
        public readonly string PluralName;
        public readonly LinearFunction LinearFunction;

        public UnitInfo(string singularName, string pluralName, LinearFunction linearFunction)
        {
            SingularName = singularName;
            PluralName = pluralName ?? singularName + "s";
            LinearFunction = linearFunction;
        } 
    }
}