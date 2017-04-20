using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetailApp.Models
{
    public class Normative
    {
        [Required]
        public int NormativeID { get; set; }

        public int ItemID { get; set; }

        public virtual Item Item { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public decimal Koeficijent { get; set; }
    }
}