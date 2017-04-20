using System;
using System.ComponentModel.DataAnnotations;

namespace RetailApp.Models
{
    public class InvoiceLine
    {
        [Required]
        public int InvoiceLineID { get; set; }

        [Display(Name = "Redni broj")]
        [Editable(false)]
        public int RedniBroj { get; set; }

        [Display(Name = "Šifra proizvoda")]
        public int ProductID { get; set; }

        [Display(Name = "Šifra proizvoda")]
        public virtual Product Product { get; set; }

        public Guid? InvoiceID { get; set; }

        public virtual Invoice Invoice { get; set; }
        
        [Display(Name = "Količina")]
        [Required]
        public int Kolicina { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required]
        public decimal Cijena { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Ukupno { get; set; }
    }
}