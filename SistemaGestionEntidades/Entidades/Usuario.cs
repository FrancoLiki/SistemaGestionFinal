using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SistemaGestionEntidades.Entidades;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    [MaxLength(100, ErrorMessage = "El Nombre no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es requerido.")]
    [MaxLength(100, ErrorMessage = "El Apellido no puede tener más de 100 caracteres.")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El campo Nombre de Usuario es requerido.")]
    [MaxLength(100, ErrorMessage = "El Nombre de Usuario no puede tener más de 100 caracteres.")]
    public string NombreUsuario { get; set; }

    [Required(ErrorMessage = "El campo Contraseña es requerido.")]
    [MaxLength(100, ErrorMessage = "La Contraseña no puede tener más de 100 caracteres.")]
    [MinLength(5, ErrorMessage = "La Contraseña debe tener al menos 5 caracteres.")]
    public string Contraseña { get; set; }

    [Required(ErrorMessage = "El campo Email es requerido.")]
    [MaxLength(100, ErrorMessage = "El Email no puede tener más de 100 caracteres.")]
    [EmailAddress(ErrorMessage = "El Email no es una dirección de correo electrónico válida.")]
    public string Mail { get; set; }

}
