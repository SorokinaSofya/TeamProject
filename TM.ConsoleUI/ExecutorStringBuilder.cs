using System.Text;
using Storage.Models;

namespace TM.ConsoleUI
{
    static public class ExecutorStringBuilder

    {
        public static StringBuilder Show(Executor executor)
        {
            StringBuilder executors = new StringBuilder();
            executors.Append($"ID: {executor.Id}" + "\n");
            executors.Append($"Name: {executor.Name}" + "\n");
            executors.Append($"Text: {executor.Surname}" + "\n");
            foreach (var g in executor.GoalExecutors)
            {
                executors.Append($"Goal: {g.Goal.Name}" + "\n");
            }
            return executors;
        }
    }
}