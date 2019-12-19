using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Core.Repositories
{
    public class DBContext : DbContext
    {
        public DbSet<Goal> Goals { get; set; }

        public DBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Goals;Trusted_Connection=True;");
        }
    }
}
