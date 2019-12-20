using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Models
{
    public class Boss
    {
        public int Id { get; set; }
        public Department DepartmentName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
