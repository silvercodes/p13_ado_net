using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProsessor.Halpers
{
    public class SqlServerHelper : IDbHelper
    {
        private const string DB_LIST_QUERY = "SELECT name FROM master.sys.databases;";

        public async Task<List<string>> GetDbList(DbConnection connection)
        {
            List<string> dbList = new List<string>();

            try
            {
                await connection.OpenAsync();

                SqlCommand cmd = new SqlCommand(DB_LIST_QUERY, connection as SqlConnection);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                DataTable dt = new DataTable();
                dt.Load(reader);                    // async

                foreach (DataRow dr in dt.Rows)
                    dbList.Add($"{dr[0]}");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dbList;
        }
    }
}
