namespace ProyectoTFG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class historial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historial", "Persona_Id", "dbo.Persona");
            DropIndex("dbo.Historial", new[] { "Persona_Id" });
            DropTable("dbo.Historial");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Historial",
                c => new
                    {
                        Historial_Id = c.Int(nullable: false, identity: true),
                        Persona_Id = c.Int(nullable: false),
                        Tipo_Evento = c.String(),
                        Descripcion = c.String(maxLength: 50),
                        Fecha_Evento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Historial_Id);
            
            CreateIndex("dbo.Historial", "Persona_Id");
            AddForeignKey("dbo.Historial", "Persona_Id", "dbo.Persona", "Persona_Id", cascadeDelete: true);
        }
    }
}
