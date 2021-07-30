namespace BooksKeeperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDuplicateID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookAuthors", "BookAuthorID");
            DropColumn("dbo.Authors", "AuthID");
            DropColumn("dbo.Books", "BoodID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BoodID", c => c.Guid(nullable: false));
            AddColumn("dbo.Authors", "AuthID", c => c.Guid(nullable: false));
            AddColumn("dbo.BookAuthors", "BookAuthorID", c => c.Guid(nullable: false));
        }
    }
}
