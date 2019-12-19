using System.Collections.Generic;
using Storage.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TM.Core.Repositories
{
    public class ExecutorDBRepository : IExecutorRepository
    {
        private DBContext exedb;
        public ExecutorDBRepository(DBContext db)
        {
            exedb = db;
        }
        public Executor Add(Executor executor)
        {
            exedb.Executors.Add(executor);
            exedb.SaveChanges();
            return executor;
        }

        public Executor Delete(int id)
        {
            var executor = exedb.Executors.First(e => e.Id == id);
            exedb.Executors.Remove(executor);
            exedb.SaveChanges();
            return executor;
        }

        public Executor Edit(Executor executor)
        {
            var dbExecutor = exedb.Executors.First(e => e.Id == executor.Id);
            dbExecutor = executor;
            exedb.SaveChanges();
            return dbExecutor;
        }

        public Executor Get(int id)
        {
            var dbExecutor = exedb.Executors.Include(g => g.GoalExecutors).ThenInclude(g => g.Goal).First(e => e.Id == id);
            return dbExecutor;
        }

        public List<Executor> GetAll()
        {
            var dbExecutor = exedb.Executors.Include(g => g.GoalExecutors).ThenInclude(e => e.Goal).ToList();
            return dbExecutor;
        }
    }
}