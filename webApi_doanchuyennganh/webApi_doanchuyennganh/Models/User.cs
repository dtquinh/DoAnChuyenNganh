using System;
using System.Collections.Generic;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int Quyenhan { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string RememberToken { get; set; }
    }
}
