using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Shows")]
    public partial class Shows
    {
        public Shows()
        {
            Saleitems = new HashSet<Saleitems>();
        }

        public string FranchiseNo { get; set; }
        public int HomeNo { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        public decimal ShowTotalSale { get; set; }

        public virtual Franchises FranchiseNoNavigation { get; set; }
        public virtual Homes HomeNoNavigation { get; set; }
        public virtual ICollection<Saleitems> Saleitems { get; set; }
    }
}
