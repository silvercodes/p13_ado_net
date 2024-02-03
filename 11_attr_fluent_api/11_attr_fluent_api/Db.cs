using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_attr_fluent_api
{
    internal class Db: DbContext
    {
        public DbSet<User> Users { get; set; }

        public Db()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=p13_ef_attr_fluent;Trusted_Connection=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // mb.Entity<Role>();

            // mb.Ignore<Role>();

            // mb.Entity<User>().Ignore(u => u.Token);

            // mb.Entity<User>().ToTable("employees");

            //mb.Entity<User>()
            //    .Property(u => u.Email)
            //    .HasColumnName("user_email");

            //mb.Entity<User>()
            //    .Property(u => u.Age)
            //    .IsRequired();

            //mb.Entity<User>()
            //    .HasKey(u => u.Email);

            //mb.Entity<User>()
            //    .HasKey(u => new { u.Id, u.Email });

            mb.Entity<User>()
                .HasAlternateKey(u => u.Email);
        }

    }
}
