using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Models
{
    public class Class
    {
        public Guid ClassID { get; set; }
        public string ClassName { get; set; }

        public ICollection<AccountClass> AccountClasses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}