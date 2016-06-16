namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class especialidadesmedicos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            CreateTable(
                "dbo.EspecialidadeMedicoes",
                c => new
                    {
                        Especialidade_Id = c.Long(nullable: false),
                        Medico_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Especialidade_Id, t.Medico_Id })
                .ForeignKey("dbo.Especialidades", t => t.Especialidade_Id, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.Medico_Id, cascadeDelete: true)
                .Index(t => t.Especialidade_Id)
                .Index(t => t.Medico_Id);
            
            DropColumn("dbo.Medicos", "Especialidade_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicos", "Especialidade_Id", c => c.Long(nullable: false));
            DropForeignKey("dbo.EspecialidadeMedicoes", "Medico_Id", "dbo.Medicos");
            DropForeignKey("dbo.EspecialidadeMedicoes", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.EspecialidadeMedicoes", new[] { "Medico_Id" });
            DropIndex("dbo.EspecialidadeMedicoes", new[] { "Especialidade_Id" });
            DropTable("dbo.EspecialidadeMedicoes");
            CreateIndex("dbo.Medicos", "Especialidade_Id");
            AddForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades", "Id", cascadeDelete: true);
        }
    }
}
