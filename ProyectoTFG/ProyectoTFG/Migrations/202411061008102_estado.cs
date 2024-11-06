namespace ProyectoTFG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas", "Estado");
        }
    }
}
