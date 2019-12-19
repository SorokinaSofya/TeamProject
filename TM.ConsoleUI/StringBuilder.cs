using System.Text;
using TM.Core;

namespace TM.ConsoleUI
{
    static class Builder
    {
        public static StringBuilder Show(Goal goal)
        {
            StringBuilder goals = new StringBuilder();
            goals.Append($"ID: {goal.Id}" + "\n");
            goals.Append($"Name: {goal.Title}" + "\n");
            goals.Append($"Text: {goal.Description}" + "\n");
            goals.Append($"Timestamp: {goal.Timestamp}" + "\n");
            goals.Append($"Deadline: {goal.Deadline}" + "\n");
            goals.Append($"Priority: {goal.Priority}" + "\n");
            goals.Append($"IsDone: {goal.IsDone}" + "\n");
            foreach (var e in goal.GoalExecutors)
            {
                goals.Append($"Executor: {e.Executor.Name} {e.Executor.Surname}" + "\n");
            }
            return goals;
        }
    }
}
