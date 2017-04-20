using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetailApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RetailApp.DAL
{
    public class RetailAppInitializer : DropCreateDatabaseAlways<RetailAppContext>
    {
        protected override void Seed(RetailAppContext context)
        {
            var proiuvod1 = new Product() { ProductID = 1, Sifra = 101 , Naziv = "Topli sendvić", Cijena = 14.00M };
            var proiuvod2 = new Product() { ProductID = 2, Sifra = 110 , Naziv = "Hamburger", Cijena = 17.00M };
            var proiuvod3 = new Product() { ProductID = 3, Sifra = 108 , Naziv = "Ćevapi", Cijena = 17.00M };
            
            var mjera1 = new Measure() { MeasureID = 1, Naziv = "Kg" };
            var mjera2 = new Measure() { MeasureID = 2, Naziv = "Lit" };
            var mjera3 = new Measure() { MeasureID = 3, Naziv = "Kom" };

            var artikal1 = new Item() { ItemID = 1, Naziv = "Šunka", Kolicina = 0.342M, MeasureID = 1 };
            var artikal2 = new Item() { ItemID = 2, Naziv = "Sir", Kolicina = 0.500M, MeasureID = 1 };
            var artikal3 = new Item() { ItemID = 3, Naziv = "Pecivo", Kolicina = 1.500M, MeasureID = 1 };
            var artikal4 = new Item() { ItemID = 4, Naziv = "Lepinja", Kolicina = 3.000M, MeasureID = 1 };
            var artikal5 = new Item() { ItemID = 5, Naziv = "Mljeveno meso", Kolicina = 2.500M, MeasureID = 1 };
            var artikal6 = new Item() { ItemID = 6, Naziv = "Kava", Kolicina = 0.700M, MeasureID = 1 };

            var normativ1 = new Normative() { NormativeID = 1, Koeficijent = 50, ItemID = 1, ProductID = 1 };
            var normativ2 = new Normative() { NormativeID = 1, Koeficijent = 50, ItemID = 2, ProductID = 1 };
            var normativ3 = new Normative() { NormativeID = 1, Koeficijent = 150, ItemID = 3, ProductID = 1 };
            var normativ4 = new Normative() { NormativeID = 1, Koeficijent = 150, ItemID = 4, ProductID = 2 };
            var normativ5 = new Normative() { NormativeID = 1, Koeficijent = 150, ItemID = 5, ProductID = 2 };

            var stavka1 = new InvoiceLine() { InvoiceLineID = 1, RedniBroj = 1, Cijena = 14, Kolicina = 2, ProductID = 1 };
            stavka1.Ukupno = stavka1.Cijena * stavka1.Kolicina;
            var stavka2 = new InvoiceLine() { InvoiceLineID = 1, RedniBroj = 2, Cijena = 17, Kolicina = 2, ProductID = 1 };
            stavka1.Ukupno = stavka1.Cijena * stavka1.Kolicina;
            
            context.Measures.Add(mjera1);
            context.Measures.Add(mjera2);
            context.Measures.Add(mjera3);

            context.Items.Add(artikal1);
            context.Items.Add(artikal2);
            context.Items.Add(artikal3);
            context.Items.Add(artikal4);
            context.Items.Add(artikal5);
            context.Items.Add(artikal6);

            context.Products.Add(proiuvod1);
            context.Products.Add(proiuvod2);
            context.Products.Add(proiuvod3);

            context.Normatives.Add(normativ1);
            context.Normatives.Add(normativ2);
            context.Normatives.Add(normativ3);
            context.Normatives.Add(normativ4);
            context.Normatives.Add(normativ5);

            context.InvoiceLines.Add(stavka1);
            context.InvoiceLines.Add(stavka2);

            //Superuser Initialization
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));


            if (!roleManager.RoleExists("Admin"))
            {
                var adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                roleManager.Create(adminRole);

                //creating superadmin
                var superAdmin = new User();
                superAdmin.Email = "admin";
                superAdmin.UserName = "admin";
                var res = userManager.Create(superAdmin, "Admin_1");
                if (res.Succeeded)
                {
                    Console.WriteLine("Super user successfuly created");
                    var role_res = userManager.AddToRole(superAdmin.Id, adminRole.Name);
                    Console.WriteLine("Super user successfuly added to role Admin");
                }
            }

            // creating Creating Manager role 
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role 
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }

            base.Seed(context);
            //context.SaveChanges();
        }
    }	
}