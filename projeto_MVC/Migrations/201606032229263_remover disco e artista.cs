namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerdiscoeartista : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discoes", "Artista_Id", "dbo.Artistas");
            DropIndex("dbo.Discoes", new[] { "Artista_Id" });
            DropTable("dbo.Artistas");
            DropTable("dbo.Discoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Discoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Artista_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Discoes", "Artista_Id");
            AddForeignKey("dbo.Discoes", "Artista_Id", "dbo.Artistas", "Id");
        }
    }
}
