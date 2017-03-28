namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MicanjeSuvisnogRacunViewModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RacunViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RacunViewModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
