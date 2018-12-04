namespace RecoilEnthusiast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Designation", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "PayMethod");
            DropColumn("dbo.Transaction", "PayAmmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "PayAmmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "PayMethod", c => c.String(nullable: false));
            DropColumn("dbo.Transaction", "Designation");
        }
    }
}
