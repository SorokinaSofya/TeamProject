using System.Collections.Generic;

namespace Storage.Models
{
    public class Executor
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Department DepartmentName { get; set; }
        public int GoalsId { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
    }
}