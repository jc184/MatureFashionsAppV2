using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Items")]
    public partial class Items
    {
        public Items()
        {
            Orderlines = new HashSet<Orderlines>();
            Saleitems = new HashSet<Saleitems>();
        }

        public string ItemNo { get; set; }
        public string ItemDescription { get; set; }
        public string ItemGender { get; set; }
        public string ItemColour { get; set; }
        public string ItemSize { get; set; }
        public decimal ItemWholesalePrice { get; set; }
        public decimal ItemRetailPrice { get; set; }

        public virtual ICollection<Orderlines> Orderlines { get; set; }
        public virtual ICollection<Saleitems> Saleitems { get; set; }
    }
}
