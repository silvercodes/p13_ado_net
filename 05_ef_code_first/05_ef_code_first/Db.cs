﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ef_code_first
{
    internal class Db: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public Db()
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
            // Database.CanConnect();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=p13_ef_cf;Trusted_Connection=True;Encrypt=False;");   
        }
    }
}
