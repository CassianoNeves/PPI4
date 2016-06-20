namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnDuracaoConsultaMedico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "DuracaoConsulta", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicos", "DuracaoConsulta");
        }
    }
}
