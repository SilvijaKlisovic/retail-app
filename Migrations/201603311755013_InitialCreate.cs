namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artikals",
                c => new
                    {
                        ArtikalID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Cijena = c.Double(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        MjeraID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtikalID)
                .ForeignKey("dbo.Mjeras", t => t.MjeraID, cascadeDelete: true)
                .Index(t => t.MjeraID);
            
            CreateTable(
                "dbo.Mjeras",
                c => new
                    {
                        MjeraID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.MjeraID);
            
            CreateTable(
                "dbo.Normativs",
                c => new
                    {
                        NormativID = c.Int(nullable: false, identity: true),
                        ArtikalID = c.Int(nullable: false),
                        ProizvodID = c.Int(nullable: false),
                        Koeficijent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NormativID)
                .ForeignKey("dbo.Artikals", t => t.ArtikalID, cascadeDelete: true)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodID, cascadeDelete: true)
                .Index(t => t.ArtikalID)
                .Index(t => t.ProizvodID);
            
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        ProizvodID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Cijena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProizvodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Normativs", "ProizvodID", "dbo.Proizvods");
            DropForeignKey("dbo.Normativs", "ArtikalID", "dbo.Artikals");
            DropForeignKey("dbo.Artikals", "MjeraID", "dbo.Mjeras");
            DropIndex("dbo.Normativs", new[] { "ProizvodID" });
            DropIndex("dbo.Normativs", new[] { "ArtikalID" });
            DropIndex("dbo.Artikals", new[] { "MjeraID" });
            DropTable("dbo.Proizvods");
            DropTable("dbo.Normativs");
            DropTable("dbo.Mjeras");
            DropTable("dbo.Artikals");
        }
    }
}
