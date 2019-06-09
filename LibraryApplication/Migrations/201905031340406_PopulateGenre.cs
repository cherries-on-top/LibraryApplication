namespace LibraryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) VALUES ('Health')");
            Sql("INSERT INTO Genres (Name) VALUES ('Fiction')");
        }
        
        public override void Down()
        {
        }
    }
}
