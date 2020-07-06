using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Repositories
{
    public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(ClassroomContext dbContext) : base(dbContext)
        {

        }
        public Assignment GetAssignmentByAssignmentId(Guid assignmentId)
        {
            var assignment = dbContext.Assignments
                         .Where(c => c.AssignmentID == assignmentId)
                         .SingleOrDefault();
            return assignment;
        }
    }
}