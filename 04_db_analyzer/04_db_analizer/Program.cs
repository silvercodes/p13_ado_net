


using DbProsessor;
using DbProsessor.Halpers;

// string connString = @"Server=(localdb)\MSSQLLocalDB;Trusted_Connection=True;Encrypt=False;";
string connString = @"Server=.\SQLEXPRESS;Trusted_Connection=True;Encrypt=False;";

Manager manager = new SqlServerManager(connString);

List<string> dbList = await manager.GetDbListAsync();

foreach(string db in dbList)
    Console.WriteLine(db);
