namespace BooksKeeperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteIntIDs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "AuthID");
            DropColumn("dbo.Books", "BookID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "AuthID", c => c.Int(nullable: false));
        }
    }
}
