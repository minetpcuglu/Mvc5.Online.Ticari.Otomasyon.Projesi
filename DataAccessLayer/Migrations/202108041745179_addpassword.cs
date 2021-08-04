namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currents", "Password", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currents", "Password");
        }
    }
}
