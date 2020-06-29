using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Models
{
    public class Grade
    {
        public Guid GradeID { get; set; }
        public int StudentGrade { get; set; }
        public bool Participation { get; set; }
        public Account Account { get; set; }
        public Guid AssignmentID { get; set; }
        public Assignment Assignment { get; set; }

    }
}