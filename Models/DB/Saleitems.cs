using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Saleitems")]
    public partial class Saleitems
    {
        public string FranchiseNo { get; set; }
        public int HomeNo { get; set; }
        public DateTime ShowDate { get; set; }
        public string ItemNo { get; set; }
        public int SaleQuantity { get; set; }

        public virtual Items ItemNoNavigation { get; set; }
        public virtual Shows Shows { get; set; }
    }
}
