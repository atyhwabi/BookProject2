namespace BooksKeeperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePrimaerykey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Author_AuthID", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BoodID", "dbo.Books");
            DropColumn("dbo.BookAuthors", "AuthorID");
            DropColumn("dbo.BookAuthors", "BookId");
            RenameColumn(table: "dbo.BookAuthors", name: "Author_AuthID", newName: "AuthorID");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_BoodID", newName: "BookId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_BoodID", newName: "IX_BookId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Author_AuthID", newName: "IX_AuthorID");
            DropPrimaryKey("dbo.BookAuthors");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Books");
            AddPrimaryKey("dbo.BookAuthors", "Id");
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "AuthorID", "dbo.Authors", "Id");
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "AuthorID", "dbo.Authors");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.Books", "BoodID");
            AddPrimaryKey("dbo.Authors", "AuthID");
            AddPrimaryKey("dbo.BookAuthors", "BookAuthorID");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_AuthorID", newName: "IX_Author_AuthID");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_BookId", newName: "IX_Book_BoodID");
            RenameColumn(table: "dbo.BookAuthors", name: "BookId", newName: "Book_BoodID");
            RenameColumn(table: "dbo.BookAuthors", name: "AuthorID", newName: "Author_AuthID");
            AddColumn("dbo.BookAuthors", "BookId", c => c.Guid());
            AddColumn("dbo.BookAuthors", "AuthorID", c => c.Guid());
            AddForeignKey("dbo.BookAuthors", "Book_BoodID", "dbo.Books", "BoodID");
            AddForeignKey("dbo.BookAuthors", "Author_AuthID", "dbo.Authors", "AuthID");
        }
    }
}
