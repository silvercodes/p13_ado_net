using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor.Analyzers
{
    public interface IDbAnalyzer
    {
        public string? ConnectionString { get; set; }
        public DbConnection Connection { get; set; }
        public Report Analize(string dbName);
    }
}
