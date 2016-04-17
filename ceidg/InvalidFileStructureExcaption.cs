using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ceidg
{
    class InvalidFileStructureExcaption : Exception
    {
        private string p;

        public InvalidFileStructureExcaption(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
    }
}
