using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Orders")]
    public partial class Orders
    {
        public Orders()
        {
            Invoices = new HashSet<Invoices>();
            Orderlines = new HashSet<Orderlines>();
        }

        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string FranchiseNo { get; set; }

        public virtual Franchises FranchiseNoNavigation { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Orderlines> Orderlines { get; set; }
    }
}
