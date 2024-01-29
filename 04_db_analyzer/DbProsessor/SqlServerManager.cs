using DbProsessor.Halpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor
{
    public class SqlServerManager : Manager
    {
        public SqlServerManager(string connectionString):
           base(connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Helper = new SqlServerHelper();
        }

        public override void GenerateConnectionString() // in serverConfig
        {
            throw new NotImplementedException();
        }

        public async override Task<List<string>> GetDbListAsync()
        {
            return await Helper.GetDbList(Connection);
        }
    }
}
