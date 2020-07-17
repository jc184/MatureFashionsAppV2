using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Partners")]
    public partial class Partners
    {
        public string FranchiseNo { get; set; }
        public string PartnerName { get; set; }

        public virtual Franchises FranchiseNoNavigation { get; set; }
    }
}
