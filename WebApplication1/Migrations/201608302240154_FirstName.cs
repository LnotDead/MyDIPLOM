namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "firstName");
        }
    }
}
