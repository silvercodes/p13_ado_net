using Microsoft.Data.SqlClient;
using System.Data;

string connString = @"Server=.\SQLEXPRESS;Database=itstep_db;Trusted_Connection=True;Encrypt=False;";
string connStringWithoutPool = @"Server=.\SQLEXPRESS;Database=_p13_intro_db;Trusted_Connection=True;Encrypt=False;Pooling=False;";
string connStringLocalDb = @"Server=(localdb)\MSSQLLocalDB;Database=itstep_db;Trusted_Connection=True;Encrypt=False;";




//using SqlConnection conn = new SqlConnection(connStringLocalDb);

//// string title = "EF CORE";

//string title = "'my_title');INSERT INTO subjects (title) VALUES ('admin looser!'";


//try
//{
//	conn.Open();

//	string query = $@"INSERT INTO subjects (title) VALUES ({title})";

//	SqlCommand cmd = new SqlCommand(query, conn);

//	cmd.ExecuteNonQuery();

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




//using SqlConnection conn = new SqlConnection(connStringLocalDb);

//// string title = "EF CORE";

//string title = "'my_title');INSERT INTO subjects (title) VALUES ('admin looser!'";


//try
//{
//    conn.Open();

//    string query = @"INSERT INTO subjects (title) VALUES (@title)";

//    SqlCommand cmd = new SqlCommand(query, conn);

//    SqlParameter prm = new SqlParameter("@title", title)
//    {
//        SqlDbType = SqlDbType.NVarChar,
//        Size = 256
//    };

//    cmd.Parameters.Add(prm);

//    int affected = cmd.ExecuteNonQuery();
//    Console.WriteLine($"Affected: {affected}");

//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}
//finally
//{
//    if (conn.State == ConnectionState.Open)
//    {
//        conn.Close();
//        Console.WriteLine("Connection closed");
//    }
//}





using SqlConnection conn = new SqlConnection(connStringLocalDb);

string number = "201";
string title = "Robotics";
int branch_id = 1;


try
{
    conn.Open();

    string query = @"
        INSERT INTO classrooms (number, title, branch_id) 
            VALUES (@number, @title, @branch_id);
        SET @last_id = SCOPE_IDENTITY();
    ";

    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.Add(new SqlParameter("@number", SqlDbType.NVarChar) 
    { 
        Size = 32,
        Value = number,
    });

    cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar)
    {
        Size = 32,
        Value = title,
    });

    cmd.Parameters.Add(new SqlParameter("@branch_id", SqlDbType.Int)
    {
        Value = branch_id,
    });

    SqlParameter id = new SqlParameter()
    {
        ParameterName = "@last_id",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Output
    };
    cmd.Parameters.Add(id);

    cmd.ExecuteNonQuery();

    Console.WriteLine($"last_id = {id.Value}");

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


