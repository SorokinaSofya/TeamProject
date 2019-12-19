using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TM.Core.Repositories
{
    public class DBRepository : IGoalRepository
    {
        private DBContext db;

        public DBRepository(DBContext dBContext)
        {
            db = dBContext;
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
            var dbGoal = db.Goals.Include(e =>e.GoalExecutors).ThenInclude((e => e.Executor)).First(g => g.Id == id);
            return dbGoal;
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
            var dbGoals = db.Goals.Include(e => e.GoalExecutors).ThenInclude(e => e.Executor).ToList();
            return dbGoals;
        }
    }
}