using PrvaAplikacija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrvaAplikacija.DAL
{
    public class SkladisteInitializer : DropCreateDatabaseAlways<SkladisteContext>
    {
        protected override void Seed(SkladisteContext context)
        {
            var proiuvod1 = new Proizvod() { ProizvodID = 1, Sifra = 101 , Naziv = "Topli sendvić", Cijena = 14.00 };
            var proiuvod2 = new Proizvod() { ProizvodID = 2, Sifra = 110 , Naziv = "Hamburger", Cijena = 17.00 };
            var proiuvod3 = new Proizvod() { ProizvodID = 3, Sifra = 108 , Naziv = "Ćevapi", Cijena = 17.00 };
            
            var mjera1 = new Mjera() { MjeraID = 1, Naziv = "Kg" };
            var mjera2 = new Mjera() { MjeraID = 2, Naziv = "Lit" };
            var mjera3 = new Mjera() { MjeraID = 3, Naziv = "Kom" };

            var artikal1 = new Artikal() { ArtikalID = 1, Naziv = "Šunka", Kolicina = 0.342, MjeraID = 1 };
            var artikal2 = new Artikal() { ArtikalID = 2, Naziv = "Sir", Kolicina = 0.500, MjeraID = 1 };
            var artikal3 = new Artikal() { ArtikalID = 3, Naziv = "Pecivo", Kolicina = 1.500, MjeraID = 1 };
            var artikal4 = new Artikal() { ArtikalID = 4, Naziv = "Lepinja", Kolicina = 3.000, MjeraID = 1 };
            var artikal5 = new Artikal() { ArtikalID = 5, Naziv = "Mljeveno meso", Kolicina = 2.500, MjeraID = 1 };
            var artikal6 = new Artikal() { ArtikalID = 6, Naziv = "Kava", Kolicina = 0.700, MjeraID = 1 };

            // mjera1.Artikli = new List<Artikal>() { artikal1, artikal2, artikal3, artikal4, artikal5, artikal6 };

            var normativ1 = new Normativ() { NormativID = 1, Koeficijent = 50, ArtikalID = 1, ProizvodID = 1 };
            var normativ2 = new Normativ() { NormativID = 1, Koeficijent = 50, ArtikalID = 2, ProizvodID = 1 };
            var normativ3 = new Normativ() { NormativID = 1, Koeficijent = 150, ArtikalID = 3, ProizvodID = 1 };
            var normativ4 = new Normativ() { NormativID = 1, Koeficijent = 150, ArtikalID = 4, ProizvodID = 2 };
            var normativ5 = new Normativ() { NormativID = 1, Koeficijent = 150, ArtikalID = 5, ProizvodID = 2 };

            var stavka1 = new Stavka() { StavkaID = 1, RedniBroj = 1, Cijena = 14, Kolicina = 2, ProizvodID = 1 };
            stavka1.Ukupno = stavka1.Cijena * stavka1.Kolicina;
            var stavka2 = new Stavka() { StavkaID = 1, RedniBroj = 2, Cijena = 17, Kolicina = 2, ProizvodID = 1 };
            stavka1.Ukupno = stavka1.Cijena * stavka1.Kolicina;
            
            var racun1 = new Racun() { Vrijeme=DateTime.Now };
            
            context.Mjere.Add(mjera1);
            context.Mjere.Add(mjera2);
            context.Mjere.Add(mjera3);

            context.Artikli.Add(artikal1);
            context.Artikli.Add(artikal2);
            context.Artikli.Add(artikal3);
            context.Artikli.Add(artikal4);
            context.Artikli.Add(artikal5);
            context.Artikli.Add(artikal6);

            context.Proizvodi.Add(proiuvod1);
            context.Proizvodi.Add(proiuvod2);
            context.Proizvodi.Add(proiuvod3);

            context.Normativi.Add(normativ1);
            context.Normativi.Add(normativ2);
            context.Normativi.Add(normativ3);
            context.Normativi.Add(normativ4);
            context.Normativi.Add(normativ5);

            context.Stavke.Add(stavka1);
            context.Stavke.Add(stavka2);

            context.Racuni.Add(racun1);

            base.Seed(context);
            //context.SaveChanges();
        }
    }	
}