namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAndSecName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "secondName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "secondName");
        }
    }
}
