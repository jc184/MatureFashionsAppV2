using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Postcodes")]
    public partial class Postcodes
    {
        public string PostcodeArea { get; set; }
        public string PostcodeName { get; set; }
        public string FranchiseNo { get; set; }

        public virtual Franchises FranchiseNoNavigation { get; set; }
    }
}
