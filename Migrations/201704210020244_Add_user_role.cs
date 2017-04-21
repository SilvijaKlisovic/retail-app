namespace RetailApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_user_role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoleID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "RoleID_Id");
            AddForeignKey("dbo.AspNetUsers", "RoleID_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RoleID_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "RoleID_Id" });
            DropColumn("dbo.AspNetUsers", "RoleID_Id");
        }
    }
}
