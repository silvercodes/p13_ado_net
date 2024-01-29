using DbProsessor.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor.Analyzers
{
    internal class SqlServerAnalyzer : IDbAnalyzer
    {
        public string? ConnectionString { get; set; }
        public DbConnection Connection { get; set; }

        public SqlServerAnalyzer(string connectionString)
        {
            ConnectionString = connectionString;

            if (string.IsNullOrEmpty(ConnectionString))
                throw new ConnectionStringException(ConnectionStringException.CONN_STR_EMPTY_MSG);

            Connection = new SqlConnection(ConnectionString);
        }

        public Report Analize(string dbName)
        {
            Connection.ChangeDatabase(dbName);





            return new Report();
        }
    }
}
