using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Student
    {
        public string IdStudent { get; set; }
        public string IdClass { get; set; }
        public string IdDepartment { get; set; }
        public string IdTrainingMode { get; set; }
        public string Name { get; set; }
        public bool? Sex { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassAccount { get; set; }

        public virtual ClassMajor IdClassNavigation { get; set; }
        public virtual TrainingMode IdTrainingModeNavigation { get; set; }
    }
}
