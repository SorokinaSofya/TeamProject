using System;
using System.Collections.Generic;
using Storage.Models;
using TM.Core.Models;

namespace TM.Core
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Timestamp { get; set; }
        public PriorityType Priority { get; set; }
        public bool IsDone { get; set; }
        public List<GoalExecutor> GoalExecutors { get; set; }
    }
}