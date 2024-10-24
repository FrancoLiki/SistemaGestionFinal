using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class UsuariosIngresosDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public UsuariosIngresosDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public UsuarioIngreso? ObtenerUsuario(string nombreUsuario)
    {
        return _context.UsuariosIngresos.FirstOrDefault(p => p.NombreUsuario == nombreUsuario);
    }

    public void CrearUsuario(UsuarioIngreso usuario)
    {
        usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
        _context.UsuariosIngresos.Add(usuario);
        _context.SaveChanges();
    }

    public void ModificarUsuario(string nonbreUsuario, string contraseña)
    {
        var usuarioExistente = ObtenerUsuario(nonbreUsuario);
        if(usuarioExistente != null)
        {
            usuarioExistente.NombreUsuario = nonbreUsuario;
            usuarioExistente.Contraseña = BCrypt.Net.BCrypt.HashPassword(contraseña);
            _context.SaveChanges();
        }
    }

    public void EliminarUsuario(string nombreUsuario)
    {
        var usuarioEliminar = ObtenerUsuario(nombreUsuario);
        if (usuarioEliminar != null)
        {
            _context.UsuariosIngresos.Remove(usuarioEliminar);
            _context.SaveChanges();
        }
    }
}
