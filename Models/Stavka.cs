using System;
using System.ComponentModel.DataAnnotations;

namespace PrvaAplikacija.Models
{
    public class Stavka
    {
        [Required]
        public int StavkaID { get; set; }

        [Display(Name = "Redni broj")]
        [Editable(false)]
        public int RedniBroj { get; set; }

        [Display(Name = "Šifra proizvoda")]
        public int ProizvodID { get; set; }

        [Display(Name = "Šifra proizvoda")]
        public virtual Proizvod Proizvod { get; set; }

        public Guid RacunID { get; set; }

        public virtual Racun Racun { get; set; }
        
        [Display(Name = "Količina")]
        [Required]
        public int Kolicina { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Cijena { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Ukupno { get; set; }
    }
}