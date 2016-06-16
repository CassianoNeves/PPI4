namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Crm = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        HrInicio = c.String(nullable: false),
                        HrFim = c.String(nullable: false),
                        Especialidade_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especialidades", t => t.Especialidade_Id, cascadeDelete: true)
                .Index(t => t.Especialidade_Id);
            
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
                        SenhaVerificador = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropForeignKey("dbo.DayOfWorks", "Medico_Id", "dbo.Medicos");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            DropIndex("dbo.DayOfWorks", new[] { "Medico_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Especialidades");
            DropTable("dbo.Medicos");
            DropTable("dbo.DayOfWorks");
        }
    }
}
