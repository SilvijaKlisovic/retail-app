using RetailApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RetailApp.Models
{
    public class Invoice
    {
        public Guid InvoiceID { get; set; }

        [Display(Name = "JIR računa")]
        public Guid JIRRacuna { get; set; }

        public DateTime Vrijeme { get; set; }

        public virtual List<InvoiceLine> InvoiceLines { get; set; }

        [Display(Name = "Ukupno za platiti")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal UkupnoZaPlatiti { get; set; }

        public Invoice()
        {
            Vrijeme = DateTime.Now;
            InvoiceID = Guid.NewGuid();
        }

        public void Fiskaliziraj()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Settings.Default.FiskalizacijaBaseURL);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("oib", Settings.Default.OIB),
                new KeyValuePair<string, string>("price", UkupnoZaPlatiti.ToString()),
                new KeyValuePair<string, string>("datetime", Vrijeme.ToString("MM-dd-yyyy hh:mm:ss:ff"))
            });

            HttpResponseMessage result = client.PostAsync(Settings.Default.FiskalizacijaEndpoint, content).Result;
            var responseData = result.Content.ReadAsStringAsync().Result;
            JIRRacuna = Guid.Parse(responseData);
        }
    }
}