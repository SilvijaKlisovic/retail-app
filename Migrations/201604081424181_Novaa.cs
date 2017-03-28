namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RacunViewModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RacunViewModels");
        }
    }
}
