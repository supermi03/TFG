using ProyectoTFG.Modelos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Ejercicios
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Ejercicios_Id { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "El nombre no puede superar los 30 caracteres.")]
    public string Nombre { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "La descripcion no puede superar los 100 caracteres.")]
    public string Descripcion { get; set; }

    [Required]
    [StringLength(100)]
    public string Imagen_Ejercicio { get; set; }

    // Relación con Entrenamiento_Ejercicios
    public virtual ICollection<Entrenamiento_Ejercicios> EntrenamientoEjercicios { get; set; }

    public Ejercicios()
    {
        EntrenamientoEjercicios = new HashSet<Entrenamiento_Ejercicios>(); // Inicialización de la colección
    }
}
