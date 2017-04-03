using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.Models
{
    public class Proizvod
    {
        [Required]
        public int ProizvodID { get; set; }

        [Display(Name = "Šifra")]
        public int Sifra { get; set; }

        [Display(Name = "Naziv proizvoda")]
        public string Naziv { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Cijena { get; set; }
    }
}