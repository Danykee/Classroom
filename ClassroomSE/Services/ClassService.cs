using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Services
{
    public class ClassService
    {
        private readonly IClassRepository classRepository;

        public ClassService(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }


        public Class GetClassByClassId(string classId)
        {
            Guid.TryParse(classId, out Guid guidClassId);

            if (guidClassId == Guid.Empty)
            {
                throw new Exception("");
            }

            var @class = classRepository.GetClassByClassId(guidClassId);

            if (@class == null)
            {
                throw new Exception("");
            }

            return @class;

        }

    }
}