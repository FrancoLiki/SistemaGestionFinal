using Microsoft.EntityFrameworkCore;
using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

//public class ProductoVendidoDataAccess 
//{
//    private readonly ProyectoCoderhouseDbContext _context;

//    public ProductoVendidoDataAccess(ProyectoCoderhouseDbContext context)
//    {
//        _context = context;
//    }

//    public ProductoVendido? ObtenerProductoVendido(int id)
//    {
//        return _context.ProductosVendidos
//         .FirstOrDefault(pv => pv.Id == id);
//    }

//    public List<ProductoVendido> ListarProductosVendidos()
//    {
//        return _context.ProductosVendidos.ToList();
//    }

//    public ProductoVendido CrearProductoVendido(ProductoVendido productoVendido)
//    {
//        _context.ProductosVendidos.Add(productoVendido);
//        _context.SaveChanges();
//        return productoVendido;
//    }

//    public void ModificarProductoVendido(ProductoVendido productoVendido)
//    {
//        var productoExistente = ObtenerProductoVendido(productoVendido.Id);
//        if (productoExistente != null)
//        {
//            productoExistente.IdProducto = productoVendido.IdProducto;
//            productoExistente.Stock = productoVendido.Stock;
//            productoExistente.IdVenta = productoVendido.IdVenta;
//            _context.SaveChanges();
//        }
//    }

//    public void EliminarProductoVendido(int id)
//    {
//        var productoEliminar = ObtenerProductoVendido(id);
//        if (productoEliminar != null)
//        {
//            _context.ProductosVendidos.Remove(productoEliminar);
//            _context.SaveChanges();
//        }
//    }

   
//}
