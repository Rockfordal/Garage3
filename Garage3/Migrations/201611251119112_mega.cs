namespace Garage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mega : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SSN = c.String(nullable: false, maxLength: 12),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SSN, unique: true);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(nullable: false, maxLength: 7),
                        Color = c.String(nullable: false),
                        NumberOfWheels = c.Int(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Owner_PersonId = c.Int(),
                        VehicleType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.Owner_PersonId)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id, cascadeDelete: true)
                .Index(t => t.RegNr, unique: true)
                .Index(t => t.Owner_PersonId)
                .Index(t => t.VehicleType_Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Type, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "Owner_PersonId", "dbo.Owners");
            DropForeignKey("dbo.Owners", "PersonId", "dbo.People");
            DropIndex("dbo.VehicleTypes", new[] { "Type" });
            DropIndex("dbo.Vehicles", new[] { "VehicleType_Id" });
            DropIndex("dbo.Vehicles", new[] { "Owner_PersonId" });
            DropIndex("dbo.Vehicles", new[] { "RegNr" });
            DropIndex("dbo.People", new[] { "SSN" });
            DropIndex("dbo.Owners", new[] { "PersonId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.People");
            DropTable("dbo.Owners");
        }
    }
}
