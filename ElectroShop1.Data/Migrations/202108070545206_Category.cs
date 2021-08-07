namespace ElectroShop1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Description = c.String(),
                        CreatedUtc = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Product", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Modified", c => c.DateTimeOffset(precision: 7));
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Product", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropColumn("dbo.Product", "Modified");
            DropColumn("dbo.Product", "CategoryId");
            DropTable("dbo.Category");
        }
    }
}
