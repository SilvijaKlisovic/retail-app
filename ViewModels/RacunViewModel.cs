using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetailApp.ViewModels
{
    public class RacunViewModel
    {
        public Guid InvoiceID { get; set; }
        [Display(Name = "Ukupno za platiti")]
        public double UkupnoZaPlatiti { get; set; }

    }
}