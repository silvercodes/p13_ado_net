using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor.Exceptions
{
    internal class ConnectionStringException: DbProcessorException
    {
        public const string CONN_STR_EMPTY_MSG = "Connection string is empty";
        public const string CONN_STR_NOT_VALID = "Connection string is not valid";
        public ConnectionStringException(string message) :
            base(message)
        { }
    }
}
