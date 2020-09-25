using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Department
    {
        public Department()
        {
            Lecturers = new HashSet<Lecturer>();
        }

        public string IdDepartment { get; set; }
        public string NameDepartment { get; set; }
        public string IdFaculty { get; set; }

        public virtual Faculty IdFacultyNavigation { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}
