using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Repositories
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(ClassroomContext dbContext) : base(dbContext)
        {

        }
        public Class GetClassByClassId(Guid classId)
        {
            var @class = dbContext.Classes
                         .Where(c => c.ClassID == classId)
                         .SingleOrDefault();
            return @class;
        }
    }
}