using System.Collections.Generic;

namespace TM.Core.Services
{
    public interface IGoalManager
    {
        Goal Add(Goal goal);
        Goal Delete(Goal goal);
        Goal Edit(Goal goal);
        List<Goal> GetAll();
        Goal Get(int id);
        Goal GetDone(Goal goal);
    }
}
