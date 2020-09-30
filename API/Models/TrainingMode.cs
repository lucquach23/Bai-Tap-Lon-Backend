using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class TrainingMode
    {
        public TrainingMode()
        {
            Students = new HashSet<Student>();
        }

        public string IdTrainingMode { get; set; }
        public string NameTraing { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
