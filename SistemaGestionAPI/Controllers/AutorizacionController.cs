using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaGestionEntidades.Entidades;
using SistemaGestionNegocio.Servicios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SistemaGestionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorizacionController : ControllerBase
{
    private readonly UsuariosServices _usuariosServices;
    private readonly IConfiguration _configuration;

    public AutorizacionController(UsuariosServices usuariosServices, IConfiguration configuration)
    {
        _usuariosServices = usuariosServices;
        _configuration = configuration;
    }


    [HttpPost("login")]
    public async  Task<IActionResult> Login([FromBody] UsuarioIngreso usuario)
    {
        try
        {
            var usuarioAutenticado = _usuariosServices.Autenticacion(usuario);
            if(usuarioAutenticado != null)
            {
                
                return Ok(usuarioAutenticado);
            }
            return Unauthorized();
        }
        catch (Exception ex)
        {
            return Unauthorized();
        }
    }
}
