using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using System.Security.AccessControl;

string connString = @"Server=.\SQLEXPRESS;Database=_p13_intro_db;Trusted_Connection=True;Encrypt=False;";
string connStringWithoutPool = @"Server=.\SQLEXPRESS;Database=_p13_intro_db;Trusted_Connection=True;Encrypt=False;Pooling=False;";
string connStringLocalDb = @"Server=(localdb)\MSSQLLocalDB;Database=_portal_db;Trusted_Connection=True;Encrypt=False;";


//string procQuery = @"
//    CREATE PROCEDURE uspGetUsersOf2000
//	AS
//	BEGIN
//		SELECT id, email
//		FROM users
//		WHERE YEAR(birthday) = 2000;
//	END
//";

//using SqlConnection conn = new SqlConnection(connStringLocalDb);

//try
//{
//	conn.Open();

//	// CreateProcedure();

//	SqlDataReader reader = GetProcReader("uspGetUsersOf2000");

//	RenderResult(reader);


//}
//catch (Exception ex)
//{
//	Console.WriteLine($"ERROR: {ex.Message}");
//}
//finally
//{
//	if (conn.State == ConnectionState.Open)
//	{
//		conn.Close();
//		Console.WriteLine("Connection closed");
//	}
//}




string procQuery = @"
    CREATE PROCEDURE uspGetUsersCountByEmail
	@pattern nvarchar(50),
	@count int OUT
	AS
	BEGIN
		SET @count = (
			SELECT COUNT(email)
			FROM users
			WHERE email LIKE @pattern
		);
	END
";

using SqlConnection conn = new SqlConnection(connStringLocalDb);

try
{
    conn.Open();

	// CreateProcedure();


	int result = countByEmails(conn, "a%");

	Console.WriteLine($"result = {result}");

}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}
finally
{
    if (conn.State == ConnectionState.Open)
    {
        conn.Close();
        Console.WriteLine("Connection closed");
    }
}


int countByEmails(SqlConnection conn, string pattern = "")
{
	string query = "uspGetUsersCountByEmail";

	SqlCommand cmd = new SqlCommand(query, conn)
	{
		CommandType = CommandType.StoredProcedure,
	};

	cmd.Parameters.Add(new SqlParameter()
	{
		ParameterName = "@pattern",
		SqlDbType = SqlDbType.NVarChar,
		Size = 50,
		Value = pattern,

    });

	SqlParameter countPrm = new SqlParameter()
	{
        ParameterName = "@count",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Output,
    };

	cmd.Parameters.Add(countPrm);

	cmd.ExecuteNonQuery();

	return (int)countPrm.Value;

}





// ----------

void CreateProcedure()
{
	SqlCommand cmd = new SqlCommand(procQuery, conn);
	cmd.ExecuteNonQuery();
}

SqlDataReader GetProcReader(string procName)
{
	SqlCommand cmd = new SqlCommand()
	{
		Connection = conn,
		CommandType = CommandType.StoredProcedure,		// !!!
		CommandText = procName,							// !!!
	};

	return cmd.ExecuteReader();
}

void RenderResult(SqlDataReader reader)
{
	int columnCount = reader.FieldCount;

	DataTable table = new DataTable();
	table.Load(reader);

	foreach(DataColumn col in table.Columns)
		Console.Write($"{col.ColumnName}\t");
	Console.WriteLine();

	foreach (DataRow row in table.Rows)
	{
        for (int i = 0; i < columnCount; ++i)
        {
			Console.Write($"{row[i]}\t");

		}
		Console.WriteLine();
    }
		
}



//SELECT ROUTINE_NAME
//FROM _portal_db.INFORMATION_SCHEMA.ROUTINES
//WHERE ROUTINE_TYPE = 'PROCEDURE'
//	AND LEFT(ROUTINE_NAME, 3) NOT IN('sp_', 'xp_', 'ms_');



//SELECT
// SCHEMA_NAME(SCHEMA_ID) AS[Schema]
//  ,SO.name AS[ObjectName]
//  , SO.Type_Desc AS [ObjectType(UDF / SP)]
//  ,P.parameter_id AS[ParameterID]
//  , P.name AS [ParameterName]
//  ,TYPE_NAME(P.user_type_id) AS[ParameterDataType]
//  ,P.max_length AS[ParameterMaxBytes]
//  , P.is_output AS [IsOutPutParameter]
//FROM sys.objects AS SO
//INNER JOIN sys.parameters AS P ON SO.OBJECT_ID = P.OBJECT_ID
//ORDER BY [Schema], SO.name, P.parameter_id

