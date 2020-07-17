using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Hometypes")]
    public partial class Hometypes
    {
        public Hometypes()
        {
            Homes = new HashSet<Homes>();
        }

        public string HometypeCode { get; set; }
        public string HometypeDescription { get; set; }

        public virtual ICollection<Homes> Homes { get; set; }
    }
}
