using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace TM.Core.Repositories
{
    public class DBRepository 
    {
        private DBContext db;

        public DBRepository()
        {
            db = new DBContext();
        }

        public Goal Add(Goal goal)
        {
            db.Goals.Add(goal);
            db.SaveChanges();
            return goal;
        }

        public Goal Delete(Goal goal)
        {
            db.Goals.Remove(goal);
            db.SaveChanges();
            return goal;
        }

        public Goal Edit(Goal goal)
        {
            var dbGoal = db.Goals.First(e => e.Id == goal.Id);
            dbGoal = goal;
            db.SaveChanges();
            return goal;
        }

        public Goal Get(int id)
        {
            return db.Goals.First(a => a.Id == id);
        }
        public Goal GetDone(int id)
        {
            var goal = Get(id);
            goal.IsDone = true;
            db.SaveChanges();
            return goal;
        }

        public List<Goal> GetAll()
        {
            return db.Goals.ToList();
        }

        public List<Boss> GetAllBosses()
        {
            return db.Bosses.ToList();
        }

        public List<Executor> GetAllExecutors()
        {
            return db.Executors.ToList();
        }
        public void AddNewBoss(Boss boss)
        {
            db.Bosses.Add(boss);
            db.SaveChanges();
        }
        public void AddNewWorker(Executor worker)
        {
            db.Executors.Add(worker);
            db.SaveChanges();
        }
        public void AddNewTask(Goal task)
        {
            db.Goals.Add(task);
            db.SaveChanges();
        }
        public Goal ReturnTask(int id)
        {
            return db.Goals.First(a => a.Id == id);
        }

        public Executor ReturnWorker(string email)
        {
            return db.Executors.First(a => a.Email == email);
        }
        public void Update(Goal goal)
        {
            db.Update(goal);
            db.SaveChanges();
        }
    }
}