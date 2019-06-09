namespace LibraryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Authors");
        }
    }
}
