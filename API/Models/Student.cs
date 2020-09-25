using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Student
    {
        public string IdStudent { get; set; }
        public int? IdClass { get; set; }
        public int? IdTrainingMode { get; set; }
        public string Name { get; set; }
        public bool? Sex { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string PassAccount { get; set; }
    }
}
