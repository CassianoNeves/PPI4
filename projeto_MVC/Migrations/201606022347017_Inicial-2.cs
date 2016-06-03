namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pessoas", newName: "Artistas");
            CreateTable(
                "dbo.Discoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Discoes");
            RenameTable(name: "dbo.Artistas", newName: "Pessoas");
        }
    }
}
