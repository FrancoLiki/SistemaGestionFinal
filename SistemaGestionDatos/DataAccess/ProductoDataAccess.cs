using Microsoft.EntityFrameworkCore;
using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class ProductoDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public ProductoDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public Producto? ObtenerProducto(int id)
    {
        return _context.Productos
           .Include(p => p.Ventas) // Incluye las ventas relacionadas
           .FirstOrDefault(p => p.Id == id);
    }

    public List<Producto> ListarProductos()
    {
        return _context.Productos
           .Include(p => p.Ventas) // Incluye las ventas relacionadas
           .ToList();
    }

    public List<Producto> ListarProductosUsuario(int idUsuario)
    {
        return _context.Productos
           .Include(p => p.Ventas) // Incluye la venta del producto
           .Include(p => p.Usuario) // Incluye el usuario del producto
           .Where(p => p.Usuario.Id == idUsuario)
           .ToList();
    }

    public Producto CrearProducto(Producto producto)
    {
        _context.Productos.Add(producto); // Añadir el producto al contexto
        _context.SaveChanges(); // Guardar cambios en la base de datos
        return producto; // Retornar el producto creado
    }

    public void ModificarProducto(Producto producto)
    {
        var productoExistente = _context.Productos.Find(producto.Id);
        if (productoExistente != null)
        {
            // Actualizar las propiedades
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Costo = producto.Costo;
            productoExistente.PrecioVenta = producto.PrecioVenta;
            productoExistente.Stock = producto.Stock;
            productoExistente.Usuario = producto.Usuario; // Actualizar el usuario asociado, si es necesario

            _context.SaveChanges(); // Guardar cambios en la base de datos
        }
    }

    public void EliminarProducto(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto); // Eliminar el producto
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }
    }

    public List<Producto> Filtrar(string filtro)
    {
        return _context.Productos.Where(p => p.Descripcion.Contains(filtro)).ToList();
    }
}
