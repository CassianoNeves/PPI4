namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medicoremovepassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicos", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicos", "Password", c => c.String());
        }
    }
}
