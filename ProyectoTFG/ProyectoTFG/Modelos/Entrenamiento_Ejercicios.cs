using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTFG.Modelos
{
    [Table("Entrenamiento_Ejercicios")]
    public class Entrenamiento_Ejercicios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Entrenamiento_Ejercicios_Id { get; set; }

        [Required]
        public int Entrenamiento_Id { get; set; }
        [ForeignKey("Entrenamiento_Id")]
        public virtual Entrenamiento Entrenamiento { get; set; }

        [Required]
        public int Ejercicios_Id { get; set; }
        [ForeignKey("Ejercicios_Id")]
        public virtual Ejercicios Ejercicios { get; set; }

        // Atributos adicionales como series, repeticiones, etc.
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public string Peso { get; set; }
        public string Tiempo { get; set; }

        // Relación con Rutina (opcional)
        public int? Rutina_Id { get; set; }
        [ForeignKey("Rutina_Id")]
        public virtual Rutina Rutina { get; set; }
    }
}
