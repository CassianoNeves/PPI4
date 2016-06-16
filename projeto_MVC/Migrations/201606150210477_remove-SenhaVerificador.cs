namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSenhaVerificador : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "SenhaVerificador");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "SenhaVerificador", c => c.String());
        }
    }
}
