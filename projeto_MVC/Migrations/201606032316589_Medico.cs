namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Crm = c.Int(nullable: false),
                        Endereco = c.String(),
                        Bairro = c.String(),
                        Email = c.String(),
                        Especialidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especialidades", t => t.Especialidade_Id)
                .Index(t => t.Especialidade_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            DropTable("dbo.Medicos");
        }
    }
}
