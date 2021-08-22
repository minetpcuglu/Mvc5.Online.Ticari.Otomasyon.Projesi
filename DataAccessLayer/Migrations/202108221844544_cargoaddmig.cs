namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargoaddmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 8000, unicode: false),
                        TrackingCode = c.String(maxLength: 8000, unicode: false),
                        Employee = c.String(),
                        ReceiverName = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingId = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
