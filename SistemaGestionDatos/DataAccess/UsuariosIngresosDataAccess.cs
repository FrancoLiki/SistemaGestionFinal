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

    public UsuarioIngreso? ObtenerUsuario(int idUsuario)
    {
        return _context.UsuariosIngresos.FirstOrDefault(p => p.Id == idUsuario);
    }

    public void CrearUsuario(UsuarioIngreso usuario)
    {
        usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
        _context.UsuariosIngresos.Add(usuario);
        _context.SaveChanges();
    }

    public void ModificarUsuario(Usuario usuario)
    {
        var usuarioExistente = ObtenerUsuario(usuario.Id);
        if(usuarioExistente != null)
        {
            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            if (usuario.Contraseña != usuarioExistente.Contraseña)
            {
                usuarioExistente.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
            }
            _context.SaveChanges();
        }
    }

    public void EliminarUsuario(int idUsuario)
    {
        var usuarioEliminar = ObtenerUsuario(idUsuario);
        if (usuarioEliminar != null)
        {
            _context.UsuariosIngresos.Remove(usuarioEliminar);
            _context.SaveChanges();
        }
    }
}
