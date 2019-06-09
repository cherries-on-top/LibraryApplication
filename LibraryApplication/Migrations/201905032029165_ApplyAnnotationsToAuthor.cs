namespace LibraryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "FullName", c => c.String());
        }
    }
}
