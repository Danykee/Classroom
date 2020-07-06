using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(ClassroomContext dbContext) : base(dbContext)
        {

        }
        public Grade GetGradeByGradeId(Guid gradeId)
        {
            var grade = dbContext.Grades
                         .Where(c => c.GradeID == gradeId)
                         .SingleOrDefault();
            return grade;
        }
    }
}