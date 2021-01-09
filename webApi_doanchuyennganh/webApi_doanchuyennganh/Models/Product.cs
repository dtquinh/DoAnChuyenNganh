using System;
using System.Collections.Generic;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class Product
    {
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdType { get; set; }
        public string Description { get; set; }
        public double? UnitPrice { get; set; }
        public double? PromotionPrice { get; set; }
        public string Image { get; set; }
        public string Unit { get; set; }
        public short? New { get; set; }

        public virtual TypeProduct IdTypeNavigation { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
