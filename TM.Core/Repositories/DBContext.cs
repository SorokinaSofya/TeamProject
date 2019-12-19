using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace TM.Core.Repositories
{
    public class DBContext : DbContext
    {
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoalExecutor>()
                .HasKey(t => new {ExecutorID = t.ExecutorId, GoalID = t.GoalId});
            
            modelBuilder.Entity<GoalExecutor>()
                .HasOne(ge => ge.Executor)
                .WithMany(e => e.GoalExecutors)
                .HasForeignKey(ge => ge.ExecutorId);
            
            modelBuilder.Entity<GoalExecutor>()
                .HasOne(ge => ge.Goal)
                .WithMany(g => g.GoalExecutors)
                .HasForeignKey(ge => ge.GoalId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Goals;Trusted_Connection=True;");
        }
    }
}
