namespace BooksKeeperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ID_on_Models : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "BookId" });
            DropIndex("dbo.BookAuthors", new[] { "AuthorID" });
            DropPrimaryKey("dbo.BookAuthors");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Books");
            AddColumn("dbo.BookAuthors", "BookAuthorID", c => c.Guid(nullable: false));
            AddColumn("dbo.BookAuthors", "Author_AuthID", c => c.Guid());
            AddColumn("dbo.BookAuthors", "Book_BoodID", c => c.Guid());
            AddColumn("dbo.Authors", "AuthID", c => c.Guid(nullable: false));
            AddColumn("dbo.Books", "BoodID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.BookAuthors", "BookAuthorID");
            AddPrimaryKey("dbo.Authors", "AuthID");
            AddPrimaryKey("dbo.Books", "BoodID");
            CreateIndex("dbo.BookAuthors", "Author_AuthID");
            CreateIndex("dbo.BookAuthors", "Book_BoodID");
            AddForeignKey("dbo.BookAuthors", "Author_AuthID", "dbo.Authors", "AuthID");
            AddForeignKey("dbo.BookAuthors", "Book_BoodID", "dbo.Books", "BoodID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "Book_BoodID", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_AuthID", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "Book_BoodID" });
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthID" });
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.BookAuthors");
            DropColumn("dbo.Books", "BoodID");
            DropColumn("dbo.Authors", "AuthID");
            DropColumn("dbo.BookAuthors", "Book_BoodID");
            DropColumn("dbo.BookAuthors", "Author_AuthID");
            DropColumn("dbo.BookAuthors", "BookAuthorID");
            AddPrimaryKey("dbo.Books", "Id");
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.BookAuthors", "Id");
            CreateIndex("dbo.BookAuthors", "AuthorID");
            CreateIndex("dbo.BookAuthors", "BookId");
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "AuthorID", "dbo.Authors", "Id");
        }
    }
}
