namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDevelopers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Developers (Id, Name) VALUES (1, 'Angelica Ramos')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (2, 'Ashton Cox')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (3, 'Bradley Greer')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (4, 'Brenden Wagner')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (5, 'Brielle Williamson')");

            Sql("INSERT INTO Developers (Id, Name) VALUES (6, 'Bruno Nash')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (7, 'Caesar Vance')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (8, 'Cara Stevens')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (9, 'Cedric Kelly')");
            Sql("INSERT INTO Developers (Id, Name) VALUES (10, 'Charde Marshall')");
        }
        
        public override void Down()
        {
        }
    }
}
