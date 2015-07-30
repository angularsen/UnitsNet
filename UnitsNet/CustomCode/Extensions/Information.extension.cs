using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Information
    {
        public static UnitsNet.Information Bits(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation);
        }

        public static UnitsNet.Information Bytes(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation * 8);
        }

        public static UnitsNet.Information KiloBytes(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation * 8 * 1024);
        }

        public static UnitsNet.Information MegaBytes(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation * 8 * 1024 * 1024);
        }
        
        public static UnitsNet.Information GigaBytes(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation * 8 * 1024 * 1024 * 1024);
        }

        public static UnitsNet.Information TeraBytes(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation * 8 * 1024 * 1024 * 1024 * 1024);
        }

        public static UnitsNet.Information PetaBytes(this int _inputInformation)
        {
            return new UnitsNet.Information(_inputInformation * 8 * 1024 * 1024 * 1024 * 1024 * 1024);
        }
    }
}
