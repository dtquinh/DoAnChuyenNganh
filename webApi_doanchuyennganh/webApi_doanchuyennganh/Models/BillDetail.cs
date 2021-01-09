using System;
using System.Collections.Generic;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class BillDetail
    {
        public int Id { get; set; }
        public int IdBill { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
