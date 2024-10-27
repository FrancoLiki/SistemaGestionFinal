using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntidades.Entidades;

public class Producto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Descripción es requerido.")]
    [MaxLength(100, ErrorMessage = "La Descripción no puede tener más de 100 caracteres.")]
    [MinLength(5, ErrorMessage = "La Descripción debe tener al menos 5 caracteres.")]
    [Display(Name = "Descripción")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El campo Precio de Compra es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El Precio de Compra debe ser mayor o igual a 0.")]
    [Display(Name = "Costo")]
    public decimal Costo { get; set; }

    [Required(ErrorMessage = "El campo Precio de Venta es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El Precio de Venta debe ser mayor o igual a 0.")]
    [Display(Name = "Precio de Venta")]
    public decimal PrecioVenta { get; set; }

    [Required(ErrorMessage = "El campo Stock es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El Stock debe ser mayor o igual a 0.")]
    public int Stock { get; set; }

    public List<Venta>? Ventas { get; set; } = new();

    // Define explicitamente la clave externa
    [Required]
    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }

    // Propiedad de navegación para la relación
    public Usuario? Usuario { get; set; }
}
