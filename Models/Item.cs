using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetailApp.Models
{
    public class Item
    {
        [Required]
        [Display(Name = "Šifra artikla")]
        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Naziv artikla")]
        public string Naziv { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Cijena { get; set; }

        [Required]
        public decimal Kolicina { get; set; }

        public int MeasureID { get; set; }

        public virtual Measure Measure { get; set; }
    }
}