using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.Models
{
    public class Mjera
    {
        [Required]
        public int MjeraID { get; set; }

        [Display(Name = "Mjera")]
        public string Naziv { get; set; }

        public virtual List<Artikal> Artikli { get; set; }
    }
}