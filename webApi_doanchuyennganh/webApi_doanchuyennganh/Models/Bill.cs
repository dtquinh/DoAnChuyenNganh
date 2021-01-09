using System;
using System.Collections.Generic;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public DateTime DateOrder { get; set; }
        public double Total { get; set; }
        public string Payment { get; set; }
        public string Note { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
