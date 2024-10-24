using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntidades.Entidades;
using SistemaGestionNegocio.Servicios;

namespace SistemaGestionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;
    private readonly UsuariosServices _usuariosServices;

    public UsuariosController(ILogger<UsuariosController> logger, UsuariosServices usuariosServices)
    {
        _logger = logger;
        _usuariosServices = usuariosServices;
    }

    [HttpGet]
    public ActionResult<List<Usuario>> ListarUsuarios([FromQuery(Name = "filtro")] string? filtro)
    {
        if(filtro == null ) return _usuariosServices.ListarUsuarios();
        return _usuariosServices.Filtrar(filtro);
    }

    [HttpGet("{id}")]
    public ActionResult<Usuario> ObtenerUsuario(int id)
    {
        var usuario = _usuariosServices.ObtenerUsuario(id);
        if (usuario is null) return NotFound();
        return usuario;
    }

    [HttpPost]
    public ActionResult<Usuario> CrearUsuario([FromBody] Usuario usuario)
    {
        var usuarioCreado = _usuariosServices.CrearUsuario(usuario);
        return CreatedAtAction(nameof(ObtenerUsuario), new {id = usuarioCreado.Id}, usuario);
    }

    [HttpPut("{id}")]
    public ActionResult ModificarUsuario([FromBody] Usuario usuario)
    {
        _usuariosServices.ModificarUsuario(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult EliminarUsuario([FromRoute(Name = "id")] int id)
    {
        _usuariosServices.EliminarUsuario(id);
        return NoContent();
    }

}
