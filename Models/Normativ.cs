using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.Models
{
    public class Normativ
    {
        [Required]
        public int NormativID { get; set; }

        public int ArtikalID { get; set; }

        public virtual Artikal Artikal { get; set; }

        public int ProizvodID { get; set; }

        public virtual Proizvod Proizvod { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double Koeficijent { get; set; }
    }
}