// encoding
// server
// auth
// ......

using Microsoft.Data.SqlClient;
using System.Data;

string connString = @"Server=.\SQLEXPRESS;Database=_p13_intro_db;Trusted_Connection=True;Encrypt=False;";
string connStringWithoutPool = @"Server=.\SQLEXPRESS;Database=_p13_intro_db;Trusted_Connection=True;Encrypt=False;Pooling=False;";
string connStringLocalDb = @"Server=(localdb)\MSSQLLocalDB;Database=_portal_db;Trusted_Connection=True;Encrypt=False;";


#region Connection

//using SqlConnection conn = new SqlConnection(connString);


//try
//{
//	conn.Open();
//    Console.WriteLine("Connection OK");
//	Console.WriteLine(conn.ConnectionString);
//	Console.WriteLine(conn.State);
//	Console.WriteLine(conn.ServerVersion);

//	string query = @"CREATE TABLE pictures(
//			id int NOT NULL PRIMARY KEY IDENTITY(1,1),
//			title varchar(64) NOT NULL
//		)";

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




//using (SqlConnection conn = new SqlConnection(connString))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//}

//using (SqlConnection conn = new SqlConnection(connString))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//}
//using (SqlConnection conn = new SqlConnection(connStringWithoutPool))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//}
//using (SqlConnection conn = new SqlConnection(connStringWithoutPool))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//}
//using (SqlConnection conn = new SqlConnection(connStringLocalDb))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//}
//using (SqlConnection conn = new SqlConnection(connStringLocalDb))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//}



#endregion


#region Command

// ==== ExecuteNonQuery()

//bool other = true;

//using (SqlConnection conn = new SqlConnection(connString))
//{
//    try
//    {
//        conn.Open();
//        Console.WriteLine("Connection opened...");

//        string query = @"INSERT INTO pictures(title) VALUES('ADO.NET')";

//        SqlCommand cmd = new SqlCommand()
//        {
//            Connection = conn,
//            CommandType = CommandType.Text,
//            CommandText = query,
//        };

//        cmd.ExecuteNonQuery();

//        if (other)
//            conn.ChangeDatabase("join_db");

//        cmd.CommandText = @"
//            CREATE TABLE logs(
//			    id int NOT NULL PRIMARY KEY IDENTITY(1,1),
//                date datetime NOT NULL,
//			    message varchar(1024) NOT NULL
//		    )

//        ";

//        cmd.ExecuteNonQuery();

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (conn.State == ConnectionState.Open)
//        {
//            conn.Close();
//            Console.WriteLine("Connection closed");
//        }
//    }
//}



// ==== ExecuteReader


//using (SqlConnection conn = new SqlConnection(connStringLocalDb))
//{
//    try
//    {
//        conn.Open();
//        Console.WriteLine("Connection opened...");

//        string query = @"SELECT * FROM users;";

//        SqlCommand cmd = new SqlCommand(query, conn);

//        using (SqlDataReader reader = cmd.ExecuteReader())
//        {
//            Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}");

//            //while(reader.Read())
//            //{
//            //    // int id = (int)reader[0];
//            //    // int id = (int)reader["id"];
//            //    // int id = reader.GetInt32("id");
//            //    // int id = (int)reader.GetValue(0);
//            //    int id = reader.GetFieldValue<int>("id");

//            //    string email = reader.GetFieldValue<string>("email");

//            //    string nickname = reader.GetFieldValue<string>("nickname");

//            //    Console.WriteLine($"{id}\t{email}\t{nickname}");
//            //}

//            DataTable table = new DataTable();
//            table.Load(reader);

//            foreach (DataRow row in table.Rows)
//                Console.WriteLine($"{row["id"]}\t{row["email"]}\t{row["nickname"]}");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (conn.State == ConnectionState.Open)
//        {
//            conn.Close();
//            Console.WriteLine("Connection closed");
//        }
//    }
//}




// ==== ExecuteScalar
//using (SqlConnection conn = new SqlConnection(connStringLocalDb))
//{
//    try
//    {
//        conn.Open();
//        Console.WriteLine("Connection opened...");

//        string query = @"SELECT MAX(id) FROM users;";

//        SqlCommand cmd = new SqlCommand(query, conn);

//        int maxId = (int)cmd.ExecuteScalar();

//        Console.WriteLine($"Max id = {maxId}");

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (conn.State == ConnectionState.Open)
//        {
//            conn.Close();
//            Console.WriteLine("Connection closed");
//        }
//    }
//}



#endregion