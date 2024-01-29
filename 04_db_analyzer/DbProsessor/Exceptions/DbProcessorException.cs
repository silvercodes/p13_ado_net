using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor.Exceptions
{
    public class DbProcessorException: Exception
    {
        public DbProcessorException(string? message):
            base(message)
        { }
    }
}
