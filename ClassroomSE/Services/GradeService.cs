using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Services
{
    public class GradeService
    {
        private readonly IGradeRepository gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }


        public Grade GetGradeByGradeId(string gradeId)
        {
            Guid.TryParse(gradeId, out Guid guidGradeId);

            if (guidGradeId == Guid.Empty)
            {
                throw new Exception("");
            }

            var grade = gradeRepository.GetGradeByGradeId(guidGradeId);

            if (grade == null)
            {
                throw new Exception("");
            }

            return grade;

        }

    }
}