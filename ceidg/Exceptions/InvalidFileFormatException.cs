using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ceidg.Exceptions
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException()
        {
        }
        public InvalidFileFormatException(string message)
            : base(message)
        {
        }
    }
}
