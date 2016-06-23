namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DataDaConsulta = c.DateTime(nullable: false),
                        TipoConsulta = c.String(nullable: false),
                        Medico_Id = c.Long(nullable: false),
                        Paciente_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Medico_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_Id, cascadeDelete: true)
                .Index(t => t.Medico_Id)
                .Index(t => t.Paciente_Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Crm = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        HrInicio = c.String(nullable: false),
                        HrFim = c.String(nullable: false),
                        DuracaoConsulta = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DayOfWorks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Medico_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Medico_Id)
                .Index(t => t.Medico_Id);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "Paciente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Agenda", "Medico_Id", "dbo.Medicos");
            DropForeignKey("dbo.EspecialidadeMedicoes", "Medico_Id", "dbo.Medicos");
            DropForeignKey("dbo.EspecialidadeMedicoes", "Especialidade_Id", "dbo.Especialidades");
            DropForeignKey("dbo.DayOfWorks", "Medico_Id", "dbo.Medicos");
            DropIndex("dbo.EspecialidadeMedicoes", new[] { "Medico_Id" });
            DropIndex("dbo.EspecialidadeMedicoes", new[] { "Especialidade_Id" });
            DropIndex("dbo.DayOfWorks", new[] { "Medico_Id" });
            DropIndex("dbo.Agenda", new[] { "Paciente_Id" });
            DropIndex("dbo.Agenda", new[] { "Medico_Id" });
            DropTable("dbo.EspecialidadeMedicoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Especialidades");
            DropTable("dbo.DayOfWorks");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agenda");
        }
    }
}
