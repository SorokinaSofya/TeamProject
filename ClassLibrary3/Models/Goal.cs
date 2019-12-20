using System;
using System.Collections.Generic;
using Storage.Models;
using TM.Core.Models;

namespace TM.Core
{
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Timestamp { get; set; }  // время создания задачи DateTime.Now
        public bool IsDone { get; set; }
        public int ExecutorsId{ get; set; }
    }
}