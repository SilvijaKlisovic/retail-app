using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.Models
{
    public class Racun
    {
        [Display(Name = "JIR računa")]
        public Guid RacunID { get; set; }

        public DateTime Vrijeme { get; set; }

        public virtual List<Stavka> Stavke { get; set; }

        [Display(Name = "Ukupno za platiti")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double UkupnoZaPlatiti { get; set; }
    }
}