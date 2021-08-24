namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcontent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Content", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Content");
        }
    }
}
