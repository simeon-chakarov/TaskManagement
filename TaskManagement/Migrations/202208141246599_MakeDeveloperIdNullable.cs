namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDeveloperIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Tasks", new[] { "DeveloperId" });
            AlterColumn("dbo.Tasks", "DeveloperId", c => c.Byte());
            CreateIndex("dbo.Tasks", "DeveloperId");
            AddForeignKey("dbo.Tasks", "DeveloperId", "dbo.Developers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Tasks", new[] { "DeveloperId" });
            AlterColumn("dbo.Tasks", "DeveloperId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tasks", "DeveloperId");
            AddForeignKey("dbo.Tasks", "DeveloperId", "dbo.Developers", "Id", cascadeDelete: true);
        }
    }
}
