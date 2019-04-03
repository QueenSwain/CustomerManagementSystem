namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id,Name) values(1,'Asim') ");
            Sql("Insert into Genres(Id,Name) values(2,'Barbbi') ");
            Sql("Insert into Genres(Id,Name) values(3,'Cati') ");
        }
        
        public override void Down()
        {
            //Sql("Update Genres set Name='Jazz' where Id=1");
            //Sql("Update Genres set Name='Blues' where Id=2");
            //Sql("Update Genres set Name='Rock' where Id=3");
            
            Sql("Delete from Genres where Id in(1,2,3)");
        }
    }
}
