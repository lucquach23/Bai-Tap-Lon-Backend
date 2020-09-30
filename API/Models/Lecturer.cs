using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            ClassMajors = new HashSet<ClassMajor>();
            ClassRegisters = new HashSet<ClassRegister>();
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
        public virtual ICollection<ClassMajor> ClassMajors { get; set; }
        public virtual ICollection<ClassRegister> ClassRegisters { get; set; }
    }
}
