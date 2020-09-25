using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Semester
    {
        public Semester()
        {
            ClassRegisters = new HashSet<ClassRegister>();
        }

        public string IdSemester { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClassRegister> ClassRegisters { get; set; }
    }
}
