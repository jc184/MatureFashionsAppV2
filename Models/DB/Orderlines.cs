using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Orderlines")]
    public partial class Orderlines
    {
        public string OrderNo { get; set; }
        public string ItemNo { get; set; }
        public int OrderQuantity { get; set; }

        public virtual Items ItemNoNavigation { get; set; }
        public virtual Orders OrderNoNavigation { get; set; }
    }
}
