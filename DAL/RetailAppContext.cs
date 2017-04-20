using RetailApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RetailApp.DAL
{
    public class RetailAppContext : IdentityDbContext<User>
    {
        public RetailAppContext()
           : base("RetailAppContext", throwIfV1Schema: false)
        {
        }

        public static RetailAppContext Create()
        {
            return new RetailAppContext();
        }

        public DbSet<Measure> Measures { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Normative> Normatives { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}