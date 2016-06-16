namespace projeto_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dayofwork : DbMigration
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
            
            AddColumn("dbo.Medicos", "HrInicio", c => c.String(nullable: false));
            AddColumn("dbo.Medicos", "HrFim", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayOfWorks", "Medico_Id", "dbo.Medicos");
            DropIndex("dbo.DayOfWorks", new[] { "Medico_Id" });
            DropColumn("dbo.Medicos", "HrFim");
            DropColumn("dbo.Medicos", "HrInicio");
            DropTable("dbo.DayOfWorks");
        }
    }
}
