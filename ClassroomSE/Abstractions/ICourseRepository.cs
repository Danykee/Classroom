using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Abstractions
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetCourseByCourseId(Guid CourseId);
        Course Add(Course itemToAdd);
        bool Delete(Course itemToDelete);
        Course Update(Course itemToUpdate);
    }
}