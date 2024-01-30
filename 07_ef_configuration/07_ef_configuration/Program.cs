
using _07_ef_configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

//string connString = @"Server=(localdb)\MSSQLLocalDB;Database=p13_ef_conf;Trusted_Connection=True;Encrypt=False;";

//using Db db = new Db(connString);






//string connString = @"Server=(localdb)\MSSQLLocalDB;Database=p13_ef_conf;Trusted_Connection=True;Encrypt=False;";

//DbContextOptionsBuilder<Db> builder = new DbContextOptionsBuilder<Db>();
//builder.UseSqlServer(connString);
//DbContextOptions<Db> options = builder.Options;

//using Db db = new Db(options);
//await db.Users.AddRangeAsync(
//    new User() { Email = "vasia@mail.com", Password = "123123123"},
//    new User() { Email = "petya@mail.com", Password = "123123123"},
//    new User() { Email = "dima@mail.com", Password = "123123123"}
//);

//await db.SaveChangesAsync();








ConfigurationBuilder cBuilder = new ConfigurationBuilder();
cBuilder.SetBasePath(Directory.GetCurrentDirectory());

cBuilder.AddJsonFile("mainConfig.json");
IConfigurationRoot config = cBuilder.Build();

string? connString = config.GetConnectionString("local");

Console.WriteLine(connString);



