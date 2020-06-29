using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Models
{
    public class Course
    {
        public Guid CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseContent { get; set; }
        public Class Class { get; set; }
    }
}