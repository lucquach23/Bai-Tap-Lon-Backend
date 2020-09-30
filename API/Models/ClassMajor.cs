using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ClassMajor
    {
        public ClassMajor()
        {
            Students = new HashSet<Student>();
        }

        public string IdClass { get; set; }
        public string IdLecturers { get; set; }
        public string NameClass { get; set; }
        public string IdFaculty { get; set; }

        public virtual Lecturer IdLecturersNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
