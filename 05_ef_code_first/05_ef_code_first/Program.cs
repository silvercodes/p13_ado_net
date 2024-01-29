
using _05_ef_code_first;

using Db db = new Db();

// await db.Database.EnsureDeletedAsync();
await db.Database.EnsureCreatedAsync();

Product p1 = new Product() { Title = "product_1", Description = "descr_1", Price = 100 };
Product p2 = new Product() { Title = "product_2", Description = "descr_2", Price = 200 };

User u1 = new User() { Email = "vasia@mail.com", Password = "123", Age = 23 };

Console.WriteLine(p1);

await db.Products.AddAsync(p1);
await db.Products.AddAsync(p2);
await db.Users.AddAsync(u1);

await db.SaveChangesAsync();

Console.WriteLine(p1);







