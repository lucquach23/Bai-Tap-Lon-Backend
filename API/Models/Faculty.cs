using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Departments = new HashSet<Department>();
        }

        public string IdFaculty { get; set; }
        public string NameFaculty { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
