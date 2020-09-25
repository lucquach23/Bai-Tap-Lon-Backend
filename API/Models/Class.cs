using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Class
    {
        public string IdClass { get; set; }
        public string IdLecturers { get; set; }
        public string NameClass { get; set; }
        public int? IdFaculty { get; set; }
        public int? Quantity { get; set; }
        public int? IdLecturersIsGvcn { get; set; }
        public int? Status { get; set; }

        public virtual Lecturer IdLecturersNavigation { get; set; }
    }
}
