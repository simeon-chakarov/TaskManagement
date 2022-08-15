namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTaskTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TaskTypes (Id, Name) VALUES (1, 'Bug')");
            Sql("INSERT INTO TaskTypes (Id, Name) VALUES (2, 'Epic')");
            Sql("INSERT INTO TaskTypes (Id, Name) VALUES (3, 'Improvement')");
            Sql("INSERT INTO TaskTypes (Id, Name) VALUES (4, 'Feature')");
            Sql("INSERT INTO TaskTypes (Id, Name) VALUES (5, 'Story')");
        }
        
        public override void Down()
        {
        }
    }
}
