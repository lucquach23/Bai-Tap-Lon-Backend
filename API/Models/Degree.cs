using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Degree
    {
        public Degree()
        {
            Lecturers = new HashSet<Lecturer>();
        }

        public string IdDegree { get; set; }
        public string NameDegree { get; set; }

        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}
