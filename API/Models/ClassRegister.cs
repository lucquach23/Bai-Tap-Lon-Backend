using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ClassRegister
    {
        public string IdClassRegister { get; set; }
        public string IdSubject { get; set; }
        public string IdLecturers { get; set; }
        public string IdStudent { get; set; }
        public string IdSemester { get; set; }

        public virtual Lecturer IdLecturersNavigation { get; set; }
        public virtual Semester IdSemesterNavigation { get; set; }
        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
