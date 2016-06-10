namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medicoalter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "Password", c => c.String());
            DropColumn("dbo.Medicos", "Endereco");
            DropColumn("dbo.Medicos", "Bairro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicos", "Bairro", c => c.String());
            AddColumn("dbo.Medicos", "Endereco", c => c.String());
            DropColumn("dbo.Medicos", "Password");
        }
    }
}
