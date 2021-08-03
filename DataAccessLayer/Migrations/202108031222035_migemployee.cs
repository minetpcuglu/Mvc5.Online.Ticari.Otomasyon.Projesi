namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migemployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TelephoneNumber", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Employees", "EMail", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.Employees", "Adress", c => c.String(maxLength: 400, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Adress");
            DropColumn("dbo.Employees", "EMail");
            DropColumn("dbo.Employees", "TelephoneNumber");
        }
    }
}
