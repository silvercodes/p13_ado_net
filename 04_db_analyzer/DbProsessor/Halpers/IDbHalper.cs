using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor.Halpers
{
    public interface IDbHelper
    {
        public Task<List<string>> GetDbList(DbConnection connection);
    }
}
