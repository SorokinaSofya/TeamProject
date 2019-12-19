using System;
using System.Collections.Generic;
using System.Linq;
using TM.Data;

namespace TM.Core.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private List<Goal> _goals = new List<Goal>();
        public IEnumerable<Goal> Goals => _goals;
        private readonly TextStorage _storage;

        public GoalRepository(TextStorage storage)
        {
            _storage = storage;
        }

        public Goal Get(int id)
        {
            var goals = GetAll();
            var goal = goals.First(e => e.Id == id);
            return goal;
        }

        public Goal GetDone(int id)
        {
            var goal = Get(id);
            goal.IsDone = true;
            return goal;
        }

        public Goal Add(Goal goal)
        {
            goal.Id = GetLastID() + 1;
            goal.Timestamp = DateTime.Now;
            goal.IsDone = false;
            _goals = GetAll();
            _goals.Add(goal);
            _storage.Rewrite(_goals);
            return goal;
        }

        public Goal Delete(Goal goal)
        {
            _goals.Remove(goal);
            _storage.Rewrite(_goals);
            return goal;
        }

        public Goal Edit(Goal goal)
        {
            var oldgoal = _goals.First(e => e.Id == goal.Id);
            oldgoal = goal;
            _storage.Rewrite(_goals);
            return goal;
        }

        public List<Goal> GetAll()
        {
            _goals = _storage.GetAll();
            return _goals;
        }

        public int GetLastID()
        {
            var lastID = _storage.GetLastID();
            return lastID;
        }
    }
}