namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicoaddrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            AlterColumn("dbo.Medicos", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Medicos", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Medicos", "Especialidade_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Medicos", "Especialidade_Id");
            AddForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            AlterColumn("dbo.Medicos", "Especialidade_Id", c => c.Long());
            AlterColumn("dbo.Medicos", "Email", c => c.String());
            AlterColumn("dbo.Medicos", "Nome", c => c.String());
            CreateIndex("dbo.Medicos", "Especialidade_Id");
            AddForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades", "Id");
        }
    }
}
