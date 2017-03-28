namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProizvodIDStavka : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stavkas", "ProizvodID", c => c.Int(nullable: false));
            CreateIndex("dbo.Stavkas", "ProizvodID");
            AddForeignKey("dbo.Stavkas", "ProizvodID", "dbo.Proizvods", "ProizvodID", cascadeDelete: true);
            DropColumn("dbo.Stavkas", "ŠifraProizvoda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stavkas", "ŠifraProizvoda", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stavkas", "ProizvodID", "dbo.Proizvods");
            DropIndex("dbo.Stavkas", new[] { "ProizvodID" });
            DropColumn("dbo.Stavkas", "ProizvodID");
        }
    }
}
