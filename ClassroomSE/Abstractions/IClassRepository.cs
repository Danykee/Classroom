using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Abstractions
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAll();
        Class GetClassByClassId(Guid ClassId);
        Class Add(Class itemToAdd);
        bool Delete(Class itemToDelete);
        Class Update(Class itemToUpdate);
    }
}