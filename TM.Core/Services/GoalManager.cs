using System.Collections.Generic;

namespace TM.Core.Services
{
    public class GoalManager : IGoalManager
    {
        private readonly IGoalRepository _goalRepository;

        public GoalManager(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }
        public Goal Add(Goal goal)
        {
            var dbGoal = _goalRepository.Add(goal);
            return dbGoal;
        }

        public Goal Get(int id)
        {
            var goal = _goalRepository.Get(id);
            return goal;
        }

        public List<Goal> GetAll()
        {
            var goals = _goalRepository.GetAll();
            return goals;
        }

        public Goal GetDone(Goal goal)
        {
            _goalRepository.GetDone(goal.Id);
            return goal;
        }
        public Goal Edit(Goal goal)
        {
            _goalRepository.Edit(goal);
            return goal;
        }
        public Goal Delete(Goal goal)
        {
            _goalRepository.Delete(goal);
            return goal;
        }
    }
}