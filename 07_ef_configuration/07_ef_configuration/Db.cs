using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ef_configuration
{
    internal class Db: DbContext
    {
        public string? ConnString { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        #region simple
        //public Db(string? connString)
        //{
        //    ConnString = connString;

        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    if (ConnString is null)
        //        throw new ArgumentNullException("Invalid connection string");

        //    builder.UseSqlServer(ConnString);
        //}
        #endregion

        #region Options to DbContext
        public Db(DbContextOptions<Db> options):
            base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        #endregion

    }
}
