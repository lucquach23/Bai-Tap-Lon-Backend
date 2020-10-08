using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Account
    {
        public int IdAccount { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public byte? Role { get; set; }
        public string Token { get; set; }
    }
}
