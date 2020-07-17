using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Invoices")]
    public partial class Invoices
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDateDue { get; set; }
        public decimal InvoiceNet { get; set; }
        public string FranchiseNo { get; set; }
        public string OrderNo { get; set; }

        public virtual Franchises FranchiseNoNavigation { get; set; }
        public virtual Orders OrderNoNavigation { get; set; }
    }
}
