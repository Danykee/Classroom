using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ClassroomContext dbContext) : base(dbContext)
        {

        }
        public Course GetCourseByCourseId(Guid courseId)
        {
            var course = dbContext.Courses
                         .Where(c => c.CourseID == courseId)
                         .SingleOrDefault();
            return course;
        }
    }
}