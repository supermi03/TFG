namespace ProyectoTFG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rutina1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id", "dbo.Rutina");
            DropForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Id", "dbo.Rutina");
            DropIndex("dbo.Entrenamiento_Ejercicios", new[] { "Rutina_Id" });
            DropIndex("dbo.Entrenamiento_Ejercicios", new[] { "Rutina_Rutina_Id" });
            DropColumn("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id", c => c.Int());
            CreateIndex("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id");
            CreateIndex("dbo.Entrenamiento_Ejercicios", "Rutina_Id");
            AddForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Id", "dbo.Rutina", "Rutina_Id");
            AddForeignKey("dbo.Entrenamiento_Ejercicios", "Rutina_Rutina_Id", "dbo.Rutina", "Rutina_Id");
        }
    }
}
