using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatureFashionsAppV2.Models.DB
{
    [Table("Homes")]
    public partial class Homes
    {
        public Homes()
        {
            Shows = new HashSet<Shows>();
        }

        public int HomeNo { get; set; }
        public string HomeName { get; set; }
        public string HometypeCode { get; set; }
        public string HomeAddress { get; set; }
        public string HomePostcode { get; set; }
        public string HomeTel { get; set; }

        public virtual Hometypes HometypeCodeNavigation { get; set; }
        public virtual ICollection<Shows> Shows { get; set; }
    }
}
