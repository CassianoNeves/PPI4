namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Especialidades", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Senha", c => c.String());
            AlterColumn("dbo.Usuarios", "Login", c => c.String());
            AlterColumn("dbo.Especialidades", "Nome", c => c.String());
        }
    }
}
