namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "userRoleName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "firstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "secondName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "patronymic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "patronymic", c => c.String());
            AlterColumn("dbo.AspNetUsers", "secondName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "firstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "userRoleName", c => c.String());
        }
    }
}
