using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTFG.Modelos
{
    [Table("Entrenamiento")]
    public class Entrenamiento
    {
        [Key]  // Definir la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Entrenamiento_Id { get; set; }  // Propiedad clave primaria

        [Required]
        public DateTime Fecha { get; set; }

        // Relación con Persona (usuario que realiza el entrenamiento)
        public int Persona_Id { get; set; }
        [ForeignKey("Persona_Id")]
        public virtual Persona Persona { get; set; }

        // Relación con Rutina (opcional)
        public int? Rutina_Id { get; set; }  // Usar int? para permitir que sea null (relación opcional)
        [ForeignKey("Rutina_Id")]
        public virtual Rutina Rutina { get; set; }

        // Relación con Entrenamiento_Ejercicios
        public virtual ICollection<Entrenamiento_Ejercicios> EntrenamientoEjercicios { get; set; }

        public Entrenamiento()
        {
            EntrenamientoEjercicios = new HashSet<Entrenamiento_Ejercicios>();
        }
    }
}
