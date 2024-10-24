using SistemaGestionDatos.DataAccess;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionNegocio.Servicios;
public class ProductosVendidosService 
{
    private ProductoVendidoDataAccess _productoVendidoDataAccess;

    public ProductosVendidosService(ProductoVendidoDataAccess productoVendidoDataAccess)
    {
        _productoVendidoDataAccess = productoVendidoDataAccess;
    }

    public ProductoVendido ObtenerProductoVendido(int id)
    {
        ProductoVendido producto = _productoVendidoDataAccess.ObtenerProductoVendido(id);
        if (producto == null) throw new Exception("El producto solicitado no se ha vendido");
        return producto;
    }

    public List<ProductoVendido> ListarProductosVendidos()
    {
        return _productoVendidoDataAccess.ListarProductosVendidos();
    }

    public ProductoVendido CrearProductoVendido(ProductoVendido productoVendido)
    {
        try
        {
            _productoVendidoDataAccess.CrearProductoVendido(productoVendido);
            return productoVendido;
        }
        catch (Exception e)
        {
            throw new Exception("Error en la carga del producto vendido");
        }
    }

    public void ModificarProductoVendido(ProductoVendido productoVendido)
    {
        try
        {
            _productoVendidoDataAccess.ModificarProductoVendido(productoVendido);
        }
        catch (Exception e)
        {
            throw new Exception("Error en la actualización del producto vendido");
        }
    }

    public void EliminarProductoVendido(int id)
    {
        try
        {
            _productoVendidoDataAccess.EliminarProductoVendido(id);
        }
        catch (Exception e)
        {
            throw new Exception("Error al eliminar producto vendido");
        }
    }
}
