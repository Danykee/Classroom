using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Models
{
    public class Account
    {
        public enum AccountType
        {
            student,
            teacher
        }
        public AccountType Type { get; set; }
        public Guid AccountID { get; set; }
        public string Name { get; set; }
        public ICollection<AccountClass> AccountClasses { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
