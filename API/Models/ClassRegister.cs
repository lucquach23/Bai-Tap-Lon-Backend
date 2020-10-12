using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ClassRegister
    {
        public ClassRegister()
        {
            ListCrs = new HashSet<ListCr>();
        }

        public string IdClassRegister { get; set; }
        public string IdSubject { get; set; }
        public string IdLecturers { get; set; }
        public string IdSemester { get; set; }
        public string Thu { get; set; }
        public string Time { get; set; }
        public string Week { get; set; }
        public string Room { get; set; }

        public virtual Lecturer IdLecturersNavigation { get; set; }
        public virtual Semester IdSemesterNavigation { get; set; }
        public virtual Subject IdSubjectNavigation { get; set; }
        public virtual ICollection<ListCr> ListCrs { get; set; }
    }
}
