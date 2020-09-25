using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Lecturers
    {
        public Lecturers()
        {
            Class = new HashSet<Class>();
            ClassRegister = new HashSet<ClassRegister>();
        }

        public string IdLecturers { get; set; }
        public string IdDepartment { get; set; }
        public string IdDegree { get; set; }
        public string Name { get; set; }
        public bool? Sex { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PassAccount { get; set; }

        public virtual Degree IdDegreeNavigation { get; set; }
        public virtual Department IdDepartmentNavigation { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<ClassRegister> ClassRegister { get; set; }
    }
}
