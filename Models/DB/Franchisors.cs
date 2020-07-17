using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Franchisors")]
    public partial class Franchisors
    {
        public Franchisors()
        {
            Franchises = new HashSet<Franchises>();
        }

        public string FranchisorNo { get; set; }
        public string FranchisorName { get; set; }
        public string FranchisorAddress { get; set; }
        public string FranchisorPostcode { get; set; }
        public string FranchisorTel { get; set; }
        public string FranchisorFax { get; set; }

        public virtual ICollection<Franchises> Franchises { get; set; }
    }
}
