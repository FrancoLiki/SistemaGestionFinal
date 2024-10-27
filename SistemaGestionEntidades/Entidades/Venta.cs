using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntidades.Entidades;

public class Venta
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150, ErrorMessage = "La Descripción no puede tener más de 150 caracteres.")]
    public string? Comentario { get; set; }

    public List<Producto> Productos { get; set; }

    [Required(ErrorMessage = "El id del usuario es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El ID debe ser mayor o igual a 0.")]
    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }

    // Propiedad de navegación para la relación
    public Usuario? Usuario { get; set; }


}
