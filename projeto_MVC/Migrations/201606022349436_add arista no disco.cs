namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaristanodisco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discoes", "Artista_Id", c => c.Int());
            CreateIndex("dbo.Discoes", "Artista_Id");
            AddForeignKey("dbo.Discoes", "Artista_Id", "dbo.Artistas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discoes", "Artista_Id", "dbo.Artistas");
            DropIndex("dbo.Discoes", new[] { "Artista_Id" });
            DropColumn("dbo.Discoes", "Artista_Id");
        }
    }
}
