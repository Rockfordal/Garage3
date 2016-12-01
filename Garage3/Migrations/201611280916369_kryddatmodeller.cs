namespace Garage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kryddatmodeller : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false));
        }
    }
}
