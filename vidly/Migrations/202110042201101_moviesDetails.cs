namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviesDetails : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Troy', '5/4/1996 12:00:00 AM', '5/4/1996 12:00:00 AM', 5, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Troy', '5/4/1996 12:00:00 AM', '5/4/1996 12:00:00 AM', 5, 2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Troy', '5/4/1996 12:00:00 AM', '5/4/1996 12:00:00 AM', 5, 3)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Troy', '5/4/1996 12:00:00 AM', '5/4/1996 12:00:00 AM', 5, 4)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Troy', '5/4/1996 12:00:00 AM', '5/4/1996 12:00:00 AM', 5, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
