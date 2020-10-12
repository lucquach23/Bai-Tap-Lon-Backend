using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ListCr
    {
        public int IdCr { get; set; }
        public string IdClassRegister { get; set; }
        public string IdStudent { get; set; }

        public virtual ClassRegister IdClassRegisterNavigation { get; set; }
    }
}
