namespace RecoilEnthusiast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "IssuerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "IssuerName");
        }
    }
}
