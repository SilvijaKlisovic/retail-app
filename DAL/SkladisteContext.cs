using PrvaAplikacija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PrvaAplikacija.DAL
{
    public class SkladisteContext : IdentityDbContext<User>
    {
        public SkladisteContext()
           : base("SkladisteContext", throwIfV1Schema: false)
        {
        }

        public static SkladisteContext Create()
        {
            return new SkladisteContext();
        }

        public DbSet<Mjera> Mjere { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Normativ> Normativi { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<Racun> Racuni { get; set; }
    }
}