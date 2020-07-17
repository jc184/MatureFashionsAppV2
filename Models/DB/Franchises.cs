using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Franchises")]
    public partial class Franchises
    {
        public Franchises()
        {
            Invoices = new HashSet<Invoices>();
            Orders = new HashSet<Orders>();
            Partners = new HashSet<Partners>();
            Postcodes = new HashSet<Postcodes>();
            Shows = new HashSet<Shows>();
        }

        public string FranchiseNo { get; set; }
        public string FranchiseName { get; set; }
        public string FranchiseAddress { get; set; }
        public string FranchisePostcode { get; set; }
        public string FranchiseTel { get; set; }
        public string FranchiseFax { get; set; }
        public DateTime FranchiseStartdate { get; set; }
        public string FranchisorNo { get; set; }

        public virtual Franchisors FranchisorNoNavigation { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Partners> Partners { get; set; }
        public virtual ICollection<Postcodes> Postcodes { get; set; }
        public virtual ICollection<Shows> Shows { get; set; }
    }
}
