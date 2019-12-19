using System.Collections.Generic;

namespace Storage.Models
{
    public class Executor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<GoalExecutor> GoalExecutors { get; set; }
    }
}