namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PovezivanjeStavkaRacun : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stavkas", "RacunID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Stavkas", "RacunID");
            AddForeignKey("dbo.Stavkas", "RacunID", "dbo.Racuns", "RacunID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stavkas", "RacunID", "dbo.Racuns");
            DropIndex("dbo.Stavkas", new[] { "RacunID" });
            DropColumn("dbo.Stavkas", "RacunID");
        }
    }
}
