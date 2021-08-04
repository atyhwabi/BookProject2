namespace BooksKeeperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AuditableEntinty : DbMigration
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
            AddColumn("dbo.BookAuthors", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.BookAuthors", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.BookAuthors", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.BookAuthors", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.BookAuthors", "UpdatedBy", c => c.String());
            AddColumn("dbo.BookAuthors", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Authors", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Authors", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Authors", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Authors", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Authors", "UpdatedBy", c => c.String());
            AddColumn("dbo.Authors", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Books", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Books", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Books", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Books", "UpdatedBy", c => c.String());
            AddColumn("dbo.Books", "IsDeleted", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.BookAuthors", "Id");
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "AuthorID", "dbo.Authors", "Id");
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id");
            DropColumn("dbo.BookAuthors", "BookAuthorID");
            DropColumn("dbo.Authors", "AuthID");
            DropColumn("dbo.Books", "BoodID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BoodID", c => c.Guid(nullable: false));
            AddColumn("dbo.Authors", "AuthID", c => c.Guid(nullable: false));
            AddColumn("dbo.BookAuthors", "BookAuthorID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "AuthorID", "dbo.Authors");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.BookAuthors");
            DropColumn("dbo.Books", "IsDeleted");
            DropColumn("dbo.Books", "UpdatedBy");
            DropColumn("dbo.Books", "DeletedAt");
            DropColumn("dbo.Books", "UpdatedAt");
            DropColumn("dbo.Books", "CreatedAt");
            DropColumn("dbo.Books", "Id");
            DropColumn("dbo.Authors", "IsDeleted");
            DropColumn("dbo.Authors", "UpdatedBy");
            DropColumn("dbo.Authors", "DeletedAt");
            DropColumn("dbo.Authors", "UpdatedAt");
            DropColumn("dbo.Authors", "CreatedAt");
            DropColumn("dbo.Authors", "Id");
            DropColumn("dbo.BookAuthors", "IsDeleted");
            DropColumn("dbo.BookAuthors", "UpdatedBy");
            DropColumn("dbo.BookAuthors", "DeletedAt");
            DropColumn("dbo.BookAuthors", "UpdatedAt");
            DropColumn("dbo.BookAuthors", "CreatedAt");
            DropColumn("dbo.BookAuthors", "Id");
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
