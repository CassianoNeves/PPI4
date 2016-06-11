namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vosaber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "SenhaVerificador", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "SenhaVerificador");
        }
    }
}
