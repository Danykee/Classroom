using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Abstractions
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetAll();
        Grade GetGradeByGradeId(Guid GradeId);
        Grade Add(Grade itemToAdd);
        bool Delete(Grade itemToDelete);
        Grade Update(Grade itemToUpdate);
    }
}