using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_crud
{
    internal class Db: DbContext
    {
        public DbSet<User> Users { get; set; }

        public Db()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=p13_ef_crud;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
