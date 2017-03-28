namespace PrvaAplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ukloniokreirao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Racuns", "Kreirao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Racuns", "Kreirao", c => c.String());
        }
    }
}
