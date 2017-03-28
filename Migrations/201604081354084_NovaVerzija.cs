namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaVerzija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        RacunID = c.Guid(nullable: false),
                        Vrijeme = c.DateTime(nullable: false),
                        UkupnoZaPlatiti = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RacunID);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        StavkaID = c.Int(nullable: false, identity: true),
                        RedniBroj = c.Int(nullable: false),
                        ŠifraProizvoda = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Double(nullable: false),
                        Ukupno = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StavkaID);
            
            AddColumn("dbo.Proizvods", "Sifra", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proizvods", "Sifra");
            DropTable("dbo.Stavkas");
            DropTable("dbo.Racuns");
        }
    }
}
