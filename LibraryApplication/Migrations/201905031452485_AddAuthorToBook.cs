namespace LibraryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AuthorId", c => c.Int());
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropColumn("dbo.Books", "AuthorId");
        }
    }
}
