using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string IdFaculty { get; set; }
    }
}
