using SistemaGestionDatos.DataAccess;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionNegocio.Servicios; 

public class UsuariosServices 
{
    private UsuarioDataAccess _usuarioDataAccess;
    private UsuariosIngresosDataAccess _usuariosIngresosDataAccess;

    public UsuariosServices(UsuarioDataAccess usuarioDataAccess, UsuariosIngresosDataAccess usuariosIngresosDataAccess)
    {
        _usuarioDataAccess = usuarioDataAccess;
        _usuariosIngresosDataAccess = usuariosIngresosDataAccess;
    }
 
    public Usuario ObtenerUsuario(int id)
    {
        Usuario usuario = _usuarioDataAccess.ObtenerUsuario(id);
        if (usuario == null) throw new Exception("El usuario solicitado no existe");
        return usuario;
    }

    public List<Usuario> ListarUsuarios()
    {
        return _usuarioDataAccess.ListarUsuarios().ToList();
    }

    public Usuario CrearUsuario(Usuario usuario)
    {
        try
        {
            _usuarioDataAccess.CrearUsuario(usuario);
            _usuariosIngresosDataAccess.CrearUsuario(new() { NombreUsuario = usuario.NombreUsuario, Contraseña = usuario.Contraseña });
            return usuario;
        }
        catch (Exception e)
        {
            throw new Exception($"Error en la creacion de usuario {e.Message}");
        }
    }

    public void ModificarUsuario(Usuario usuario)
    {
        try
        {
            _usuarioDataAccess.ModificarUsuario(usuario);
            _usuariosIngresosDataAccess.ModificarUsuario(usuario);
        }
        catch (Exception e)
        {
            throw new Exception($"Error en la actualización del usuario {e.Message}");
        }
    }

    public void EliminarUsuario(int id)
    {
        try
        {
            _usuariosIngresosDataAccess.EliminarUsuario(id);
            _usuarioDataAccess.EliminarUsuario(id);
        }
        catch (Exception e)
        {
            throw new Exception("Error al eliminar usuario");
        }
    }

    public List<Usuario> Filtrar(string filtro)
    {
        return _usuarioDataAccess.Filtrar(filtro);  
    }

    public Usuario? Autenticacion(UsuarioIngreso usuario)
    {
        return _usuarioDataAccess.Autenticacion(usuario);
    }

}