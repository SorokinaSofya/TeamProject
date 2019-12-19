using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace TM.Core.Repositories
{
    public class DBContext : DbContext
    {
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Executor> Executors { get; set; }
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
