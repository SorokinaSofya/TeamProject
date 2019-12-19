using System.Collections.Generic;

namespace TM.Core
{
    public interface IGoalRepository
    {
        Goal Add(Goal goal);
        Goal Edit(Goal goal);
        Goal Delete(Goal goal);
        List<Goal> GetAll();
        Goal Get(int id);
        Goal GetDone(int id);
    }
}
