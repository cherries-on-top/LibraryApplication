namespace LibraryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAuthor : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Authors (FullName) VALUES ('Elena Ferante')");
            Sql("INSERT INTO Authors (FullName) VALUES ('Jamie Oliver')");
        }
        
        public override void Down()
        {
        }
    }
}
