namespace ProyectoTFG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rutina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rutina",
                c => new
                    {
                        Rutina_Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Rutina_Id)
                .ForeignKey("dbo.Persona", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
            AddColumn("dbo.Entrenamiento_Ejercicios", "Rutina_Id", c => c.Int());
            AddColumn("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id", c => c.Int());
            AddColumn("dbo.Entrenamiento", "Rutina_Id", c => c.Int());
            CreateIndex("dbo.Entrenamiento_Ejercicios", "Rutina_Id");
            CreateIndex("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id");
            CreateIndex("dbo.Entrenamiento", "Rutina_Id");
            AddForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id", "dbo.Rutina", "Rutina_Id");
            AddForeignKey("dbo.Entrenamiento", "Rutina_Id", "dbo.Rutina", "Rutina_Id");
            AddForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Id", "dbo.Rutina", "Rutina_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Id", "dbo.Rutina");
            DropForeignKey("dbo.Entrenamiento", "Rutina_Id", "dbo.Rutina");
            DropForeignKey("dbo.Rutina", "Persona_Id", "dbo.Persona");
            DropForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id", "dbo.Rutina");
            DropIndex("dbo.Rutina", new[] { "Persona_Id" });
            DropIndex("dbo.Entrenamiento", new[] { "Rutina_Id" });
            DropIndex("dbo.Entrenamiento_Ejercicios", new[] { "Rutina_Rutina_Id" });
            DropIndex("dbo.Entrenamiento_Ejercicios", new[] { "Rutina_Id" });
            DropColumn("dbo.Entrenamiento", "Rutina_Id");
            DropColumn("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id");
            DropColumn("dbo.Entrenamiento_Ejercicios", "Rutina_Id");
            DropTable("dbo.Rutina");
        }
    }
}
