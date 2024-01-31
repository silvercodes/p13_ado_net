
using _08_crud;
using Microsoft.EntityFrameworkCore;



// ==== CREATE
//using Db db = new Db();
//db.Users.AddRange(
//    new User() { Email = "email_1@mail.com", Password = "123123123", Age = 34},
//    new User() { Email = "email_2@mail.com", Password = "123123123", Age = 23},
//    new User() { Email = "email_3@mail.com", Password = "123123123", Age = 31}
//);

//db.SaveChanges();


// ==== READ
//using Db db = new Db();
//List<User> users = db.Users.Where(u => u.Id > 1).ToList();
//users.ForEach(u => Console.WriteLine(u));

//Console.ReadLine();

//var usersQ = db.Users.Where(u => u.Id > 1);
//foreach(User u in usersQ)
//    Console.WriteLine(u);

//Console.ReadLine();



// ==== UPDATE

//using Db db = new Db();
//User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == 2);

//if (user is not null)
//{
//    user.Email = "vasia@mail.com";
//    user.Age = 50;

//    db.SaveChanges();
//}




//User? user = null;

//using (Db db = new Db())
//{
//    user = await db.Users.FirstOrDefaultAsync(u => u.Id == 2);
//}

//user.Id = 3;
//user.Email = "petya555@mail.com";
//user.Age = 20;

//using (Db db = new Db())
//{
//    db.Update(user);            // add user to current context
//    db.SaveChanges();
//}




// ==== DELETE

//using Db db = new Db();
//User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == 2);

//if (user is not null)
//    db.Users.Remove(user);

//db.SaveChanges();




