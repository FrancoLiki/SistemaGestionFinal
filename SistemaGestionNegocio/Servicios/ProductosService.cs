using SistemaGestionDatos.DataAccess;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionNegocio.Servicios;

public class ProductosService 
{
    private ProductoDataAccess _productoDataAccess;

    public ProductosService(ProductoDataAccess productoDataAccess)
    {
        _productoDataAccess = productoDataAccess;
    }

    public Producto ObtenerProducto(int id)
    {
        Producto producto = _productoDataAccess.ObtenerProducto(id);
        if (producto == null) throw new Exception("El producto solicitado no existe");
        return producto;
    }
    public List<Producto> ListarProductos()
    {
        return _productoDataAccess.ListarProductos();
    }

    public List<Producto> ListarProductosUsuario(int idUsuario)
    {
        return _productoDataAccess.ListarProductosUsuario(idUsuario);
    }

    public Producto CrearProducto(Producto producto)
    {
        try
        {
            Console.WriteLine(producto);
            _productoDataAccess.CrearProducto(producto);
            return producto;
        }
        catch (Exception e)
        {
            throw new Exception("Error en la creacion del producto" + e.Message,e);
        }
    }

    public void ModificarProducto(Producto producto)
    {
        try
        {
            Console.WriteLine(producto);
            _productoDataAccess.ModificarProducto(producto);
        }
        catch (Exception e)
        {
            throw new Exception("Error en la actualización del producto");
        }
    }

    public void EliminarProducto(int id)
    {
        try
        {
            _productoDataAccess.EliminarProducto(id);
        }
        catch (Exception e)
        {
            throw new Exception("Error al eliminar el producto");
        }
    }

    public List<Producto> Filtrar(string filtro)
    {
        return _productoDataAccess.Filtrar(filtro);
    }
}
