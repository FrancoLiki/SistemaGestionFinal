using System;
using System.ComponentModel.DataAnnotations;


namespace SistemaGestionEntidades.Entidades;

public class ProductoVendido
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El id del producto es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El ID debe ser mayor o igual a 0.")]
    public int IdProducto { get; set; }

    [Required(ErrorMessage = "El campo Stock es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El Stock debe ser mayor o igual a 0.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "El id de la venta es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El ID debe ser mayor o igual a 0.")]
    public int IdVenta { get; set; }
}
