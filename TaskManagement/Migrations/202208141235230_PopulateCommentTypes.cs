namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCommentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CommentTypes (Id, Name) VALUES (1, 'Text')");
            Sql("INSERT INTO CommentTypes (Id, Name) VALUES (2, 'CodeChange')");
            Sql("INSERT INTO CommentTypes (Id, Name) VALUES (3, 'System')");
        }
        
        public override void Down()
        {
        }
    }
}
