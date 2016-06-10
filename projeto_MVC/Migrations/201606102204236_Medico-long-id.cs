namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medicolongid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            DropPrimaryKey("dbo.Especialidades");
            DropPrimaryKey("dbo.Medicos");
            AlterColumn("dbo.Especialidades", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Medicos", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Medicos", "Especialidade_Id", c => c.Long());
            AddPrimaryKey("dbo.Especialidades", "Id");
            AddPrimaryKey("dbo.Medicos", "Id");
            CreateIndex("dbo.Medicos", "Especialidade_Id");
            AddForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            DropPrimaryKey("dbo.Medicos");
            DropPrimaryKey("dbo.Especialidades");
            AlterColumn("dbo.Medicos", "Especialidade_Id", c => c.Int());
            AlterColumn("dbo.Medicos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Especialidades", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Medicos", "Id");
            AddPrimaryKey("dbo.Especialidades", "Id");
            CreateIndex("dbo.Medicos", "Especialidade_Id");
            AddForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades", "Id");
        }
    }
}
