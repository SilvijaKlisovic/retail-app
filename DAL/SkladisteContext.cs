﻿using PrvaAplikacija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.DAL
{
    public class SkladisteContext : DbContext
    {
        public DbSet<Mjera> Mjere { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Normativ> Normativi { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<Racun> Racuni { get; set; }
    }
}