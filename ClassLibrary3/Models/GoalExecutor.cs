using TM.Core;

namespace Storage.Models
{
    public class GoalExecutor
    {
        public int ExecutorId { get; set; }
        public Executor Executor { get; set; }
        
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}