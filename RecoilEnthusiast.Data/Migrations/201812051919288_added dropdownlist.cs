namespace RecoilEnthusiast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddropdownlist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "CustomerID");
            CreateIndex("dbo.Transaction", "ProductID");
            AddForeignKey("dbo.Transaction", "CustomerID", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "ProductID", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Transaction", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Transaction", new[] { "ProductID" });
            DropIndex("dbo.Transaction", new[] { "CustomerID" });
            DropColumn("dbo.Transaction", "ProductID");
            DropColumn("dbo.Transaction", "CustomerID");
        }
    }
}
