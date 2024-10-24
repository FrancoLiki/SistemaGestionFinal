using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntidades.Entidades;

public class Venta
{
    [Key]
    public int Id { get; set; }

    [MaxLength(150, ErrorMessage = "La Descripción no puede tener más de 150 caracteres.")]
    public string Comentario { get; set; }

    public List<ProductoVendido> Productos { get; set; } // Relación con ProductoVendido

    [Required(ErrorMessage = "El id del usuario es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El ID debe ser mayor o igual a 0.")]
    public Usuario Usuario { get; set; } // Relación con Usuario


}
