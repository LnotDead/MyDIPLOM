namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patronymic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "patronymic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "patronymic");
        }
    }
}
