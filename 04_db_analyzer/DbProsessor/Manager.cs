using DbProsessor.Halpers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor
{
    public abstract class Manager
    {
        public IDbHelper Helper { get; protected set; }
        public DbConnection Connection { get; protected set; }
        public string ConnectionString { get; protected set; }
        public Manager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract void GenerateConnectionString();
        public abstract Task<List<string>> GetDbListAsync();

    }
}
