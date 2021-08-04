namespace BooksKeeperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        BookAuthorID = c.Guid(nullable: false),
                        BookId = c.Guid(),
                        AuthorID = c.Guid(),
                        PublishDate = c.DateTime(nullable: false),
                        Author_AuthID = c.Guid(),
                        Book_BoodID = c.Guid(),
                    })
                .PrimaryKey(t => t.BookAuthorID)
                .ForeignKey("dbo.Authors", t => t.Author_AuthID)
                .ForeignKey("dbo.Books", t => t.Book_BoodID)
                .Index(t => t.Author_AuthID)
                .Index(t => t.Book_BoodID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BoodID = c.Guid(nullable: false),
                        BookName = c.String(),
                        ISBN = c.String(),
                        Edition = c.String(),
                    })
                .PrimaryKey(t => t.BoodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "Book_BoodID", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_AuthID", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "Book_BoodID" });
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthID" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.BookAuthors");
        }
    }
}
