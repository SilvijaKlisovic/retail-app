using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.Models
{
    public class Artikal
    {
        [Required]
        [Display(Name = "Šifra artikla")]
        public int ArtikalID { get; set; }

        [Display(Name = "Naziv artikla")]
        public string Naziv { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Cijena { get; set; }

        //[DisplayFormat(DataFormatString = "{0:#,#0.00#}", ApplyFormatInEditMode = true)]
        public double Kolicina { get; set; }

        public int MjeraID { get; set; }

        public virtual Mjera Mjera { get; set; }
    }
}