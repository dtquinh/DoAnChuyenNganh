using System;
using System.Collections.Generic;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
