namespace proyectoef.Models;
using System.ComponentModel.DataAnnotations;

public class Categoria
{
    [Key] 
    public Guid CategoriaId { get; set; }
    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    //Relaciones
    public virtual ICollection<Tarea> Tareas { get; set; }
}