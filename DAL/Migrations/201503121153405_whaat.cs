namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whaat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserName", c => c.String());
            DropColumn("dbo.User", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Login", c => c.String());
            DropColumn("dbo.User", "UserName");
        }
    }
}
