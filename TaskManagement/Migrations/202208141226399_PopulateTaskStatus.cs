namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTaskStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (1, 'Open')");
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (2, 'InProgress')");
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (3, 'InReview')");
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (4, 'Approved')");
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (5, 'Rejected')");
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (6, 'Cancelled')");
            Sql("INSERT INTO TaskStatus (Id, Name) VALUES (7, 'Done')");
        }
        
        public override void Down()
        {
        }
    }
}
