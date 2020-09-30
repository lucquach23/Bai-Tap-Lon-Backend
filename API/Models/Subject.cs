using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ClassRegisters = new HashSet<ClassRegister>();
        }

        public string IdSubject { get; set; }
        public string NameSubject { get; set; }
        public int? NumberOfCredits { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ClassRegister> ClassRegisters { get; set; }
    }
}
