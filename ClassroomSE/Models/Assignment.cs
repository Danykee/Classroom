using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Models
{
    public class Assignment
    {
        public Guid AssignmentID { get; set; }
        public string AssignmentTitle { get; set; }
        public string AssignmentContent { get; set; }
        public DateTime DueDate { get; set; }
        public Grade Grade { get; set; }
        public Class Class { get; set; }

    }
}
