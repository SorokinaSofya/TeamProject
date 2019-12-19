using System;
using TM.Core.Models;

namespace TM.Core
{
    public class Goal
    {
        public int ID;
        public string Name;
        public string Text;
        public DateTime Deadline;
        public DateTime Timestamp;
        public PriorityType Priority;
        public bool IsDone;
    }
}
