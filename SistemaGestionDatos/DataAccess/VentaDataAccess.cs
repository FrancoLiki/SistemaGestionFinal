using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class VentaDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public VentaDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public Venta? ObtenerVenta(int id)
    {
        return _context.Ventas
            .Include(v => v.Productos) // Incluye los productos relacionados
            .Include(v => v.Usuario)   // Incluye los usuarios relacionados
            .FirstOrDefault(v => v.Id == id);
    }

    public List<Venta> ListarVentas()
    {
        return _context.Ventas
           .Include(v => v.Productos) // Incluye los productos relacionados
           .Include(v => v.Usuario) // Incluye los usuarios relacionados
           .ToList();
    }

    public void CrearVenta(Venta venta)
    {
        try
        {
            // Agrega la venta
            _context.Ventas.Add(venta);
            _context.SaveChanges();
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
    }




    public void ModificarVenta(Venta venta)
    {
        var ventaExistente = _context.Ventas.Find(venta.Id);
        if (ventaExistente != null)
        {
            // Actualizar las propiedades
            ventaExistente.Comentario = venta.Comentario;
            ventaExistente.Productos = venta.Productos; // Actualizar la relación de productos
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }
    }

    public void EliminarVenta(int id)
    {
        var venta = _context.Ventas.Find(id);
        if (venta != null)
        {
            _context.Ventas.Remove(venta); // Eliminar la venta
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }
    }

    public List<Venta> Filtrar(string filtro)
    {
        return _context.Ventas.Where(p => p.Comentario.Contains(filtro)).ToList();
    }
}
