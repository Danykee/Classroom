using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Models
{
    public class AccountClass
    {
        public Guid AccountID { get; set; }
        public Guid ClassID { get; set; }
        public Account Account { get; set; }
        public Class Class { get; set; }
    }
}
