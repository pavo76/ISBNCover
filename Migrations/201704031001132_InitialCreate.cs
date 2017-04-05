namespace ISBNCover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Knjigas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Knjigas");
        }
    }
}
