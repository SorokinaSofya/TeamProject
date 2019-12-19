using System.Collections.Generic;
using System.Linq;
using Storage.Models;

namespace TM.Core.Repositories
{
    public class GoalExecutorRepository
    {
        private DBContext _db;

        public GoalExecutorRepository(DBContext db)
        {
            _db = db;
        }

        public void AddGoalsExecutor(Goal goal, Executor executor)
        {
            var dbGoal = _db.Goals.First(g => g.Id == goal.Id);
            var dbExecutor = _db.Executors.First(e => e.Id == executor.Id);
            var newGoalExecutor = new GoalExecutor {GoalId = dbGoal.Id, ExecutorId = dbGoal.Id};
            if (dbExecutor.GoalExecutors != null)
            {
                if (dbExecutor.GoalExecutors.Any(e => e.GoalId == newGoalExecutor.GoalId))
                {
                    return;
                }

                dbExecutor.GoalExecutors.Add(newGoalExecutor);
                _db.SaveChanges();
            }
            else
            {
                dbExecutor.GoalExecutors = new List<GoalExecutor>();
                dbExecutor.GoalExecutors.Add(new GoalExecutor {GoalId = dbGoal.Id, ExecutorId = dbExecutor.Id});
                _db.SaveChanges();
            }
        }

        public void RemoveGoalsExecutor(Goal goal, Executor executor)
        {
            var dbGoal = _db.Goals.First(g => g.Id == goal.Id);
            var dbExecutor = _db.Executors.First(e => e.Id == executor.Id);
            if (dbExecutor.GoalExecutors.Any(e => e.GoalId == dbGoal.Id) & dbExecutor.GoalExecutors != null)
            {
                var goalsExecutor = executor.GoalExecutors.FirstOrDefault(ge => ge.GoalId == goal.Id);
                executor.GoalExecutors.Remove(goalsExecutor);
                _db.SaveChanges();
            }
        }
    }
}