using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Services
{
    public class CourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }


        public Course GetCourseByCourseId(string courseId)
        {
            Guid.TryParse(courseId, out Guid guidCourseId);

            if (guidCourseId == Guid.Empty)
            {
                throw new Exception("");
            }

            var course = courseRepository.GetCourseByCourseId(guidCourseId);

            if (course == null)
            {
                throw new Exception("");
            }

            return course;

        }

    }
}