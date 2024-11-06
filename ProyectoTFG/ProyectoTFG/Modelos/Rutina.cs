using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTFG.Modelos
{
    [Table("Rutina")]
    public class Rutina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rutina_Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre de la rutina no puede superar los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "La descripción de la rutina no puede superar los 200 caracteres.")]
        public string Descripcion { get; set; }

        // Relación con Persona (usuario que tiene esta rutina)
        public int Persona_Id { get; set; }
        [ForeignKey("Persona_Id")]
        public virtual Persona Persona { get; set; }

        // Relación con los entrenamientos (ahora cada rutina tiene muchos entrenamientos)
        public virtual ICollection<Entrenamiento> Entrenamientos { get; set; }

        public Rutina()
        {
            Entrenamientos = new HashSet<Entrenamiento>(); // Inicializa la colección
        }
    }
}
