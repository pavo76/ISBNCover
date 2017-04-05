namespace ISBNCover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Knjigas", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Knjigas", "Name");
        }
    }
}
