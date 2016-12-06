namespace Garage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validering_regnr : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vehicles", new[] { "RegNr" });
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Vehicles", "RegNr", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "RegNr" });
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false, maxLength: 7));
            CreateIndex("dbo.Vehicles", "RegNr", unique: true);
        }
    }
}
