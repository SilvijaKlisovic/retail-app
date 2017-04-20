using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetailApp.Models
{
    public class Measure
    {
        [Required]
        public int MeasureID { get; set; }

        [Display(Name = "Measure")]
        public string Naziv { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}